using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Bildiri
{
    public class PopUp
    {
        public class BahaBoxSettings
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public BahaBoxPosition Position { get; set; }
            public int Time { get; set; } = 3000;
            public string Icon { get; set; }
            public BahaBoxIcon? WindowsIcon { get; set; }
        }

        public enum BahaBoxPosition
        {
            BottomRight = 0,
            BottomLeft = 1,
            TopRight = 2,
            TopLeft = 3,
        }
        public enum BahaBoxIcon
        {
            Error = 0,
            Information,
            Question,
            Shield,
            Warning,
            WinLogo,
        }
        
        /// <summary>
        /// <para>Description: Açıklama</para>
        /// <para>Title: Başlık</para>
        /// <para>Time: Süre (Saniye Cinsinden)</para>
        /// <para>Position: Konum (Sol Üst: 1 - Sağ Üst: 2 - Sol Alt: 3 - Sağ Alt: 4)</para>
        /// <para>Icon: İki Tür;</para>
        /// <para> int(Error: 1 - (Default)Information: 2 - Question: 3 - Shield: 4 - Warning: 5 - Winlogo: 6)</para>
        /// <para> string(Seçtiğiniz Resim - Default: Information)</para>
        /// <para>Null = 0</para>
        /// </summary>
        public void BahaBox(BahaBoxSettings model)
        {
            Form.CheckForIllegalCrossThreadCalls = false;

            Form frm = new Form();
            BackgroundWorker backWork1 = new BackgroundWorker();
            Panel panel1 = new Panel();
            Panel panel2 = new Panel();
            Label lblBaslik = new Label();
            Label lblAciklama = new Label();
            Label lblBos = new Label();
            PictureBox IconResim = new PictureBox();

            frm.Text = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 10);
            frm.BackColor = Color.FromArgb(20, 31, 41);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Width = 364;
            frm.Height = 102;
            frm.ShowInTaskbar = false;
            frm.Opacity = 0.0F;
            frm.TopMost = true;

            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Size = new Size(40, 265);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(126, 0);

            IconResim.Location = new Point(11, 10);
            IconResim.Size = new Size(0, 45);
            IconResim.SizeMode = PictureBoxSizeMode.StretchImage;
            IconResim.Dock = DockStyle.Top;
            IconResim.Padding = new Padding(5, 10, 5, 5);

            if (model.Icon != null && model.Icon != "" && model.Icon.Length > 4)
            {
                string sub = model.Icon.Substring(model.Icon.Length - 3, 3);
                if (sub == "png" || sub == "jpg" || sub == "ico" || sub == "peg")
                    IconResim.Image = new Bitmap(model.Icon);

            }
            else if (model.WindowsIcon.HasValue)
            {
                switch (model.WindowsIcon.Value)
                {
                    case BahaBoxIcon.Error: IconResim.Image = SystemIcons.Error.ToBitmap(); break;
                    case BahaBoxIcon.Information: IconResim.Image = SystemIcons.Information.ToBitmap(); break;
                    case BahaBoxIcon.Question: IconResim.Image = SystemIcons.Question.ToBitmap(); break;
                    case BahaBoxIcon.Shield: IconResim.Image = SystemIcons.Shield.ToBitmap(); break;
                    case BahaBoxIcon.Warning: IconResim.Image = SystemIcons.Warning.ToBitmap(); break;
                    case BahaBoxIcon.WinLogo: IconResim.Image = SystemIcons.WinLogo.ToBitmap(); break;
                    default: IconResim.Image = SystemIcons.Information.ToBitmap(); break;
                }
            }
            else
            {
                IconResim.Image = SystemIcons.Information.ToBitmap();
            }

            lblBaslik.AutoSize = false;
            lblBaslik.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(162)));
            lblBaslik.Size = new Size(0, 32);
            lblBaslik.ForeColor = Color.White;

            if (model.Title.Length > 1)
                lblBaslik.Text = model.Title;
            else
                lblBaslik.Text = "";

            lblBaslik.Dock = DockStyle.Top;
            lblBaslik.Padding = new Padding(0, 5, 5, 0);

            lblBos.Location = new Point(11, 10);
            lblBos.Size = new Size(32, 0);
            lblBos.Dock = DockStyle.Fill;

            lblAciklama.AutoSize = false;
            lblAciklama.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(162)));
            lblAciklama.ForeColor = Color.White;
            lblAciklama.Text = model.Description;
            lblAciklama.Dock = DockStyle.Fill;

            frm.Controls.Add(panel2);
            frm.Controls.Add(panel1);
            panel1.Controls.Add(IconResim);
            panel1.Controls.Add(lblBos);
            panel2.Controls.Add(lblAciklama);
            panel2.Controls.Add(lblBaslik);
            frm.Show();

            frm.Location = new Point(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - (frm.Height + 50));

            Thread myThread = new Thread(new ThreadStart(Islemler));
            myThread.Start();

            void Islemler()
            {
                switch (model.Position)
                {
                    case BahaBoxPosition.BottomRight:
                        SagAltOpen(model.Time);
                        SagAltClose();
                        break;
                    case BahaBoxPosition.BottomLeft:
                        SolAltOpen(model.Time);
                        SolAltClose();
                        break;
                    case BahaBoxPosition.TopRight:
                        SagUstOpen(model.Time);
                        SagUstClose();
                        break;
                    case BahaBoxPosition.TopLeft:
                        SolUstOpen(model.Time);
                        SolUstClose();
                        break;
                    default:
                        SagAltOpen(model.Time);
                        SagAltClose();
                        break;
                }
            }

            void SolUstOpen(int time)
            {
                for (int i = 0; i <= frm.Width; i += 5)
                {
                    frm.Location = new Point((i + 20) - frm.Width, 25);
                    Thread.Sleep(1);

                    if (i % 8 == 0)
                    {
                        if (frm.Opacity != 1.0)
                        {
                            Thread.Sleep(1);
                            frm.Opacity += 0.1;
                        }
                    }
                }
                Thread.Sleep(time);
            }
            void SolUstClose()
            {
                for (int i = frm.Width; i >= -(frm.Width * 2); i -= 5)
                {
                    frm.Location = new Point(i - frm.Width, 25);
                    Thread.Sleep(1);

                    if (i % 20 == 0)
                    {
                        if (frm.Opacity != 0.0)
                        {
                            Thread.Sleep(1);
                            frm.Opacity -= 0.1;
                        }
                    }
                }

                frm.Close();
            }

            void SagUstOpen(int time)
            {
                for (int i = Screen.PrimaryScreen.Bounds.Width; i >= (Screen.PrimaryScreen.Bounds.Width - (frm.Width + 15)); i -= 5)
                {
                    frm.Location = new Point(i - 5, 25);
                    Thread.Sleep(1);

                    if (i % 8 == 0)
                    {
                        if (frm.Opacity != 1.0)
                        {
                            Thread.Sleep(1);
                            frm.Opacity += 0.1;
                        }
                    }
                }
                Thread.Sleep(time);
            }
            void SagUstClose()
            {
                for (int i = frm.Location.X; i <= Screen.PrimaryScreen.Bounds.Width; i += 5)
                {
                    frm.Location = new Point(i, 25);
                    Thread.Sleep(1);

                    if (i % 20 == 0)
                    {
                        if (frm.Opacity != 0.0)
                        {
                            Thread.Sleep(1);
                            frm.Opacity -= 0.1;
                        }
                    }
                }
                frm.Close();
            }

            void SolAltOpen(int time)
            {
                for (int i = 0; i <= frm.Width; i += 5)
                {
                    frm.Location = new Point((i + 20) - frm.Width, Screen.PrimaryScreen.Bounds.Height - (frm.Height + 50));
                    Thread.Sleep(1);

                    if (i % 8 == 0)
                    {
                        if (frm.Opacity != 1.0)
                        {
                            Thread.Sleep(1);
                            frm.Opacity += 0.1;
                        }
                    }
                }
                Thread.Sleep(time);
            }
            void SolAltClose()
            {
                for (int i = frm.Width; i >= -(frm.Width * 2); i -= 5)
                {
                    frm.Location = new Point(i - frm.Width, Screen.PrimaryScreen.Bounds.Height - (frm.Height + 50));
                    Thread.Sleep(1);

                    if (i % 20 == 0)
                    {
                        if (frm.Opacity != 0.0)
                        {
                            Thread.Sleep(1);
                            frm.Opacity -= 0.1;
                        }
                    }
                }

                frm.Close();
            }

            void SagAltOpen(int time)
            {
                for (int i = Screen.PrimaryScreen.Bounds.Width; i >= (Screen.PrimaryScreen.Bounds.Width - (frm.Width + 15)); i -= 5)
                {
                    frm.Location = new Point(i - 5, Screen.PrimaryScreen.Bounds.Height - (frm.Height + 50));
                    Thread.Sleep(1);

                    if (i % 8 == 0)
                    {
                        if (frm.Opacity != 1.0)
                        {
                            Thread.Sleep(1);
                            frm.Opacity += 0.1;
                        }
                    }
                }
                Thread.Sleep(time);
            }
            void SagAltClose()
            {
                for (int i = frm.Location.X; i <= Screen.PrimaryScreen.Bounds.Width; i += 5)
                {
                    frm.Location = new Point(i, Screen.PrimaryScreen.Bounds.Height - (frm.Height + 50));
                    Thread.Sleep(1);

                    if (i % 20 == 0)
                    {
                        if (frm.Opacity != 0.0)
                        {
                            Thread.Sleep(1);
                            frm.Opacity -= 0.1;
                        }
                    }
                }
                frm.Close();
            }
        }
    }
}