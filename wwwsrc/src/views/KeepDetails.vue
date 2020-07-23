<template>
  <div class="keep container-fluid">
    <div class="row">
      <div class="col-6">
        <img class="card-img-top" :src="keep.img" />
        <p>Views: {{keep.views}}</p>
        <p>Vaulted: {{keep.keeps}}</p>
      </div>
      <div class="col-6">
        <div class="row">
          <div class="col">
            <h2>Name: {{keep.name}}</h2>
            <h2>Description: {{keep.description}}</h2>
            <button @click="addForm = true;" class="btn btn-primary">add to Vault</button>
            <form v-if="addForm" @submit.prevent="createVault">
              <div class="form-group">
                <label for="name">Vault Name</label>
                <input
                  type="text"
                  class="form-control"
                  id
                  placeholder="Vault Name..."
                  v-model="newVault.name"
                />
              </div>
              <div class="form-group">
                <label for="description">Vault Description</label>
                <input
                  type="text"
                  class="form-control"
                  id
                  placeholder="Vault Description..."
                  v-model="newVault.description"
                />
              </div>
              <div class="form-group">
                <div class="form-check">
                  <input class="form-check-input" type="checkbox" id="gridCheck" />
                  <label class="form-check-label" for="gridCheck">private?</label>
                </div>
              </div>
              <button type="submit" class="btn btn-primary">add</button>
            </form>
          </div>
        </div>
        <div class="col-6">
          <div class="row">
            <div class="col"></div>
            <div class="row">
              <div class="col">
                <div class="btn-group">
                  <button
                    type="button"
                    class="btn btn-secondary dropdown-toggle"
                    data-toggle="dropdown"
                    aria-haspopup="true"
                    aria-expanded="false"
                  >choose vault to add to</button>
                  <div class="dropdown-menu dropdown-menu-right">
                    <VaultComponent v-for="vault in vault" :key="vault.id" :vaultProp="vault"></VaultComponent>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import VaultComponent from "@/components/VaultListComponent.vue";
export default {
  name: "keep",
  data() {
    return {
      addForm: false,
      newVault: {}
    };
  },
  mounted() {
    this.$store.dispatch("getActiveKeep", this.$route.params.keepId);
    this.$store.dispatch("getVaults");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keep() {
      return this.$store.state.activeKeep;
    },
    vault() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    createVault() {
      this.$store.dispatch("createVault", this.newVault);
    }
    // addToVault() {
    //   event.stopPropagation();
    //   debugger;
    //   this.$store.dispatch("addVaultKeep", {
    //     keepId: this.keep.id,
    //     vaultId: this.vaultid
    //   });
    // }
  },
  components: {
    VaultComponent
  }
};
</script>


<style scoped>
</style>