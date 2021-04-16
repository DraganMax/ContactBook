<template>
  <div>
    <b-button variant="primary" v-b-modal.modal-1 class="mt-0 mb-2">Add Contact</b-button>

    <b-modal id="modal-1" size="lg" hide-footer @shown="focusElement" title="Adding Contact">
      <div>
        <b-form @submit="onSubmit" @reset="onReset" v-if="show">
          <b-row>
            <b-col>
              <b-form-group id="input-group-1" label="Contact's Name:" label-for="input-1">
                <b-form-input
                  id="input-1"
                  ref="focusThis"
                  v-model="form.name"
                  required
                  placeholder="Enter name"
                ></b-form-input>
              </b-form-group>
            </b-col>
            <b-col>
              <b-form-group id="input-group-2" label="Contact's Surname:" label-for="input-2">
                <b-form-input
                  id="input-2"
                  v-model="form.surname"
                  required
                  placeholder="Enter surname"
                ></b-form-input>
              </b-form-group>
            </b-col>
          </b-row>

          <b-row>
            <b-col>
              <b-form-group id="input-group-3" label="Contact's Working Place:" label-for="input-3">
                <b-form-input id="input-3" v-model="form.company" placeholder="Enter company">
                </b-form-input>
              </b-form-group>
            </b-col>

            <b-col>
              <b-form-group id="input-group-4" label="Contact's Birthday:" label-for="input-4">
                <b-form-input id="input-4" v-model="form.date" type="date"></b-form-input>
              </b-form-group>
            </b-col>
          </b-row>

          <b-row>
            <b-col>
              <b-form-group id="input-group-5" label="Contact's Phone Number:" label-for="input-5">
                <b-form-text id="phone-help-block">
                  Phone number requires exactly 8 digits.</b-form-text>
                <b-form-input
                  :class="[phoneFormat() ? 'correct' : '']"
                  class="mb-0"
                  type="tel"
                  pattern="^2(\d){7}$"
                  id="input-5"
                  v-model="form.number"
                  placeholder="Enter phone number"
                ></b-form-input>
                <b-button
                  class="mx-0"
                  variant="success"
                  size="sm"
                  :disabled="!phoneFormat()"
                  @click="addPhone"
                >New Phone</b-button>
                <ul v-for="(phone, index) in phones" :key="index">
                  <li class="mx-0">
                    {{ phone }}
                    <b-button variant="outline-danger" size="sm" 
                    @click="deletePhone(index)">Delete</b-button>
                  </li>
                </ul>
              </b-form-group>
            </b-col>

            <b-col>
              <b-form-group id="input-group-6" label="Contact's Email Address:" label-for="input-6">
                <b-form-text
                  id="password-help-block"
                >Email requires '@' symbol. For example: email@gmail.com</b-form-text>
                <b-form-input
                  id="input-6"
                  v-model="form.email"
                  type="email"
                  placeholder="Enter email"
                  :class="[emailFormat() ? 'correct' : '']"
                ></b-form-input>
                <b-button
                  class="mx-0 mb-2"
                  :disabled="!emailFormat()"
                  variant="success"
                  size="sm"
                  @click="addEmail"
                >New Email</b-button>
                <ul v-for="(email, index) in emails" :key="index">
                  <li class="mx-0">
                    {{ email }}
                    <b-button variant="outline-danger" size="sm" 
                    @click="deleteEmail(index)">Delete</b-button>
                  </li>
                </ul>
              </b-form-group>
            </b-col>
          </b-row>
          <b-form-group id="input-group-7"
          label="Contact's Adress:" label-for="input-7">
            <b-row>
              <b-col>
                <b-form-input id="input-8" v-model="form.city" placeholder="Enter city"></b-form-input>
                <b-button
                  class="mx-0 mb-2"
                  variant="success"
                  size="sm"
                  :disabled="!adressFormat()"
                  @click="addAdress"
                >New Adress</b-button>
                <ul v-for="(adress, index) of adresses" :key="index">
                  <li class="mx-0">
                    {{ adress.city }} - {{ adress.street }} {{ adress.house }}
                    <b-button variant="outline-danger" size="sm" 
                    @click="deleteAdress(index)">Delete</b-button>
                  </li>
                </ul>
              </b-col>
              <b-col>
                <b-form-input id="input-9" v-model="form.street" 
                placeholder="Enter street"></b-form-input>
              </b-col>
              <b-col>
                <b-form-input id="input-10" v-model="form.house" 
                placeholder="Enter house number"></b-form-input>
              </b-col>
            </b-row>
          </b-form-group>

          <b-button class="formBtn" type="reset" variant="warning">Reset</b-button>
          <b-button class="formBtn" @click="$bvModal.hide('modal-1')">Cancel</b-button>
          <b-button class="formBtn" type="submit" variant="primary">Ok</b-button>
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
        street: "",
        house: ""
      },
      phones: [],
      emails: [],
      adresses: [],
      format: false,
      show: true,
      errored: false
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
      console.log(index);
      console.log(this.phones);
      this.phones.splice(index, 1);
    },
    addEmail: function() {
      if (this.form.email !== "" && this.form.email.includes("@")) {
        this.emails.push(this.form.email);
      }
      this.form.email = "";
    },
    deleteEmail: function(index) {
      console.log(index);
      console.log(this.emails);
      this.emails.splice(index, 1);
    },
    addAdress: function() {
      const { city, street, house } = this.form;
      if (city || street) {
        this.adresses.push({
          city: city,
          street: street,
          house: house
        });
        this.form.city = "";
        this.form.street = "";
        this.form.house = "";
      }
    },
    deleteAdress: function(index) {
      this.adresses.splice(index, 1);
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
          adresses: this.adresses
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
          console.log(error);
          this.errored = true;
          Swal.fire({
            icon: "error",
            title: "Oooops....",
            text: "Something went wrong!"
          });
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
      this.form.house = "";
      this.phones.length = 0;
      this.emails.length = 0;
      this.adresses.length = 0;

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
      if (this.form.number.length === 8) {
        return true;
      }
      return false;
    },
    emailFormat() {
      if (this.form.email.includes("@")) {
        return true;
      }
      return false;
    },
    adressFormat() {
      if (this.form.city || this.form.street) {
        return true;
      }
      return false;
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
</style>