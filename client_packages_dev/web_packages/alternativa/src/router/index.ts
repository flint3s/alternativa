import {createRouter, createWebHistory} from 'vue-router'

import Authorization from '../module/authorization/Authorization.vue';
import WelcomeView from '../module/authorization/views/WelcomeView.vue'
import LoginView from '../module/authorization/views/LoginView.vue'
import RegistrationView from '../module/authorization/views/RegistrationView.vue'
import LoaderView from '../module/authorization/views/LoaderView.vue'

import CharacterManager from '../module/character-manager/CharacterManager.vue';
import CharacterSelect from '../module/character-manager/views/CharacterSelect.vue';
import CharacterCreator from '../module/character-manager/views/CharacterCreator.vue';

import AdminPanel from '../module/admin-panel/AdminPanel.vue';
import AdminIndex from '../module/admin-panel/views/AdminIndex.vue';

import DeathAndReborn from '../module/death-and-reborn/DeathAndReborn.vue';

import RoomManager from '../module/room-manager/RoomManager.vue';
import RoomManagerHouseInterface from '../module/room-manager/views/RoomManagerHouseInterface.vue';


const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/login',
      redirect: '/login/loader',
      component: Authorization,
      children: [
        {
          path: 'loader',
          name: 'loader',
          component: LoaderView
        },
        {
          path: 'welcome',
          name: 'Welcome',
          component: WelcomeView
        },
        {
          path: 'login',
          name: 'login',
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
      path: '/character-manager',
      component: CharacterManager,
      redirect: '/character-manager/select-character',
      children: [
        {
          path: 'select-character',
          component: CharacterSelect
        },
        {
          path: 'create-character',
          component: CharacterCreator
        }
      ]
    },
    {
      path: '/admin-panel',
      component: AdminPanel,
      children: [
        {
          path: 'index',
          component: AdminIndex
        }
      ]
    },
    {
      path: '/death-and-reborn',
      component: DeathAndReborn,
      name: 'DeathAndReborn'
    },
    {
      path: '/room-manager',
      component: RoomManager,
      name: 'RoomManager',
      children: [
        {
          path: 'house-interface/:houseId',
          component: RoomManagerHouseInterface
        }
      ]
    }
  ]
})

export default router
