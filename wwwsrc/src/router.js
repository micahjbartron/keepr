import Vue from "vue";
import Router from "vue-router";
// @ts-ignore
import Home from "./views/Home.vue";
// @ts-ignore
import Dashboard from "./views/Dashboard.vue";
// @ts-ignore
import Keep from "./views/KeepDetails.vue";
// @ts-ignore
import Vault from "./views/VaultDetails.vue";
import { authGuard } from "@bcwdev/auth0-vue";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      name: "home",
      component: Home,
    },
    {
      path: "/dashboard",
      name: "dashboard",
      component: Dashboard,
      beforeEnter: authGuard
    },
    {
      path: "/keeps/:keepId",
      name: "keep",
      component: Keep,
      beforeEnter: authGuard
    },
    {
      path: "/vaults/:vaultId",
      name: "vault",
      component: Vault,
      beforeEnter: authGuard
    },
  ]
});
