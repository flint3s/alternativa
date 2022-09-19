<template>
  <n-config-provider :date-locale="dateRuRU" :locale="locale" :theme="theme" :theme-overrides="themeOverrides">
    <n-global-style/>
    <n-message-provider>
      <router-view v-slot="{ Component }">
<!--        TODO: Есть проп overlayBackdropTransition для отключения анимации бэкдропа, можно его вынести в стор (для резких переходов) -->
        <alt-overlay :is-overlay-open="isOverlayShown" :overlay-backdrop="isOverlayBackdropVisible" :overlay-backdrop-transition="overlayBackdropTransition">
          <transition mode="out-in" name="fade">
            <component :is="Component"/>
          </transition>
        </alt-overlay>
      </router-view>
    </n-message-provider>

    <debug-drawer/>


  </n-config-provider>
</template>


<script lang="ts" setup>
import {computed, ref} from "vue";
import {useRouter} from "vue-router";
import {storeToRefs} from "pinia";

import type {NLocale} from 'naive-ui'
import {dateRuRU, NConfigProvider, NGlobalStyle, NMessageProvider, ruRU} from 'naive-ui'

import themeOverrides from './assets/theme/naive-ui-theme-overrides.json'
import {useRootStore} from "@/store"

import AltOverlay from "@/components/AltOverlay.vue"
import useRootOverlay from "@/data/useRootOverlay"
import DebugDrawer from "@/DebugDrawer.vue";

const {theme, altMpRoot} = storeToRefs(useRootStore())

const router = useRouter()
altMpRoot.value.on("GoTo", (location) => {
  router.push(location);
});

const locale = ref<NLocale>(ruRU)
const {isOverlayShown, isOverlayBackdropVisible, overlayBackdropTransition} = useRootOverlay()
</script>

