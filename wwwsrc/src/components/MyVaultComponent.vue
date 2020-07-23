<template>
  <tr>
    <td>
      <router-link :to="{name: 'vault', params: {vaultId: vaultProp.id}}">{{vaultProp.name}}</router-link>
    </td>
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