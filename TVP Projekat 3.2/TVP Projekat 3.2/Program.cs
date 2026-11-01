using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVP_Projekat_3._2
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
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (sender,e) => MessageBox.Show(e.Exception.Message,"Operacija nije zavrsena");
            bool created;
            using(var mutex=new System.Threading.Mutex(true,"FilipProjects.TourismDesktop",out created))
            {
                if(!created){MessageBox.Show("Aplikacija je vec pokrenuta.");return;}
                try { Funkcije.ucitajSve(); Application.Run(new LoginForm()); }
                catch(Exception ex){MessageBox.Show(ex.Message,"Pokretanje nije uspelo");}
            }
        }
    }
}
