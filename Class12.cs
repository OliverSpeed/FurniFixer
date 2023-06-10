// Decompiled with JetBrains decompiler
// Type: Class12
// Assembly: CF_fixer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94294967-D321-4A46-AF93-F2C77C2AB85D
// Assembly location: C:\Temp\13221\CF_fixer.exe

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

internal class Class12
{
  public static void smethod_0(string string_0) => Process.Start(new ProcessStartInfo()
  {
    FileName = "swfbinexport.exe",
    Arguments = string_0,
    WindowStyle = ProcessWindowStyle.Hidden
  }).WaitForExit();

  public static void smethod_1()
  {
    Class0.bool_0 = true;
    Console.Clear();
    Class0.smethod_3("Im decompiling all swf in the furni folder! Please wait before im done!", ConsoleColor.DarkMagenta);
    Class0.smethod_3("");
    Class0.smethod_3("Removing Old bin files because it can cause errors", ConsoleColor.DarkRed);
    Class0.smethod_4();
    string[] files = Directory.GetFiles("graphicsfurni/", "*.swf");
    Class0.smethod_3("Found in total " + (object) files.Length + " Furni's to decompile!", ConsoleColor.DarkGreen);
    foreach (string str in files)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      new Thread(new ThreadStart(new Class12.Class13()
      {
        string_0 = str
      }.method_0)).Start();
    }
    Class0.smethod_3("Its done yeahh! All SWFS are decompiled yeahh :P", ConsoleColor.Cyan);
    Class0.bool_0 = false;
    Console.ReadKey();
    Class0.smethod_1();
  }

    private class Class13
    {
        public Class13()
        {
        }

        public string string_0 { get; set; }

        internal void method_0()
        {
            throw new NotImplementedException();
        }
    }
}
