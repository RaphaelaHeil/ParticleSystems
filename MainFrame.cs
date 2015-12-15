using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using System.Timers;

namespace ParticleSystems
{
    
    public partial class MainFrame : Form
    {

        private const double DEFAULT = 1000.0/ 60.0; // might need fine-tuning later on TODO!! 

        private bool glControlLoaded = false;
        private bool stopped = true;
        private bool paused = true;
        private Context context = new Context();
        private FrameManager  manager;

        private System.Timers.Timer timer = new System.Timers.Timer(DEFAULT);

        public MainFrame()
        {
            InitializeComponent();

            manager = new FrameManager(context);
            

            //TODO move to some other init function !!
            //register listener: 
            timer.Elapsed += timerListener;

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            initialiseParticleSystem();

            //TODO cleanup this start/stop/pause mess !!! 
            if (stopped)
            {
                startButton.Text = "Stop";
                initialiseBasedOnSelection();
                stopped = false;
                timer.Start();
                frameButton.Enabled = false;
                pauseButton.Enabled = true;
            }
            else
            {
                stopped = true;
                paused = true;
                timer.Stop();
                startButton.Text = "Start";
                pauseButton.Text = "Pause";
                frameButton.Enabled = false;
            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (paused)
            {
                startButton.Text = "Stop";
                timer.Stop();
                pauseButton.Text = "Continue";
                frameButton.Enabled = true;
                paused = false;
            }
            else
            {
                timer.Start();
                pauseButton.Text = "Pause";
                frameButton.Enabled = false;
                paused = true;
            }
            
        }

        private void frameButton_Click(object sender, EventArgs e)
        {
            manager.prepareFrame();
            glControl.Invalidate();
        }

        private void initialiseBasedOnSelection()
        {
            context.clear();

            int amount = int.Parse(amountBox.Text);
            int lifetime = int.Parse(lifetimeBox.Text);
            int newParticles = int.Parse(newParticleBox.Text);
            if (randomRadioButton.Checked)
            {
                manager.initContext(amount, lifetime, newParticles, true);
            }
            else
            {
                manager.initContext(amount, lifetime, newParticles, false);
            }

            
        }

        private void timerListener(object sender, ElapsedEventArgs e)
        {
            // UpdateModel(); // this is where you'd do whatever you need to do to update your model per frame
            // Invalidate will cause the Paint event on your GLControl to fire
            //_glControl.Invalidate(); // _glControl is obviously a private reference to the GLControl
            manager.prepareFrame();
           // Console.Write("beep\n");
            glControl.Invalidate();
            //  renderStuff();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            glControlLoaded = true;
            GL.ClearColor(Color.SkyBlue);
            
            SetupViewport();
        }

        private void SetupViewport()
        {
            int w = glControl.Width;
            int h = glControl.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, w, 0, h, -1, 1); // Bottom-left corner pixel has coordinate (0, 0)
            GL.Viewport(0, 0, w, h); // Use all of the glControl painting area
        }


        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            //Console.Write("paint");
            if (!glControlLoaded)
            {
                return;
            }
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            
            GL.PointSize(3f);
            GL.Begin(PrimitiveType.Points);
            foreach(Particle particle in context.getParticles())
            {
                GL.Color3(new Vector3(particle.getRemainingLifetime() * 0.05f));
                GL.Vertex2(particle.getPosition());
            }
            
            GL.End();
 
			glControl.SwapBuffers();
        }

        private void initialiseParticleSystem()
        {

        }
    }
}
