using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KONTEYNER
{
    public partial class Form2 : Form
    {
        //sınıflar
        BasitKntynr bstK;
        OzelKntynr ozlK;
        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start(); //giris nesnelerini kontrol için baslatılmıs timer 
            bstK  =new BasitKntynr(this); //richTextBox1 bilgi vermek için
          ozlK = new OzelKntynr(this);
        }
        public Form2()
        {
            InitializeComponent();
        }
        //tüm bilgileri tutan değişkenler
        string gIsim, gSoyisim, gAdres, gSehir, gTel;
        string aİsim, aSoyisim, aAdres, aSehir, aTel;
        double agirlik;
        string icerikTuru, kntynrTuru;
        Gonderi.IcerikTuru Icerikturu;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer ile girilen değerlerin kontrolü sağlandı
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || G_sehir.Text == ""||
              textBox5.Text == "" || comboBox1.Text == ""|| textBox9.Text == "" || textBox8.Text == "" || textBox7.Text == "" || textBox6.Text == "" || A_sehir.Text == "")
            {
              
                        groupBox5.Visible = false;                
                
            }
            else groupBox5.Visible = true;

        }
        // keypres olayları ile gereksiz karakterlerin girilmesi engellendi
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)//isim
        {
            e.Handled = char.IsNumber(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar);
        }

        private void kAPATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)//soyisim
        {
            e.Handled = char.IsNumber(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsSeparator(e.KeyChar) || char.IsPunctuation(e.KeyChar);
        }           
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)//telefon no
        {
            e.Handled = char.IsSymbol(e.KeyChar) || char.IsLetter(e.KeyChar)||char.IsSeparator(e.KeyChar);
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)//agirlik
        {
            e.Handled = char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar)|| char.IsSeparator(e.KeyChar);
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)//alici telefon no
        {
            e.Handled = char.IsSymbol(e.KeyChar) || char.IsLetter(e.KeyChar)|| char.IsSeparator(e.KeyChar);
        }
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)//alıcı soyisim
        {
            e.Handled = char.IsNumber(e.KeyChar) || char.IsSymbol(e.KeyChar)|| char.IsSeparator(e.KeyChar) || char.IsPunctuation(e.KeyChar);
        }
        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)//alıcı ism
        {
            e.Handled = char.IsNumber(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar);
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //kontrollerin görünürlüğü ayarlandı
            if (comboBox1.Text=="NORMAL")
            {
                label8.Visible = true;
                comboBox2.Visible = true;
                richTextBox1.Visible = true;
            }
            else
            {
                label8.Visible = false;
                comboBox2.Visible = false;
                richTextBox1.Visible = true;
            }
        }
        Gonderi gndr;
        private void button1_Click(object sender, EventArgs e)
        {
           // bilgileri alma yükleme ve boşaltma işlemleri yapılır .
            gIsim = textBox1.Text;
            gSoyisim = textBox2.Text;
            gAdres = textBox3.Text;
            gTel = textBox4.Text;
            gSehir = G_sehir.Text;
            
            agirlik =double.Parse( textBox5.Text);
            icerikTuru = comboBox1.Text;
            if (icerikTuru=="HASSAS")
            {
                kntynrTuru = "ÖZEL KONTEYNER";
            }
            else
            kntynrTuru = comboBox2.Text;
            
            aİsim = textBox9.Text;
            aSoyisim = textBox8.Text;
            aAdres = textBox7.Text;
            aTel = textBox6.Text;
            aSehir = A_sehir.Text;
           
            if (icerikTuru=="HASSAS")
            {
                Icerikturu = Gonderi.IcerikTuru.HASSAS;

            }
            else
            {
                Icerikturu = Gonderi.IcerikTuru.NORMAL;
            }          
             gndr = new Gonderi(gIsim, gSoyisim, gAdres, gSehir, gTel//gönderi sınfına girdi gönderildi constructor dain
                , aİsim, aSoyisim, aAdres, aSehir, aTel, agirlik
                , kntynrTuru,Icerikturu,this,bstK,ozlK);
           
        }
    }
}
