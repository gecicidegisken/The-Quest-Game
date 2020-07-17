using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DungeonQuest
{
    class Bat:Enemy
    {
        public static new int health=20;  //hitpoint 3
       

        public override void Attack(PictureBox enemyPic, PictureBox playerPic)
        {

            if (enemyPic.Bounds.IntersectsWith(playerPic.Bounds))

                this.hitPoint = 3;

             else
                this.hitPoint = 0;

                Player.health -= this.hitPoint;
            
        }
      
        public override void Move(PictureBox enemyPic)
        {
            
            var rnd = new Random();
            location = enemyPic.Location;
            enemyPic.Location = hareketEt(FindPlayerDirection(player.location));  
            //findPlayerDirection konumundan dönen yöne gitmesi için override edildi. 
        }
    }
}
