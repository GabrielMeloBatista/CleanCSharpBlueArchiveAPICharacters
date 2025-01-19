import CharacterGrid from './components/CharacterGrid.vue';
import { createRouter, createWebHistory } from "vue-router";

const routes = [
  {
    path: "/",
    name: "Home",
    component: CharacterGrid,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
