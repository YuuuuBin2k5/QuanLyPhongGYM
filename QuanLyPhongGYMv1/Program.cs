using DataAccessLayer;
using QuanLyPhongGYMv1;
using System;
using System.Windows.Forms;

namespace QuanLyPhongGYMv1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new loginForm2());

        }
    }
}
