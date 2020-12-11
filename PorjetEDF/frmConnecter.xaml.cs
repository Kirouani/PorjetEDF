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
using System.Windows.Shapes;

namespace PorjetEDF
{
    /// <summary>
    /// Logique d'interaction pour frmConnecter.xaml
    /// </summary>
    public partial class frmConnecter : Window
    {
        edfEntities gst;
        int idControleur;
        public frmConnecter()
        {
            InitializeComponent();
        }
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            gst = new edfEntities();
            lstControleur.ItemsSource = gst.controleur.ToList();

        }

        private void LstControleur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
            if (lstControleur.SelectedItem != null)
            {
                    int idControleur = (lstControleur.SelectedItem as controleur).id;
                    var request = from clie in gst.client
                                  join contro in gst.controleur on clie.idcontroleur equals contro.id
                                  where contro.id == idControleur
                                  select new Total
                                  {
                                      ancienReleve = clie.ancienReleve,
                                      dernierReleve = clie.dernierReleve,
                                      total = clie.dernierReleve - clie.ancienReleve,
                                      identifiant = clie.identifiant,
                                      nom = clie.nom,
                                      prenom = clie.prenom,
                                  };

                    lstClients.ItemsSource = request.ToList();

              

            }
        }

        private void BtnInsererControl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnInsererClient_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
