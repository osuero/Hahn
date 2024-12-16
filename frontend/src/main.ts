import { createApp } from 'vue';
import App from './App.vue'; // Tu componente raíz
import vuetify from './plugins/vuetify'; // Si usas Vuetify (opcional)

const app = createApp(App);

app.use(vuetify); // Habilita plugins, si los tienes
app.mount('#app');
