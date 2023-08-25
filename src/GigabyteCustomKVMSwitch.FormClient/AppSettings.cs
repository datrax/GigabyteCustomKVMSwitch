using System.Text.Json;
using System.Text.Json.Serialization;

namespace GigabyteCustomKVMSwitch_FormClient;

public class AppSettings
{
    public List<Keys> SpecialKeys { get; set; } = new List<Keys>();


    public Keys AdditionalKey { get; set; }

    private const string configFilePath = "config.json";


    [JsonIgnore]
    public Keys ModifierKeys => SpecialKeys.Any() ? SpecialKeys.Aggregate((first, second) => first | second) : Keys.None;

    public void SaveToFile()
    {
        File.WriteAllText(configFilePath, JsonSerializer.Serialize(this));
    }

    public static AppSettings ReadFromFile()
    {
        if (!File.Exists(configFilePath))
        {
            var defaultAppSettings = new AppSettings()
            {
                AdditionalKey = Keys.Back,
                SpecialKeys = new List<Keys> { Keys.Control, Keys.Alt }
            };
            File.WriteAllText(configFilePath, JsonSerializer.Serialize(defaultAppSettings));
        }
        return JsonSerializer.Deserialize<AppSettings>(File.ReadAllText(configFilePath))!;
    }
}