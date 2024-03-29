import type {AltRPCEventType} from "@/connect/events/altEventType";
import {altLog} from "@/connect/logger/altLogger";
import type {RPCEventSting} from "@/connect/events/rpc/rpcEventSting";

export class AltRPCEvent {
  eventString: RPCEventSting
  type: AltRPCEventType
  data?: object

  constructor(eventString: RPCEventSting, type: AltRPCEventType, data?: object) {
    this.eventString = eventString
    this.type = type
    this.data = data

    altLog.rpcEvent(this)
  }
}
