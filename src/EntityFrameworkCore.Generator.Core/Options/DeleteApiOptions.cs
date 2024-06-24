namespace EntityFrameworkCore.Generator.Options;
public class DeleteApiOptions : ModelOptionsBase
{
    public DeleteApiOptions(VariableDictionary variables, string prefix)
        : base(variables, AppendPrefix(prefix, "Delete"))
    {
        Name = "{Entity.Name}DeleteApi";
    }
}
