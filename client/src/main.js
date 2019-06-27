import Vue from 'vue'
import App from './App.vue'
import router from './router/index'
import {store} from './store/index'
import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'
import axios from 'axios';
 
axios.defaults.baseURL = 'http://localhost:5001/api/';
Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
