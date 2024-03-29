import {VirtualKey} from "../utils/virtualKeys";
import {ModuleBrowser} from "../BrowserManager/altBrowser";
import "./spawnCamera.js"
import {AuthorizationEvents} from "./AuthorizationEvents";
import {logger} from "../utils/logger";
import {browserManager} from "../BrowserManager/browserManager";
import {showCursor} from "../Managers/cursorManager";
import {localPlayer} from "../Managers/localPlayerManager";
import {keyboardMapping} from "../Managers/keyboardManager";

export let loginCam
let authorizationBrowser = new ModuleBrowser("Authorization", "/login/loader")

mp.game.gameplay.setFadeOutAfterDeath(false);

mp.events.add("playerReady", () => {
  loginCam = mp.cameras.new('default', new mp.Vector3(0, 0, 0), new mp.Vector3(0, 0, 0), 40);
  localPlayer.position = new mp.Vector3(-1757.12, -739.53, 10);

  localPlayer.freezePosition(true);
  mp.game.ui.setMinimapVisible(true);
  // mp.gui.chat.activate(false);
  // mp.gui.chat.show(false);
  mp.game.ui.displayRadar(false);

  loginCam.setActive(true);
  loginCam.setCoord(-1757.12, -739.53, 25);
  loginCam.pointAtCoord(-1757.12, -739.53, 22);
  mp.game.cam.renderScriptCams(true, false, 0, true, false);
  mp.events.call("moveSkyCamera", localPlayer, "up", 1, true)

})

browserManager.onBrowserLoad("alt").then(() => {
  authorizationBrowser.setAsActive()
  authorizationBrowser.browser.openOverlay(false)
  authorizationBrowser.execClient("AuthorizationInit")

  setTimeout(() => {
    mp.events.callRemote(AuthorizationEvents.PLAYER_READY_TO_SERVER)
  }, 3000)
})

mp.events.add(AuthorizationEvents.FIRST_CONNECTION_FROM_SERVER, () => {
  authorizationBrowser.execClient("WelcomeScreen")
  showCursor()
})

mp.events.add(AuthorizationEvents.NEED_LOGIN_FROM_SERVER, () => {
  authorizationBrowser.execClient("LoginScreen")
  showCursor()
})

mp.keys.bind(keyboardMapping.ToggleOverlay, true, () => {
  authorizationBrowser.browser.toggleOverlay()
})

mp.events.add(AuthorizationEvents.LOGIN_SUCCESS_FROM_SERVER, () => {
  authorizationBrowser.execClient("LoginSuccess")
  mp.events.call(AuthorizationEvents.GO_TO_CHARACTER_MANAGER)

  showCursor()
})

mp.events.add(AuthorizationEvents.REGISTER_SUCCESS_FROM_SERVER, () => {
  authorizationBrowser.execClient("RegisterSuccess")
  mp.events.call(AuthorizationEvents.GO_TO_CHARACTER_MANAGER)
})

mp.events.add(AuthorizationEvents.CHARACTER_SPAWNED_FROM_SERVER, (secondsToReborn: number) => {
  loginCam.destroy();

  mp.game.cam.renderScriptCams(false, false, 0, false, false);
  localPlayer.freezePosition(false);
  mp.game.ui.setMinimapVisible(false);
  mp.gui.chat.activate(true);
  mp.gui.chat.show(true);
  mp.game.ui.displayRadar(true);

  mp.events.call("moveSkyCamera", localPlayer, "down", 1, true)

  authorizationBrowser.browser.settings.canCloseOverlay = true
  authorizationBrowser.browser.closeOverlay()

  if (secondsToReborn > 0) {
    mp.events.call("SERVER:CLIENT:DeathAndReborn:Death", secondsToReborn, "")
  }
})
