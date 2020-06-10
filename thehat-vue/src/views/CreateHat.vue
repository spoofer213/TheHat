<template>
  <div class="hat-container">
    <h4>Введите название игры</h4>
    <div v-if="hats.length">
      <div v-for="hat in hats" :key="hat.name">
        {{hat.name}}
      </div>      
    </div>
    <div>
      {{errs}}
    </div>
  </div>  
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import IHat from "../../types/Hat";
import HatService from "../../services/hat-service";

const hatService = new HatService();

@Component({
  name: 'CreateHat',
  components: {}
})

export default class CreateHat extends Vue{
  // data
  hats: IHat[] = [];
  errs: string = '';

  get hatCount(){
    return this.hats.length;
  }

  created(){
    hatService.createHat().then(res => console.log(res)).catch(function(error){if(error.response){console.log(error.response.status);
    console.log(error.response.data.errorMessage);}});
    hatService.gatHats()
    .then(res => this.hats = res)
    .catch(err => {this.errs = err, console.log(err)});
  }
}
</script>