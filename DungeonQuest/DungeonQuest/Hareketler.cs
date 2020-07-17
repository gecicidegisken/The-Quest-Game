using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace DungeonQuest
{
  public class Hareketler
    {
        public int hareketMesafesi = 20;
        public Point location;
        //yakinlik olcen fonksiyon. Parametre olaarak iki noktayı alıyor ve belli mesafelerde mi değil mi kontrol ediyor
        //public bool yakinlikOlcer(Point ilkLocation, Point ikinciLocation, int distanceX, int distanceY)
        //{
        //    if (Math.Abs(ilkLocation.X - ikinciLocation.X) < distanceX && Math.Abs(ilkLocation.Y - ikinciLocation.Y) < distanceY)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

       
        public Point hareketEt(Yonler yon)
        {
            Point newLocation = location;
            switch (yon)
            {
                case Yonler.Up:
                    if (newLocation.Y - hareketMesafesi >=47)
                    {
                        newLocation.Y -= hareketMesafesi;
                    }
                    break;
                case Yonler.Down:
                    if (newLocation.Y + hareketMesafesi <=268)
                    {
                        newLocation.Y += hareketMesafesi;
                    }
                    break;
                case Yonler.Left:
                    if (newLocation.X - hareketMesafesi >= 35)
                    {
                        newLocation.X -= hareketMesafesi;
                    }
                    break;
                case Yonler.Right:
                    if (newLocation.X + hareketMesafesi <= 729)
                    {
                        newLocation.X += hareketMesafesi;
                    }
                    break;
                default: break;
            }
            return newLocation;
        }

        
    }
}
