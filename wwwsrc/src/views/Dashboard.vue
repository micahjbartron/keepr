<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col-9">
        <h1>WELCOME TO THE DASHBOARD</h1>
      </div>
      <div class="col-3"></div>
    </div>
    <div class="row orderContents">
      <div class="col">
        <table class="table">
          <thead>
            <tr>
              <th scope="col">Vault Name</th>
              <th scope="col">Vault Description</th>
            </tr>
          </thead>
          <tbody>
            <MyVaultComponent v-for="vault in vaults" :key="vault.id" :vaultProp="vault"></MyVaultComponent>
          </tbody>
        </table>
      </div>
    </div>
    <div class="row">
      <MyKeepsComponent v-for="keep in keeps" :key="keep.id" :keepProp="keep"></MyKeepsComponent>
    </div>
  </div>
</template>

<script>
import MyKeepsComponent from "@/components/MyKeepsComponent.vue";
import MyVaultComponent from "@/components/MyVaultComponent.vue";
export default {
  name: "dashboard",
  mounted() {
    this.$store.dispatch("getMyKeeps");
    this.$store.dispatch("getMyVaults");
  },
  name: "dashboard",
  components: {
    MyVaultComponent,
    MyKeepsComponent
  },
  computed: {
    vaults() {
      return this.$store.state.myVaults;
    },
    keeps() {
      return this.$store.state.myKeeps;
    }
  },
  props: ["keepProp", "vaultProp"]
};
</script>

<style scoped>
.orderContents {
  max-height: 40vh;
  overflow-y: scroll;
  overflow-x: hidden;
}
</style>
