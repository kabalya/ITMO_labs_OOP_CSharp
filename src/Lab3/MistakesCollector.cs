using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class MistakesCollector
{
    private List<string>? ListOfErrors { get; set; }

    public void ListAddError(string value)
    {
        ListOfErrors?.Add(value);
    }
}