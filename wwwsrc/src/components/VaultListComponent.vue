<template>
  <button @click="addToVault(vaultProp.id)" class="dropdown-item" type="button">{{vaultProp.name}}</button>
</template>


<script>
export default {
  name: "vault",
  data() {
    return {};
  },
  mounted() {
    // this.$store.dispatch("getMyVaults");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keep() {
      return this.$store.state.activeKeep;
    },
  },
  methods: {
    addToVault() {
      event.stopPropagation();

      this.$store.dispatch("addVaultKeep", {
        keepId: this.$store.state.activeKeep.id,
        vaultId: this.vaultProp.id,
      });
    },
  },
  components: {},
  props: ["vaultProp"],
};
// <option class="vault">{{vaultProp.name}}</option>
</script>


<style scoped>
</style>