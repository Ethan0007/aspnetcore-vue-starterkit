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
      if(data.payload){
        data.payload.map(item => {
            if (item.name == "firstName")
              state.stringValErrors.fnameError = `${item.name} ${item.errors[0]}`;
            if (item.name == "lastName")
              state.stringValErrors.lnameError = `${item.name} ${item.errors[0]}`;
          });
      }
    }
  },

  actions: {
    validateString: async function({ commit }, params) {
      axios
        .post("validator/isstring", params)
        .then(() => {commit("stringValError")})
        .catch(err => {commit("stringValError", err.response.data)});
    }
  },
  modules: {}
};
