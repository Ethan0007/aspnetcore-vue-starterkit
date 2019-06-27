import axios from "axios";

export default {
  namespaced: true,
  state: {
    booleanValErrors: null
  },

  mutations: {
    booleanValErrors: function(state, payload) {
      state.booleanValErrors = payload.Message;
    }
  },

  //Note: Its not a good practice to commit errors in catch callback,
  //this is just for a demo purposes of using vuex with validation errors from server.
  actions: {
    validateBoolean: async function({ commit }, params) {
      axios
        .post("validator/isBool", params)
        .then(commit("booleanValErrors", {}))
        .catch(err => {
          commit("booleanValErrors", err.response.data.payload);
        });
    }
  },
  modules: {}
};
