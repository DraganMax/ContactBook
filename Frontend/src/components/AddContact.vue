<template>
  <div>
    <b-button variant="primary" @click="onReset" v-b-modal.add-modal class="mt-0 mb-2">Add Contact <b-icon icon="person-plus-fill" /></b-button>

    <b-modal id="add-modal" size="xl" hide-footer @shown="focusElement" title="Adding Contact">
      <div>
        <b-form @submit="onSubmit" @reset="onReset" v-if="show">
          <b-row>
            <b-col>
              <b-form-group id="input-group-1" label-for="input-1">
                <template>
                  Contact's Name<span class="text-danger">*</span>
                </template>
                <b-form-input
                  id="input-1"
                  ref="focusThis"
                  v-model="form.name"
                  required
                  placeholder="Enter name"
                ></b-form-input>
                <b-form-text id="name-help-block">
                  Name should contain only letters.
                </b-form-text>
              </b-form-group>
            </b-col>
            <b-col>
              <b-form-group id="input-group-2" label-for="input-2">
                <template>
                  Contact's Surname<span class="text-danger">*</span>
                </template>
                <b-form-input
                  id="input-2"
                  v-model="form.surname"
                  required
                  placeholder="Enter surname"
                  class="required"
                ></b-form-input>
                <b-form-text id="surname-help-block">
                  Surname should contain only letters.
                </b-form-text>
              </b-form-group>
            </b-col>
          </b-row>

          <b-row>
            <b-col>
              <b-form-group id="input-group-3" label-for="input-3">
                <template>
                  Contact's Working Place
                </template>
                <b-form-input id="input-3" v-model="form.company" placeholder="Enter company">
                </b-form-input>
              </b-form-group>
            </b-col>

            <b-col>
              <b-form-group id="input-group-4" label-for="input-4">
                <template>
                  Contact's Birthday:
                </template>
                <b-form-input id="input-4" v-model="form.date" type="date"></b-form-input>
              </b-form-group>
            </b-col>
          </b-row>

          <b-row>
            <b-col>
              <b-form-group id="input-group-5" label-for="input-5">
                <template>
                  Contact's Phone Number
                </template>
                <b-form-input
                  :class="[this.form.number !== '' ? (phoneFormat() ? 'correct' : 'error') : '']"
                  class="mb-0"
                  type="tel"
                  pattern="^2(\d){7}$"
                  id="input-5"
                  v-model="form.number"
                  placeholder="Enter phone number"
                ></b-form-input>
                <b-form-text id="phone-help-block">
                  Number requires 8 digits. Starts with 2 for Latvian numbers.
                </b-form-text>
                <b-button
                  class="mx-0 mb-2 insert"
                  variant="success"
                  size="sm"
                  :disabled="!phoneFormat() || this.form.number === ''"
                  @click="addPhone"
                >Add Phone <b-icon icon="plus" /></b-button>
                <span v-if="!phoneFormat()" style="color: red"> {{ phoneError }}</span>
                <ul v-for="(phone, index) in phones" :key="index">
                  <li class="mx-0">
                    {{ phone }}
                    <b-button variant="outline-danger" size="sm" 
                    @click="deletePhone(index)">Delete <b-icon icon="trash2" /></b-button>
                  </li>
                </ul>
              </b-form-group>
            </b-col>

            <b-col>
              <b-form-group id="input-group-6" label-for="input-6">
                <template>
                  Contact's Email Address
                </template>
                <b-form-input
                  id="input-6"
                  v-model="form.email"
                  type="email"
                  placeholder="Enter email"
                  :class="[this.form.email !== '' ? (emailFormat() ? 'correct' : 'error') : '']"
                ></b-form-input>
                <b-form-text id="password-help-block">
                  Email requires '@' symbol. For example: email@gmail.com
                </b-form-text>
                <b-button
                  class="mx-0 mb-2 insert"
                  :disabled="!emailFormat() || this.form.email === ''"
                  variant="success"
                  size="sm"
                  @click="addEmail">
                   Add Email <b-icon icon="plus" />
                </b-button>
                <span v-if="!emailFormat()" style="color: red"> {{ emailError }}</span>
                <ul v-for="(email, index) in emails" :key="index">
                  <li class="mx-0">
                    {{ email }}
                    <b-button variant="outline-danger" size="sm" 
                    @click="deleteEmail(index)">Delete <b-icon icon="trash2" /></b-button>
                  </li>
                </ul>
              </b-form-group>
            </b-col>
          </b-row>
          <b-form-group id="input-group-7" label-for="input-7">
            <template>
              Contact's Adress
            </template>
            <b-row>
              <b-col>
                <b-form-input id="input-8" :required="this.form.street.length > 0" v-model="form.city" placeholder="Enter city"></b-form-input>
              </b-col>
              <b-col>
                <b-form-input id="input-9" :required="this.form.city.length > 0" v-model="form.street" 
                placeholder="Enter street"></b-form-input>
              </b-col>
            </b-row>
            <b-button
                  class="mx-0 mb-2 insert"
                  variant="success"
                  size="sm"
                  :disabled="!addressFormat()"
                  @click="addAddress"
                >Add Adress <b-icon icon="plus" /></b-button>
                <span v-if="!addressFormat()" style="color: red"> {{ addressError }}</span>
                <ul v-for="(address, index) of addresses" :key="index">
                  <li class="mx-0">
                    {{ address.city }} - {{ address.street }}
                    <b-button variant="outline-danger" size="sm" 
                    @click="deleteAddress(index)">Delete <b-icon icon="trash2" /></b-button>
                  </li>
                </ul>
          </b-form-group>

          <b-button class="formBtn" type="reset" variant="warning">Reset</b-button>
          <b-button class="formBtn" @click="$bvModal.hide('add-modal')">Cancel</b-button>
          <b-button class="formBtn" type="submit" variant="primary">Submit</b-button>
        </b-form>
      </div>
    </b-modal>
  </div>
