namespace EntityFrameworkCore.Generator.Options;

/// <summary>
/// Update model options
/// </summary>
/// <seealso cref="ModelOptionsBase" />
public class SearchModelOptions : ModelOptionsBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateModelOptions"/> class.
    /// </summary>
    public SearchModelOptions(VariableDictionary variables, string prefix)
        : base(variables, AppendPrefix(prefix, "Search"))
    {
        Name = "{Entity.Name}SearchModel";
    }
}
