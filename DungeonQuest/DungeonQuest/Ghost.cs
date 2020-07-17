using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonQuest
{
    class Ghost:Enemy
    {
        public static new int health = 25;  // hitpoint 5
        public override void Attack(PictureBox enemyPic, PictureBox playerPic)
        {

            if (enemyPic.Bounds.IntersectsWith(playerPic.Bounds))

            {
                this.hitPoint = 5;

            }

            else
                this.hitPoint = 0;

            Player.health -= this.hitPoint;

        }
    }
}
