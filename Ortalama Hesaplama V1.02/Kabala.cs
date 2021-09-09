using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ortalama_Hesaplama_V1._02
{
    public partial class Kabala : Form
    {
        public Kabala()
        {
            InitializeComponent();
        }
        private void Kabala_Load(object sender, EventArgs e)
        {
            kisisayisibox.SelectedIndex = 0;
        }
        //1. Tartım verileri
        public double tartim1kg;        
        public double tartim1kasa;
        public double tartim1palet;
        public double tartim1boskasa;        
        //2. Tartım verileri
        public double tartim2kg;
        public double tartim2kasa;        
        public double tartim2palet;
        public double tartim2kasadara;
        public double tartim2paletdara;
        //Diğer veriler
        public double dolukasa;
        public double kisisayisi;
        public double kisilerkasatoplam;
        public double tartim1ort;
        public double tartim2ort;
        public double netkgort;
        public double toplamkasadara;
        public double toplampaletdara;
        public double tartim1kisi1;
        public double tartim1kisi2;
        public double tartim1kisi3;
        public double tartim1kisi4;
        public double tartim1kisi5;
        public double tartim2kisi1;
        public double tartim2kisi2;
        public double tartim2kisi3;
        public double tartim2kisi4;
        public double tartim2kisi5;
        public double kisikasa1;
        public double kisikasa2;
        public double kisikasa3;
        public double kisikasa4;
        public double kisikasa5;
        public double netkg1kisi1;
        public double netkg1kisi2;
        public double netkg1kisi3;
        public double netkg1kisi4;
        public double netkg1kisi5;
        public double tartim1detaytoplam;
        public double tartim2detaytoplam;
        public double netkgtoplam;
        public double daratoplam;
        public double tartim2darali;

        public double dolukasabul(double tartim1kasasi, double tartim1boskasasi){ double sonuc = Math.Round(tartim1kasasi - tartim1boskasasi, 4); return sonuc; } 
        public double tartim1ortbul(double tartim1kgsi, double dolukasasi) { double sonuc = Math.Round(tartim1kgsi / dolukasasi, 4); return sonuc; }
        public double tartim2ortbul(double tartim2kgsi, double dolukasasi) { double sonuc = Math.Round(tartim2kgsi / dolukasasi, 4); return sonuc; }
        public double tartim1detaybul(double kisikasasi, double tartim1ortalamasi) { double sonuc = Math.Round(kisikasasi * tartim1ortalamasi, 4); return sonuc; }
        public double tartim2detaybul(double kisikasasi, double tartim2ortalamasi) { double sonuc = Math.Round(kisikasasi * tartim2ortalamasi, 4); return sonuc; }
        public double netkgbul(double detay1toplam, double detay2toplam) { double sonuc = Math.Round(detay1toplam - detay2toplam, 0); return sonuc; }
        public double netkgortbul(double netkgtoplami, double dolukasasi) { double sonuc = Math.Round(netkgtoplami / dolukasasi, 4); return sonuc; }
        public double netkgdetaybul(double kisikasasi, double netkgortalamasi) { double sonuc = Math.Round(kisikasasi * netkgortalamasi, 0); return sonuc; }
        public double kasadarabul(double kasadara, double toplamkasasi) { double sonuc = Math.Round(kasadara * toplamkasasi, 4); return sonuc; }
        public double paletdarabul(double paletdara, double toplampaleti) { double sonuc = Math.Round(paletdara * toplampaleti, 4); return sonuc; }

        private void tartim1hesaplabutton_Click(object sender, EventArgs e)
        {
            //gerekli bilgiler
            tartim1kasa = Convert.ToDouble(tartimkasa1.Text);
            tartim1palet = Convert.ToDouble(tartimpalet1.Text);
            tartim1boskasa = Convert.ToDouble(tartimbos1.Text);
            tartim1kg = Convert.ToDouble(tartimkg1.Text);
            kisikasa1 = Convert.ToDouble(kisi1kasa.Text);
            kisikasa2 = Convert.ToDouble(kisi2kasa.Text);
            kisikasa3 = Convert.ToDouble(kisi3kasa.Text);
            kisikasa4 = Convert.ToDouble(kisi4kasa.Text);
            kisikasa5 = Convert.ToDouble(kisi5kasa.Text);
            tartim2kg = Convert.ToDouble(tartimkg2.Text);


            


            //dolu kasa sayısı hesaplama
            dolukasa = dolukasabul(tartim1kasa, tartim1boskasa);
            dolukasasayisi.Text = dolukasa.ToString();

            //1. tartım ortalaması
            tartim1ort = tartim1ortbul(tartim1kg, dolukasa);
            tartimort1.Text = tartim1ort.ToString();
            
            //1. tartım detayları
            var kisikasalist = new List<double>() { kisikasa1, kisikasa2, kisikasa3, kisikasa4, kisikasa5 };
            var kisisonuclist = new List<TextBox>() { kisi1detay1, kisi2detay1, kisi3detay1, kisi4detay1, kisi5detay1 };
            for (int i = 0; i< kisikasalist.Count; i++)
            {                
                double kasa = kisikasalist[i];                
                double tartim1sonuc = tartim1detaybul(kasa, tartim1ort);                              
                kisisonuclist[i].Text = tartim1sonuc.ToString();                
            }
            detay1toplam.Text = Math.Round(Convert.ToDouble(kisi1detay1.Text) + Convert.ToDouble(kisi2detay1.Text) + Convert.ToDouble(kisi3detay1.Text) + Convert.ToDouble(kisi4detay1.Text) + Convert.ToDouble(kisi5detay1.Text), 0).ToString();

            //2. tartım kasasız yapıldıysa
            if (tartimkasasizcheck.Checked == true)
            {                
                double kdara = Convert.ToDouble(tartimkasadara.Text);
                double pdara = Convert.ToDouble(tartimpaletdara.Text);
                tartim2kasadara = kasadarabul(kdara, tartim1kasa);
                tartim2paletdara = paletdarabul(pdara, tartim1palet);
                toplamkasadarabox.Text = tartim2kasadara.ToString();
                toplampaletdarabox.Text = tartim2paletdara.ToString();
                daratoplam = Math.Round(tartim2kasadara + tartim2paletdara, 4);
                toplamdarabox.Text = daratoplam.ToString();
                tartim2kg = Convert.ToDouble(tartimkg2.Text) + daratoplam;
                MessageBox.Show(tartim2kg.ToString());
            }

            //2. tartım ortalaması
            tartim2ort = tartim2ortbul(tartim2kg, dolukasa);
            tartimort2.Text = tartim2ort.ToString();

            //2. tartım detayları
            //var kisikasalist2 = new List<double>() { kisikasa1, kisikasa2, kisikasa3, kisikasa4, kisikasa5 };
            var kisisonuclist2 = new List<TextBox>() { kisi1detay2, kisi2detay2, kisi3detay2, kisi4detay2, kisi5detay2 };
            for (int i2 = 0; i2 < kisikasalist.Count; i2++)
            {
                double kasa2 = kisikasalist[i2];
                double tartim2sonuc = tartim2detaybul(kasa2, tartim2ort);
                kisisonuclist2[i2].Text = tartim2sonuc.ToString();
            }
            detay2toplam.Text = Math.Round(Convert.ToDouble(kisi1detay2.Text) + Convert.ToDouble(kisi2detay2.Text) + Convert.ToDouble(kisi3detay2.Text) + Convert.ToDouble(kisi4detay2.Text) + Convert.ToDouble(kisi5detay2.Text), 0).ToString();
            
            //net kg ortalaması
            netkgtoplambox.Text = Math.Round(Convert.ToDouble(detay1toplam.Text) - Convert.ToDouble(detay2toplam.Text), 0).ToString();
            netkgort = netkgortbul(Convert.ToDouble(netkgtoplambox.Text), dolukasa);
            tartimortnet.Text = netkgort.ToString();

            //net kg detayları
            var kisisonuclist3 = new List<TextBox>() { kisi1netkg, kisi2netkg, kisi3netkg, kisi4netkg, kisi5netkg };
            for (int i3 =0; i3 < kisikasalist.Count; i3++)
            {
                double kasa3 = kisikasalist[i3];
                double netkgsonuc = netkgdetaybul(kasa3, netkgort);
                kisisonuclist3[i3].Text = netkgsonuc.ToString();
            }
        }

        private void kisisayisibox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //kişi sayısına göre texbox açma kapama
            if (kisisayisibox.SelectedIndex == 0){ kisi1kasa.ReadOnly = false; kisi2kasa.ReadOnly = false; kisi3kasa.ReadOnly = true; kisi4kasa.ReadOnly = true; kisi5kasa.ReadOnly = true; kisi3kasa.Text = "0"; kisi4kasa.Text = "0"; kisi5kasa.Text = "0"; }
            else if (kisisayisibox.SelectedIndex == 1) { kisi1kasa.ReadOnly = false; kisi2kasa.ReadOnly = false; kisi3kasa.ReadOnly = false; kisi4kasa.ReadOnly = true; kisi5kasa.ReadOnly = true; kisi4kasa.Text = "0"; kisi5kasa.Text = "0"; }
            else if (kisisayisibox.SelectedIndex == 2) { kisi1kasa.ReadOnly = false; kisi2kasa.ReadOnly = false; kisi3kasa.ReadOnly = false; kisi4kasa.ReadOnly = false; kisi5kasa.ReadOnly = true; kisi5kasa.Text = "0"; }
            else { kisi1kasa.ReadOnly = false; kisi2kasa.ReadOnly = false; kisi3kasa.ReadOnly = false; kisi4kasa.ReadOnly = false; kisi5kasa.ReadOnly = false; }
        }

        private void kisi1kasa_TextChanged(object sender, EventArgs e)
        {
            if(kisi1kasa.Text == "") { kisi1kasa.Text = "0"; }
            else if (kisi2kasa.Text == "") { kisi2kasa.Text = "0"; }
            else if (kisi3kasa.Text == "") { kisi3kasa.Text = "0"; }
            else if (kisi4kasa.Text == "") { kisi4kasa.Text = "0"; }
            else if (kisi5kasa.Text == "") { kisi5kasa.Text = "0"; }
            kisikasa1 = Convert.ToDouble(kisi1kasa.Text);
            kisikasa2 = Convert.ToDouble(kisi2kasa.Text);
            kisikasa3 = Convert.ToDouble(kisi3kasa.Text);
            kisikasa4 = Convert.ToDouble(kisi4kasa.Text);
            kisikasa5 = Convert.ToDouble(kisi5kasa.Text);
            kisikasatoplam.Text = (kisikasa1 + kisikasa2 + kisikasa3 + kisikasa4 + kisikasa5).ToString();
        }

        private void tartimkg1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber((char)e.KeyChar) || e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if (tartimkg1.Text == "") { tartimkg1.Text = "0"; }
            else if (tartimkasa1.Text == "") { tartimkasa1.Text = "0"; }
            else if (tartimpalet1.Text == "") { tartimpalet1.Text = "0"; }
            else if (tartimbos1.Text == "") { tartimbos1.Text = "0"; }
            else if (tartimkg2.Text == "") { tartimkg2.Text = "0"; }
            else if (tartimkasa2.Text == "") { tartimkasa2.Text = "0"; }
            else if (tartimpalet2.Text == "") { tartimpalet2.Text = "0"; }  
            else if (tartimkasadara.Text == "") { tartimkasadara.Text = "0"; }
            else if (tartimpaletdara.Text == "") { tartimpaletdara.Text = "0"; }
        }

        private void tartimkasasizcheck_CheckedChanged(object sender, EventArgs e)
        {
            if(tartimkasasizcheck.Checked == true) { tartimkasadara.ReadOnly = false; tartimpaletdara.ReadOnly = false; }
            else { tartimkasadara.ReadOnly = true; tartimpaletdara.ReadOnly = true; tartimkasadara.Text = "0"; tartimpaletdara.Text = "0"; }
        }
    }
}
