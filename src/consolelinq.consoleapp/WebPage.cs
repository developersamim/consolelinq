using System.Text.Json;

namespace consolelinq;

public class WebPage{
    public List<PageComponent> PageComponents {get; set;}

    public string Name {get;set;} = string.Empty;

    public WebPage(List<PageComponent> PageComponents){
        this.PageComponents = PageComponents;
    }

    public WebPage(){}
}

