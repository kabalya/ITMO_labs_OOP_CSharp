using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class ExceptionCollector : IExceptionCollector
{
      private List<string>? ListOfErrors { get; set; }

      public void AddExceptionToList(string stringValue)
    {
         ListOfErrors?.Add(stringValue);
    }
}