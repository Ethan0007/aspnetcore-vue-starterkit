<template>
    <form>
        <div class="form-group"> 
            <select v-model="boolVal" class="form-control">
                <option disabled value="" >Select</option>
                <option value="true">True</option>
                <option value="false">False</option>
                <option value="null">Text</option>
            </select>
            <small class="form-text text-danger">{{booleanError}}</small>
        </div>
        <div class="form-group"> 
            <button type="button" @click="validate" class="btn btn-primary">Validate</button>
        </div>
    </form>
</template>

<script>
export default {
    data(){
        return {
            boolVal: true
        }
    },

    methods: {
        validate: async function() {
            this.$store.dispatch('booleanValidator/validateBoolean', {
                IsTrue : this.boolVal
            });
        }
    },

    computed: {
        booleanError: function(){ 
            return this.$store.state.booleanValidator.booleanValErrors
        }
    }
}
</script>
