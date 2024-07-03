<script lang="ts">
import type IContact from '@/interfaces/IContact';
import { Contact } from '@/models/Contact';
import { getContactById } from '@/services/AgendaService';
import { ERROR_MESSAGES, REGEX } from '@/utils/constants';

export default {
  props: {
    contactId: {
      type: Number,
      required: false
    }
  },
  data() {
    return new Contact()
  },
  methods: {
    close() {
      this.$emit('close');
    },
    validateData(formData: IContact) {
      const { name, email, phone } = formData;
      if (!name.match(REGEX.VALID_NAME) || name.length > 255)
        return ERROR_MESSAGES.INVALID_NAME;
      if (!email.match(REGEX.VALID_EMAIL) || name.length > 255)
        return ERROR_MESSAGES.INVALID_EMAIL;
      if (isNaN(Number(phone)) || name.length > 15)
        return ERROR_MESSAGES.INVALID_PHONE;
    },
    submitForm() {
      const formData = new Contact(this.name, this.email, this.phone)
      const message = this.validateData(formData)
      if (message) {
        alert(message)
        return
      }
      this.$emit('submit', formData);
      this.close();
    },

  },
  async created() {
    if (this.contactId) {
    const { name, email, phone } = await getContactById(this.contactId)
    this.name = name
    this.email = email
    this.phone = phone
    }
  }
};
</script>

<template>
  <div class="modal-overlay">
    <div class="modal-content">
      <form @submit.prevent="submitForm">
        <div>
          <label for="name">Nome:</label>
          <input type="text" v-model="name" id="name" required />
        </div>
        <div>
          <label for="email">Email:</label>
          <input type="email" v-model="email" id="email" required />
        </div>
        <div>
          <label for="phone">Telefone:</label>
          <input type="tel" v-model="phone" id="phone" required />
        </div>
        <div class="buttons">
            <button type="submit">Salvar</button>
            <button @click="close" class="button-close">Fechar</button>
        </div>
      </form>
    </div>
  </div>
</template>

<style lang="scss" scoped>
  @import "@/utils/constants.scss";

  label, input {
    color: $regular-color; 
  }
  input {
    width: 100%;
  }
  .buttons {
    display: flex;
    justify-content: space-between;
  }
  button {
    padding: $normal-spacing;
    margin-top: $large-spacing;
    cursor: pointer;
    background-color: $confirm-bg-color;
  }
  .button-close {
    background-color: $cancel-bg-color;
  }
  .modal-overlay {
    position: fixed;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background: rgba(0, 0, 0, 0.5);
    display: flex;
    align-items: center;
    justify-content: center;
  }
  .modal-content {
    background: $regular-bg-color;
    padding: $large-spacing;
    border-radius: $normal-spacing;
    width: 300px;
  }
  .modal-content form div {
    margin-bottom: $normal-spacing;
  }
</style>