// Decompiled with JetBrains decompiler
// Type: Class8
// Assembly: CF_fixer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94294967-D321-4A46-AF93-F2C77C2AB85D
// Assembly location: C:\Temp\13221\CF_fixer.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

internal class Class8
{
  private string string_0;
  private List<string> list_0;
  private List<string> list_1;
  private List<string> list_2;
  private List<string> list_3;
  private List<string> list_4;
  private string string_1;

  public Class8(string map)
  {
    this.string_0 = map;
    this.list_0 = new List<string>();
    this.list_1 = new List<string>();
    this.list_2 = new List<string>();
    this.list_3 = new List<string>();
    this.list_4 = new List<string>();
    this.string_1 = Class0.class1_0.dictionary_0["DefaultPageID"];
  }

  public void method_0(
    string string_2,
    string string_3,
    string string_4,
    string string_5,
    string string_6,
    string string_7,
    string string_8,
    string string_9,
    string string_10,
    bool bool_0)
  {
    ++Class0.uint_0;
    ++Class0.uint_1;
    string oldValue = "DO NOT REPLACE";
    if (string_7 != "")
      oldValue = string_7;
    uint uint0 = Class0.uint_0;
    string string_11 = Convert.ToString(Class0.uint_1);
    if ((Class0.bool_2 || string_7 == "" ? 0 : (Convert.ToUInt32(string_7) > 0U ? 1 : 0)) == 0)
    {
      ++Class0.uint_2;
      string_7 = Convert.ToString(Class0.uint_2);
    }
    string string_7_1 = "s";
    if (!bool_0)
    {
      if (string_2 != "")
        this.list_0.Add(string_2.Replace(oldValue, string_7));
      else
        this.list_0.Add(this.method_1(Class0.string_1, string_7, string_3, string_6, string_5, string_7_1, string_8, string_9, string_10, uint0, string_11));
    }
    else
    {
      string_7_1 = "i";
      if (string_2 != "")
        this.list_1.Add(string_2);
      else
        this.list_1.Add(this.method_1(Class0.string_3, string_7, string_3, string_6, string_5, string_7_1, string_8, string_9, string_10, uint0, string_11));
    }
    this.list_2.Add(this.method_1(Class0.string_2, string_7, string_3, string_6, string_5, string_7_1, string_8, string_9, string_10, uint0, string_11));
    this.list_3.Add(this.method_1(Class0.string_4, string_7, string_3, string_6, string_5, string_7_1, string_8, string_9, string_10, uint0, string_11));
    this.list_4.Add(this.method_1(Class0.string_5, string_7, string_3, string_6, string_5, string_7_1, string_8, string_9, string_10, uint0, string_11));
  }

  public string method_1(
    string string_2,
    string string_3,
    string string_4,
    string string_5,
    string string_6,
    string string_7,
    string string_8,
    string string_9,
    string string_10,
    uint uint_0,
    string string_11)
  {
    return string_2.Replace("%baseid%", string_3).Replace("%swfname%", string_4).Replace("%pubname%", string_6).Replace("%desc%", string_5).Replace("%type%", string_7).Replace("%x%", string_8).Replace("%y%", string_9).Replace("%z%", string_10).Replace("%cataid%", Convert.ToString(uint_0)).Replace("%pageid%", this.string_1).Replace("%furnitureid%", string_11);
  }

