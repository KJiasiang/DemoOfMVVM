using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Game1
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            bool showConsole = false;
            for (int i = 0; i != e.Args.Length; ++i)
            {
                if (e.Args[i] == "-dg")
                {
                    showConsole = true;
                }
            }

            if(showConsole)
                My.OpenConsoleWindow();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
