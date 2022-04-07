using System.Text.Json;

namespace consolelinq;
public class PageComponent{
    public string Name {get; set;} = string.Empty;
    public string Type {get;set;} = string.Empty;
    public string Extension {get;set;} = string.Empty;
    public int SizeBytes {get;set;}

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}