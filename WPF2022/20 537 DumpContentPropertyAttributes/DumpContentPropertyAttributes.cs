﻿//--------- ----------------------------------------------------- 
// DumpContentPropertyAttributes.cs (c) 2006 by  Charles Petzold 
//------------------------------------------------ -------------- 
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Navigation;

public class DumpContentPropertyAttributes
{
    [STAThread]
    public static void Main()
    {

        UIElement dummy1 = new UIElement();
        FrameworkElement dummy2 = new FrameworkElement();
        // SortedList to store class and content  property.         
        SortedList<string, string> listClass = new SortedList<string, string>();
        // Formatting string.         
        string strFormat = "{0,-35}{1}";
        // Loop through the loaded assemblies.         
        foreach (AssemblyName asmblyname in
            Assembly.GetExecutingAssembly().GetReferencedAssemblies())
        {
            foreach (Type type in Assembly.Load(asmblyname).GetTypes())     // перебрать типы          
            {

                // (Set argument to 'false' for  non-inherited only!)                 
                foreach (object obj in type.GetCustomAttributes(


                    typeof(ContentPropertyAttribute), true))
                {
                    // Add to list if  ContentPropertyAttribute.                     
                    if (type.IsPublic && obj as ContentPropertyAttribute != null)
                        listClass.Add(type.Name,
                            (obj as ContentPropertyAttribute).Name);
                }
            }
        }

        Console.WriteLine(strFormat, "Class", "Content Property");
        Console.WriteLine(strFormat, "-----", "----------------");
        foreach (string strClass in listClass.Keys)
            Console.WriteLine(strFormat, strClass, listClass[strClass]);      // результаты 
    }
}