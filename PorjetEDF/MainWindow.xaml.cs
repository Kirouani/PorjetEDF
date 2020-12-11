using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PorjetEDF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        edfEntities gst;
       
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void BtnConncetr_Click(object sender, RoutedEventArgs e)
        {
            controleur leControleur = gst.controleur.ToList().Find(contr => contr.login == txtLogin.Text && contr.mdp == txtMdp.Text);

            if (leControleur == null)
            {
                MessageBox.Show("Login inccorecte", "Veuiller refaire", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if (leControleur == null)
                {
                    MessageBox.Show("Mot de passe incorrecte", "Veuiller refaire", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    if (leControleur != null)
                    {
                        if(leControleur.statut == "admin")
                        {
                            frmConnecter frm = new frmConnecter();
                            frm.Show();
                        }
                        else
                        {
                            if(leControleur != null)
                            {
                                frmControleur frm = new frmControleur(leControleur);
                                frm.Show();
                            }
                        }
                     
                    }
                }
                
            }

           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new edfEntities();
            
        }
    }
}
