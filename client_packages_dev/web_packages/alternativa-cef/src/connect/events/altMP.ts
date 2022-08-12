// @ts-nocheck
// Проверка отключена из-за использования window.и mp в коде плагина

import {AltEvent} from "@/connect/events/altEvent";
import {ModuleDependent} from "@/connect/moduleDependent";
import {AltEventCallback, AltEventType} from "@/connect/events/altEventType";
import {altLog} from "@/connect/logs/altLogger";
import {EventString} from "@/connect/events/eventString";

window.altListeners = new Map<string, Array<AltEventCallback>>();


/**
 * @class altMP
 *
 * Класс для взаимодействия с клиентом посредством событий
 * */
export class altMP extends ModuleDependent {
  /**
   * @method trigger
   *
   * Отправляет событие клиенту
   * */
  trigger(eventName: string, data: object) {
    const es = new EventString("CEF", "CLIENT", this.moduleName, eventName)
    new AltEvent(es, AltEventType.SEND, data)

    mp.trigger(eventString, ...data)
  }

  /**
   * @method on
   *
   * Добавляет обработчик события
   * */
  on(eventName: string, callback: (...data: any) => void) {
    const es = new EventString("CLIENT", "CEF", this.moduleName, eventName)
    new AltEvent(es, AltEventType.REGISTER_LISTENER)

    const currentListeners = window.altListeners.get(es.eventString)
    if (!currentListeners) {
      window.altListeners.set(es.eventString, [callback])
    } else {
      window.altListeners.set(es.eventString, [...currentListeners, callback])
    }
  }

  call(eventString: string, data: object) {
    const es = new EventString("CLIENT", "CEF", this.moduleName, eventString)
    new AltEvent(es, AltEventType.RECEIVED, data)

    const eventListeners: Array<AltEventCallback> = window.altListeners.get(eventString)
    if (!eventListeners || eventListeners.length === 0) altLog.warning(`No listeners for event ${eventString}`)
    else eventListeners.forEach(listener => listener(data))
  }
}