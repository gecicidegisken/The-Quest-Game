using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace DungeonQuest
{
    class Mace : Weapon
    {
        //public Mace(int hitPoint, Player oyuncu, PictureBox weaponPic,Point location) : base(hitPoint, oyuncu, weaponPic,location)
        //{

        //}
        public Mace(int hitPoint)
        {
            this.hitPoint = hitPoint;  //hp 6
        }
    }
}
