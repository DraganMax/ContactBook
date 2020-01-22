<template>
  <div id="app">
    <b-jumbotron v-if="isShown">
      <h1>
        <b>That's Your Contact List</b>
      </h1>
    </b-jumbotron>
    <ContactBook v-if="!isShown" msg="Contact Book"/>
    <img alt="Vue logo" v-if="!isShown" @click="isShown=true" src="./assets/logo.png">
    <b-container>
      <ContactList v-if="isShown" />
    </b-container>
  </div>
</template>

<script>
import ContactBook from './components/ContactBook.vue'
import ContactList from './components/ContactList.vue'


export default {
  name: 'app',
  components: {
    ContactBook,
    ContactList
  },
  data() {
    return {
      isShown: false
    }
  },
   methods: {

   }
  }
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  align-items: center;
  color: #2c3e50;
  
}
img
{
  height: 200px;
  width: 200px;
  margin: 2px;
}
</style>
