import {AltBrowser} from "./altBrowser";
import {logger} from "../utils/logger";

mp.events.add("browserDomReady", (browser) => {
  const abr = browserManager.getByUrl(browser.url)
  if (abr) {
    abr.loaded = true
    mp.events.call("AltBrowserLoaded_" + abr.name)
    logger.log("AltBrowserLoaded_" + browserManager.getByUrl(browser.url).name + " url: " + browser.url)
  }
})

export class browserManager {
  static getBrowser<T>(browserName: string): T {
    if (global.altBrowsers === undefined) {
      global.altBrowsers = {}
      return
    }

    return global.altBrowsers[browserName]
  }

  static addBrowser(browser: AltBrowser): void {
    if (global.altBrowsers === undefined) {
      global.altBrowsers = {}
    }

    global.altBrowsers[browser.name] = browser
  }

  static getAllBrowsers(): AltBrowser[] {
    if (global.altBrowsers === undefined) {
      global.altBrowsers = {}
      return []
    }

    return Object.values(global.altBrowsers)
  }

  static renameBrowser(browserName: string, newName: string): void {
    if (global.altBrowsers === undefined) {
      global.altBrowsers = {}
      return
    }

    const browser = global.altBrowsers[browserName]
    if (browser === undefined) {
      return
    }

    browser.name = newName
    delete global.altBrowsers[browserName]
    global.altBrowsers[newName] = browser
  }

  static deleteBrowser(browserName: string): void {
    if (global.altBrowsers === undefined) {
      global.altBrowsers = {}
      return
    }

    const browser: AltBrowser = global.altBrowsers[browserName]
    if (browser === undefined) {
      return
    }

    browser.getInstance().destroy()
    delete global.altBrowsers[browserName]
  }

  static onBrowserLoad(browserName: string): Promise<unknown> {
    return new Promise((resolve) => {
      if (this.getBrowser<AltBrowser>(browserName)?.loaded) {
        resolve(true)
        return
      }

      mp.events.add("AltBrowserLoaded_" + browserName, () => {
        resolve(true)
        mp.events.remove("AltBrowserLoaded_" + browserName)
      })
    })
  }

  static getByUrl(url: string): AltBrowser {
    return this.getAllBrowsers().find(browser => browser.url === url)
  }
}
