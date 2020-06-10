<template>
  <div class="home">
    <HelloWorld msg="Добро пожаловать в Шляпу!"/>
    <img class="logo" alt="Vue logo" src="../assets/hat.svg">    
  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from '@/components/HelloWorld.vue'

export default {
  name: 'Home',
  components: {
    HelloWorld
  }
}
</script>

<style scoped>
  .logo{
    max-width: 200px;
  }
</style>
