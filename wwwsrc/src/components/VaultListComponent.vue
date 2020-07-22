<template>
  <option class="vault">{{vaultProp.name}}</option>
</template>


<script>
export default {
  name: "vault",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getVaults");
  },
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {},
  components: {},
  props: ["vaultProp"]
};
</script>


<style scoped>
</style>