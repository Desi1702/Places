using PlaatsNamen;
using Places;

namespace PlaceApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Search_Clicked(object sender, EventArgs e)
        {
            string searchQuery = PlaceNameEntry.Text; 
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                var placeDatabase = new PlaceDatabase("geo"); 
                List<Place> searchResults = placeDatabase.Search(searchQuery); 
                DisplaySearchResults(searchResults); 
            }
        }

        private void DisplaySearchResults(List<Place> searchResults)
        {
            
            PlacesTableView.Root.Clear();
            
            foreach (var result in searchResults)
            {
                PlacesTableView.Root.Add(new TableSection
                {
                    new TextCell { Text = result.Naam_2 }
                });
            }
            
        }
    }
}
