using Newtonsoft.Json;

public class AstronomyPictureOfTheDay
{
    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("explanation")]
    public string Explanation { get; set; }
}
