<template>
  <div>
    <div class="form-group">
      <input
        type="text"
        class="form-control"
        id="fname"
        v-model="firstName"
        aria-describedby="firstNameHelp"
        :placeholder="!hasMaxMin ? 'Enter Firstname' : 'Enter Firstname with (Max and Min)'"
      >
      <small id="fnameHelp" class="form-text text-danger">{{stringValErrors.fnameError}}</small>
    </div>
    <div class="form-group">
      <input
        type="text"
        v-model="lastName"
        class="form-control"
        id="lname"
        aria-describedby="lastNameHelp"
        :placeholder="!hasMaxMin ? 'Enter Lastname' : 'Enter Lastname with (Max and Min)'"
      >
      <small id="fnameHelp" class="form-text text-danger">{{stringValErrors.lnameError}}</small>
    </div>
    <button type="button" class="btn btn-primary" @click="validate">Validate</button>
  </div>
</template>


<script>
export default {
  props: ["hasMaxMin"],
  data() {
    return {
      firstName: null,
      lastName: null,
      placeHolder: "Enter Firstname"
    };
  },

  methods: {
    validate: async function() {
      this.$store.dispatch("stringValidator/validateString", {
        FirstName: this.firstName,
        LastName: this.lastName
      });
    }
  },

  computed: {
    stringValErrors: function() {
      return this.$store.state.stringValidator.stringValErrors;
    }
  }
};
</script>
