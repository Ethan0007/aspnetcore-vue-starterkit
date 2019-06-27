import axios from "axios";

export default {
  namespaced: true,
  state: {
    dateTimeValErrors: null
  },

  mutations: {
    dateTimeValErrors: function(state, payload) {
      state.dateTimeValErrors = payload.Message;
    }
  },

  //Note: Its not a good practice to commit errors in catch callback,
  //this is just for a demo purposes of using vuex with validation errors from server.
  actions: {
    validateDateTime: async function({ commit }, params) {
      axios
        .post("validator/isDateTime", params)
        .then(commit("dateTimeValErrors", {}))
        .catch(err => {
          commit("dateTimeValErrors", err.response.data.payload);
        });
    }
  },
  modules: {}
};
