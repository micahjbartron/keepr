<template>
  <tr>
    <td>{{vaultProp.name}}</td>
    <td>{{vaultProp.description}}</td>
  </tr>
</template>


<script>
export default {
  name: "myVaults",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getMyVaults");
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