namespace AocDay5;

public class PrintQueue
{
    public List<PageOrderingRule> PageOrderingRules { get; set; } = [];
    public List<List<int>> PagesToProduce { get; set; } = [];

    public List<List<int>> ValidPagesToProduce { get; set; } = [];

    public bool IsValid(List<int> pagesToProduce)
    {
        var pageIndex = pagesToProduce
            .Select((page, index) => new { page, index })
            .ToDictionary(x => x.page, x => x.index);
        
        foreach (var rule in PageOrderingRules)
        {
            if (pageIndex.TryGetValue(rule.PageX, out var indexX) &&
                pageIndex.TryGetValue(rule.PageY, out var indexY))
            {
                if (indexX >= indexY)
                {
                    return false;
                }
            }
        }
        
        return true;
    }
    
    public List<int> OrderPages(List<int> pagesToProduce)
    {
        var orderedPages = pagesToProduce.ToList();
        orderedPages.Sort((x, y) =>
        {
            foreach (var rule in PageOrderingRules)
            {
                if (rule.PageX == x && rule.PageY == y)
                {
                    return -1;
                }
                if (rule.PageX == y && rule.PageY == x)
                {
                    return 1;
                }
            }
            return 0;
        });
        return orderedPages;
    }
}

public record PageOrderingRule(int PageX, int PageY)
{
}