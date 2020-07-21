<template>
  <div class="keepComponent col-3">
    <div class="card my-1 shadow">
      <img class="card-img-top" :src="keepProp.img" />
      <div class="card-body">
        <h4 class="card-title">{{keepProp.name}}</h4>
        <p class="card-text">{{keepProp.description}}</p>
        <div class="row">
          <div class="col-6">
            <i @click="addToVault" class="fa fa-plus" aria-hidden="true"></i>
          </div>
          <div class="col-6 justify-content end">
            <button v-if="keepProp.id == $auth.user.sub" class="btn btn-outline-danger">delete</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "keepComponent",
  data() {
    return {};
  },
  computed: {},
  methods: {},
  components: {},
  props: ["keepProp"]
};
</script>


<style scoped>
</style>