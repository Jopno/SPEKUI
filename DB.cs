using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Speku
{
    public class DB
    {
        public static ObservableCollection<Henkilo> LoadHenkilotFromMysql(string password)
        {
            //try
            //{
            ObservableCollection<Henkilo> henkilot = new ObservableCollection<Henkilo>();
            //luodaan yhteys labranetin mysql-palvelimelle
            string connStr = GetMysqlConnectionString(password);
            string sql = "SELECT htun, nimi, syntymaaika, tilinumero, palokunta_palokuntaid, liittymispvm FROM henkilo";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Henkilo s = new Henkilo();

                        s.Henkilotunnus = reader.GetString(0);
                        s.Nimi = reader.GetString(1);
                        s.Syntymaaika = reader.GetDateTime(2);
                        s.Tilinumero = reader.GetString(3);
                        s.Palokunta = reader.GetString(4);
                        s.Liittyminen = reader.GetDateTime(5);

                        henkilot.Add(s);
                    }
                    return henkilot;
                }
            }
        }
        //catch
        //{
        //    throw;
        //}

        private static string GetMysqlConnectionString(string password)
        {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            string Server = "mysql.labranet.jamk.fi";
            string UserID = "L4538";
            string Password = password;
            string Database = "L4538_3";
            return "Server=" + Server + ";Database=" + Database + ";UID=" + UserID + ";Password=" + Password;

        }
        public static ObservableCollection<Palokunta> LoadPalokunnatFromMysql(string password)
        {
            //try
            //{
            ObservableCollection<Palokunta> palokunnat = new ObservableCollection<Palokunta>();
            //luodaan yhteys labranetin mysql-palvelimelle
            string connStr = GetMysqlConnectionString(password);
            string sql = "SELECT palokuntaid, tyyppi, paikkakunta, alue FROM palokunta";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Palokunta s = new Palokunta();

                        s.PalokuntaID = reader.GetString(0);
                        s.Tyyppi = reader.GetString(1);
                        s.paikkakunta = reader.GetString(2);
                        s.alue = reader.GetString(3);

                        palokunnat.Add(s);
                    }
                    return palokunnat;
                }
            }
        }
        public static ObservableCollection<Tyosuoritus> LoadTyotFromMysql(string password)
        {
            //try
            //{
            ObservableCollection<Tyosuoritus> tyot = new ObservableCollection<Tyosuoritus>();
            //luodaan yhteys labranetin mysql-palvelimelle
            string connStr = GetMysqlConnectionString(password);
            string sql = "SELECT tyosuoritus.* FROM tyosuoritus";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tyosuoritus s = new Tyosuoritus();

                        s.TyosuoritusID = reader.GetString(0);
                        s.henkilo = reader.GetString(1);

                        tyot.Add(s);
                    }
                    return tyot;
                }
            }
        }
    }

}

