// Decompiled with JetBrains decompiler
// Type: Class2
// Assembly: CF_fixer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94294967-D321-4A46-AF93-F2C77C2AB85D
// Assembly location: C:\Temp\13221\CF_fixer.exe

using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Xml.Linq;

internal class Class2
{
  private string string_0;
  private WebClient webClient_0;
  private string string_1;
  private string string_2;
  private bool bool_0;
  private XDocument xdocument_0;
  private int int_0 = 0;
  private Class8 class8_0 = new Class8("sql");

  public Class2()
  {
    try
    {
      this.string_0 = Class0.class1_0.dictionary_0["HabboFurniDataXMLURL"];
      this.string_2 = Class0.class1_0.dictionary_0["HabbboHofFurniUrl"];
      this.bool_0 = Class0.class1_0.dictionary_0["AddReversionToUrl"] == "true";
      this.webClient_0 = new WebClient();
      this.string_1 = this.webClient_0.DownloadString(this.string_0);
      this.xdocument_0 = XDocument.Parse(this.string_1);
    }
    catch (Exception ex)
    {
      Class0.smethod_3("The furnidata didnt load correct: " + ex.ToString());
    }
  }

  public void method_0(bool bool_1)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Class2.Class3 class3 = new Class2.Class3();
    // ISSUE: reference to a compiler-generated field
    class3.bool_0 = bool_1;
    // ISSUE: reference to a compiler-generated field
    class3.class2_0 = this;
    try
    {
      Console.Clear();
      Class0.smethod_3("Hi, Im Gona check the furnidata for new furni's for you!", ConsoleColor.DarkGreen);
      Class0.smethod_3("This can take a while because the furnidata has 3000+ furni", ConsoleColor.DarkGreen);
      Class0.smethod_3("Lets start getting the Furnidata from: " + this.string_0, ConsoleColor.Cyan);
      Class0.smethod_3("");
      Class0.bool_0 = true;
      this.int_0 = 0;
      foreach (XElement descendant in this.xdocument_0.Descendants((XName) "roomitemtypes").Descendants<XElement>((XName) "furnitype"))
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        Class2.Class4 class4 = new Class2.Class4();
        // ISSUE: reference to a compiler-generated field
        class4.class3_0 = class3;
        // ISSUE: reference to a compiler-generated field
        class4.xelement_0 = descendant;
        if (this.int_0 >= 600)
        {
          Thread.Sleep(5000);
          this.int_0 = 0;
        }
        // ISSUE: reference to a compiler-generated method
        new Thread(new ThreadStart(class4.method_0)).Start();
      }
      foreach (XElement descendant in this.xdocument_0.Descendants((XName) "wallitemtypes").Descendants<XElement>((XName) "furnitype"))
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        Class2.Class5 class5 = new Class2.Class5();
        // ISSUE: reference to a compiler-generated field
        class5.class3_0 = class3;
        // ISSUE: reference to a compiler-generated field
        class5.xelement_0 = descendant;
        if (this.int_0 >= 600)
        {
          Thread.Sleep(5000);
          this.int_0 = 0;
        }
        // ISSUE: reference to a compiler-generated method
        new Thread(new ThreadStart(class5.method_0)).Start();
      }
      Class0.smethod_3("");
      Class0.smethod_3("waiting 5 seconds..", ConsoleColor.DarkCyan);
      Thread.Sleep(5000);
      // ISSUE: reference to a compiler-generated field
      if ((!class3.bool_0 ? 1 : (this.int_0 < 1 ? 1 : 0)) == 0)
      {
        string string_2 = Class0.smethod_5().ToString() + "_Downloaded.txt";
        Class0.smethod_3("Done lets make " + string_2 + " ..", ConsoleColor.DarkGreen);
        this.class8_0.method_2(string_2);
      }
      Class0.smethod_3(Environment.NewLine);
      Class0.smethod_3("Its done yeahh we downloaded " + (object) this.int_0 + " Furnis! and placed it in Yhof_furni and newfurni", ConsoleColor.Cyan);
      Console.ReadKey();
      Class0.bool_0 = false;
      Class0.smethod_1();
    }
    catch
    {
      Class0.bool_0 = false;
      Class0.smethod_1();
    }
  }

  private void method_1(XElement xelement_0, bool bool_1, bool bool_2)
  {
    string string_3 = "";
    try
    {
      WebClient webClient = new WebClient();
      uint num1 = 1;
      uint num2 = 1;
      string string_10 = "1";
      string_3 = xelement_0.Attribute((XName) "classname").Value;
      if (string_3.Contains("*"))
        string_3 = string_3.Split('*')[0];
      if (System.IO.File.Exists("Yhof_furni/" + string_3 + ".swf"))
        return;
      string string_4 = "";
      string string_5 = xelement_0.Element((XName) "name").Value;
      string string_6 = xelement_0.Element((XName) "description").Value;
      string string_7 = xelement_0.Attribute((XName) "id").Value;
      if (this.bool_0)
        string_4 = xelement_0.Element((XName) "revision").Value;
      webClient.DownloadFile(this.string_2 + string_4 + "/" + string_3 + ".swf", "Yhof_furni/" + string_3 + ".swf");
      ++this.int_0;
      if ((!bool_1 ? 1 : (this.int_0 < 1 ? 1 : 0)) == 0)
      {
        if (!System.IO.File.Exists("newfurni/" + string_3 + ".swf"))
          System.IO.File.Copy("Yhof_furni/" + string_3 + ".swf", "newfurni/" + string_3 + ".swf");
        Class12.smethod_0("newfurni/" + string_3 + ".swf");
        if (!bool_2)
        {
          foreach (string file in Directory.GetFiles("newfurni/", string_3 + "-*.bin"))
          {
            try
            {
              string text = System.IO.File.ReadAllText(file);
              if ((string.IsNullOrEmpty(text) ? 1 : (!text.Contains("<dimensions") ? 1 : 0)) == 0)
              {
                XElement xelement = XDocument.Parse(text).Root.Element((XName) "model").Element((XName) "dimensions");
                if (xelement != null)
                {
                  num1 = Convert.ToUInt32(xelement.Attribute((XName) "x").Value);
                  num2 = Convert.ToUInt32(xelement.Attribute((XName) "y").Value);
                  string_10 = xelement.Attribute((XName) "z").Value;
                }
              }
              System.IO.File.Delete(file);
            }
            catch (Exception ex)
            {
              System.IO.File.Delete(file);
            }
          }
        }
        this.class8_0.method_0(xelement_0.ToString(), string_3, string_4, string_5, string_6, string_7, Convert.ToString(num1), Convert.ToString(num2), string_10, bool_2);
      }
      Class0.smethod_3("Downloaded " + string_3 + " and generated the sql.", ConsoleColor.Green);
    }
    catch (Exception ex)
    {
      if (!ex.ToString().Contains("404"))
        return;
      Class0.smethod_3("Furni " + string_3 + " niet gevonden!", ConsoleColor.Red);
    }
  }

    internal class Class3
    {
        internal bool bool_0;
        internal Class2 class2_0;
    }

    private class Class4
    {
        internal Class2.Class3 class3_0;
        internal XElement xelement_0;

        public Class4()
        {
        }

        internal void method_0()
        {
            throw new NotImplementedException();
        }
    }

    private class Class5
    {
        internal Class3 class3_0;
        internal XElement xelement_0;

        internal void method_0()
        {
            throw new NotImplementedException();
        }
    }
}
