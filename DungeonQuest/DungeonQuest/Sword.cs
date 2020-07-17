using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace DungeonQuest
{
    class Sword:Weapon
    {
       
        public Sword(int hitPoint)
        {
            this.hitPoint = hitPoint;  //HP 3
        }
    }
}
