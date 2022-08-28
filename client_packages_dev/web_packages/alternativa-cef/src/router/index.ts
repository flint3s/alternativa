import {createRouter, createWebHashHistory, RouteRecordRaw} from 'vue-router'
import LoginView from '../modules/authorization/views/LoginView.vue'
import RegistrationView from '../modules/authorization/views/RegistrationView.vue'
import WelcomeView from '../modules/authorization/views/WelcomeView.vue'
import LoaderView from '../modules/authorization/views/LoaderView.vue'
import Authorization from "@/modules/authorization/Authorization.vue";
import CharacterManager from "@/modules/character-manager/CharacterManager.vue";
import CharacterSelect from "@/modules/character-manager/views/CharacterSelect.vue";
import AltRoot from "@/modules/AltRoot.vue";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    name: "root",
    component: AltRoot,
    children: [
      {
        path: "login",
        redirect: "/login/loader",
        component: Authorization,
        children: [
          {
            path: "loader",
            name: "loader",
            component: LoaderView
          },
          {
            path: 'welcome',
            name: 'Welcome',
            component: WelcomeView
          },
          {
            path: 'login',
            name: 'home',
            component: LoginView
          },
          {
            path: 'registration',
            name: 'registration',
            component: RegistrationView
          }
        ]
      },
      {
        path: "character-manager",
        component: CharacterManager,
        redirect: "character-manager/select-character",
        children: [
          {
            path: "select-character",
            component: CharacterSelect
          }
        ]
      }
    ]
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
