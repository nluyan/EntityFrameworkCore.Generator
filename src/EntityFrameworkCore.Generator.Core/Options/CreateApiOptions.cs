namespace EntityFrameworkCore.Generator.Options;
public class CreateApiOptions : ModelOptionsBase
{
    public CreateApiOptions(VariableDictionary variables, string prefix)
        : base(variables, AppendPrefix(prefix, "Create"))
    {
        Name = "{Entity.Name}CreateApi";
    }
}
