<template>
  <b-container fluid>
    <section v-if="errored">
      <h4>We're sorry, something went wrong, please try back later</h4>
    </section>
    <section v-else>
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
    <b-row class="justify-content-md-center">
      <add-contact id="add-contact" :onSave="() => {fetchContacts()}"/>
      <b-button @click="removeContacts()" variant="danger" class="mt-0 mb-2">Delete All Contacts <b-icon icon="trash-fill" /></b-button>
    </b-row>
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
          <template v-if="data.item.addresses.length">
            <div v-for="address in data.item.addresses" :key="address.id">
              <b>{{ address.city }} - {{ address.street }}</b>
            </div>
          </template>
          <div v-if="!data.item.addresses.length">
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
          <b-button class="mx-1" @click="showEditModal(data.item.id)" variant="success" size="sm">Edit  <b-icon icon="pencil-fill" /></b-button>
          <b-button class="mx-1" @click="removeFromList(data.item.id)" size="sm" variant="danger">Delete <b-icon icon="person-dash-fill" /></b-button>
        </template>
      </b-table>
      <edit-contact v-if="showEditPopup" :contact="this.editedContact">
      </edit-contact>
    </section>
  </b-container>
</template>

<script>
import AddContact from "./AddContact.vue";
import EditContact from "./EditContact.vue";
import axios from "axios";
import Swal from "sweetalert2";

export default {
  name: "ContactList",
  components: {
    AddContact,
    EditContact
  },
  data() {
    return {
      errored: false,
      contactList: [],
      editedContact: {},
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
      headVariant: "dark",
      editModal: {
        id: 'modal-2',
        content: ''
      },
      showEditPopup: false
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
    removeFromList(id) {
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
          axios.delete("api/contacts/" + id)
          .then(() => {
            Swal.fire("Deleted!", "Your contact has been deleted.", "success");
            this.fetchContacts();
          });
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
    showEditModal(id) {
      axios
      .get(`api/contacts/${id}`)
      .then(response => {
        this.editedContact = response.data;
        console.log(this.editedContact.birthday)
        this.showEditPopup = !this.showEditPopup;
      })
      .catch(error => {
        console.log(error);
        this.errored = true;
      });
    },
    fetchContacts() {
      axios
        .get("api/contacts")
        .then(response => {
          this.contactList = response.data;
        })
        .catch(error => {
          console.log(error);
          this.errored = true;
        });
    },
    removeContacts() {
      if (this.contactList.length > 0) {
        Swal.fire({
          title: "Are you sure you want do delete all contacts?",
          text: "You won't be able to revert this!",
          icon: "warning",
          showCancelButton: true,
          cancelButtonColor: "#d33",
          confirmButtonColor: "#3085d6",
          confirmButtonText: "Yes, delete!",
          reverseButtons: true
        })
        .then(result => {
          if (result.value) {
            axios.delete("api/contacts/clear")
            .then(() => {
              Swal.fire("Deleted!", "All contacts have been deleted.", "success");
              this.fetchContacts();
            })
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
      }
      else {
        Swal.fire("Wrong Operation!", "There is no contacts to delete.");
      }
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
#add-contact {
  margin-right: 10px;
}
</style>