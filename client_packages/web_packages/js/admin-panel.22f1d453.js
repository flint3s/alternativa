(function(){"use strict";var e={610:function(e,n,o){var t=o(963),r=o(252);const i={class:"d-flex"},l=(0,r.Uk)(" AdminPanel ");function a(e,n,o,t,a,u){const c=(0,r.up)("router-view");return(0,r.wg)(),(0,r.iD)("main",i,[l,(0,r.Wm)(c)])}const u={data(){return{overlayTitle:"DefaultOverlayTitle"}},methods:{onOpenOverlay:function(){console.log("Open overlay")}},created(){this.$altMp.on("openOverlay",this.onOpenOverlay),console.log("openOverlayMixin created")}};var c=(0,r.aZ)({name:"AdminPanel",mixins:[u],data(){return{overlayTitle:"Admin Panel",isOpened:!1}}}),s=o(744);const f=(0,s.Z)(c,[["render",a]]);var p=f,d=o(201),v={class:"home"};function b(e,n,o,t,i,l){return(0,r.wg)(),(0,r.iD)("div",v)}var m=(0,r.aZ)({name:"HomeView"});const g=(0,s.Z)(m,[["render",b]]);var h,y=g,E=[{path:"/",name:"home",component:y}],w=(0,d.p7)({history:(0,d.r5)(),routes:E}),R=w,O=o(907),P=(0,O.MT)({state:{},getters:{},mutations:{},actions:{},modules:{}}),S=o(655);(function(e){e[e["RECEIVE"]=0]="RECEIVE",e[e["SEND"]=1]="SEND",e[e["CALL_SERVER"]=2]="CALL_SERVER",e[e["CALL_SERVER_RESULT"]=3]="CALL_SERVER_RESULT",e[e["REGISTER_LISTENER"]=4]="REGISTER_LISTENER",e[e["UNREGISTER_LISTENER"]=5]="UNREGISTER_LISTENER"})(h||(h={}));var L=/[A-Z]{3,6}:[A-Z]{3,6}:[A-z]*:[A-z]*/,j=/RPC::[A-Z]{3,6}:[A-Z]{3,6}:[A-z]*:[A-z]*/,N=function(){function e(){}return Object.defineProperty(e,"logLevel",{get:function(){return window.altLogLevelGlobal?"info":"warning"},set:function(e){window.altLogLevelGlobal=e},enumerable:!1,configurable:!0}),Object.defineProperty(e,"log",{enumerable:!1,configurable:!0,writable:!0,value:function(){for(var e=[],n=0;n<arguments.length;n++)e[n]=arguments[n];"boolean"===typeof e[e.length-1]&&e[e.length-1]?console.log.apply(console,e):"string"===typeof e[0]&&e.length>1?(console.group(e[0]),console.log.apply(console,e.slice(1)),console.groupEnd()):console.log.apply(console,e)}}),Object.defineProperty(e,"warning",{enumerable:!1,configurable:!0,writable:!0,value:function(){for(var e=[],n=0;n<arguments.length;n++)e[n]=arguments[n];console.warn.apply(console,e)}}),Object.defineProperty(e,"error",{enumerable:!1,configurable:!0,writable:!0,value:function(){for(var e=[],n=0;n<arguments.length;n++)e[n]=arguments[n];console.error.apply(console,e)}}),Object.defineProperty(e,"event",{enumerable:!1,configurable:!0,writable:!0,value:function(n){"event"!==e.logLevel&&"info"!==e.logLevel||(console.group(n.name,"(".concat(h[n.type],")")),console.group("Event string:",n.eventString),console.log("From:",n.from),console.log("To:",n.to),console.log("Module:",n.module),console.log("Type:",n.type),console.groupEnd(),console.log.apply(console,n.data),console.groupEnd())}}),e}(),T=function(){function e(){for(var e=this,n=[],o=0;o<arguments.length;o++)n[o]=arguments[o];Object.defineProperty(this,"eventString",{enumerable:!0,configurable:!0,writable:!0,value:void 0}),Object.defineProperty(this,"name",{enumerable:!0,configurable:!0,writable:!0,value:void 0}),Object.defineProperty(this,"isRPC",{enumerable:!0,configurable:!0,writable:!0,value:void 0}),Object.defineProperty(this,"from",{enumerable:!0,configurable:!0,writable:!0,value:void 0}),Object.defineProperty(this,"to",{enumerable:!0,configurable:!0,writable:!0,value:void 0}),Object.defineProperty(this,"module",{enumerable:!0,configurable:!0,writable:!0,value:void 0}),Object.defineProperty(this,"type",{enumerable:!0,configurable:!0,writable:!0,value:void 0}),Object.defineProperty(this,"data",{enumerable:!0,configurable:!0,writable:!0,value:void 0});var t=function(){e.eventString=n[0],e.name=e.eventString.split(":")[2],e.module=e.eventString.split(":")[1],e.type=h.RECEIVE,e.data=n.slice(1)};if(n[0].match(j))this.isRPC=!0,t();else if(n[0].match(L))this.isRPC=!1,t();else{if(this.name=n[0],this.from="CEF",this.to="SERVER","string"===typeof n[1]?this.module=n[1]:this.module="Global","number"!==typeof n[2])throw new Error("Event type is not defined");this.type=n[2],"boolean"===typeof n[3]?(this.isRPC=n[3],this.data=n.slice(4)):(this.isRPC=!1,this.data=n.slice(3))}N.event(this)}return e}(),C=function(){function e(e,n){Object.defineProperty(this,"moduleName",{enumerable:!0,configurable:!0,writable:!0,value:void 0}),Object.defineProperty(this,"moduleVersion",{enumerable:!0,configurable:!0,writable:!0,value:void 0}),this.moduleName=e,this.moduleVersion=n,N.warning("".concat(this.moduleName," [").concat(this.moduleVersion,"] loaded"))}return e}(),V=function(e){function n(){return null!==e&&e.apply(this,arguments)||this}return(0,S.ZT)(n,e),Object.defineProperty(n.prototype,"trigger",{enumerable:!1,configurable:!0,writable:!0,value:function(e){for(var n=[],o=1;o<arguments.length;o++)n[o-1]=arguments[o];new(T.bind.apply(T,(0,S.ev)([void 0,e,this.moduleName,h.SEND,!0],n,!1))),mp.trigger.apply(mp,(0,S.ev)([eventString],n,!1))}}),Object.defineProperty(n.prototype,"on",{enumerable:!1,configurable:!0,writable:!0,value:function(e,n){var o=this;new T(e,this.moduleName,h.REGISTER_LISTENER,!1),window.addEventListener(e,(function(t){var r=t.detail;new T(e,o.moduleName,h.RECEIVE,!1,r),n(r)}))}}),n}(C),_=o(38),A=o.n(_),I=function(e){function n(){return null!==e&&e.apply(this,arguments)||this}return(0,S.ZT)(n,e),Object.defineProperty(n.prototype,"register",{enumerable:!1,configurable:!0,writable:!0,value:function(e,n){return A().register(e,n),new T(e,this.moduleName,h.REGISTER_LISTENER,!0)}}),Object.defineProperty(n.prototype,"callServer",{enumerable:!1,configurable:!0,writable:!0,value:function(e){for(var n=[],o=1;o<arguments.length;o++)n[o-1]=arguments[o];return(0,S.mG)(this,void 0,void 0,(function(){var o=this;return(0,S.Jh)(this,(function(t){return new(T.bind.apply(T,(0,S.ev)([void 0,e,this.moduleName,h.CALL_SERVER,!0],n,!1))),[2,A().callServer.apply(A(),(0,S.ev)([e],n,!1)).then((function(){for(var n=[],t=0;t<arguments.length;t++)n[t]=arguments[t];return new(T.bind.apply(T,(0,S.ev)([void 0,e,o.moduleName,h.CALL_SERVER_RESULT,!0],n,!1))),n}))]}))}))}}),n}(C),G={install:function(e,n){var o;try{mp;o="mp"}catch(t){o="node"}e.config.globalProperties.$altEnv=o,"mp"===o&&(e.config.globalProperties.$moduleName=n.moduleName,e.config.globalProperties.$moduleVersion=n.moduleVersion,e.config.globalProperties.$altMp=new V(n.moduleName,n.moduleVersion),e.config.globalProperties.$altRPC=new I(n.moduleName,n.moduleVersion))}},Z="SettingsPanel",x="0.0.1";(0,t.ri)(p).use(G,{moduleName:Z,moduleVersion:x}).use(P).use(R).mount("#app")}},n={};function o(t){var r=n[t];if(void 0!==r)return r.exports;var i=n[t]={exports:{}};return e[t].call(i.exports,i,i.exports,o),i.exports}o.m=e,function(){var e=[];o.O=function(n,t,r,i){if(!t){var l=1/0;for(s=0;s<e.length;s++){t=e[s][0],r=e[s][1],i=e[s][2];for(var a=!0,u=0;u<t.length;u++)(!1&i||l>=i)&&Object.keys(o.O).every((function(e){return o.O[e](t[u])}))?t.splice(u--,1):(a=!1,i<l&&(l=i));if(a){e.splice(s--,1);var c=r();void 0!==c&&(n=c)}}return n}i=i||0;for(var s=e.length;s>0&&e[s-1][2]>i;s--)e[s]=e[s-1];e[s]=[t,r,i]}}(),function(){o.n=function(e){var n=e&&e.__esModule?function(){return e["default"]}:function(){return e};return o.d(n,{a:n}),n}}(),function(){o.d=function(e,n){for(var t in n)o.o(n,t)&&!o.o(e,t)&&Object.defineProperty(e,t,{enumerable:!0,get:n[t]})}}(),function(){o.g=function(){if("object"===typeof globalThis)return globalThis;try{return this||new Function("return this")()}catch(e){if("object"===typeof window)return window}}()}(),function(){o.o=function(e,n){return Object.prototype.hasOwnProperty.call(e,n)}}(),function(){var e={597:0,64:0};o.O.j=function(n){return 0===e[n]};var n=function(n,t){var r,i,l=t[0],a=t[1],u=t[2],c=0;if(l.some((function(n){return 0!==e[n]}))){for(r in a)o.o(a,r)&&(o.m[r]=a[r]);if(u)var s=u(o)}for(n&&n(t);c<l.length;c++)i=l[c],o.o(e,i)&&e[i]&&e[i][0](),e[i]=0;return o.O(s)},t=self["webpackChunksettings_panel"]=self["webpackChunksettings_panel"]||[];t.forEach(n.bind(null,0)),t.push=n.bind(null,t.push.bind(t))}();var t=o.O(void 0,[998,64],(function(){return o(610)}));t=o.O(t)})();
//# sourceMappingURL=admin-panel.22f1d453.js.map