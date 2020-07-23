<template>
  <div class="vault">
    <div class="row">
      <div class="col">
        <h4>{{vault.name}}</h4>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "vault",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getActiveVault", this.$route.params.vaultId);
    this.$store.dispatch("getVaultKeeps");
  },
  computed: {
    vault() {
      return this.$store.state.activeVault;
    }
  },
  methods: {},
  components: {}
};
</script>


<style scoped>
</style>