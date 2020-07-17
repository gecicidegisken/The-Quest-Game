using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DungeonQuest
{
    public class Weapon : Hareketler
    {
        public int hitPoint; //silahın gücü
        public Player oyuncu;
        public PictureBox weaponPic;
        public static string name;
        public static bool equipped;
        public int iksirGucu;
        public Weapon()
        {

        }

    }
}
