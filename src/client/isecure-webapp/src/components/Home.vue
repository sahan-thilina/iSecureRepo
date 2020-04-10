<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <div v-for="(button, index) in buttons" :key="index">
      <button @click="changeText(button)">{{button.name}}</button>
    </div>
    <h2>{{departmentMsg}}</h2>
    <p>Powered by Vue.js</p>
    <h3>Coming soon.........</h3>
  </div>
</template>

<script>
export default {
  name: "Home",
  props: {
    msg: String
  },
  data: function() {
    return {
      departmentMsg: "",
      buttons: [
        {
          id: 1,
          name: "Police",
          text: "This is police station"
        },
        {
          id: 2,
          name: "Hospital",
          text: "This is Hospital"
        },
        {
          id: 3,
          name: "Fire Brigade",
          text: "This is Fire Brigade"
        }
      ]
    };
  },
  methods: {
    changeText: function(button) {
      this.departmentMsg = button.text;
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
