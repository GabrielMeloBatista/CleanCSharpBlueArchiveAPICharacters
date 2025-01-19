<template>
  <v-btn v-if="showButton"
         @click="scrollToTop"
         class="go-to-top-btn"
         color="primary">
    ↑
  </v-btn>
  <v-container>
    <header>
      <h1 class="text-center">Blue Archive Character Viewer</h1>
    </header>
    <main class="center">
      <router-view />
    </main>
    <footer class="bg-white">
      <p>&copy; 2025 Blue Archive Viewer</p>
    </footer>
  </v-container>
</template>

<script lang="ts">
  import { defineComponent } from "vue";


  export default defineComponent({
    name: "App",
    data() {
      return {
        showButton: false,
      };
    },
    methods: {
      handleScroll() {
        this.showButton = window.scrollY > 100;
      },
      scrollToTop() {
        window.scrollTo({ top: 0, behavior: 'smooth' });
      },
    },
    mounted() {
      window.addEventListener('scroll', this.handleScroll);
    },
    beforeDestroy() {
      window.removeEventListener('scroll', this.handleScroll);
    },
  });
</script>

<style>
  .go-to-top-btn {
    position: fixed !important;
    z-index: 9999;
    bottom: 60px;
    right: 60px;
  }

  #app {
    font-family: Arial, sans-serif;
    text-align: center;
    margin: 0;
    padding: 0;
  }

  header {
    padding: 10px 0;
    width: 100vw !important;
  }

  main {
    width: 100vw !important;
  }

  nav {
    margin-top: 10px;
  }

  footer {
    padding: 10px 0;
    bottom: 0;
    width: 100vw;
  }
</style>
