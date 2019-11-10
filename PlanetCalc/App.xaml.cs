using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PlanetCalc.View;

namespace PlanetCalc
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //FrameworkElement.StyleProperty.OverrideMetadata(typeof(Window), new FrameworkPropertyMetadata
            //{
            //    DefaultValue = FindResource(typeof(Window))
            //});

            MainWindow mainWindow = new MainWindow();
            if (e.Args.Length == 1)
            {
                MessageBox.Show("Custom path to dadatabe file was given: " + e.Args[0], "Warning");
                //TODO Logic for custom database path
            }
            mainWindow.Show();
        }
    }
}
