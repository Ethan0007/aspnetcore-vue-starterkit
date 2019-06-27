<template>
  <form>
    <div class="form-group">
      <input type="date" v-model="dateTimeVal" id="formDate" class="form-control">
    </div>
    <div class="form-group"> 
        <small  id="errorHelp" class="form-text text-danger">{{dateTimeValErrors}}</small>
    </div>
    <div class="form-group">
      <button type="button"  @click="validate" class="btn btn-primary">Validate</button>
    </div>
  </form>
</template>


<script>
export default {
    data(){
        return {
            dateTimeVal: null
        }
    },

    methods: {
        validate : async function() {
            this.$store.dispatch('dateTimeValidator/validateDateTime', {
                DateTime: this.dateTimeVal
            });
        }
    },
    
    computed: {
        dateTimeValErrors: function() {
            return this.$store.state.dateTimeValidator.dateTimeValErrors;
        }
    }
};
</script>
