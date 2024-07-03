<script lang="ts">
  import Table from './components/Table.vue';
  import Form from './components/Form.vue';
  import { insertContact } from '@/services/AgendaService';
  import type IContact from './interfaces/IContact';

  export default {
    components: { Table, Form },
    data() {
      return {
        openFormToAdd: false,
        refresh: 0
      }
    },
    methods: {
      async addContact(contact: IContact) {
        await insertContact(contact)
        this.refresh++
      }
    }
  }
</script>

<template>
  
  <header>
    <span>Agenda</span>
  </header>
  
  <main>
    <Table :refresh="refresh" />
    <button @click="openFormToAdd = true">
      Adicionar Contato
    </button>
    <Form v-if="openFormToAdd" @close="openFormToAdd = false" @submit="addContact"/>
  </main>

</template> 

<style scoped>
  button {
    padding: 8px;
    margin-top: 16px;
    cursor: pointer;
    background-color: #04AA6D;
  }
</style>

