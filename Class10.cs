// Decompiled with JetBrains decompiler
// Type: Class10
// Assembly: CF_fixer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94294967-D321-4A46-AF93-F2C77C2AB85D
// Assembly location: C:\Temp\13221\CF_fixer.exe

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

internal class Class10
{
  public static int int_0;

  public static void smethod_0()
  {
    Class0.bool_0 = true;
    Class10.int_0 = 0;
    Console.Clear();
    double num1 = (double) Class0.smethod_5();
    Class0.smethod_3("Compile Process started lets do it!", ConsoleColor.DarkMagenta);
    Class0.smethod_3("");
    Class0.smethod_3("Getting all SWF/BinFiles!", ConsoleColor.DarkRed);
    string[] files = Directory.GetFiles("graphicsfurni/", "*.bin");
    Class0.smethod_3("");
    Class0.smethod_3("Found " + (object) files.Length + " binfiles to compile. Lets start Compiling! D:", ConsoleColor.DarkGreen);
    Class0.smethod_3("");
    foreach (string str in files)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      new Thread(new ThreadStart(new Class10.Class11()
      {
        string_0 = str
      }.method_0)).Start();
    }
    double num2 = (double) Class0.smethod_5();
    Class0.smethod_4();
    Class0.smethod_3("Yeah We are done we compiled " + (object) Class10.int_0 + " binfiles in " + (object) (num2 - num1) + " Seconds!", ConsoleColor.Cyan);
    Class0.bool_0 = false;
    Console.ReadKey();
    Class0.smethod_1();
  }

  public static void smethod_1(string string_0, string string_1) => Process.Start(new ProcessStartInfo()
  {
    FileName = "swfbinreplace.exe",
    Arguments = "graphicsfurni/" + string_0 + ".swf " + string_1 + " graphicsfurni/" + string_0 + "-" + string_1 + ".bin",
    WindowStyle = ProcessWindowStyle.Hidden
  }).WaitForExit();

  public static void smethod_2(string string_0)
  {
    if ((!File.Exists(string_0) || !string_0.Contains("-") ? 1 : (!string_0.Contains(".bin") ? 1 : 0)) != 0)
      return;
    string str = string_0.Split('-')[1].Replace(".bin", "");
    string string_0_1 = string_0.Split('/')[1].Split('-')[0].Replace(".bin", "");
    if ((!File.Exists("graphicsfurni/" + string_0_1 + ".swf") ? 1 : (!int.TryParse(str, out int _) ? 1 : 0)) != 0)
      return;
    ++Class10.int_0;
    Class0.smethod_3("Compiling " + string_0_1 + " Binid " + str, ConsoleColor.DarkGreen);
    Class10.smethod_1(string_0_1, str);
  }

    private class Class11
    {
        public Class11()
        {
        }

        public string string_0 { get; set; }

        internal void method_0()
        {
            throw new NotImplementedException();
        }
    }
}
