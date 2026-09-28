using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace ProjectTracker;

public class Config
{
    public static Config Instance { get; private set; } = new Config();
    public WindowConfig Window { get; set; } = new();
    
    public class WindowConfig
    {
        public int Height { get; set; } = 300;
        public int Width { get; set; } = 200;
        public int MarginTop { get; set; } = 0;
        public int MarginLeft { get; set; } = 0;
    }

    public static void Load()
    {
        const string path = "config.json";
        
        if (File.Exists(path)) Instance = JsonSerializer.Deserialize<Config>(File.ReadAllText(path)) ?? new Config();
            
        File.WriteAllText(path, JsonSerializer.Serialize(Instance, new JsonSerializerOptions { WriteIndented = true }));

    }
}