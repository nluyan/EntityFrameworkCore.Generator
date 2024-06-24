namespace EntityFrameworkCore.Generator.Options;
public class SearchApiOptions : ModelOptionsBase
{
    public SearchApiOptions(VariableDictionary variables, string prefix)
        : base(variables, AppendPrefix(prefix, "Search"))
    {
        Name = "{Entity.Name}SearchApi";
    }
}
