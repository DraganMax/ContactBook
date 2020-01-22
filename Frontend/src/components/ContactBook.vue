<template>
  <div class="header">
    <b-jumbotron>
      <template v-slot:header> {{ msg }}</template>
      <hr class="my-4">
      <p>
        <b>To display list of contacts click on the image.</b>
      </p>
    </b-jumbotron>
  </div>
</template>

<script>
export default {
  name: 'ContactBook',
  props: {
    msg: String
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.jumbotron
{
  padding: 5px;
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
