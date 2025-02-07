using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public interface ICommand
{
      public void DoCommand(IReadOnlyList<string> args);
}