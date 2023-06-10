// Decompiled with JetBrains decompiler
// Type: Class0
// Assembly: CF_fixer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94294967-D321-4A46-AF93-F2C77C2AB85D
// Assembly location: C:\Temp\13221\CF_fixer.exe

using System;
using System.IO;

internal class Class0
{
  public static Class1 class1_0;
  public static bool bool_0 = false;
  public static bool bool_1 = true;
  public static string string_0 = Path.GetTempPath();
  public static string string_1;
  public static string string_2;
  public static string string_3;
  public static string string_4;
  public static string string_5;
  public static uint uint_0 = 0;
  public static uint uint_1 = 0;
  public static uint uint_2 = 0;
  public static bool bool_2 = false;

  public static void smethod_0()
  {
    if (!Directory.Exists("graphicsfurni"))
      Directory.CreateDirectory("graphicsfurni");
    if (!Directory.Exists("WithfixedFurni"))
      Directory.CreateDirectory("WithfixedFurni");
    if (!Directory.Exists("sql/furni"))
      Directory.CreateDirectory("sql/furni");
    Class0.class1_0 = new Class1("settings/config.ini");
    Class0.string_4 = Class0.class1_0.dictionary_0["DefaultCatalogItem"];
    Class0.string_5 = Class0.class1_0.dictionary_0["DefaultFurniture"];
    Class0.string_1 = File.ReadAllText("settings/Default_furnidata_floor.txt");
    Class0.string_3 = File.ReadAllText("settings/Default_furnidata_wall.txt");
    Class0.string_2 = File.ReadAllText("settings/Default_furnidata_old.txt");
    Class0.uint_0 = Convert.ToUInt32(Class0.class1_0.dictionary_0["StartCatalogItemID"]);
    Class0.uint_1 = Convert.ToUInt32(Class0.class1_0.dictionary_0["StartFurnitureItemID"]);
    Class0.uint_2 = Convert.ToUInt32(Class0.class1_0.dictionary_0["StartBaseItemID"]);
    Class0.bool_2 = Class0.class1_0.dictionary_0["UseStartBaseitem"] == "true";
    Class0.smethod_1();
  }

  public static void smethod_1()
  {
    Console.Title = "Custom furni / normal furni Fixer By SpotIfy";
    if (!Directory.Exists("graphicsfurni"))
      Directory.CreateDirectory("graphicsfurni");
    if (!Directory.Exists("WithfixedFurni"))
      Directory.CreateDirectory("WithfixedFurni");
    if (!Directory.Exists("sql/furni"))
      Directory.CreateDirectory("sql/furni");
    Console.Clear();
    Class0.smethod_3("Welcome to the automaticly Furni fixer!", ConsoleColor.Green);
    Class0.smethod_3("This program is made by Spot IFy (Skype: Draakwars)!", ConsoleColor.DarkYellow);
    Class0.smethod_3("Automatic furni fixer adds or removes the graphics tags in all swf in the furni folder by simpel typing add or remove");
    Class0.smethod_3("");
    Class0.smethod_3("Commands:", ConsoleColor.DarkCyan);
    Class0.smethod_3("'add' add the Graphics tag into the swfs for fixing customs in plus r2", ConsoleColor.DarkGreen);
    Class0.smethod_3("'remove' Remove the Graphics tags from the swfs to fix new furni for old builds", ConsoleColor.DarkGreen);
    Class0.smethod_3("'decompileall' Decompile all swf in the furni folder", ConsoleColor.DarkGreen);
    Class0.smethod_3("'decompile' decompile a swf usage: decompile SWFNAME BINID", ConsoleColor.DarkGreen);
    Class0.smethod_3("'compileall' Compile all binfiles into all swfs", ConsoleColor.DarkGreen);
    Class0.smethod_3("'compile' compile a binfile into a swf usage: compile SWFNAME BINID", ConsoleColor.DarkGreen);
    Class0.smethod_3("'download' Downloads and generates the SQL's from the furnidata for new furni!", ConsoleColor.DarkGreen);
    Class0.smethod_3("'downloadn' Downloads from the furnidata for redownloading the hof_furni", ConsoleColor.DarkGreen);
    Class0.smethod_3("'generate' Generate SQLS/furnidata from sql/furni map without furnidata", ConsoleColor.DarkGreen);
  }

  public static void smethod_2(string string_6)
  {
    if (Class0.bool_0 || string_6.Length < 1)
      return;
    string[] strArray = string_6.Split(' ');
    switch (strArray[0].ToLower())
    {
      case "add":
        Class6.smethod_0(false);
        break;
      case "remove":
        Class6.smethod_0(true);
        break;
      case "decompileall":
        Class12.smethod_1();
        break;
      case "decompile":
        if (strArray.Length >= 2)
        {
          string str1 = strArray[1];
          if (str1.Contains(".swf"))
            str1 = str1.Split('.')[0];
          string str2 = "graphicsfurni/" + str1 + ".swf";
          if (File.Exists(str2))
          {
            Class0.smethod_3("Decompiling " + str1 + "...", ConsoleColor.Green);
            Class12.smethod_0(str2);
            Class0.smethod_3("Done!", ConsoleColor.Cyan);
          }
          else
            Class0.smethod_3("File Doesnt exist!", ConsoleColor.Red);
          Console.ReadKey();
          Class0.smethod_1();
          break;
        }
        Class0.smethod_3("You need to use decompile SWFNAME", ConsoleColor.Red);
        break;
      case "compile":
        if ((strArray.Length != 3 ? 1 : (strArray[1].Contains(".swf") ? 1 : 0)) == 0)
        {
          if (int.TryParse(strArray[2], out int _))
          {
            int num;
            if (File.Exists("graphicsfurni/" + strArray[1] + ".swf"))
              num = !File.Exists("graphicsfurni/" + strArray[1] + "-" + strArray[2] + ".bin") ? 1 : 0;
            else
              num = 1;
            if (num == 0)
            {
              Class0.smethod_3("Compiling the swf...", ConsoleColor.Green);
              Class10.smethod_1(strArray[1], strArray[2]);
              Class0.smethod_3("Done!", ConsoleColor.Cyan);
            }
            else
              Class0.smethod_3("File Doesnt exist!", ConsoleColor.Red);
            Console.ReadKey();
            Class0.smethod_1();
            break;
          }
          Class0.smethod_3("BinId is wrong!");
          break;
        }
        Class0.smethod_3("You need to it like this compile swfname binid", ConsoleColor.Red);
        break;
      case "compileall":
        Class10.smethod_0();
        break;
      case "download":
        new Class2().method_0(true);
        break;
      case "downloadn":
        new Class2().method_0(false);
        break;
      case "generate":
        new Class8("sql/furni").method_3();
        break;
      case "reset":
        Class0.smethod_1();
        break;
      default:
        Class0.smethod_3("Wrong command :p", ConsoleColor.Red);
        break;
    }
  }

  public static void smethod_3(string string_6, ConsoleColor consoleColor_0 = ConsoleColor.Gray)
  {
    Console.ForegroundColor = consoleColor_0;
    Console.WriteLine(string_6);
    Console.ForegroundColor = ConsoleColor.Gray;
  }

  public static void smethod_4()
  {
    foreach (string file in Directory.GetFiles("graphicsfurni/", "*.bin"))
    {
      if (File.Exists(file))
        File.Delete(file);
    }
  }

  internal static int smethod_5() => (int) (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
}
