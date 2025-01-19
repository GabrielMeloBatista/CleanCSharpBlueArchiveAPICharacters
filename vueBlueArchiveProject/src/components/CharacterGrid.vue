<template>
  <v-container>
    <v-row>
      <v-col cols="12" class="d-flex justify-space-between">
        <v-text-field v-model="search"
                      label="Search by Name"
                      @input="onSearch"
                      clearable
                      outline
                      class="flex-grow-1 mr-4"></v-text-field>
        <v-btn color="primary" @click="fetchRandomCharacter" class="h-100">
          Random Character
        </v-btn>
      </v-col>

      <v-row class="pa-8 mb-2" 
             v-for="(character, index) in characters"
             :key="character.id || index"
             align="center"
             justify="center">
          <v-card width="480px" class="pa-2">
            <v-card-title>
              {{ character.name }}
            </v-card-title>
            <v-img :src="character.photoUrl || placeholderImage"
                   alt="Character Image"
                   class="mr-4 align-center"></v-img>
            <v-card-text>

              <p><strong>School:</strong> {{ character.school }}</p>
              <p><strong>Birthday:</strong> {{ character.birthday }}</p>
              <p><strong>Damage Type:</strong> {{ character.damageType }}</p>
            </v-card-text>
          </v-card>
      </v-row>

      <v-col cols="12" v-if="characters.length === 0 && !loading" class="text-center">
        <p>No characters found.</p>
      </v-col>


      <v-col cols="12" class="text-center" v-if="loading">
        <v-progress-circular indeterminate color="primary"></v-progress-circular>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
  import { getAllCharacters, getRandomCharacter } from "../services/apiService";

  export default {
    data() {
      return {
        characters: [],
        page: 1,
        itemsPerPage: 10,
        totalItems: 100,
        search: "",
        placeholderImage: "https://placehold.co/150",
        loading: false,
        noMoreData: false,
      };
    },
    methods: {
      async fetchCharacters() {
        if (this.loading || this.noMoreData) return;

        this.loading = true;
        try {
          const params = {
            page: this.page,
            pageSize: this.itemsPerPage,
            search: this.search,
          };
          const response = await getAllCharacters(params);
          const items = response || [];
          if (items.length > 0) {
            this.characters = [...this.characters, ...items];
            this.totalItems = response?.totalItems || 0;
            this.page++;
          } else {
            this.noMoreData = true;
          }
        } catch (error) {
          console.error("Error fetching characters:", error);
        } finally {
          this.loading = false;
        }
      },
      async fetchRandomCharacter() {
        this.loading = true;
        try {
          const randomCharacter = await getRandomCharacter();
          this.characters = [randomCharacter];
          this.noMoreData = true;
        } catch (error) {
          console.error("Error fetching random character:", error);
        } finally {
          this.loading = false;
        }
      },
      onSearch() {
        this.characters = [];
        this.page = 1;
        this.noMoreData = false;
        this.fetchCharacters();
      },
    },
    mounted() {
      this.fetchCharacters();
    },
  };
</script>
