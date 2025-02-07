using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Parser : IParser
{
   public Parser(string inputedTextofComand)
   {
       InputedTextofCommand = inputedTextofComand;
   }

   public string InputedTextofCommand { get; }
   public IReadOnlyList<string>? SeparatedTextofCommand { get; private set; }
   public string? CommandText { get; private set; }

   public void Parse()
   {
       ValueVerificator.NullStringValue(InputedTextofCommand);
       SeparatedTextofCommand = InputedTextofCommand.Split(' ');
       CommandText = string.Join(" ", SeparatedTextofCommand.TakeWhile(i => !i.StartsWith('-') && !i.Contains(':', StringComparison.Ordinal)).ToArray());
   }
}