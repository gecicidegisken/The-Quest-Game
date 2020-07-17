using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace DungeonQuest
{
    public class Player : Hareketler
    {
        public int hitPoint=1;// vurulan ve alinan darbeler
        public static int health=500; // kolaylık seviyesine göre değişebilir
        public static Weapon equippedWeapon; //seçtiği silah
        public static Enemy enemy; //karşısındaki düşman
        public bool alive; // false ise ölü.
        public PictureBox playerPic;  // fotoğrafı burda duracak
        public static List<Weapon> inventory = new List<Weapon>(); //Silahları buna ekleme üzerine çalışıcam
        public static bool kızPlayerCheck;

        public Player()
        {

        }
        public static bool silahTopla(PictureBox weaponPic, PictureBox playerPic)
        {

            if (weaponPic.Bounds.IntersectsWith(playerPic.Bounds))
            {
                weaponPic.Visible = false;
                return true;
            }

            return false;
        }
        public static void Attack(PictureBox playerPic, PictureBox enemyPic)
        {
            Player player = new Player();
            Enemy enemy = new Enemy();
            /// silah seçili değilken 1 vurabiliyor


            if (Weapon.equipped) { 
                 player.hitPoint = equippedWeapon.hitPoint;
        }
            else
                player.hitPoint = 1;


            if (Enemy.name == "ghost")
            {
                Ghost.health -= player.hitPoint;
                if (Ghost.health <= 0)
                {

                    enemyPic.Visible = false;
                    enemyPic.Location = new Point(883, 291); //mezarlığa gönder ki bi daha vuramasın
                    MessageBox.Show("Ghost died");
                }
            }
            else if (Enemy.name == "ghoul")
            {
                Ghoul.health -= player.hitPoint;
                if (Ghoul.health <= 0)
                {
                    enemyPic.Visible = false;
                    enemyPic.Location = new Point(883, 291); 
                    MessageBox.Show("Ghoul died");
                }
            }
            else if (Enemy.name == "bat")
            {
                Bat.health -= player.hitPoint;
                if (Bat.health <= 0)
                {

                   enemyPic.Visible = false;
                    enemyPic.Location = new Point(883, 291); 
                    MessageBox.Show("Bat died");
                }
            }

            }

        public static void DrinkPotion(Weapon potion)
        {

             Player.health += equippedWeapon.iksirGucu;  
           
        }

        public static bool Equip(Weapon weapon)
        {
              Player.equippedWeapon = weapon;
              Weapon.equipped = true;    
                 return true;
        }
        public void Die()
        {
            if (Player.health <= 0)
            {
                MessageBox.Show("Özgürlük uğruna savaşırken can verdin. Seni unutmayacağız.", "Öldün");
                Application.Exit();
            }
           
        }
    }
    }

