﻿//--------------------------------------------------- 
// DockAroundTheBlock.cs (c) 2006 by Charles Petzold 
//--------------------------------------------------- 
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


    class DockAroundTheBlock : Window
{
    [STAThread]
    public static void Main()
    {
        Application app = new Application();
        app.Run(new DockAroundTheBlock());
    }
    public DockAroundTheBlock()
    {
        Title = "Dock Around the Block";
        DockPanel dock = new DockPanel(); // последовательно присваивает каждой кнопке значения из перечисл dot              
        Content = dock;
        for (int i = 0; i < 17; i++)
        {
            Button btn = new Button();
            btn.Content = "Button No. " + (i + 1);
            dock.Children.Add(btn);
            btn.SetValue(DockPanel.DockProperty, (Dock)(i % 4));
        }
    }
} 

