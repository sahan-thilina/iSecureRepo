<template>
  <div class="hello">
    <h2>{{ msg }}</h2>
    <div class="row">
      <div class="column" v-for="(button, index) in buttons" :key="index">
        <!-- <button @click="changeText(button)">{{button.name}}</button> -->
        <h3>{{button.name}}</h3>
        <p>{{button.text}}</p>
      </div>
    </div>
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
          text: "The police are a constituted body of persons empowered by a state to enforce the law, to ensure the safety, health and possessions of citizens, and to prevent crime and civil disorder. Their lawful powers include arrest and the legitimized use of force."
        },
        {
          id: 2,
          name: "Hospital",
          text: "A hospital is a health care institution providing patient treatment with specialized medical and nursing staff and medical equipment."
        },
        {
          id: 3,
          name: "Fire Brigade",
          text: "Firefighters respond to fires, accidents and other incidents where there are risks to life and property. Full-time firefighters help protect the public in emergency situations. They respond to a wide variety of calls: as well as fires, they assist at car crashes, chemical spills, flooding and water rescue."
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

.column {
  float: left;
  width: 33.33%;
  padding: 10px;
  height: 300px; /* Should be removed. Only for demonstration */
}
.row:after {
  content: "";
  display: table;
  clear: both;
}

* {
  box-sizing: border-box;
}
</style>
