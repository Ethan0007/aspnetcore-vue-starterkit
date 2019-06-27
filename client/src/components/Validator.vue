<template>
  <div class="container">
    <div class="dropdown">
      <button
        class="btn btn-secondary dropdown-toggle"
        type="button"
        id="dropdownMenuButton"
        data-toggle="dropdown"
        aria-haspopup="true"
        aria-expanded="false"
      >Select Validator</button>
      <div
        @click="changeValidator($event)"
        class="dropdown-menu"
        aria-labelledby="dropdownMenuButton"
      >
        <a class="dropdown-item" data-value="1" href="#">String</a>
        <a class="dropdown-item" data-value="2" href="#">String(with max and min)</a>
        <a class="dropdown-item" data-value="3" href="#">Number</a>
        <a class="dropdown-item" data-value="4" href="#">Bool</a>
        <a class="dropdown-item" data-value="5" href="#">DateTime</a>
        <a class="dropdown-item" data-value="6" href="#">Object</a>
      </div>
    </div>

    <div class="col" style="margin-top:25px">
      <!-- String validator -->
      <StringVal :hasMaxMin="hasMaxMin" v-if="selectedType == 1 || selectedType == 2"/>
      <!-- Number validator -->
      <NumberVal v-if="selectedType == 3"/>
      <!-- Bool validator -->
      <BoolVal v-if="selectedType == 4"/>
      <!-- DateTime validator -->
      <DateTimeVal v-if="selectedType == 5"/>
    </div>
  </div>
</template>

<script>
import StringVal from "./string/string";
import NumberVal from "./number/number";
import BoolVal from "./boolean/boolean";
import DateTimeVal from "./dateTime/dateTime";

export default {
  name: "HelloWorld",
  data() {
    return {
      hasMaxMin: false,
      selectedType: 0
    };
  },
  methods: {
    changeValidator: async function(e) {
      this.selectedType = e.target.dataset.value;
      this.hasMaxMin = this.selectedType == 2 ? true : false;
    }
  },
  components: {
    StringVal,
    NumberVal,
    BoolVal,
    DateTimeVal
  }
};
</script>


<style>
</style>

 