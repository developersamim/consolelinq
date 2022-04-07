namespace consolelinq;

public class Flatten{
    private readonly Func<string> _inputProvider;
    private readonly Action<string> _outputProvider;
    private IEnumerable<WebPage> _webPageList;
    public readonly Dictionary<string, Action> flattenType;

    public Flatten(Func<string> inputProvider, Action<string> outputProvider){
        _inputProvider = inputProvider;
        _outputProvider = outputProvider;
        flattenType = new Dictionary<string, Action>
        {
            { "listAllPageComponent",  ExecuteListAllPageComponent},
            { "listDistinctExtension", ExecuteListDistinctExtension},
            { "listIndexWithComponentName", ExecuteListIndexWithComponentName},
            { "listPageNameWithComponentName", ExecuteListPageNameWithComponentName},
            { "listPageNameWithComponentNameAnotherWay", ExecuteListPageNameWithComponentNameAnotherWay},
            { "listPageNameWithIndexAndComponentName", ExecuteListPageNameWithIndexAndComponentName}
        };
        SetWebPageList();
    }

    public void ExecuteListAllPageComponent(){
        var result = _webPageList.SelectMany(wp => wp.PageComponents).ToList();
        foreach(var item in result){
            System.Console.WriteLine(item.ToString());
        }
    }

    public void ExecuteListDistinctExtension(){
        var result = _webPageList.SelectMany(wp => wp.PageComponents.Select(p => new { Extension = p.Extension })).Distinct().OrderBy(x => x.Extension);
        foreach(var item in result){
            System.Console.WriteLine(item.Extension);
        }
    }

    public void ExecuteListIndexWithComponentName(){
        var result = _webPageList.SelectMany((wp, index) => wp.PageComponents.Select(p => new { PName = p.Name, Position = index}));
        foreach(var item in result){
            System.Console.Write($"Component Name: {item.PName}, ");
            System.Console.WriteLine($"Position: {item.Position}");
        }
    }

    public void ExecuteListPageNameWithComponentName(){
        var result = _webPageList.SelectMany(wp => wp.PageComponents.Select(p => new {PName = wp.Name, CName = p.Name}));
        foreach(var item in result){
            System.Console.Write($"Webpage Name: {item.PName}");
            System.Console.WriteLine($"Component Name: {item.CName}");
        }
    }

    public void ExecuteListPageNameWithComponentNameAnotherWay(){
        var result = _webPageList.SelectMany(wp => wp.PageComponents, (w, c) => new { WName = w.Name, CName = c.Name});
        foreach(var item in result){
            System.Console.Write($"Webpage Name: {item.WName}");
            System.Console.WriteLine($"Component Name: {item.CName}");
        }
    }

    public void ExecuteListPageNameWithIndexAndComponentName(){
        var result = _webPageList.SelectMany((w, index) => w.PageComponents.Select(p => new {CName = w.Name, Position = index}), (wp, cp) => new { WName = wp.Name, Position = cp.Position, CName = cp.CName});
        foreach(var item in result){
            System.Console.Write($"Webpage Name: {item.WName}, ");
            System.Console.Write($"Position: {item.Position}, ");
            System.Console.WriteLine($"Component Name: {item.CName}");
        }
    }

    public void SetWebPageList(){
        _webPageList = new List<WebPage>()
            {
                new WebPage()
                {
                    Name = "www.greatsite.com", PageComponents = new List<PageComponent>() {
                        new PageComponent() { Name = "home.html", Type = "html", Extension = "html", SizeBytes = 35623},
                        new PageComponent() { Name = "datatables.js", Type = "script", Extension = "js", SizeBytes = 2345},
                        new PageComponent() { Name = "nicepic.img", Type = "image", Extension = "img", SizeBytes = 24140},
                        new PageComponent() { Name = "favicon.ico", Type = "image", Extension = "ico", SizeBytes = 64152}}
                },
                new WebPage()
                {
                    Name = "www.awesomeness.com", PageComponents = new List<PageComponent>() {
                        new PageComponent() { Name = "home.html", Type = "html", Extension = "html", SizeBytes = 35623},
                        new PageComponent() { Name = "myscript.ts", Type = "script", Extension = "ts", SizeBytes = 86124},
                        new PageComponent() { Name = "daily.img", Type = "image", Extension = "img", SizeBytes = 52667},
                        new PageComponent() { Name = "selfie.png", Type = "image", Extension = "png", SizeBytes = 22922},
                        new PageComponent() { Name = "mybeautifulface.png", Type = "image", Extension = "png", SizeBytes = 78416},
                        new PageComponent() { Name = "hello.img", Type = "image", Extension = "img", SizeBytes = 65046}}
                },
                new WebPage()
                {
                    Name = "www.boring.com", PageComponents = new List<PageComponent>() {
                        new PageComponent() { Name = "datatables.css", Type = "stylesheet", Extension = "css", SizeBytes = 27470},
                        new PageComponent() { Name = "combined.css", Type = "stylesheet", Extension = "css", SizeBytes = 24627},
                        new PageComponent() { Name = "externallink.html", Type = "html", Extension = "html", SizeBytes = 72639},
                        new PageComponent() { Name = "googleads.html", Type = "html", Extension = "html", SizeBytes = 15873},
                        new PageComponent() { Name = "nicepic.img", Type = "image", Extension = "img", SizeBytes = 24140}}
                }
            };

    }
}