import { defineConfig } from 'vite';
import plugin from '@vitejs/plugin-vue';
import vuetify from "vite-plugin-vuetify";

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [plugin(), vuetify({ autoImport: true })],
    server: {
        port: 52920,
  },
  devServer: {
    proxy: 'http://localhost:5092'
  }
})
