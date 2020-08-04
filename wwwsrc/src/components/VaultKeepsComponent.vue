<template>
  <div class="VaultKeepsComponent">
    <div class="card my-1 shadow">
      <router-link :to="{name: 'keep', params: {keepId: keepProp.id}}">
        <img class="card-img-top" :src="keepProp.img" />
      </router-link>
      <div class="card-body">
        <h4 class="card-title">{{keepProp.name}}</h4>
        <p class="card-text">{{keepProp.description}}</p>
        <div class="row">
          <div class="col-6">
            <router-link :to="{name: 'keep', params: {keepId: keepProp.id}}">
              <i class="fa fa-plus" aria-hidden="true"></i>
            </router-link>
          </div>
          <div>
            <div
              v-if="$auth.user && keepProp.userId == $auth.user.sub"
              class="col-6 justify-content end"
            >
              <button @click="deleteKeep(keepProp.id)" class="btn btn-outline-danger">delete</button>
            </div>
            <button @click="remove(keepProp.vaultKeepId)" class="btn btn-outline-danger">Remove</button>
          </div>
        </div>
        <div class="row">
          <div class="col">Vaulted: {{keepProp.keeps}}</div>
        </div>
        <div class="row">
          <div class="col">views: {{keepProp.views}}</div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "VaultKeepsComponent",
  data() {
    return {
      vaultKeepId: "",
    };
  },
  mounted() {
    // this.$store.dispatch("getVaultKeeps");
    this.getVaultKeeps();
  },
  computed: {},
  methods: {
    getVaultKeeps() {
      this.$store.dispatch("getVaultKeeps", this.$route.params.vaultId);
    },
    deleteKeep() {
      this.$store.dispatch("deleteKeep", this.keepProp.id);
    },
    remove() {
      this.$store.dispatch("removeFromVault", {
        vaultKeepId: this.keepProp.vaultKeepId,
        vaultId: this.$route.params.vaultId,
      });
    },
  },
  components: {},
  props: ["keepProp"],
};
</script>


<style scoped>
</style>