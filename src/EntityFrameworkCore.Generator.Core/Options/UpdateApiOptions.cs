namespace EntityFrameworkCore.Generator.Options;
public class UpdateApiOptions : ModelOptionsBase
{
    public UpdateApiOptions(VariableDictionary variables, string prefix)
        : base(variables, AppendPrefix(prefix, "Update"))
    {
        Name = "{Entity.Name}UpdateApi";
    }
}
