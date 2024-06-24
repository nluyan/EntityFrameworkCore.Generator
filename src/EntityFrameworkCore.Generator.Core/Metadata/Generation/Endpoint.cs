using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Generator.Metadata.Generation;
public class Endpoint : ModelBase, IOptionVariable
{
    public Entity Entity { get; set; }

    public EndpointType EndpointType { get; set; }

    public string Namespace { get; set; }

    public string ClassName { get; set; }

    public string BaseClass { get; set; }

    public string RequestModelName { get; set; }

    public string ResponseModelName { get; set; }

    public void Remove(VariableDictionary variableDictionary)
    {
        variableDictionary.Set(VariableConstants.EndpointName, ClassName);
    }

    public void Set(VariableDictionary variableDictionary)
    {
        variableDictionary.Remove(VariableConstants.EndpointName);
    }
}
