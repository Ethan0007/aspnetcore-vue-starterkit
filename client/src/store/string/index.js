import axios from "axios";

export default {
  namespaced: true,
  state: {
    stringValErrors: {
      fnameError: null,
      lnameError: null
    }
  },

  mutations: {
    stringValError: async function(state, data) {
      state.stringValErrors = {};
      if (data.payload) {
        data.payload.map(item => {
          if (item.name == "firstName")
            state.stringValErrors.fnameError = `${item.name} ${item.errors[0]}`;
          if (item.name == "lastName")
            state.stringValErrors.lnameError = `${item.name} ${item.errors[0]}`;
        });
      }
    }
  },
  //Note: Its not a good practice to commit errors in catch callback,
  //this is just for a demo purposes of using vuex with validation errors from server.
  actions: {
    validateString: async function({ commit }, params) {
      axios
        .post("validator/isString", params)
        .then(() => {
          commit("stringValError", {});
        })
        .catch(err => {
          commit("stringValError", err.response.data);
        });
    },

    validateStringWithMaxMin: async function({ commit }, params) {
      axios
        .post("validator/IsStringWithMinMax", params)
        .then(() => {
          commit("stringValError", {});
        })
        .catch(err => commit("stringValError", err.response.data));
    }
  },
  modules: {}
};
