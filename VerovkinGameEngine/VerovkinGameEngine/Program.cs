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
            MainWindow window = new MainWindow(1000, 1000, "CourseWork", "D:\\Git Projects\\Course_Work_2021_Spring\\Pictures\\map1.bmp");
            window.Run(60.0);

        }
    }
}
