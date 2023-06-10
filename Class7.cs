// Decompiled with JetBrains decompiler
// Type: Class7
// Assembly: CF_fixer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94294967-D321-4A46-AF93-F2C77C2AB85D
// Assembly location: C:\Temp\13221\CF_fixer.exe

using System;

internal class Class7
{
  private static void Main(string[] args)
  {
    Class0.smethod_0();
    while (Class0.bool_1)
    {
      Console.CursorVisible = true;
      Console.Write("CFfixer> ");
      Class0.smethod_2(Console.ReadLine());
    }
  }

  public static void smethod_0(string string_0, ConsoleColor consoleColor_0 = ConsoleColor.Gray)
  {
    Console.ForegroundColor = consoleColor_0;
    Console.WriteLine(string_0);
    Console.ForegroundColor = ConsoleColor.Gray;
  }
}
