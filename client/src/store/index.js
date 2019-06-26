import Vue from 'vue';
import Vuex from 'vuex';
import state from './state';
import getters from './getters';
import mutations from './mutations';
import actions from './actions';
import modules from './modules';


Vue.use(Vuex);

export const store = new Vuex.Store({
    state,
    getters,
    mutations,
    actions,
    modules
})

