using System.Text.Json;
using System.Text.Json.Serialization;
    public class Lista_civilizaciones
    {
        [JsonPropertyName("civilizations")]
        public List<Civilization> Civilizations { get; set; }
    }


