using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using MySql.Data.MySqlClient;

namespace Speku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //listat
        public Henkilo curHenkilo;
        public static MainWindow instance;
        public ObservableCollection<Henkilo> Henkilolista { get; set; }
        public ObservableCollection<Palokunta> palokuntalista = new ObservableCollection<Palokunta>();
        public ObservableCollection<Tyosuoritus> tyosuorituslista = new ObservableCollection<Tyosuoritus>();

        public  MainWindow()
        {
            InitializeComponent();
            instance = this;
            Window1 w1 = new Window1();
            w1.Show();
        
        }

        //Vaihtaa tabin oikeeseen
        //ja täyttää henkilön datan näkyville
        private void HenkiloListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainTabControl.SelectedIndex = 0;
            NameBox.Text = Henkilolista[HenkiloListBox.SelectedIndex].Nimi;
            SyntymaaikaBox.Text = Henkilolista[HenkiloListBox.SelectedIndex].Syntymaaika.ToShortDateString();
            PalokuntaBox.Text = Henkilolista[HenkiloListBox.SelectedIndex].Palokunta;
            TilinumBox.Text = Henkilolista[HenkiloListBox.SelectedIndex].Tilinumero;
            LiittyminenBox.Text = Henkilolista[HenkiloListBox.SelectedIndex].Liittyminen.ToShortDateString();
            EroaminenBox.Text = Henkilolista[HenkiloListBox.SelectedIndex].Eroaminen.ToShortDateString();
            HenkilotunnusBox.Text = Henkilolista[HenkiloListBox.SelectedIndex].Henkilotunnus;
        }


        //Vaihtaa tabin oikeeseen
        //ja täyttää henkilön datan näkyville
        private void TyoListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainTabControl.SelectedIndex = 2;
            TyosuoritusIDBox.Text = tyosuorituslista[TyoListBox.SelectedIndex].TyosuoritusID;
            TyoHenkiloBox.Text = tyosuorituslista[TyoListBox.SelectedIndex].henkilo;
        }

        private void PalokuntaListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainTabControl.SelectedIndex = 1;
            PalokuntaNimi.Text = palokuntalista[PalokuntaListBox.SelectedIndex].PalokuntaNimi;
            PalokuntaIDBox.Text = palokuntalista[PalokuntaListBox.SelectedIndex].PalokuntaID;
            TyyppiBox.Text = palokuntalista[PalokuntaListBox.SelectedIndex].Tyyppi;
            PaikkakuntaBox.Text = palokuntalista[PalokuntaListBox.SelectedIndex].paikkakunta;
            AlueBox.Text = palokuntalista[PalokuntaListBox.SelectedIndex].alue;
        }

        //Hakee oikeat tiedot tietokannasta
        //Foreach ottaa jokaisen henkilölistasta ja lisää listaan, jotta sitä voi klikata
         public void GetData(string password)
        {
            Henkilolista = DB.LoadHenkilotFromMysql(password);
            palokuntalista = DB.LoadPalokunnatFromMysql(password);
            tyosuorituslista = DB.LoadTyotFromMysql(password);

            foreach (Henkilo h in Henkilolista)
            {
                HenkiloListBox.Items.Add(h);
            }
            foreach (Palokunta p in palokuntalista)
            {
                PalokuntaListBox.Items.Add(p);
            }
            foreach (Tyosuoritus t in tyosuorituslista)
            {
                TyoListBox.Items.Add(t);
            }
        }
    }
}
