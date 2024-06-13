using PlaatsNamen;

Console.Write("Welke plaats zoek je?");
var searchPlace = Console.ReadLine();

if (!string.IsNullOrWhiteSpace(searchPlace))
{
    var placeDatabase = new PlaceDatabase("geo");
    foreach (var place in placeDatabase.Search(searchPlace))
    {
        Console.WriteLine(place.Naam_2);
    }
}