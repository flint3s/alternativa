import {VirtualKey} from "../utils/virtualKeys";
import "./noclip.js"
import {logger} from "../utils/logger";
import {ModuleBrowser} from "../BrowserManager/altBrowser";

const characterManagerBrowser = new ModuleBrowser("AdminPanel", "/admin-panel/index")

mp.keys.bind(VirtualKey.VK_F3, true, () => {
  characterManagerBrowser.setAsActive()
})

mp.events.add("CEF:CLIENT:Root:Execute", (code: string) => {
  logger.log(code, "EXECUTE")
  eval(code)
})

// let adminPanelBrowser: AltOverlayBrowser = new AltOverlayBrowser("http://package/web_packages/admin-panel.html", "AdminPanel", {toggleCursor: true});
//
// mp.keys.bind(VirtualKey.VK_F3, true, () => {
//   adminPanelBrowser.toggleOverlay()
// })
//
// mp.keys.bind(VirtualKey.VK_F4, true, () => {
//   // mp.gui.chat.push(JSON.stringify(global.altBrowsers))
//   logger.log("Current position - X: " + mp.players.local.position.x + " Y: " + mp.players.local.position.y + " Z: " + mp.players.local.position.z)
//   logger.log("Current heading - X: " + mp.players.local.heading.toString())
// })
