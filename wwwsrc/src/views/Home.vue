<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col text-center">
        <keep-form />
      </div>
    </div>
    <div class="row">
      <keepComponent v-for="keep in keeps" :key="keep.id" :keepProp="keep"></keepComponent>
    </div>
  </div>
</template>

<script>
import KeepComponent from "../components/KeepComponent.vue";
import KeepForm from "../components/KeepFormComponent.vue";
export default {
  name: "home",
  components: {
    KeepComponent,
    KeepForm
  },
  mounted() {
    this.getKeeps();
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    getKeeps() {
      this.$store.dispatch("getKeeps");
    }
  }
};
</script>
