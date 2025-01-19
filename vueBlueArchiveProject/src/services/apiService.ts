import axios from "axios";

const apiClient = axios.create({
  baseURL: "http://localhost:5092/api/characters",
  headers: {
    "Content-Type": "application/json",
  },
});

export async function getAllCharacters() {
  const response = await apiClient.get("/");
  return response.data;
}

export async function getCharacterByName(name: string) {
  const response = await apiClient.get(`/by-name?name=${name}`);
  return response.data;
}

export async function getCharactersBySchool(school: string) {
  const response = await apiClient.get(`/by-school?school=${school}`);
  return response.data;
}

export async function getStudents() {
  const response = await apiClient.get("/students");
  return response.data;
}

export async function getRandomCharacter() {
  const response = await apiClient.get("/random");
  return response.data;
}
