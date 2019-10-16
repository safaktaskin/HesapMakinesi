using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HesapMakinesi
{
    public partial class Form1 : Form
    {
        bool optDurum = false; //operatör durumunu kontrol etmek amacıyla oluşturuldu.
        double sonuc = 0;
        string opt = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void RakamOlay(object sender, EventArgs e)
        {
            if (txtSonuc.Text == "0" || optDurum) 
                txtSonuc.Clear(); //Başta gelen 0'ı engellemek için yazıldı.

            optDurum = false;
            Button btn = (Button)sender;
            txtSonuc.Text += btn.Text; //Butonun yazısını txt alanına yazdıracak.
        }

        private void OptHesap(object sender, EventArgs e)
        {
            optDurum = true; //herhangi bir operatöre basılacağı için. 
            Button btn = (Button)sender;
            string yeniOpt = btn.Text; //Yeni operatör bilgisini tutmak için. 

            lbSonuc.Text = lbSonuc.Text + " " + txtSonuc.Text + " " + yeniOpt; //yapılan işlemi görmek amacıyla yazıldı.
            switch(opt) //Eski operatör bilgisini alıp işleme tabi tutulacak.
            {
                case "+": txtSonuc.Text = (sonuc + Double.Parse(txtSonuc.Text)).ToString(); break;
                case "-": txtSonuc.Text = (sonuc - Double.Parse(txtSonuc.Text)).ToString(); break;
                case "*": txtSonuc.Text = (sonuc * Double.Parse(txtSonuc.Text)).ToString(); break;
                case "/": txtSonuc.Text = (sonuc / Double.Parse(txtSonuc.Text)).ToString(); break;
            }

            sonuc = Double.Parse(txtSonuc.Text); //Son işlem sonucunu aktarma.
            txtSonuc.Text = sonuc.ToString(); //İşlem gerçekleştirildikten sonra sonucunu yazdırmak için kullanıyoruz.
            opt = yeniOpt;

        }

        private void button5_Click(object sender, EventArgs e) // ce
        {
            txtSonuc.Text = "0"; //text kutusundaki değerini sıfırlıyor.
        }

        private void button6_Click(object sender, EventArgs e) // c
        {
            txtSonuc.Text = "0";
            lbSonuc.Text = ""; //labeldaki bilgi temizleniyor.
            opt = ""; //hafızadaki operatör bilgisini temizliyor.
            sonuc = 0;
            optDurum = false;
        }

        private void button11_Click(object sender, EventArgs e) // eşittir " = "
        {
            lbSonuc.Text = ""; 
            optDurum = true;
            switch (opt)
            {
                case "+": txtSonuc.Text = (sonuc + Double.Parse(txtSonuc.Text)).ToString(); break;
                case "-": txtSonuc.Text = (sonuc - Double.Parse(txtSonuc.Text)).ToString(); break;
                case "*": txtSonuc.Text = (sonuc * Double.Parse(txtSonuc.Text)).ToString(); break;
                case "/": txtSonuc.Text = (sonuc / Double.Parse(txtSonuc.Text)).ToString(); break;
            }

            sonuc = Double.Parse(txtSonuc.Text);
            txtSonuc.Text = sonuc.ToString();
            opt = "";
        }

        private void button18_Click(object sender, EventArgs e) // virgül " , "
        {
            
            if(txtSonuc.Text=="0") //başta 0 varsa,
            {
                txtSonuc.Text = "0"; // 0 olarak kalsın.
            }
            else if(optDurum) //operatöre basılmış mı onu kontrol etmemiz gerekiyor ve basıldıktan sonra
            {
                txtSonuc.Text = "0"; //defalarca 0'a basmasını engellemek amacıyla yazılır.
            }

            if(!txtSonuc.Text.Contains(",")) //eğer sonuç text " , " ifadesini içermiyorsa,
            {
                txtSonuc.Text += ","; //ondalıklı sayıyı eklesin.
            }
            optDurum = false;
        }
    }
}
