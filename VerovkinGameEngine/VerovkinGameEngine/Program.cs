using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VerovkinGameEngine
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MainWindow window = new MainWindow(800, 600, "CourseWork");
            window.Run(60.0);
        }
    }
}
