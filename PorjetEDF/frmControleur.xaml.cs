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
    /// Logique d'interaction pour frmControleur.xaml
    /// </summary>
    public partial class frmControleur : Window
    {
        edfEntities gst;
        controleur leCtrl;
        public frmControleur(controleur unCtrl)
        {
            InitializeComponent();
            leCtrl = unCtrl;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new edfEntities();
            lstClients.ItemsSource = gst.client.ToList().FindAll(c=>c.idcontroleur == leCtrl.id);



        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
