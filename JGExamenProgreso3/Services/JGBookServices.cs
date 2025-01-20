using JGExamenProgreso3.Properties.Model;
using System.Net.Http.Json;

public class JGBookService
{
    private readonly HttpClient _httpClient;

    public JGBookService()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://www.googleapis.com/books/v1/")
        };
    }

    public async Task<List<JGBookModel>> SearchBooksAsync(string query)
    {
        var response = await _httpClient.GetFromJsonAsync<GoogleBooksResponse>($"volumes?q={query}");
        return response?.Items?.Select(item => new JGBookModel
        {
            Title = item.VolumeInfo.Title,
            Authors = item.VolumeInfo.Authors != null ? string.Join(", ", item.VolumeInfo.Authors) : "Unknown Author",
            Thumbnail = item.VolumeInfo.ImageLinks?.Thumbnail
        }).ToList() ?? new List<JGBookModel>();
    }
}
