<template>
  <div class="keep container-fluid">
    <div class="row">
      <div class="col-6">
        <img class="card-img-top" :src="keep.img" />
        <h5>Views:{{keep.views}}</h5>
        <h5>Vaulted:{{keep.Keeps}}</h5>
      </div>
      <div class="col-6">
        <h2>Name:{{keep.name}}</h2>
        <h2>Description:{{keep.description}}</h2>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "keep",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getActiveKeep", this.$rout.params.keepId);
  },
  computed: {
    keep() {
      return this.$store.state.activeKeep;
    }
  },
  methods: {},
  components: {}
};
</script>


<style scoped>
</style>