using PlaatsNamen;
using Places;
using System.Text.Json;

var jsonString = File.ReadAllText("plaatsnamen.json");
var data = JsonSerializer.Deserialize<AllPlaces>(jsonString);

if (data != null && data.PlacesDictionary != null)
{
    using var database = new PlaceDatabase("geo");
    database.Clear();

    foreach (var (id, place) in data.PlacesDictionary)
    {
        Console.WriteLine($"{id} {place.Naam_2}");

        place.RemoveSpaces();
        database.Write(place);
    }
}