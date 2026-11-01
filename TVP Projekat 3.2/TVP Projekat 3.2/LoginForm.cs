using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVP_Projekat_3._2
{
    public partial class LoginForm : Form
    {
        Korisnik k;
        public LoginForm()
        {
            InitializeComponent();
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            Funkcije.ucitajSve();
            ErrorLabel.Text = "";
        }
       
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (LoginPrazan())
            {
                ErrorLabel.Text = "Nisu popunjena sva polja!";
                return;
            }

            if (LoginValidan())
            {
                this.Hide();
                Form sledeciForm = k.IsAdmin ? (Form)new AdminForm() : new UserForm(k);
                sledeciForm.Closed += (s, args) => this.Close();
                sledeciForm.ShowDialog();
                /*if (k.IsAdmin)//k.IsAdmin
                {
                    AdminForm adminForm = new AdminForm();
                    adminForm.Closed += (s, args) => this.Close();
                    adminForm.ShowDialog();
                }
                else
                {
                    UserForm userForm = new UserForm(k);
                    userForm.Closed += (s, args) => this.Close();
                    userForm.ShowDialog();
                }*/
            }
        }
        private bool LoginPrazan()
        {
            return String.IsNullOrWhiteSpace(UsernameTextBox.Text) || String.IsNullOrWhiteSpace(PasswordTextBox.Text);
        }
        private bool LoginValidan()
        {
            k = Funkcije.pronadjiLogin(UsernameTextBox.Text,PasswordTextBox.Text);
           
            if (k == null)
            {
                ErrorLabel.Text = "Uneti podaci nisu ispravni";
                return false;
            }

            return true;
        }

        
    }
}
