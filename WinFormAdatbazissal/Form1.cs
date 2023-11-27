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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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
            //Színek beállítása -- Műveletek
            groupBox_Muveletek.BackColor = Color.Red;
            button_Letrehoz.BackColor = Color.FromArgb(200, 0, 0);
            button_Modosit.BackColor = Color.FromArgb(200, 0, 0);
            button_Torles.BackColor = Color.FromArgb(200, 0, 0);
            //Színek beállítása -- Kiválasztott tag
            groupBox_KivalasztottTag.BackColor = Color.FromArgb(255, 218, 155);
            //Színek beállítása -- Tagok
            listBox_Tagok.BackColor = Color.FromArgb(255, 240, 245);

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
            //Megnézzük, hogy melyik ügyfél van kiválasztva
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

            //Létrehozás SQL parancs
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

            //Módosítás után az adatok újratöltése a ListBox-ba
            TagokBetoltese();
        }

        private void button_Modosit_Click(object sender, EventArgs e)
        {
            //Megnézzük, hogy melyik ügyfél van kiválasztva
            if (listBox_Tagok.SelectedIndex < 0)
            {
                MessageBox.Show("Nincs elem kiválasztva!");
                return;
            }

            Tag kivalaszottTag = listBox_Tagok.SelectedItem as Tag;     //'as Tag' -- objektummá alakítás

            //Módosítás előtt azonosító és új értékek lekérése
            int azonosito = kivalaszottTag.azon;
            string ujNev = textBox_Nev.Text;
            decimal ujSzulev = numericUpDown_SzuletesiEv.Value;
            decimal ujIrszam = numericUpDown_Iranyitoszam.Value;
            string ujOrszag = textBox_Orszagkod.Text;

            //Módosítás SQL parancs
            command.CommandText = "UPDATE `ugyfel` SET `nev`=@nev, `szulev`=@szulev, `irszam`=@irszam, `orsz`=@orsz WHERE `azon`=@azon";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@nev", ujNev);
            command.Parameters.AddWithValue("@szulev", ujSzulev);
            command.Parameters.AddWithValue("@irszam", ujIrszam);
            command.Parameters.AddWithValue("@orsz", ujOrszag);
            command.Parameters.AddWithValue("@azon", azonosito);

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                command.ExecuteNonQuery();
                MessageBox.Show("Sikeres módosítás!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            //Módosítás után az adatok újratöltése a ListBox-ba
            TagokBetoltese();
        }

        private void button_Torles_Click(object sender, EventArgs e)
        {
            //Megnézzük, hogy melyik ügyfél van kiválasztva
            if (listBox_Tagok.SelectedIndex < 0)
            {
                MessageBox.Show("Nincs elem kiválasztva!");
                return;
            }

            Tag kivalaszottTag = listBox_Tagok.SelectedItem as Tag;     //'as Tag' -- objektummá alakítás

            //Azonosító lekérése
            int azonosito = kivalaszottTag.azon;

            //Törlés SQL parancs
            command.CommandText = "DELETE FROM `ugyfel` WHERE `azon`=@azon";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@azon", azonosito);

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                command.ExecuteNonQuery();
                MessageBox.Show("Sikeres törlés!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            //Törlés után az adatok újratöltése a ListBox-ba
            TagokBetoltese();
        }
    }
}
