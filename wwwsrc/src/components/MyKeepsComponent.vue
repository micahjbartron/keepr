<template>
  <div class="myKeepComponent col-3">
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
          <div
            v-if="$auth.user && keepProp.userId == $auth.user.sub"
            class="col-6 justify-content end"
          >
            <button @click="deleteKeep(keepProp.id)" class="btn btn-outline-danger">delete</button>
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
  name: "MyKeepsComponent",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getMyKeeps");
  },
  computed: {},
  methods: {
    deleteKeep() {
      this.$store.dispatch("deleteKeep", this.keepProp.id);
    },
  },
  components: {},
  props: ["keepProp"],
};
</script>


<style scoped>
</style>