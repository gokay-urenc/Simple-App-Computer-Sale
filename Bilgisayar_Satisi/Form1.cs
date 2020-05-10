using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilgisayar_Satisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bilgisayar bilgisayar = new Bilgisayar();
        private void Form1_Load(object sender, EventArgs e)
        {
            List<int> gelen_ramlar = bilgisayar.RamDoldur();
            foreach (var item in gelen_ramlar)
            {
                cmbRam.Items.Add(item);
            }
            HDD_Listesi();
        }

        void HDD_Listesi()
        {
            List<string> hdd_sayilari = new List<string>() { "250 GB", "500 GB", "1 TB", "2 TB" };
            foreach (var hdd in hdd_sayilari)
            {
                cmbHDD.Items.Add(hdd);
            }
        }


        List<Bilgisayar> urunlerim = new List<Bilgisayar>();
        string ListeyeEkle(Bilgisayar parametre)
        {
            urunlerim.Add(parametre);
            return "Eklendi.";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Bilgisayar yeniPC = new Bilgisayar();
            yeniPC.anakart = txtAnakart.Text;
            yeniPC.marka = txtMarka.Text;
            yeniPC.ram = (int)cmbRam.SelectedItem;
            yeniPC.hdd = (string)cmbHDD.SelectedItem;
            string mesaj = ListeyeEkle(yeniPC);
            MessageBox.Show(mesaj);
            listBox1.Items.Clear();
            foreach (var urun_listesi in urunlerim)
            {
                listBox1.Items.Add(urun_listesi);
            }
        }

        Bilgisayar secilenPC;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilenPC = listBox1.SelectedItem as Bilgisayar;
            txtAnakart.Text = secilenPC.anakart;
            txtMarka.Text = secilenPC.marka;
            cmbRam.SelectedItem = secilenPC.ram;
            cmbHDD.SelectedItem = secilenPC.hdd;
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            // Referanslar aynı olduğu için listedeki veriye değişiklikler etki etmiştir.
            secilenPC.marka = txtMarka.Text;
            secilenPC.anakart = txtAnakart.Text;
            secilenPC.ram = (int)cmbRam.SelectedItem;
            secilenPC.hdd = (string)cmbHDD.SelectedItem;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            urunlerim.Remove(secilenPC);
            listBox1.Items.Clear();
            foreach (var item in urunlerim)
            {
                listBox1.Items.Add(item);
            }
        }
    }
}