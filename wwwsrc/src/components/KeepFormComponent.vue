<template>
  <div class="keep-form">
    <button @click="addForm = !addForm">Add Keep</button>
    <form v-show="addForm" @submit.prevent="createKeep">
      <div class="form-group">
        <label for="name">Name</label>
        <input
          type="text"
          name="name"
          class="form-control"
          placeholder="Enter name or title...."
          v-model="newKeep.name"
        />
      </div>
      <div class="form-group">
        <label for="description">Description</label>
        <input
          type="text"
          name="description"
          class="form-control"
          placeholder="Enter description...."
          v-model="newKeep.description"
        />
      </div>
      <div class="form-group">
        <label for="imgUrl">imgUrl</label>
        <input
          type="text"
          name="imgUrl"
          class="form-control"
          placeholder="Enter imgUrl...."
          v-model="newKeep.img"
        />
      </div>
      <button type="submit" class="btn btn-primary">Add</button>
    </form>
  </div>
</template>


<script>
export default {
  name: "KeepForm",

  data() {
    return {
      addForm: false,
      newKeep: {},
    };
  },
  computed: {},
  methods: {
    createKeep() {
      this.$store.dispatch("createKeep", this.newKeep);
    },
  },
  components: {},
};
// v-model="newCar.model"
</script>


<style scoped>
</style>