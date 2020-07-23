<template>
  <tr>
    <td>
      <router-link :to="{name: 'vault', params: {vaultId: vaultProp.id}}">{{vaultProp.name}}</router-link>
    </td>
    <td>{{vaultProp.description}}</td>
    <td>
      <button @click="deleteVault(vaultProp.id)" class="btn btn-outline-danger">-</button>
    </td>
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
  methods: {
    deleteVault() {
      this.$store.dispatch("deleteVault", this.vaultProp.id);
    }
  },
  components: {},
  props: ["vaultProp"]
};
// <i @click="deleteVault(vaultprop.id)" class="fa fa-minus-square" aria-hidden="true"></i>
</script>


<style scoped>
</style>