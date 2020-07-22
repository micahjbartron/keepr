<template>
  <div class="dashboard">
    <h1>WELCOME TO THE DASHBOARD</h1>
    public {{ publicKeep }} user {{ userKeeps }}
  </div>
</template>

<script>
export default {
  mounted() {
    this.$store.dispatch("getMyKeeps");
  },
  computed: {}
};
</script>

<style></style>
