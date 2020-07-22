<template>
  <div class="keep container-fluid">
    <div class="row">
      <div class="col-6">
        <img class="card-img-top" :src="keep.img" />
        <p>Views: {{keep.views}}</p>
        <p>Vaulted: {{keep.Keeps}}</p>
      </div>
      <div class="col-6">
        <h2>Name: {{keep.name}}</h2>
        <h2>Description: {{keep.description}}</h2>
        <button @click="addForm = true;" class="btn btn-primary">add to Vault</button>
        <form v-if="addForm">
          <div class="form-group">
            <label for="name">Vault Name</label>
            <input type="text" class="form-control" id placeholder="Vault Name..." />
          </div>
          <div class="form-group">
            <label for="description">Vault Description</label>
            <input type="text" class="form-control" id placeholder="Vault Description..." />
          </div>
          <div class="form-row">
            <div class="form-group col-md-4">
              <label for="vaults">Vaults</label>
              <select id class="form-control">
                <option selected>Choose...</option>
                <VaultComponent v-for="vault in vault" :key="vault.id" :vaultProp="vault"></VaultComponent>
              </select>
            </div>
          </div>
          <div class="form-group">
            <div class="form-check">
              <input class="form-check-input" type="checkbox" id="gridCheck" />
              <label class="form-check-label" for="gridCheck">private?</label>
            </div>
            <button type="submit" class="btn btn-primary">add</button>
            <p>{{vault.name}}</p>
          </div>
        </form>
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
      addForm: false
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
  methods: {},
  components: {
    VaultComponent
  }
};
</script>


<style scoped>
</style>