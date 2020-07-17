using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DungeonQuest
{
    /*---- bow silahını sonradan axe ile değiştirdim
     * 1.level ghost + sword
     * 2.level bat   
     * 3.level ghost+bat  + axe
     * 4.level ghoul + mavi iksir
     * 5.level ghoul+ghost + kırmızı iksir
     * 6. level ghoul+bat+ghost +mace
     * 7. level BAŞARDIN SAYFASI
     */
    public partial class Form1 : Form
    {
        public static int level =1;  // bu sayıyı değiştirerek her leveli test et 

        //Player.health arttırarak oyunu baştan sona oynayıp kontrol etmeyi unutma
        
        public Form1()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //karakter seçimi kutusunu özelleştirme
            MessageBoxManager.Yes = "Erkek";
            MessageBoxManager.No = "Kız";
            MessageBoxManager.Register();
            //karakter seçimi kutusunu özelleştirme
            //nasıl oynanır mesajı
            MessageBox.Show("Zindana hoşgeldin! Masum olmana rağmen haksızca hapsedildiğini öğrenen adamların bir kaçış planı yapıp gizlice sana gönderdiler. Özgürlüğüne kavuşmak için kuleleri geçmeli ve yoluna çıkan düşmanları öldürmelisin.\n\n*İşte plana göre bilmen gereken bazı kurallar:\n\n -->Bir kuleden ayrılmak için bütün canavarları öldürdükten sonra hızla çıkış kapısına gitmelisin!\n\n-> Hayaletler kulelerin içinde rastgele gezinirler. Zararsız gibi gözüken bu yaratıklara yaklaştığında epey tehlikeli olabilirler.\n->Hortlaklar (ghouls) ve yarasalar seni takip ederler. Etrafında dolanan canavarlara karşı çok dikkatli ol.\n-> 3 farklı silahın var. En güçlüden en zayıfa olmak üzere:gürz,balta ve kılıç.\n-> Yerdeki silahları toplamak için üzerine gelince topla <pick up> butonuna bas.\n-> Silahı kuşanmak için envanterindeki simgeye tıklamalısın.\n-> Silah kuşanmaman yumrukla savaşman demek! Yumrukla darbe gücün en fazla 1'dir.\n-> Kırmızı ve mavi iksirlerden içersen canın artar. İksir içtikten sonra tekrar silahını kuşanmayı unutma.\n-> Butonların ne işe yaradığını unutursan fareni üzerine getirerek bilgi alabilirsin.\n\n Başlamadan önce karakterini seç. Bol şans! \n(ihtiyacın olacak)","Nasıl Oynanır?");
            //karakter seçim kutusu
            DialogResult karakterSecimi = MessageBox.Show("Kız mı erkek mi?",
             "Karakterini Seç",
             MessageBoxButtons.YesNo);
            if (karakterSecimi == DialogResult.No)//kızı seçti demektir
            {
                playerPic.Image = Properties.Resources.womanplayerv3;   //BURAYA KIZ GELİCEK UNUTMA
                Player.kızPlayerCheck = true;
            }
            //erkeği seçerse zaten default yüklü.

            YeniLevel();
            canlariGuncelle();
     
        }
        public void canlariGuncelle()
        {
         
            ghostlabel.Text ="Ghost: "+ Convert.ToString(Ghost.health);
            ghoullabel.Text = "Ghoul: "+Convert.ToString(Ghoul.health);
            batlabel.Text ="Bat: "+ Convert.ToString(Bat.health);
            playerlabel.Text ="Player: "+ Convert.ToString(Player.health);
           
            if (playerPic.Bounds.IntersectsWith(bitisKapısı.Bounds)&& Ghost.health <= 0 && Bat.health <= 0 && Ghoul.health <= 0)
            {
                bitisKapısıbtn.PerformClick();
            }
        }  //can barlarının son durumunu gör

        public void CanlariSifirla()
        {
            Bat.health = 20;
            Ghost.health = 25;
            Ghoul.health = 30;
            playerPic.Location = new Point(60, 100);
        }   //her levelde düşmanların canı sıfırlanacak ve player başa dönecek

        public Point RandomYereGit()
        {
            Random rastgele = new Random();
            Point yeniLocation = new Point(rastgele.Next(147, 729), rastgele.Next(50, 268)); //dusmanlar rastgele konum alicak
            return yeniLocation;
        }
        public void YeniLevel()
        {
            Random sayisalla = new Random();
       

            // randomyeregit metodu bir defa çağrıldığı için karakterler aynı yere ışınlanıyor. o yüzden birine new Point ver.

            switch (level)
            {

                case 1:
                    {
                        CanlariSifirla();
                        Bat.health = 0;   //ilk levelde bunlar olmayacak yani
                        Ghoul.health = 0;
                        batPic.Visible = false;
                        ghoulPic.Visible = false;
                        swordPic.Visible = true;
                        swordPic.Location = new Point(147, 288);
                        //ghostPic.Visible = true;
                        ghostPic.Location = RandomYereGit();//rastgele bi yere gitsin
                        if(Ghost.health<=0)
                            level=2;
                    }
                    break;
                case 2:
                    { 
                        CanlariSifirla();
                       
                        Ghost.health = 0;
                        Ghoul.health = 0;
                        ghostPic.Visible = false;
                        ghoulPic.Visible = false;
                        batPic.Visible = true;
                        batPic.Location = RandomYereGit();//rastgele bi yere gitsin
                        if (Bat.health <= 0)
                            level = 3;
                    }
                    break;
                case 3:
                    {
                       
                        CanlariSifirla();
                        Ghoul.health = 0;
                        bowwPic.Visible = true;
                        bowwPic.Location = new Point(121, 69);
                        ghoulPic.Visible = false;
                        ghostPic.Visible = true;
                        ghostPic.Location = new Point(sayisalla.Next(147, 729), sayisalla.Next(50, 268));
                        batPic.Visible = true;
                        batPic.Location = RandomYereGit(); //rastgele bi yere gitsin   
                        if (Bat.health <= 0 && Ghost.health<=0)
                            level = 4;
                    }
                    break;
                case 4:
                    {
                        CanlariSifirla();
                       
                       
                        potionBluePic.Visible = true;
                        potionBluePic.Location = new Point(394,325);
                        Ghost.health = 0;
                        ghostPic.Visible = false;
                        Bat.health = 0;
                        batPic.Visible = false;
                        ghoulPic.Location = RandomYereGit();
                        ghoulPic.Visible = true;
                        if (Ghoul.health <= 0)
                            level = 5;

                    }
                    break;
                case 5:
                    {
                        CanlariSifirla();
                        potionRedPic.Visible = true;
                        potionRedPic.Location = new Point(394, 325);
                        ghostPic.Visible = true;
                        ghoulPic.Visible = true;
                        batPic.Visible = false;
                        Bat.health = 0;
                        ghostPic.Location = RandomYereGit();
                        ghoulPic.Location = new Point(sayisalla.Next(147, 729), sayisalla.Next(50, 268));
                        if (Ghoul.health <= 0 && Bat.health <= 0)
                            level = 6;
                    }
                    break;

                case 6:
                    {
                        CanlariSifirla();
                        macePic.Location = new Point(106, 289); //yakında bi yerde olsun
                        macePic.Visible = true;
                       
                        ghostPic.Visible = true;
                        ghoulPic.Visible = true;
                        batPic.Visible = true;
                        ghostPic.Location = RandomYereGit();
                        batPic.Location = new Point(sayisalla.Next(147, 729), sayisalla.Next(50, 268));
                        ghoulPic.Location= new Point(sayisalla.Next(200, 729), sayisalla.Next(60, 268));

                        //batPic.Location = RandomYereGit();
                        //ghostPic.Location = RandomYereGit();
                        //ghoulPic.Location = RandomYereGit();

                    }
                    break;
                case 7:
                    {
                        FinalForm f2 = new FinalForm();
                        f2.ShowDialog(); // Shows Form2  
                        Application.Exit();

                    }
                    break;
                default:
                    break;
            }
          
        }
        public void DusmanHamlesi()
        {
            
            //oyuncunun her hamlesinden sonra düşmanlar hamle yapıyor. sırayla.
            Bat bat = new Bat();
            Ghost ghost = new Ghost();
            Ghoul ghoul = new Ghoul();
            Player player = new Player();
            player.location = playerPic.Location;
            bat.player = player;
            ghoul.player = player;
            ghost.player = player;


            if (Bat.health > 0)  //böylece mezarlığa gidince bi daha geri dönemeyecekler
            {
                bat.Move(batPic);
                bat.Attack(batPic, playerPic);
            }
            if (Ghost.health > 0)
            {
                ghost.Move(ghostPic); //rastgele hareket ediyor etrafta
                ghost.Attack(ghostPic, playerPic);
            }
            if (Ghoul.health > 0)
            {
                ghoul.Move(ghoulPic);//oyuncuyu takip ediyor
                ghoul.Attack(ghoulPic, playerPic);
            }
            player.Die();      //darbeler sonucu player ölürse diye kontrol et                                                                                                    

        }
        private void AttackBtn_Click(object sender, EventArgs e)
        {
            
            if (playerPic.Bounds.IntersectsWith(ghostPic.Bounds))
            {
               
                    Enemy.name = "ghost";
                    Player.Attack(playerPic, ghostPic);
            }

            else if (playerPic.Bounds.IntersectsWith(ghoulPic.Bounds))
            {
               
                    Enemy.name = "ghoul";
                    Player.Attack(playerPic, ghoulPic);

            }
            else if (playerPic.Bounds.IntersectsWith(batPic.Bounds))
            {
                    Enemy.name = "bat";
                    Player.Attack(playerPic, batPic);
                
            }

            //if (Ghost.health <= 0 && Bat.health <= 0 && Ghoul.health <= 0)
            //{
            //    //yani hepsi öldüyse ve kapıya gidildiyse
            //    bitisKapısıbtn.PerformClick();
            //}

            DusmanHamlesi();
            canlariGuncelle();
            //bunun için canları güncelle fonksiyonu yapıp buda çağırıcam

        }

        private void moveRightBtn_Click(object sender, EventArgs e)
        {
            Player player = new Player();
            player.location = playerPic.Location;
            playerPic.Location = player.hareketEt(Yonler.Right);
            DusmanHamlesi();
            canlariGuncelle();


        }

        private void moveDownBtn_Click(object sender, EventArgs e)
        {
            Player player = new Player();
            player.location = playerPic.Location;
            playerPic.Location = player.hareketEt(Yonler.Down);
            DusmanHamlesi();
            canlariGuncelle();
        }

        private void moveUpBtn_Click(object sender, EventArgs e)
        {
            Player player = new Player();
           
            player.location = playerPic.Location;
            playerPic.Location = player.hareketEt(Yonler.Up);
            DusmanHamlesi();
            canlariGuncelle();
        }

        private void moveLeftBtn_Click(object sender, EventArgs e)
        {
            Player player = new Player();
            player.location = playerPic.Location;
            playerPic.Location = player.hareketEt(Yonler.Left);
            DusmanHamlesi();
            canlariGuncelle();
        }

        private void pickUpBtn_Click(object sender, EventArgs e)
        {
            Player.silahTopla(bowwPic, playerPic);
            if (Player.silahTopla(bowwPic, playerPic))
                envanterBoww.Visible = true;
            else if (Player.silahTopla(macePic, playerPic))
                envanterMace.Visible = true;
            else if (Player.silahTopla(swordPic, playerPic))
                envanterSword.Visible = true;
            else if (Player.silahTopla(potionRedPic, playerPic))
                envanterRedPot.Visible = true;
            else if (Player.silahTopla(potionBluePic, playerPic))
                envanterBluePot.Visible = true;
            canlariGuncelle();
          
        }

        private void envanterBoww_Click(object sender, EventArgs e)
        {
            Bow bow = new Bow(5);

            Player.Equip(bow);
            weaponLabel.Text = "Weapon hit point:" + Convert.ToString(Player.equippedWeapon.hitPoint);

            if (Player.kızPlayerCheck)

            {
                playerPic.Image = Properties.Resources.womanaxe;
            }
            else
              playerPic.Image = Properties.Resources.newplayeraxe;


          //iksir seçimini kaldırırsa diye 

            RedPotion.iksirCheck = false;    
            BluePotion.iksirCheck = false;
            if (drinkBtn.Visible)
            {
                drinkBtn.Visible = false;
            }

        }

        private void envanterSword_Click(object sender, EventArgs e)
        {
            Sword sword = new Sword(3);

            Player.Equip(sword);
            weaponLabel.Text = "Weapon hit point:" + Convert.ToString(Player.equippedWeapon.hitPoint);
           
            if (Player.kızPlayerCheck)
            {
                playerPic.Image = Properties.Resources.womasword;
            }
            else 
                playerPic.Image = Properties.Resources.newplayersword;

            //iksir seçimini kaldırırsa diye 

            RedPotion.iksirCheck = false;
            BluePotion.iksirCheck = false;
            if (drinkBtn.Visible)
            {
                drinkBtn.Visible = false;
            }
        }

        private void envanterMace_Click(object sender, EventArgs e)
        {
            Mace mace = new Mace(7);

            Player.Equip(mace);
            weaponLabel.Text = "Weapon hit point:" + Convert.ToString(Player.equippedWeapon.hitPoint);
            
            if (Player.kızPlayerCheck)
            {
                playerPic.Image = Properties.Resources.womanmace;
            }
            else
                  playerPic.Image = Properties.Resources.newplayermace;
            //iksir seçimini kaldırırsa diye 

            RedPotion.iksirCheck = false;
            BluePotion.iksirCheck = false;
            if (drinkBtn.Visible)
            {
                drinkBtn.Visible = false;
            }
        }

        private void envanterRedPot_Click(object sender, EventArgs e)
        {
            RedPotion redpotion = new RedPotion(10);
            drinkBtn.Visible = true;
            Player.Equip(redpotion);
            RedPotion.iksirCheck = true;
        
            //envanterRedPot.Visible = false;
            weaponLabel.Text = "Potion equipped.";

          if (Player.kızPlayerCheck)
            {
                playerPic.Image = Properties.Resources.womanplayerv3;
            }
            else
            playerPic.Image = Properties.Resources.newplayer;

        }
        
    

        private void drinkBtn_Click(object sender, EventArgs e)
        {
            
            Player.DrinkPotion(Player.equippedWeapon);
            canlariGuncelle();
            drinkBtn.Visible = false;
            if (RedPotion.iksirCheck)
            {
                envanterRedPot.Visible = false;
                RedPotion.iksirCheck = false;
            }
            if (BluePotion.iksirCheck)
            {
                envanterBluePot.Visible = false;
                BluePotion.iksirCheck = false;
            }

         
        }

        private void playerPic_Click(object sender, EventArgs e)
        {

        }

        private void bitisKapısıbtn_Click(object sender, EventArgs e)
        {
            level++;
            YeniLevel(); 

        }

        private void envanterBluePot_Click(object sender, EventArgs e)
        {
            BluePotion bluepotion = new BluePotion(5);  //canı 5 arttırır
            Player.Equip(bluepotion);
            BluePotion.iksirCheck = true;
            drinkBtn.Visible = true;
          //  envanterBluePot.Visible = false;
            weaponLabel.Text = "Potion equipped.";
            if (Player.kızPlayerCheck)
            {
                playerPic.Image = Properties.Resources.womanplayerv3;
            }
           else
                playerPic.Image = Properties.Resources.newplayer;
           
        }

        private void envanter_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(envanter, "This is your inventory.Use your weapons by clicking on them.");
        }

        private void pickUpBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pickUpBtn, "Pick up");
        }

        private void AttackBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(AttackBtn, "Attack");
        }

        
        private void potionBluePic_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

    
    }
}
