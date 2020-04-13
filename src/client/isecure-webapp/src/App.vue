<template>
  <div id="app">
    <img alt="Vue logo" class="logo-isecure" src="./assets/logo_png_isecure.png" />
    <Home msg="EMERGENCY ALERTING SYSYTEM" />
  </div>
</template>

<script>
import Home from "./components/Home.vue";

export default {
  name: "App",
  components: {
    Home
  }
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

.logo-isecure {
  height: 250px;
  width: 250px;
}
</style>
