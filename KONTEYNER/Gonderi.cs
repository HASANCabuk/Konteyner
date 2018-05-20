using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONTEYNER
{
    class Gonderi
    {
        //siniflar kullanılmak üzere oluşturuldu referans tipinde
        BasitKntynr bst;
        OzelKntynr ozl;
        protected Form2 f;
      
        string gIsim, gSoyisim, gAdres, gSehir, gTel;
        string aİsim, aSoyisim, aAdres, aSehir, aTel;
        double agirlik;
        string kntynrTuru;
        //enum kullanıldı.
      public enum IcerikTuru
        {
            HASSAS,
            NORMAL
        }
        IcerikTuru icerikturu;
        public Gonderi(string gIsim,string gSoyisim,string gAdres,string gSehir,string gTel
            ,string aİsim,string aSoyisim, string aAdres, string aSehir, string aTel,
            double agirlik, string kntynrTuru, IcerikTuru icerikturu,Form2 form,BasitKntynr bst,OzelKntynr ozl)
        {
            f = form;
            this.bst = bst;
            this.ozl = ozl;
            this.gIsim = gIsim;
            this.gSoyisim = gSoyisim;
            this.gAdres = gAdres;
            this.gSehir = gSehir;
            this.gTel = gTel;
            this.aİsim = aİsim;
            this.aSoyisim = aSoyisim;
            this.aAdres = aAdres;
            this.aSehir = aSehir;
            this.aTel = aTel;
            this.agirlik = agirlik;
            this.kntynrTuru = kntynrTuru;
            this.icerikturu = icerikturu;
            if (f.radioButton1.Checked)//constructor dan gelen bilgiler kontrolünde  konteynır sınıflarındaki yükle ve boşalt metotları kullanıldı
            {
                if (kntynrTuru == "ÖZEL KONTEYNER")
                {
                    ozl.Yukle(gIsim,gSoyisim, agirlik,icerikturu);
                }
                else
                {
                    bst.Yukle(gIsim,gSoyisim, agirlik, icerikturu);
                }
            }
            else
            {
                if (kntynrTuru == "ÖZEL KONTEYNER")
                {

                    ozl.Bosalt(gIsim,gSoyisim, agirlik, icerikturu);
                }
                else
                {

                    bst.Bosalt(gIsim,gSoyisim, agirlik, icerikturu);
                }
            }
        }   
        
        
    }
}
