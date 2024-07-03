<script lang="ts">
import type IContact from '@/interfaces/IContact';
import { getContacts, deleteContact, updateContact } from '@/services/AgendaService';
import Form from './Form.vue';
  
export default {
  props: {
    refresh: {
      type: Number,
      required: true
    }
  },
  watch: {
    async refresh(newVal) {
      if (newVal) {
        await this.loadContacts()
      }
    }
  },
  data() {
    return {
      contacts: [] as IContact[],
      openFormToEdit: false,
      contactId: 0 
    }
  },
  async created() {
    await this.loadContacts()
  },
  components: { Form },
  methods: {
    async loadContacts() {
      this.contacts = await getContacts()
    },
    async removeContact(id: number | undefined) {
      if (id) {
        await deleteContact(id)
        await this.loadContacts()
      }
    },
    async editContact(contact: IContact) {
      await updateContact(this.contactId, contact)
      await this.loadContacts()
    }
  }
}
</script>

<template>
  <table v-if="contacts.length">
    <tr>
      <td>Nome</td>
      <td>Email</td>
      <td>Telefone</td>
      <td>Ações</td>
    </tr>
    <tr v-for="contact in contacts" :key="contact.id">
      <td>{{contact.name}}</td>
      <td>{{contact.email}}</td>
      <td>{{contact.phone}}</td>
      <td>
        <img src="../assets/edit.svg" alt="edit" class="icon edit" id="edit-image" @click="openFormToEdit = true; contactId=contact.id;" title="Editar Contato">
        <img src="../assets/delete.svg" alt="delete" class="icon delete" @click="removeContact(contact.id)" title="Deletar Contato">
      </td>
    </tr>
  </table>
  <Form v-if="openFormToEdit" :contactId="contactId" @close="openFormToEdit = false" @submit="editContact"/>
</template>

<style lang="scss" scoped>
  @import "@/utils/constants.scss";

  table, span {
    margin-top: $normal-spacing;
  }

  table, th, td {
    border: 1px solid black;
    border-collapse: collapse;
  }

  td {
    padding: $large-spacing;
  }

  .icon {
    cursor: pointer;
    margin-right: $normal-spacing;
  }

</style>