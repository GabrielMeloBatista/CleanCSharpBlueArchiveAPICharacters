import './assets/main.css'
import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import { createVuetify } from "vuetify";
import * as components from "vuetify/components";
import * as directives from "vuetify/directives";
import 'vuetify/styles';

const vuetify = createVuetify({
  components,
  directives,
  theme: {
    defaultTheme: 'dark',
    themes: {
      dark: {
        colors: {
          primary: '#1E88E5',
          secondary: '#424242',
          accent: '#FF4081',
          error: '#D32F2F',
          info: '#0288D1',
          success: '#388E3C',
          warning: '#FBC02D',
          background: '#121212',
          surface: '#333333',
          text: '#FFFFFF',
        },
      },
      light: {
        colors: {
          primary: '#1976D2',
          secondary: '#616161',
          accent: '#FF4081',
          error: '#D32F2F',
          info: '#0288D1',
          success: '#388E3C',
          warning: '#FF9800',
          background: '#F5F5F5',
          surface: '#FFFFFF',
          text: '#212121',
        },
      },
    },
  },
});


createApp(App).use(router).use(vuetify).mount("#app");
