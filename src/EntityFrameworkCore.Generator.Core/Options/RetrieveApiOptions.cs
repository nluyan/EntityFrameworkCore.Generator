namespace EntityFrameworkCore.Generator.Options;
public class RetrieveApiOptions : ModelOptionsBase
{
    public RetrieveApiOptions(VariableDictionary variables, string prefix)
        : base(variables, AppendPrefix(prefix, "Retrieve"))
    {
        Name = "{Entity.Name}RetrieveApi";
    }
}
