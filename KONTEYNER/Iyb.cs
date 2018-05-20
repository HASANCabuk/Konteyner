using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONTEYNER
{
    interface Iyb
    {
        void Yukle(string gAdi ,double agirlik,Gonderi.IcerikTuru tur);
        void Bosalt(string gAdi,double agirlik,Gonderi.IcerikTuru tur);
    }
}
