using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
namespace KONTEYNER
{
    class BasitKntynr
    {
       
       protected Form2 yaz; //form2 formuna ait erişim
        double bosAgirlik = 150, kapasite = 1000, depo=0;// agirliklar kg cinsindendir.
        double birimFiyat = 500;//fiyat dolar cinsindendir.
       // kişi bilgilerinin tutulacağı listeler
        ArrayList isimList = new ArrayList();
        ArrayList agirlikList = new ArrayList();
        protected int  a;
        public BasitKntynr(Form2 f)
        {
            //çok kıymetli constructor metodu 
            yaz = f;
        }

       
       public virtual  void  Yukle(string gIsmi, string gsoyisimi,double agirlik,Gonderi.IcerikTuru durum)
        {
            //basit konteyner için yükle metodu
            if (agirlik>kapasite)//gelen agirlik kapasiteden büyük ise mesaj verildi
            {
                MessageBox.Show("Yükleme başarısız");
            }
            else
            {
                bool mevcut=false; 
                for (int i = 0; i < isimList.Count; i++)
                {

                    if (isimList[i].ToString() == gIsmi + " " + gsoyisimi)
                    {  
                        mevcut = true;
                       a = i;
                        depo += agirlik;
                        kapasite -= agirlik;
                        agirlikList[i] = Convert.ToDouble(agirlikList[i].ToString()) + agirlik;
                        break;
                    }                                       
                }
                if (mevcut == false)
                {
                    isimList.Add(gIsmi + " " + gsoyisimi);
                    agirlikList.Add(agirlik);
                    kapasite -= agirlik;
                    depo += agirlik;
                    a = isimList.Count-1;
                }
                YukleYazdir(gIsmi, Convert.ToDouble(agirlikList[a].ToString()));
            }
            
        }
        public virtual void Bosalt(string gIsmi, string gsoyismi, double agirlik, Gonderi.IcerikTuru durum)
        {
            //basit konteyner için boşalt metodu       
            for (int i = 0; i < isimList.Count; i++)
            {

                if (isimList[i].ToString() == gIsmi + " " + gsoyismi)
                {
                    if (Convert.ToDouble(agirlikList[i].ToString()) == agirlik)
                    {
                        depo -= agirlik;
                        kapasite += agirlik;
                        agirlikList.RemoveAt(i);
                        isimList.RemoveAt(i);
                        BosaltYazdir(gIsmi, 0);
                        break;
                    }
                    else if (Convert.ToDouble(agirlikList[i].ToString()) > agirlik)
                    {
                        depo -= agirlik;
                        kapasite += agirlik;
                        agirlikList[i] = Convert.ToDouble(agirlikList[i].ToString()) - agirlik;
                        BosaltYazdir(gIsmi, Convert.ToDouble(agirlikList[i].ToString()));
                        break;
                    }
                    else
                        yaz.richTextBox1.Text = "Fazla miktar girdiniz";
                }
            }
        }   
       public virtual void YukleYazdir(string isim,double tplmAgirlik)
        {
           //kullanıcıya yükleme bilgisini veren metod
            yaz.richTextBox1.Text=(String.Format("{0} bey/hanım {1} kg agırlıgındaki ürününüz {2} fiyatıyla basit konteyner da tasınmaktadır", isim,tplmAgirlik, (tplmAgirlik * birimFiyat)));
        }
        public virtual void BosaltYazdir(string isim, double agirlik)
        {
            //kullanıcıya boşaltma bilgisini veren metod
            yaz.richTextBox1.Text = (String.Format("{0} bey/hanım konteynerde {1} kg ürününüz kalmıştır",isim,agirlik));
        }
    }
}
