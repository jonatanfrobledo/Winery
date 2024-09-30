namespace Winery.Entities
{
    public class Wine
    {
        public int Id { get; set; }

        // El nombre del vino, requerido
        public string Name { get; set; } = string.Empty;

        // Variedad del vino (ej: Cabernet Sauvignon)
        public string Variety { get; set; } = string.Empty;

        // Año de cosecha, debe ser un valor válido
        public int Year { get; set; }

        // Región de origen (ej: Mendoza, La Rioja)
        public string Region { get; set; } = string.Empty;

        public int Stock { get; set; }

    }
}
