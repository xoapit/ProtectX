using System.Drawing;
using System.Windows.Forms;

namespace Explore
{
    partial class CustomControl : TabControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public CustomControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);

            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new System.Drawing.Size(30, 120);

        }


        protected override void OnPaint(PaintEventArgs e)
        {
            var B = new Bitmap(Width, Height);
            var G = (Graphics)Graphics.FromImage(B);
            G.Clear(Color.Gainsboro);

            for (int i = 0; i < TabCount - 1; i++)
            {
                var TabRectangle = (Rectangle)GetTabRect(i);

                if (i == SelectedIndex)
                {
                    G.FillRectangle(Brushes.Navy, TabRectangle);
                }
                else
                {

                    G.FillRectangle(Brushes.BlueViolet, TabRectangle);


                }
                G.DrawString(TabPages[i].Text, Font, Brushes.White, TabRectangle, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                TabPages[i].Font = new Font(TabPages[i].Font, FontStyle.Strikeout);

            }

            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();

            base.OnPaint(e);

        }
        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        

        #endregion
    }
}
