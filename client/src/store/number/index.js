import axios from "axios";

export default {
  namespaced: true,
  state: {
    numberValErrors: null
  },

  mutations: {
    numberValErrors: function(state, payload) {
      state.numberValErrors = payload.Message;
    }
  },

  //Note: Its not a good practice to commit errors in catch callback,
  //this is just for a demo purposes of using vuex with validation errors from server.
  actions: {
    validateNum: async function({ commit }, params) {
      axios
        .post("validator/isNumber", params)
        .then(commit("numberValErrors", {}))
        .catch(err => {
          commit("numberValErrors", err.response.data.payload);
        });
    }
  },
  modules: {}
};
