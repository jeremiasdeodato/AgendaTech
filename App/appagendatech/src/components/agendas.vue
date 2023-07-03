<template>
  <div>
    <div class="table table-striped table-hover">
      <thead>
        <tr>
          <th>Id</th>
          <th>Nome</th>
          <th>E-mail</th>
          <th>Telefone</th>          
        </tr>
      </thead>

        <tbody>
          <tr v-for="(agenda, key) in agendas" :key="key">            
            <td> {{ agenda.id }} </td>
            <td> {{ agenda.nome }} </td>
            <td> {{ agenda.email }} </td>
            <td> {{ agenda.telefone }} </td>            
          </tr>
        </tbody>      
    </div>    
  </div>

</template>

<script>

export default{
  props: {agendas: {type: Object, required: true}},
}


</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
