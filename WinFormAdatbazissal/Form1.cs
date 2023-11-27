using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;

namespace WinFormAdatbazissal
{
    public partial class Form1 : Form
    {
        //Csatlakozás -- Osztályváltozó -- Tudjuk máshol is használni
        MySqlConnection connection = null;

        //Command -- Osztályváltozó -- Tudjuk máshol is használni
        MySqlCommand command = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Kapcsolat kialakítása
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Clear();
            sb.Server = "localhost";
            sb.UserID = "root";
            sb.Password = "";
            sb.Database = "tagdij";

            connection = new MySqlConnection(sb.ConnectionString);
            command = connection.CreateCommand();

            TagokBetoltese();
        }

        private void TagokBetoltese()
        {
            //Lista tisztítása
            listBox_Tagok.Items.Clear();

            //Kapcsolat kialakítása

            //Csatlakozás

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    //Ha sikeres a csatlakohzás
                    connection.Open();
                }
                
                command.CommandText = "SELECT `azon`,`nev`,`szulev`,`irszam`,`orsz` FROM `ugyfel` WHERE 1 ORDER BY nev;";    //SQL utasítás
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())   //Beolvas, és ha talál, akkor ki is írja
                    {
                        Tag beolvasottTag = new Tag(dr.GetInt32("azon"), dr.GetString("nev"), dr.GetInt32("szulev"), dr.GetInt32("irszam"), dr.GetString("orsz"));
                        listBox_Tagok.Items.Add(beolvasottTag);   //Értékek kiírása
                    }
                }
            }
            catch (MySqlException ex)
            {
                //Ha sikertelen a csatlakozás
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
        }

        private void listBox_Tagok_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_Tagok.SelectedIndex < 0)
            {
                return;     //Befejezés
            }
            Tag kivalaszottTag = listBox_Tagok.SelectedItem as Tag;     //'as Tag' -- objektummá alakítás

            //Értékek kiírása a megfelelő mezőkbe
            textBox_Azonosito.Text = kivalaszottTag.azon.ToString();    
            textBox_Nev.Text = kivalaszottTag.nev.ToString();
            numericUpDown_Iranyitoszam.Value = kivalaszottTag.irszam;
            numericUpDown_SzuletesiEv.Value = kivalaszottTag.szulev;
            textBox_Orszagkod.Text = kivalaszottTag.orsz;
        }

        private void button_Letrehoz_Click(object sender, EventArgs e)
        {
            //A viteli mezőkben lévő adatok ellenőrzése
            if (string.IsNullOrEmpty(textBox_Nev.Text))
            {
                MessageBox.Show("Nincs név megadva!");
                return;     //Befejezés
            }
            //A többinél is meg lehet adni....

            //Értékek megadása
            string nev = textBox_Nev.Text;
            decimal szulev = numericUpDown_SzuletesiEv.Value;
            decimal irszam = numericUpDown_Iranyitoszam.Value;
            string orsz = textBox_Orszagkod.Text;

            //Létrehozás utasítás
            command.CommandText = "INSERT INTO `ugyfel`(`azon`, `nev`, `szulev`, `irszam`, `orsz`) VALUES (NULL, @nev, @szulev, @irszam, @orsz)"; //'@' - jelezzük a programnak, hogy később küldjük az értékét
            command.Parameters.Clear(); //Ha esetleg valami benne maradt volna, akkor tisztítunk
            command.Parameters.AddWithValue("@nev", nev);
            command.Parameters.AddWithValue("@szulev", szulev);
            command.Parameters.AddWithValue("@irszam", irszam);
            command.Parameters.AddWithValue("@orsz", orsz);
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();  //Kapcsolat nyitása, ha nincs nyitva
                }
                command.ExecuteNonQuery();  //Parancs futtatása
                MessageBox.Show("Sikeres rögzítés!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            textBox_Nev.Text = "";
            numericUpDown_Iranyitoszam.Value = numericUpDown_Iranyitoszam.Minimum;
            numericUpDown_SzuletesiEv.Value = numericUpDown_SzuletesiEv.Minimum;
            textBox_Orszagkod.Text = "";

            TagokBetoltese();
        }

        private void button_Modosit_Click(object sender, EventArgs e)
        {

        }
    }
}
