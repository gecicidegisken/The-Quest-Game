using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonQuest
{
   
    class Ghoul:Enemy
    {
        public static new int health = 30; //hitpoint 6
        public override void Attack(PictureBox enemyPic, PictureBox playerPic)
        {
            if (enemyPic.Bounds.IntersectsWith(playerPic.Bounds))

            {
                this.hitPoint = 10;

            }

            else
                this.hitPoint = 0;

            Player.health -= this.hitPoint;

        }
        public override void Move(PictureBox enemyPic)
        {

            var rnd = new Random();
            location = enemyPic.Location;
            enemyPic.Location = hareketEt(FindPlayerDirection(player.location));
        }
    }
}
