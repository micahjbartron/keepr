<template>
  <div class="vault">
    <div class="row">
      <div class="col">
        <h4>{{vault.name}}</h4>
        <p>Description: {{vault.description}}</p>
        <VaultKeepsComponent v-for="keep in keeps" :key="keep.id" :keepProp="keep"></VaultKeepsComponent>
      </div>
    </div>
  </div>
</template>


<script>
import VaultKeepsComponent from "@/components/VaultKeepsComponent.vue";
export default {
  name: "vault",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getActiveVault", this.$route.params.vaultId);
    this.getKeeps();
    this.$store.dispatch("getKeeps", this.vault.id);
  },
  computed: {
    vault() {
      return this.$store.state.activeVault;
    },
    keeps() {
      return this.$store.state.vaultKeeps;
    }
  },
  methods: {
    getKeeps() {
      this.$store.dispatch("getVaultKeeps");
    }
  },
  components: {
    VaultKeepsComponent
  },
  props: ["keep"]
};
</script>


<style scoped>
</style>