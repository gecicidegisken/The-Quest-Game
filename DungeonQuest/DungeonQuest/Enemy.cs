using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace DungeonQuest
{
    public class Enemy : Hareketler
    {
        public int health; 
        public int hitPoint; //Vurduğu ya d aldığı darbe
        public static string name;
        public bool alive;
        public PictureBox enemyPic;
        public Player player;
     
        public Enemy()
        {

        }

        public virtual void Attack(PictureBox enemyPic,PictureBox playerPic)
        {
            if (enemyPic.Bounds.IntersectsWith(playerPic.Bounds))

            {
                this.hitPoint = 5;
                
            }

            else
                this.hitPoint = 0;

            Player.health -= this.hitPoint;
            //yan yana oldukları sürece düsmanlar saldırı yapabiliyor. default hitPoint=5
        }

        public virtual void Move(PictureBox enemyPic)
        {
            var rnd = new Random();
            location = enemyPic.Location;
            enemyPic.Location = hareketEt((Yonler)rnd.Next(Enum.GetNames(typeof(Yonler)).Length));
           //random olarak düsmanları hareket ettirir.
        }
        protected Yonler FindPlayerDirection(Point playerLocation)
        {
            Yonler directionToMove;
            if (playerLocation.X > location.X + 10) directionToMove = Yonler.Right;
            else if (playerLocation.X < location.X - 10) directionToMove = Yonler.Left;
            else if (playerLocation.Y < location.Y - 10) directionToMove = Yonler.Up;
            else directionToMove = Yonler.Down;
            return directionToMove;
            //takip etmek üzere oyuncunu konumunu bulur ve gidilecek bir yön enum döndürür
        }
    }
}

