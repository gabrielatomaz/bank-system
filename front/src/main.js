import Vue from 'vue'
import App from './App.vue'
import Loading from 'vue-loading-overlay';
import 'vue-loading-overlay/dist/vue-loading.css';

Vue.use(Loading);

Vue.config.productionTip = false

new Vue({
  render: h => h(App),
}).$mount('#app')
