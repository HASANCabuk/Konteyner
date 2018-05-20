using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
namespace KONTEYNER
{

    class OzelKntynr : BasitKntynr
    {
        //basit konteyner clasınndan kalıtılan özel konteynerimiz .
             
        public OzelKntynr(Form2 f):base(f)
        {
            //saygıdeger constructor metodu 
        }
        //aşağıdakiler hassas ve normal için oluşturulan listeler ve konteyner özellikleri
        double bosAgirlikH = 100, kapasiteH = 700, depoH = 0;// agirliklar kg cinsindendir.
        double bosAgirlikN = 125, kapasiteN = 850, depoN = 0;// agirliklar kg cinsindendir.
        double birimFiyatH = 750;//fiyat dolar cinsindendir.
        double birimFiyatN = 600;//fiyat dolar cinsindendir.
        ArrayList isimListH = new ArrayList();
        ArrayList agirlikListH = new ArrayList();
        ArrayList isimListN = new ArrayList();
        ArrayList agirlikListN = new ArrayList();          
        public override  void Yukle(string gIsmi,string gsoyisimi, double agirlik,Gonderi.IcerikTuru durum)
        {

            //ozel konteyner için yükle metodu
            if (durum== Gonderi.IcerikTuru.HASSAS)
            {
                if (agirlik>kapasiteH)
                {
                    MessageBox.Show(durum.ToString()+" durum daki urun özel konteynerınız yüklenemedi");
                }else
                {
                    bool mevcut = false;
                    for (int i = 0; i < isimListH.Count; i++)
                    {

                        if (isimListH[i].ToString() == gIsmi + " " + gsoyisimi)
                        {
                          
                            mevcut = true;
                            base.a = i;
                            depoH += agirlik;
                            kapasiteH -= agirlik;
                            agirlikListH[i] = Convert.ToDouble(agirlikListH[i].ToString()) + agirlik;
                            break;
                        }
                    }
                    if (mevcut == false)
                    {
                        isimListH.Add(gIsmi + " " + gsoyisimi);
                        agirlikListH.Add(agirlik);
                        kapasiteH -= agirlik;
                        depoH += agirlik;
                        base.a = agirlikListH.Count - 1;
                    }
                    YukleYazdir(gIsmi, Convert.ToDouble(agirlikListH[a].ToString()), birimFiyatH);
                }
            }
            else
            {
                if (agirlik > kapasiteN)
                {
                    MessageBox.Show(durum.ToString()+" durum daki urun özel konteynerınız yüklenemedi");
                }
                else
                {
                    bool mevcut = false;
                    for (int i = 0; i < isimListN.Count; i++)
                    {

                        if (isimListN[i].ToString() == gIsmi + " " + gsoyisimi)
                        {
                            mevcut = true;
                            base.a = i;
                            depoN += agirlik;
                            kapasiteN -= agirlik;
                            agirlikListN[i] = Convert.ToDouble(agirlikListN[i].ToString()) + agirlik;
                            break;
                        }
                    }
                    if (mevcut == false)
                    {
                        isimListN.Add(gIsmi + " " + gsoyisimi);
                        agirlikListN.Add(agirlik);
                        kapasiteN -= agirlik;
                        depoN += agirlik;
                        base.a = agirlikListN.Count - 1;
                    }
                    YukleYazdir(gIsmi, Convert.ToDouble(agirlikListN[a].ToString()),birimFiyatN);
                }
            }
        }
        public override void Bosalt(string gIsmi, string gsoyisimi, double agirlik,Gonderi.IcerikTuru durum)
        {
            //özel konteyner için boşalt metodu
            if (durum==Gonderi.IcerikTuru.HASSAS)
            {                         
                    for (int i = 0; i < isimListH.Count; i++)
                    {
                        if (isimListH[i].ToString() == gIsmi + " " + gsoyisimi)
                        {
                            if (Convert.ToDouble(agirlikListH[i].ToString()) == agirlik)
                            {
                                depoH -= agirlik;
                                kapasiteH += agirlik;
                                agirlikListH.RemoveAt(i);
                                isimListH.RemoveAt(i);
                                BosaltYazdir(gIsmi, 0);
                                break;
                            }
                            else if (Convert.ToDouble(agirlikListH[i].ToString()) > agirlik)
                            {
                                depoH -= agirlik;
                                kapasiteH += agirlik;
                                agirlikListH[i] = Convert.ToDouble(agirlikListH[i].ToString()) - agirlik;
                                BosaltYazdir(gIsmi, Convert.ToDouble(agirlikListH[i].ToString()));
                                break;
                            }
                            else
                                base.yaz.richTextBox1.Text = "Fazla miktar girdiniz";
                        }
                      
                    }
                }            
            else
            {             
                    for (int i = 0; i < isimListN.Count; i++)
                    {
                        if (isimListN[i].ToString() == gIsmi + " " + gsoyisimi)
                        {
                            if (Convert.ToDouble(agirlikListN[i].ToString()) == agirlik)
                            {
                                depoN -= agirlik;
                                kapasiteN += agirlik;
                                agirlikListN.RemoveAt(i);
                                isimListN.RemoveAt(i);
                                BosaltYazdir(gIsmi, 0);
                                break;
                            }
                            else if (Convert.ToDouble(agirlikListN[i].ToString()) > agirlik)
                            {
                                depoN -= agirlik;
                                kapasiteN += agirlik;
                                agirlikListN[i] = Convert.ToDouble(agirlikListN[i].ToString()) - agirlik;

                                BosaltYazdir(gIsmi, Convert.ToDouble(agirlikListN[i].ToString()));
                                break;
                            }
                            else
                                base.yaz.richTextBox1.Text = "Fazla miktar girdiniz";
                        }
                       
                    }

                }
            
        }
         public  void YukleYazdir(string isim,double tplmagirlik,double birimFiyat)
        {
            //kullanıcıya yükleme bilgisini veren metod
            base.yaz.richTextBox1.Text = (String.Format("{0} bey/hanım {1} kg agırlıgındaki ürününüz {2} fiyatıyla özel konteyner da tasınmaktadır", isim,tplmagirlik,(tplmagirlik * birimFiyat)));

        }
        public override void BosaltYazdir(string isim, double agirlik)
        {
            //kullanıcıya boşaltma bilgisini veren metod
            base.yaz.richTextBox1.Text = (String.Format("{0} bey/hanım konteynerde {1} kg ürününüz kalmıştır", isim, agirlik));
        }
    }
}
