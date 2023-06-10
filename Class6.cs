// Decompiled with JetBrains decompiler
// Type: Class6
// Assembly: CF_fixer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94294967-D321-4A46-AF93-F2C77C2AB85D
// Assembly location: C:\Temp\13221\CF_fixer.exe

using System;
using System.IO;
using System.Text.RegularExpressions;

internal class Class6
{
  public static void smethod_0(bool bool_0)
  {
    Class0.bool_0 = true;
    Console.Clear();
    double num1 = (double) Class0.smethod_5();
    if (bool_0)
      Class0.smethod_3("Graphics Remove proces started! Wait before its done!", ConsoleColor.DarkMagenta);
    else
      Class0.smethod_3("Graphics add proces started! Wait before its done!", ConsoleColor.DarkMagenta);
    Class0.smethod_3("");
    Class0.smethod_3("Removing Old bin files because it can cause errors", ConsoleColor.DarkRed);
    Directory.GetFiles("graphicsfurni/", "*.bin");
    Class0.smethod_4();
    string[] files1 = Directory.GetFiles("graphicsfurni/", "*.swf");
    int length = files1.Length;
    foreach (string string_0 in files1)
    {
      Class0.smethod_3("found furni: " + string_0, ConsoleColor.Green);
      Class12.smethod_0(string_0);
    }
    int num2 = 0;
    Class0.smethod_3(length.ToString() + " furnis are decompiled lets start replacing shit in the bin files yeahh :$", ConsoleColor.DarkGreen);
    string[] files2 = Directory.GetFiles("graphicsfurni/", "*.bin");
    Class0.smethod_3("Found " + (object) files2.Length + " Bin files lets search in it!");
    foreach (string str1 in files2)
    {
      if ((!File.Exists(str1) ? 0 : (str1.StartsWith("graphicsfurni/") ? 1 : 0)) != 0)
      {
        string str2 = File.ReadAllText(str1);
        bool flag = false;
        string contents = "";
        string str3 = str1.Split('/')[1].Split('-')[0];
        if (!bool_0)
        {
          string oldValue = "<visualizationData type=\"@FurniName\">".Replace("@FurniName", str3).Replace("/", "");
          if ((str2.Contains("<graphics>") || !str2.Contains("</visualizationData>") ? 1 : (!str2.Contains(oldValue) ? 1 : 0)) == 0)
          {
            flag = true;
            contents = str2.Replace(oldValue, oldValue + Environment.NewLine + "<graphics>").Replace("</visualizationData>", "</graphics>" + Environment.NewLine + " </visualizationData>");
          }
        }
        else if ((!str2.Contains("<graphics>") ? 1 : (!str2.Contains("</graphics>") ? 1 : 0)) == 0)
        {
          flag = true;
          contents = str2.Replace("<graphics>", "").Replace("</graphics>", "");
        }
        if ((!flag ? 1 : (!(contents != "") ? 1 : 0)) == 0)
        {
          ++num2;
          Class0.smethod_3("Found a File Thats Has or needs a graphics tag!", ConsoleColor.Green);
          File.WriteAllText(str1, contents);
          Class10.smethod_1(str3, new Regex("-(.*).bin").Match(str1).Groups[1].ToString());
          Class0.smethod_3("Added graphics tags to and compiled the furni: " + str1, ConsoleColor.Green);
        }
      }
    }
    Class0.smethod_3("Removing Bin Files! and places the fixed furni into a new folder");
    Class0.smethod_4();
    foreach (string str4 in files1)
    {
      string fileName = Path.GetFileName(str4);
      if (File.Exists(str4))
      {
        string str5 = "WithfixedFurni/" + fileName;
        if (bool_0)
          str5 = "WithoutFixedFurni/" + fileName;
        if (File.Exists(str5))
          File.Delete(str5);
        File.Copy(str4, str5);
        File.Delete(str4);
      }
    }
    Class0.smethod_3("We edited " + (object) num2 + " bin files to fix all furnis! in " + ((double) Class0.smethod_5() - num1).ToString());
    if (!bool_0)
      Class0.smethod_3("Its done yeahh! All fixed furnis are placed in WithfixedFurni", ConsoleColor.Cyan);
    else
      Class0.smethod_3("Its done yeahh! All fixed furnis are placed in WithoutFixedFurni", ConsoleColor.Cyan);
    Class0.bool_0 = false;
    Console.ReadKey();
    Class0.smethod_1();
  }
}
