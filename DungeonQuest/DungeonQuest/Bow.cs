using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace DungeonQuest
{
  public class Bow:Weapon
    {
        //public static new int hitPoint=10;

        //public Bow(int hitPoint, Player oyuncu, PictureBox weaponPic,Point location):base(hitPoint,oyuncu,weaponPic,location)
        //{

        //}
        public Bow(int hitPoint)
        {
           this.hitPoint = hitPoint; //bunun yerine axe geldi. hitpoint= 5
        }
    }
}
