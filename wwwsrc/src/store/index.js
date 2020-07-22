import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    user: {},
    publicKeeps: [],
    keeps: [],
    vaults: [],
    myKeeps: [],
    myVaults: [],
    activeKeep: {}
  },
  mutations: {
    setVaults(state, vaults) {
      state.vaults = vaults;
    },
    setUser(state, user) {
      state.user = user;
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setActiveKeep(state, activeKeep) {
      state.activeKeep = activeKeep
    }
  },
  actions: {
    setBearer({ }, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    async getActiveKeep({ commit, dispatch }, id) {
      try {
        let res = await api.get('keeps/' + id)
        commit("setActiveKeep", res.data)
      } catch (error) {
        console.error(error)
      }

    },
    async getUser({ commit }) {
      try {
        let res = await api.get("user");
        commit("setUser", res.data)
      } catch (error) {
        console.error(error);
      }
    },
    async deleteKeep({ dispatch }, keepId) {
      try {
        await api.delete("keeps/" + keepId)
        dispatch("getKeeps")
      } catch (error) {
        alert(JSON.stringify(error.response.data));
      }
    },
    async getKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("keeps")
        commit("setKeeps", res.data)
      } catch (error) {
        console.error(error)
      }
    },
    async createKeep({ commit, dispatch }, newKeep) {
      let res = await api.post("keeps", newKeep)
      dispatch("getKeeps")
    },
    async getVaults({ commit, dispatch }) {
      try {
        let res = await api.get("vaults")
        commit("setVaults", res.data)
      } catch (error) {
        console.error(error)
      }
    }
  }
});