</template>

<script>
import "bootstrap/dist/css/bootstrap.css";
import Swal from "sweetalert2";
import axios from "axios";

export default {
  components: {},
  props: {
    onSave: Function
  },
  data() {
    return {
      form: {
        name: "",
        surname: "",
        company: "",
        date: "",
        number: "",
        email: "",
        city: "",
        street: ""
      },
      phones: [],
      emails: [],
      addresses: [],
      format: false,
      show: true,
      errored: false,
      phoneError: "",
      emailError: "",
      addressError: ""
    };
  },
  methods: {
    addPhone: function() {
      if (this.form.number.length === 8) {
        this.phones.push(this.form.number);
      }
      this.form.number = "";
    },
    deletePhone: function(index) {
      this.phones.splice(index, 1);
    },
    addEmail: function() {
      if (this.form.email !== "" && this.form.email.includes("@")) {
        this.emails.push(this.form.email);
      }
      this.form.email = "";
    },
    deleteEmail: function(index) {
      this.emails.splice(index, 1);
    },
    addAddress: function() {
      const { city, street } = this.form;
      if (city || street) {
        this.addresses.push({
          city: city,
          street: street
        });
        this.form.city = "";
        this.form.street = "";
      }
    },
    deleteAddress: function(index) {
      this.addresses.splice(index, 1);
    },
    onSubmit(evt) {
      evt.preventDefault();

      axios
        .post("api/contacts", {
          name: this.form.name,
          surname: this.form.surname,
          company: this.form.company,
          birthday: this.form.date,
          phones: this.phones.map(phone => {
          return { number: phone };
          }),
          emails: this.emails.map(email => {
            return { email: email };
          }),
          addresses: this.addresses
        })
        .then(response => {
          if (response.status === 200 || response.status === 201) {
            Swal.fire("Good job!", "You added a contact!", "success");
          }
          console.log(response.data);
          if (this.onSave) {
            console.log("onSave exists");
            this.onSave();
          }
        })
        .catch(error => {
          this.errored = true;
          Swal.fire({
            icon: "error",
            title: "Oooops....",
            text: error.response.data.message
          });
        })
        .then(() => {
          this.$bvModal.hide('add-modal');
        });
    },
    onReset(evt) {
      evt.preventDefault();

      this.form.email = "";
      this.form.name = "";
      this.form.surname = "";
      this.form.number = "";
      this.form.company = "";
      this.form.date = "";
      this.form.email = "";
      this.form.street = "";
      this.form.city = "";
      this.phones.length = 0;
      this.emails.length = 0;
      this.addresses.length = 0;

      // Trick to reset/clear native browser form validation state
      this.show = false;
      this.$nextTick(() => {
        this.show = true;
      });
    },
    focusElement() {
      this.$refs.focusThis.focus();
    },
    phoneFormat() {
      if (this.phones.includes(this.form.number) && this.form.number.length > 0) {
        this.phoneError = "This phone number is already added.";
        return false;
      }
      if (this.form.number.length !== 8 && this.form.number.length > 0) {
        this.phoneError = "Wrong phone format.";
        return false;
      }
      return true;
    },
    emailFormat() {
      if (this.emails.includes(this.form.email) && this.form.email.length > 0) {
        this.emailError = "This email address is already added.";
        return false;
      }
      if (!this.form.email.includes("@") && this.form.email.length > 0) {
        this.emailError = "Wrong email format.";
        return false;
      }
      return true;
    },
    addressFormat() {
      var parsedElement = JSON.parse(JSON.stringify(this.addresses))
      if (parsedElement.length > 0 && (this.form.city.length > 0 && this.form.street.length > 0)) {
        if (parsedElement.some(el => el.city === this.form.city) && parsedElement.some(el => el.street === this.form.street)) {
          this.addressError = "This address is already added."
          return false;
        }
      }
      if ((!this.form.city && !this.form.street)) {
        this.addressError = "";
        return false;
      }
      if ((!this.form.city || !this.form.street)) {
        this.addressError = "Please, enter both: city and street."
        return false;
      }
      return true;
    }
  }
};
</script>

<style scoped>
.formBtn {
  margin: 10px;
}
.correct {
  border: green solid 2px;
}
.error {
  border: red solid 2px;
}
.insert {
  margin-top: 10px;
}
.required:after {
  content: "*";
  color: red;
}
input {
  color: black;
}
</style>