  public void method_2(string string_2)
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append("## Catalog Items ##");
    stringBuilder.Append(Environment.NewLine);
    foreach (string str in this.list_3)
    {
      stringBuilder.Append(str);
      stringBuilder.Append(Environment.NewLine);
    }
    stringBuilder.Append(Environment.NewLine);
    stringBuilder.Append(Environment.NewLine);
    stringBuilder.Append("## Furniture ##");
    stringBuilder.Append(Environment.NewLine);
    foreach (string str in this.list_4)
    {
      stringBuilder.Append(str);
      stringBuilder.Append(Environment.NewLine);
    }
    stringBuilder.Append(Environment.NewLine);
    stringBuilder.Append(Environment.NewLine);
    stringBuilder.Append("## Furnidata ROOMITEMS ##");
    stringBuilder.Append(Environment.NewLine);
    foreach (string str in this.list_0)
    {
      stringBuilder.Append(str);
      stringBuilder.Append(Environment.NewLine);
    }
    stringBuilder.Append(Environment.NewLine);
    stringBuilder.Append(Environment.NewLine);
    stringBuilder.Append("## Furnidata WALLITEMS ##");
    stringBuilder.Append(Environment.NewLine);
    foreach (string str in this.list_1)
    {
      stringBuilder.Append(str);
      stringBuilder.Append(Environment.NewLine);
    }
    stringBuilder.Append(Environment.NewLine);
    stringBuilder.Append(Environment.NewLine);
    stringBuilder.Append("## Old furnidata for phoenix etc ##");
    stringBuilder.Append(Environment.NewLine);
    foreach (string str in this.list_2)
    {
      stringBuilder.Append(str);
      stringBuilder.Append(Environment.NewLine);
    }
    stringBuilder.Append(Environment.NewLine);
    stringBuilder.Append(Environment.NewLine);
    stringBuilder.Append("If the SQLS or the furnidata is wrong edit it in the settings map!");
    File.WriteAllText("sql/" + string_2, stringBuilder.ToString());
    string oldValue1 = "StartCatalogItemID=" + Class0.class1_0.dictionary_0["StartCatalogItemID"];
    string oldValue2 = "StartFurnitureItemID=" + Class0.class1_0.dictionary_0["StartFurnitureItemID"];
    string oldValue3 = "StartBaseItemID=" + Class0.class1_0.dictionary_0["StartBaseItemID"];
    File.WriteAllText("settings/config.ini", File.ReadAllText("settings/config.ini").Replace(oldValue1, "StartCatalogItemID=" + (object) Class0.uint_0).Replace(oldValue2, "StartFurnitureItemID=" + (object) Class0.uint_1).Replace(oldValue3, "StartBaseItemID=" + (object) Class0.uint_2));
    Class0.class1_0 = new Class1("settings/config.ini");
  }

  public void method_3()
  {
    XDocument xdocument = XDocument.Load(Class0.class1_0.dictionary_0["HabboFurniDataXMLURL"]);
    Class0.bool_0 = true;
    Console.Clear();
    Class0.smethod_3("Starting Generate Process. from map: " + this.string_0, ConsoleColor.DarkYellow);
    Class0.smethod_3("Checking FurniCount");
    string[] files = Directory.GetFiles(this.string_0, "*.swf");
    int length = files.Length;
    if (length == 0)
    {
      Class0.bool_0 = false;
      Class0.smethod_3("No furni's found!", ConsoleColor.Red);
      Console.ReadKey();
      Class0.smethod_1();
    }
    else
    {
      Class0.smethod_3("Found " + (object) length + " furni's to work with", ConsoleColor.Green);
      Class0.smethod_3("");
      foreach (string str in files)
      {
        try
        {
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: variable of a compiler-generated type
          Class8.Class9 class9 = new Class8.Class9();
          // ISSUE: reference to a compiler-generated field
          class9.string_0 = Path.GetFileNameWithoutExtension(str);
          uint num1 = 1;
          uint num2 = 1;
          string string_10 = "1";
          string string_2 = "";
          string string_6 = "no desc";
          // ISSUE: reference to a compiler-generated field
          string string0 = class9.string_0;
          string string_7 = "";
          bool bool_0 = false;
          if (xdocument != null)
          {
            try
            {
              // ISSUE: reference to a compiler-generated method
              XElement xelement1 = xdocument.Descendants((XName) "wallitemtypes").Descendants<XElement>().Where<XElement>(new Func<XElement, bool>(class9.method_0)).FirstOrDefault<XElement>();
              if (xelement1 != null)
              {
                string_2 = xelement1.ToString();
                bool_0 = true;
                string0 = xelement1.Element((XName) "name").Value;
                string_6 = xelement1.Element((XName) "description").Value;
                string_7 = xelement1.Attribute((XName) "id").Value;
              }
              // ISSUE: reference to a compiler-generated method
              XElement xelement2 = xdocument.Descendants((XName) "roomitemtypes").Descendants<XElement>().Where<XElement>(new Func<XElement, bool>(class9.method_1)).FirstOrDefault<XElement>();
              if (xelement2 != null)
              {
                string_2 = xelement2.ToString();
                bool_0 = false;
                string0 = xelement2.Element((XName) "name").Value;
                string_6 = xelement2.Element((XName) "description").Value;
                string_7 = xelement2.Attribute((XName) "id").Value;
              }
            }
            catch
            {
              Class0.smethod_3("Error with parsing furnidata ", ConsoleColor.Red);
            }
          }
          Class12.smethod_0(str);
          // ISSUE: reference to a compiler-generated field
          foreach (string file in Directory.GetFiles("sql/furni/", class9.string_0 + "-*.bin"))
          {
            try
            {
              string text = File.ReadAllText(file);
              if ((string.IsNullOrEmpty(text) ? 1 : (!text.Contains("<dimensions") ? 1 : 0)) == 0)
              {
                XElement xelement = XDocument.Parse(text).Root.Element((XName) "model").Element((XName) "dimensions");
                if (xelement != null)
                {
                  int num3 = xelement.Attribute((XName) "centerZ") != null ? 1 : 0;
                  num1 = Convert.ToUInt32(xelement.Attribute((XName) "x").Value);
                  num2 = Convert.ToUInt32(xelement.Attribute((XName) "y").Value);
                  string_10 = xelement.Attribute((XName) "z").Value;
                }
              }
              File.Delete(file);
            }
            catch (FormatException ex)
            {
              // ISSUE: reference to a compiler-generated field
              bool_0 = class9.string_0.Contains("wall");
              File.Delete(file);
            }
          }
          // ISSUE: reference to a compiler-generated field
          this.method_0(string_2, class9.string_0, "", string0, string_6, string_7, Convert.ToString(num1), Convert.ToString(num2), string_10, bool_0);
          // ISSUE: reference to a compiler-generated field
          Class0.smethod_3("Generated SQLS , furnidata for " + class9.string_0, ConsoleColor.Green);
        }
        catch
        {
        }
      }
      Class0.smethod_3("");
      string string_2_1 = Class0.smethod_5().ToString() + "_generated.txt";
      Class0.smethod_3("Done lets make " + string_2_1 + " ..", ConsoleColor.DarkGreen);
      this.method_2(string_2_1);
      Class0.smethod_3("Its DONE! Yeahh we generated evrything!", ConsoleColor.Cyan);
      Class0.bool_0 = false;
      Console.ReadKey();
      Class0.smethod_1();
    }
  }

    private class Class9
    {
        internal string string_0;

        public Class9()
        {
        }

        internal bool method_0(XElement arg)
        {
            throw new NotImplementedException();
        }

        internal bool method_1(XElement arg)
        {
            throw new NotImplementedException();
        }
    }
}
