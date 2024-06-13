namespace Places
{
    public class Place
    {
        public string? ID { get; set; }
        public string? Woonplaatsen { get; set; }
        public string? Woonplaatscode_1 { get; set; }
        public string? Naam_2 { get; set; }
        public string? Code_3 { get; set; }
        public string? Naam_4 { get; set; }
        public string? Code_5 { get; set; }
        public string? Naam_6 { get; set; }
        public string? Code_7 { get; set; }

        public void RemoveSpaces()
        {
            Woonplaatsen = Woonplaatsen?.Trim();
            ID = ID?.Trim();
            Naam_2 = Naam_2?.Trim();
            Woonplaatscode_1 = Woonplaatscode_1?.Trim();
            Code_3 = Code_3?.Trim();
            Naam_4 = Naam_4?.Trim();
            Code_5 = Code_5?.Trim();
            Naam_6 = Naam_6?.Trim();
            Code_7 = Code_7?.Trim();  
        }
    }
}
