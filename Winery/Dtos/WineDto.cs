namespace Winery.Dtos
{
    public class WineDto
    {
        public string Name { get; set; } = string.Empty;
        public string Variety { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Region { get; set; } = string.Empty;
        public int Stock { get; set; }
    }
}
