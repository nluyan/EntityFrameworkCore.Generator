namespace EntityFrameworkCore.Generator.Options;

/// <summary>
/// Model options group
/// </summary>
public class EndpointOptions : ModelOptionsBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ModelOptions" /> class.
    /// </summary>
    /// <param name="variables">The shared variables dictionary.</param>
    /// <param name="prefix">The variable key prefix.</param>
    public EndpointOptions(VariableDictionary variables, string prefix)
        : base(variables, AppendPrefix(prefix, "Api"))
    {
        Create = new CreateApiOptions(Variables, Prefix);
        Update = new UpdateApiOptions(Variables, Prefix);
        Search = new SearchApiOptions(Variables, Prefix);
        Delete = new DeleteApiOptions(Variables, Prefix);
        Retrieve = new RetrieveApiOptions(Variables, Prefix);
    }


    public CreateApiOptions Create { get; }

    public UpdateApiOptions Update { get; }

    public SearchApiOptions Search { get; }

    public DeleteApiOptions Delete { get; }

    public RetrieveApiOptions Retrieve { get; }
}
