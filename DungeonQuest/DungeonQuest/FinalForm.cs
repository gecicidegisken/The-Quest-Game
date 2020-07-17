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
    public partial class FinalForm : Form
    {
        public FinalForm()
        {
            InitializeComponent();
            
        }

        private void FinalForm_Load(object sender, EventArgs e)
        {
           
        }

        private void FinalForm_Shown(Object sender, EventArgs e)
        {
            MessageBox.Show("Başardın!\n\n Canavarları öldürüp altı kuleyi de geçtin. Adamların seni burdan götürmek üzere kapıda bekliyor. Gün doğumunda evine varmış olursun. Özgürlüğünün tadını çıkart!", "Yolun Açık Olsun!");
            Application.Exit();    
        }

    }
}
