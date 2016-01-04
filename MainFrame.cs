using System;
using System.Drawing;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using System.Diagnostics;

namespace ParticleSystems
{

    public partial class MainFrame : Form
    {
        private ParticleSystemRegistration particleSystemRegistration = new ParticleSystemRegistration();

        private const double DEFAULT = 1000.0 / 60.0; //TODO: figure this out ... :/ 


        private Stopwatch stopWatch = new Stopwatch();
        private bool glControlLoaded = false;
        private bool ready = false;
        private bool stopped = true;
        private bool paused = true;

        private ParticleSystem selectedParticleSystem;

        private System.Timers.Timer timer = new System.Timers.Timer(DEFAULT);
        private Timer fpsTimer = new Timer();
        private long frameCounter = 0;

        public MainFrame()
        {
            InitializeComponent();
            particleSystemSelection.BeginUpdate();
            particleSystemSelection.Items.AddRange(particleSystemRegistration.GetParticleSystemNames());
            particleSystemSelection.EndUpdate();

            timer.Elapsed += timerListener;

            fpsTimer.Tick += fpsTimerListener;
            fpsTimer.Interval = 1000;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (stopped)
            {
                startButton.Text = "Stop";
                initialiseBasedOnSelection();
                particleSystemSettings.Enabled = false;
                generalSettings.Enabled = false;
                stopped = false;
                timer.Start();
                fpsTimer.Start();
                frameButton.Enabled = false;
                pauseButton.Enabled = true;
            }
            else
            {
                stopped = true;
                paused = true;
                timer.Stop();
                fpsTimer.Stop();
                startButton.Text = "Start";
                pauseButton.Text = "Pause";
                pauseButton.Enabled = false;
                frameButton.Enabled = false;
                particleSystemSettings.Enabled = true;
                generalSettings.Enabled = true;
            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (paused)
            {
                startButton.Text = "Stop";
                timer.Stop();
                fpsTimer.Stop();
                pauseButton.Text = "Continue";
                frameButton.Enabled = true;
                paused = false;
            }
            else
            {
                timer.Start();
                fpsTimer.Start();
                pauseButton.Text = "Pause";
                frameButton.Enabled = false;
                paused = true;
            }

        }

        private void frameButton_Click(object sender, EventArgs e)
        {
            selectedParticleSystem.PrepareFrame();
            glControl.Invalidate();
        }

        private void initialiseBasedOnSelection()
        {
            ParticleSettings particleSettings = new ParticleSettings();

            particleSettings.SetInitialNumberOfParticles(Math.Abs(int.Parse(initialAmountInput.Text)));
            particleSettings.SetAgingVelocity(Math.Abs(int.Parse(agingVelocityInput.Text)));
            particleSettings.SetLifetime(Math.Abs(int.Parse(lifetimeInput.Text)));
            particleSettings.SetNewParticlesPerFrame(Math.Abs(int.Parse(newParticlesInput.Text)));
            particleSettings.SetVelocity(Math.Abs(int.Parse(velocityInput.Text)));

            particleSettings.SetAgingVelocityIsRandomlyGenerated(agingRand.Checked);
            particleSettings.SetLifetimeIsRandomlyGenerated(lifetimeRand.Checked);
            particleSettings.SetNumberOfNewParticlesIsRandomlyGenerated(newPerFrameRand.Checked);
            particleSettings.SetVelocityIsRandomlyGenerated(velocityRand.Checked);

            Context context = new Context();

            //TODO: read context ... :S 

            selectedParticleSystem.Initialise(particleSettings, context);
            ready = true;
        }

        private void timerListener(object sender, EventArgs eventArgs)
        {
            selectedParticleSystem.PrepareFrame();
            glControl.Invalidate();
            stopWatch.Reset();
        }

        private void fpsTimerListener(object sender, EventArgs eventArgs)
        {
            framesPerSecondOutput.Text = frameCounter.ToString();
            frameCounter = 0;
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
            GL.Ortho(0, w, 0, h, -1, 1);
            GL.Viewport(0, 0, w, h);
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
            GL.Color3(Color.Black);

            

            //TODO: prepare VBO(s) 
            if (ready) {
                selectedParticleSystem.RenderFrame();
                frameCounter++;
            }


            //TODO: change to shader mode stuff
            //e.g. manager.renderFrame()

            //foreach (Particle particle in manager.GetParticles())
            //{
            //    GL.Color3(new Vector3(particle.getRemainingLifetime() * 0.05f));
            //    GL.Vertex2(particle.GetPosition());
            //}

            GL.End();

            glControl.SwapBuffers();
        }

        private void particleSystemSelected(object sender, EventArgs e)
        {
            if (particleSystemSelection.SelectedIndex >= 0)
            {
                frameControls.Enabled = true;
                selectedParticleSystem = particleSystemRegistration.GetParticleSystemInstance((string)particleSystemSelection.SelectedItem);
                particleSystemDescription.Text = selectedParticleSystem.GetDescription();

                psSettings.Controls.Remove(particleSystemSettingsPanel);
                particleSystemSettingsPanel = selectedParticleSystem.GetParticleSystemSettingsPanel();
                psSettings.Controls.Add(particleSystemSettingsPanel);
            }
            Invalidate();
        }
    }
}
