using Application.Services;
using Domain.Entities;
using System.Net.Http;
using System.Text.Json;

namespace WorkerServiceHost
{
    public class DataUpsertJob(IHttpClientFactory httpClientFactory)
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient();
        private readonly CharacterService _characterService;

        public async Task UpsertData()
        {
            var characters = await FetchCharactersFromApi();
            foreach (var character in characters)
            {
                await _characterService.UpsertCharacter(character);
            }
        }

        public async Task<IEnumerable<Character>> FetchCharactersFromApi()
        {
            var apiUrl = "https://api-blue-archive.vercel.app/api/characters";
            try
            {
                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonSerializer.Deserialize<ApiResponse>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (apiResponse?.Data == null || !apiResponse.Data.Any())
                {
                    Console.WriteLine("No data returned from the API.");
                    return Enumerable.Empty<Character>();
                }


                return apiResponse?.Data.Select(d => new Character
                {
                    Id = d.Id,
                    Name = d.Name,
                    School = d.School,
                    Birthday = d.Birthday,
                    PhotoUrl = d.PhotoUrl,
                    Image = d.Image,
                    ImageSchool = d.ImageSchool,
                    DamageType = d.DamageType
                }) ?? [];
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Deserialization error: {ex.Message}");
                return Enumerable.Empty<Character>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }

    public class ApiResponse
    {
        public string Message { get; set; }
        public int DataAllPage { get; set; }
        public List<ApiCharacter> Data { get; set; }
    }

    public class ApiCharacter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string School { get; set; }
        public string Birthday { get; set; }
        public string PhotoUrl { get; set; }
        public string? Image {  get; set; }
        public string ImageSchool { get; set; }
        public string DamageType { get; set; }
    }
}