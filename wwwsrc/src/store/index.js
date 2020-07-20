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
    publicKeeps: [],
    keeps: [],
    myKeeps: [],
    myVaults: [],
    activeKeep: {}
  },
  mutations: {
    setKeeps(state, keeps) {
      state.keeps = keeps
    }
  },
  actions: {
    setBearer({ }, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
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
    }
  }
});
