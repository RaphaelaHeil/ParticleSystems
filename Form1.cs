using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParticleSystems
{
    using OpenTK.Graphics.OpenGL4;

    public partial class Form1 : Form
    {

        private bool glControlLoaded = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void renderButton_Click(object sender, EventArgs e)
        {
            String amountText = amountBox.Text;
            int amount = int.Parse(amountText);
            Console.Write(amount);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            glControlLoaded = true;
            GL.ClearColor(Color.SkyBlue);
        }

        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            if (!glControlLoaded)
            {
                return;
            }

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            glControl.SwapBuffers();
        }
    }
}
