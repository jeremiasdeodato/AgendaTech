<template>
  <div class="container grid-lg my-2 text-dark">
    
    <div class="card">

      <div class="card-header">

        <div class="h4"> Agendas </div>

      </div>

      <div class="card-body">
        <agendas :agendas="agendas"/>  
      </div>

    </div>    
  </div>
</template>

<script>

import agendas from './components/agendas.vue'
import api from '@/servidor/api.js'
import { onMounted, reactive, toRefs } from 'vue';


export default {
  name: 'App',
  components: {
    agendas
  },

  setup(){
    const data = reactive ({
      agendas: { },

    });

    onMounted( async() => {

      const response = await api.agendas();
      data.agendas = response.data.data;
    })
    
    return { ...toRefs(data)}
  }
}
</script>

<style>

  .h4 {
    text-align: center;
    margin-bottom: 10px;
  }

  .card {
    box-shadow: inset 0 0 1em black;
    align-content: center;
  }

</style>
