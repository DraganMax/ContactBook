<template>
<div>
    
    <b-modal id="modal-2" size="lg" hide-footer @shown="focusElement" title="Contact Editing">
        <b-form @submit="onSubmit" @reset="onReset">
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
                <b-form-input id="input-3" v-model="form.company" placeholder="Enter company"></b-form-input>
              </b-form-group>
            </b-col>

            <b-col>
              <b-form-group id="input-group-4" label="Contact's Birthday:" label-for="input-4">
                <b-form-input id="input-4" v-model="form.date" type="date">
                </b-form-input>
              </b-form-group>
            </b-col>
          </b-row>

          <b-row>
            <b-col>
              <b-form-group id="input-group-5" label="Contact's Phone Number:" label-for="input-5">
                <b-form-input id="input-5" v-model="form.number" placeholder="Enter phone number"></b-form-input>
              </b-form-group>
            </b-col>

            <b-col>
              <b-form-group id="input-group-6" label="Contact's Email Address:" label-for="input-6">
                <b-form-input
                  id="input-6"
                  v-model="form.email"
                  type="email"
                  placeholder="Enter email"
                ></b-form-input>
              </b-form-group>
            </b-col>
          </b-row>
          <b-form-group id="input-group-7" label="Contact's Adress:" label-for="input-7">
            <b-row>
              <b-col>
                <b-form-input id="input-8" v-model="form.city" placeholder="Enter city"></b-form-input>
              </b-col>
              <b-col>
                <b-form-input id="input-9" v-model="form.street" placeholder="Enter street"></b-form-input>
              </b-col>
              <b-col>
                <b-form-input id="input-10" v-model="form.house" placeholder="Enter house number"></b-form-input>
              </b-col>
            </b-row>
          </b-form-group>

          <b-button type="reset" variant="warning">Reset</b-button>
          <b-button @click="$bvModal.hide('modal-2')">Cancel</b-button>
          <b-button type="submit" variant="primary">Ok</b-button>
        </b-form>

    </b-modal>
          </div>
</template>

<script>
import "bootstrap/dist/css/bootstrap.css";
import axios from 'axios'
import Swal from 'sweetalert2'

export default {
  components: {
  },
  props: {
      id: Number
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
      options: {
        format: "DD/MM/YYYY",
        useCurrent: false
      },
      show: true,
      errored: false
    };
  },
  methods: {
    onSubmit() {
      axios.put(`api/contacts/${this.id}`, {
        name: this.form.name,
        surname: this.form.surname,
        company: this.form.company,
        birthday: this.form.date,
        phones: [{
          number: this.form.number
        }],
        emails: [{
          email: this.form.email
        }],
        adresses: [{
          city: this.form.city,
          street: this.form.street,
          house: this.form.house
        }]
      })
      .then(response => {
        if(response.status === 200 || response.status === 201) {
          Swal.fire(
          'Congratulations!',
          'You updated a contact!',
          'success'
          )
        }
        console.log(response.data)
      })
      .catch(error => {
        console.log(error)
        this.errored = true
        Swal.fire({
          icon: 'error',
          title: 'Oooops....',
          text: 'Something went wrong!'
        })
      })
      
      },
    onReset(evt) {
      evt.preventDefault();

      this.form.email = "";
      this.form.name = "";
      this.form.surname = "";
      this.form.number = "";
      this.form.company = "";
      this.form.date = new Date();
      this.form.email = "";
      this.form.street = "";
      this.form.city = "";
      this.form.house = "";

      // Trick to reset/clear native browser form validation state
      this.show = false;
      this.$nextTick(() => {
        this.show = true;
      });
    },
    focusElement() {
      this.$refs.focusThis.focus()
    }
  }
};
</script>

<style scoped>
.btn {
  margin: 10px;
  position: relative;
}
</style>