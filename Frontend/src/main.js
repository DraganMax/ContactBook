import Vue from 'vue'
import BootstrapVue from 'bootstrap-vue'
import App from './App.vue'
import axios from 'axios'

import 'pc-bootstrap4-datetimepicker/build/css/bootstrap-datetimepicker.css';

Vue.use(BootstrapVue, axios)

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

Vue.config.productionTip = false


new Vue({
  render: h => h(App),
}).$mount('#app')

