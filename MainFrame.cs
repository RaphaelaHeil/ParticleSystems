using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using System.Timers;

namespace ParticleSystems
{

    public partial class MainFrame : Form
    {

        private ParticleSystemRegistration particleSystemRegistration = new ParticleSystemRegistration();

        //private const double DEFAULT = 1000.0/ 60.0; // might need fine-tuning later on TODO!! 
        private const int DEFAULT = 1000 / 60;

        private bool glControlLoaded = false;
        private bool stopped = true;
        private bool paused = true;

        private ParticleSystem selectedParticleSystem;

        private FrameManager manager;

        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        //private System.Timers.Timer timer = new System.Timers.Timer(DEFAULT);

        public MainFrame()
        {
            InitializeComponent();
            particleSystemSelection.BeginUpdate();
            particleSystemSelection.Items.AddRange(particleSystemRegistration.GetParticleSystemNames());
            particleSystemSelection.EndUpdate();

            manager = new FrameManager();


            //TODO move to some other init function !!
            //register listener: 
            // timer.Elapsed += timerListener;
            timer.Tick += timerListener;
            timer.Interval = DEFAULT;

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
            manager.PrepareFrame();
            glControl.Invalidate();
        }

        private void initialiseBasedOnSelection()
        {




            manager = new FrameManager();

            //TODO: read selection and prepare FrmaeManager

            int amount = Math.Abs(int.Parse(amountBox.Text));
            int lifetime = Math.Abs(int.Parse(lifetimeBox.Text));
            int newParticles = Math.Abs(int.Parse(newParticleBox.Text));
            //if (randomRadioButton.Checked)
            //{
            //    manager.SetPositionHandler(new RandomPositionUpdater());
            //    manager.InitContext(amount, lifetime, newParticles, true);
            //}
            //else
            //{
            //    int xIncrease = int.Parse(xIncreaseBox.Text);
            //    int yIncrease = int.Parse(yIncreaseBox.Text);
            //    manager.SetPositionHandler(new LinearPositionUpdater(xIncrease, yIncrease));
            //    manager.InitContext(amount, lifetime, newParticles, false);
            //}
        }

        private void timerListener(object sender, EventArgs eventArgs)
        //private void timerListener(object sender, ElapsedEventArgs e)
        {
            manager.PrepareFrame();
            glControl.Invalidate();
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


        private void onRender(object sender, PaintEventArgs e)
        {
            if (!glControlLoaded)
            {
                return;
            }

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.PointSize(3f);
            GL.Begin(PrimitiveType.Points);

            //TODO: change to shader mode stuff
            //e.g. manager.renderFrame()

            foreach (Particle particle in manager.GetParticles())
            {
                GL.Color3(new Vector3(particle.getRemainingLifetime() * 0.05f));
                GL.Vertex2(particle.GetPosition());
            }

            GL.End();

            glControl.SwapBuffers();
        }

        private void initialiseParticleSystem()
        {

        }

        private void linearRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //xIncreaseBox.Enabled = true;
            //yIncreaseBox.Enabled = true;
        }

        private void randomRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //xIncreaseBox.Enabled = false;
            //yIncreaseBox.Enabled = false;
        }

        private void particleSystemSelected(object sender, EventArgs e)
        {
            if (particleSystemSelection.SelectedIndex >= 0)
            {
                selectedParticleSystem = particleSystemRegistration.GetParticleSystemInstance((string)particleSystemSelection.SelectedItem);
                particleSystemDescription.Text = selectedParticleSystem.GetDescription();


                //particleSystemSettingsPanel.Controls.Remove(particleSystemSettingsPanel);
                //particleSystemSettingsPanel.Dispose();
                ////_currentControl.Controls.Remove(_currentControl);
                ////_currentControl.Dispose();
                //particleSystemSettingsPanel = selectedParticleSystem.GetParticleSystemSettingsPanel();

                //psSettings.Controls.Add(particleSystemSettingsPanel);

                psSettings.Controls.Remove(particleSystemSettingsPanel);
                particleSystemSettingsPanel = selectedParticleSystem.GetParticleSystemSettingsPanel();
                psSettings.Controls.Add(particleSystemSettingsPanel);

            }
            Invalidate();
        }
    }
}
