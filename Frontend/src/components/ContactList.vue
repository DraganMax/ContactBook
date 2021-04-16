<template>
  <b-container fluid>
    <b-col md="5" offset="3" class="my-3">
      <b-form-group
        label="Filter"
        label-cols-sm="2"
        label-align-sm="right"
        label-size="sm"
        label-for="filterInput"
        class="mb-0"
      >
        <b-input-group size="sm">
          <b-form-input
            v-model="search"
            type="search"
            id="filterInput"
            placeholder="Type to Search Contact"
          ></b-form-input>
        </b-input-group>
      </b-form-group>
    </b-col>
    <section v-if="errored">
      <p>We're sorry, something went wrong, please try back later</p>
    </section>
    <AddContact :onSave="() => {fetchContacts()}"/>
    <b-form-group label="Choose theme for table" label-for="table-style-variant" label-cols-lg="2">
      <b-form-select v-model="tableVariant" :options="tableVariants" id="table-style-variant">
        <template v-slot:first>
          <option value>-- None --</option>
        </template>
      </b-form-select>
    </b-form-group>
    <b-table
      responsive
      id="my-table"
      stacked="md"
      small
      show-empty
      :table-variant="tableVariant"
      :head-variant="headVariant"
      hover
      :items="filteredContacts"
      :fields="fields"
    >
      <template v-slot:cell(Nr)="data">
        <b>{{ data.index + 1 }}</b>
      </template>
      <template v-slot:cell(name)="data">
        <b>{{ data.item.name }}</b>
      </template>
      <template v-slot:cell(phones)="data">
        <template v-if="data.item.phones.length">
          <div v-for="phone in data.item.phones" :key="phone.id">
            <b>{{ phone.number }}</b>
          </div>
        </template>
        <div v-if="!data.item.phones.length">
          <b>-</b>
        </div>
      </template>
      <template v-slot:cell(emails)="data">
        <template v-if="data.item.emails.length">
          <div v-for="email in data.item.emails" :key="email.id">
            <b>{{ email.email }}</b>
          </div>
        </template>
        <div v-if="!data.item.emails.length">
          <b>-</b>
        </div>
      </template>
      <template v-slot:cell(adresses)="data">
        <template v-if="data.item.adresses.length">
          <div v-for="adress in data.item.adresses" :key="adress.id">
            <b>{{ adress.city }} - {{ adress.street }} {{ adress.house }}</b>
          </div>
        </template>
        <div v-if="!data.item.adresses.length">
          <b>-</b>
        </div>
      </template>
      <template v-slot:cell(birthday)="data">
        <div v-if="data.item.birthday">
          <b>{{ data.item.birthday.substring(0, 10) }}</b>
        </div>
        <b v-else>-</b>
      </template>
      <template v-slot:cell(surname)="data">
        <b>{{ data.item.surname }}</b>
      </template>
      <template v-slot:cell(company)="data">
        <b v-if="data.item.company">{{ data.item.company }}</b>
        <b v-else>-</b>
      </template>
      <template v-slot:cell(manipulations)="data">
        <EditContact :id="data.item.id"/>
        <b-button @click="onEdit" variant="success" class="mx-1" v-b-modal.modal-2 size="sm">Edit</b-button>
        <b-button :deleting="() => {fetchContacts()}" @click="onDelete(data.item.id)" size="sm" variant="danger">Delete</b-button>
      </template>
    </b-table>
  </b-container>
</template>

<script>
import AddContact from "./AddContact.vue";
import EditContact from "./EditContact.vue";
import axios from "axios";
import Swal from "sweetalert2"

export default {
  name: "ContactList",
  components: {
    AddContact,
    EditContact
  },
  props: {
    deleting: Function
  },
  data() {
    return {
      errored: false,
      contactList: [],
      fields: [
        "Nr",
        {
          key: "name",
          sortable: true
        },
        "surname",
        "company",
        "birthday",
        "phones",
        "emails",
        "adresses",
        "manipulations"
      ],
      search: "",
      tableVariants: [
        "primary",
        "secondary",
        "danger",
        "warning",
        "success",
        "dark"
      ],
      tableVariant: "",
      headVariant: "dark"
    };
  },
  computed: {
    filteredContacts() {
      const searchContact = this.search.toLowerCase().trim();
      return this.contactList.filter(contact => {
        return (
          contact.name.toLowerCase().includes(searchContact) ||
          contact.surname.toLowerCase().includes(searchContact) ||
          contact.company.toLowerCase().includes(searchContact) ||
          contact.phones.some(element =>
            element.number.includes(searchContact)
          ) ||
          contact.emails.some(element =>
            element.email.toLowerCase().includes(searchContact)
          )
        );
      });
    }
  },
  methods: {
    onDelete(id) {
      Swal.fire({
        title: "Do you really want to delete this contact?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        cancelButtonColor: "#d33",
        confirmButtonColor: "#3085d6",
        confirmButtonText: "Yes, delete it!",
        reverseButtons: true
      })
        .then(result => {
          if (result.value) {
            axios.delete("api/contacts/" + id);
            Swal.fire("Deleted!", "Your contact has been deleted.", "success");
            axios.get("api/contacts");
          }
        })
        .catch(error => {
          console.log(error);
          Swal.fire({
            icon: "error",
            title: "Oooops....",
            text: "Something went wrong!"
          });
        });
    },
    onEdit() {
      
    },
    fetchContacts() {
      axios
        .get("/api/contacts")
        .then(response => {
          this.contactList = response.data;
        })
        .catch(error => {
          console.log(error);
          this.errored = true;
        });
    }
  },
  mounted: function() {
    this.fetchContacts();
  }
};
</script>

<style scoped>
.form-control {
  height: 30px;
  border-radius: 10px;
  border: solid 1px gray;
  margin-left: 10px;
}
.btn {
  text-align: left;
}
</style>