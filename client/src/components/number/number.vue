<template>
    <form>
        <div class="form-group">
             <label class="formLabel"> </label>
             <input  type="text"
              v-model="numVal"
              class="form-control"
              id="fromText" 
              placeholder="Input Number" />
        </div>
        <div class="form-group">
            <small id="numHelp" class="form-text text-danger">{{numValErrors}}</small>
        </div>
        <div class="form-group">
            <button class="btn btn-primary" @click="validate">Valiate</button>
        </div>
    </form>
</template>


<script>
    export default {
        data() {
            return {
                numVal: null
            }
        },
        methods: {
            validate: async function() {
                this.$store.dispatch('numberValidator/validateNum', {
                    One: this.numVal
                });
            }
        },

        computed: {
            numValErrors:  function() {
                return this.$store.state.numberValidator.numberValErrors
            }
        }
    }    
</script>