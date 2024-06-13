using System.Text.Json.Serialization;

namespace Places
{
    public class AllPlaces
    {
        [JsonPropertyName("value")]
        public Dictionary<string, Place>? PlacesDictionary { get; set; }
    }
}
