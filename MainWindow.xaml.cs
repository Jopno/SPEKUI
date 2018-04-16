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

namespace Speku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //listat
        public List<Henkilo> henkilolista = new List<Henkilo>();
        public List<Palokunta> palokuntalista = new List<Palokunta>();
        public List<Tyosuoritus> tyosuorituslista = new List<Tyosuoritus>();
        public MenuItem HenkiloRoot = new MenuItem() { Title = "Henkilöt" };
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                henkilolista.Add(new Henkilo("Henkilo" + i, DateTime.Now, "FI123456", "21512-12E"));
                HenkiloRoot.Items.Add(new Henkilo("Henkilo" + i, DateTime.Now, "FI123456", "21512-12E"));
                HenkiloTreeView.Items.Add(henkilolista[i]);
            }
            MenuItem PalokuntaRoot = new MenuItem() { Title = "Palokunnat" };
            MenuItem TyoRoot = new MenuItem() { Title = "Työt" };
            MainTreeView.Items.Refresh();
            
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MainTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Henkilo selectedHenkilo = (Henkilo)MainTreeView.SelectedItem;
            DataPanel.DataContext = selectedHenkilo;

        }
    }
}
