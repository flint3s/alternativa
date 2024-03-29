import {defineStore} from "pinia";
import {ref} from "vue";
import type {Ref} from "vue";
import {altMP} from "@/connect/events/altMP";
import router from "@/router";

export const useDeathAndRebornStore = defineStore('deathAndReborn', () => {
  const showDeathSign: Ref<boolean> = ref(true)
  const rebornIntervalId: Ref<number| null> = ref(null)
  const secondsToReborn: Ref<number> = ref(0)
  const deathReason: Ref<string> = ref('')
  const altMpDR: Ref<altMP> = ref(new altMP("DeathAndReborn", "1"))

  function registerDeathListeners() {
    altMpDR.value.on("Death", (timeToReborn: number, reason: string) => {
      router.push({name: "DeathAndReborn"}).then(() => {
        clearInterval(rebornIntervalId.value!)
        showDeathSign.value = true
        secondsToReborn.value = timeToReborn
        deathReason.value = reason

        rebornIntervalId.value = setInterval(() => {
          secondsToReborn.value--
          if (secondsToReborn.value === 0) {
            clearInterval(rebornIntervalId.value!)
          }
        }, 1000)
      })
    })

    altMpDR.value.on("Reborn", () => {
      clearInterval(rebornIntervalId.value!)
      secondsToReborn.value = 0
    })
  }

  return {
    showDeathSign,
    rebornIntervalId,
    secondsToReborn,
    deathReason,
    registerDeathListeners
  }
})
