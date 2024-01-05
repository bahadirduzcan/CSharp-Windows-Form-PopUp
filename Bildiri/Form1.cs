using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Bildiri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PopUp bhdr = new PopUp();

            bhdr.BahaBox(new PopUp.BahaBoxSettings()
            {
                Description = "Açıklama mesajıdır bu mesaj açıklamadır. 1",
                Title = "Bildirim - Bahax41",
                WindowsIcon = PopUp.BahaBoxIcon.Warning,
                Position = PopUp.BahaBoxPosition.TopLeft,
                Time = 3000,
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PopUp bhdr = new PopUp();

            bhdr.BahaBox(new PopUp.BahaBoxSettings()
            {
                Description = "Açıklama mesajıdır bu mesaj açıklamadır. 2",
                Title = "Bildirim - Bahax41",
                WindowsIcon = PopUp.BahaBoxIcon.WinLogo,
                Position = PopUp.BahaBoxPosition.TopRight,
                Time = 3000,
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PopUp bhdr = new PopUp();

            bhdr.BahaBox(new PopUp.BahaBoxSettings()
            {
                Description = "Açıklama mesajıdır bu mesaj açıklamadır. 3",
                Title = "Bildirim - Bahax41",
                WindowsIcon = PopUp.BahaBoxIcon.Shield,
                Position = PopUp.BahaBoxPosition.BottomLeft,
                Time = 3000,
            });

        }

        private void button4_Click(object sender, EventArgs e)
        {
            PopUp bhdr = new PopUp();

            bhdr.BahaBox(new PopUp.BahaBoxSettings()
            {
                Description = "Açıklama mesajıdır bu mesaj açıklamadır. 4",
                Title = "Bildirim - Bahax41",
                WindowsIcon = PopUp.BahaBoxIcon.Information,
                Position = PopUp.BahaBoxPosition.BottomRight,
                Time = 3000,
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }
    }
}
