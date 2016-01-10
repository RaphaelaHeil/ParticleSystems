using System;
using System.Drawing;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using System.IO;

namespace ParticleSystems
{
    /// <summary>
    /// Entry point of the application.
    /// </summary>
    public partial class MainFrame : Form
    {
        private ParticleSystemRegistration particleSystemRegistration = new ParticleSystemRegistration();
        private System.Timers.Timer timer = new System.Timers.Timer(TICK_IN_MS);
        private Timer fpsTimer = new Timer();
        private IdHolder idHolder = new IdHolder();
        private ParticleSystem selectedParticleSystem;

        private const double TICK_IN_MS = 15.0;
        private const double SMOOTHING = 0.8;

        private bool glControlLoaded = false;
        private bool ready = false;
        private bool stopped = true;
        private bool paused = true;
        private double FpsMeasurement = 30;
        private long frameCounter = 0;
        private long droppedFrames = 0;


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

        private void Form1_Load(object sender, EventArgs e)
        {
            idHolder.Width = glControl.Width;
            idHolder.Height = glControl.Height;

            InitializeProgram();

            glControlLoaded = true;
            GL.ClearColor(Color.CornflowerBlue);
            SetupViewport();

        }

        private void onRender(object sender, PaintEventArgs e)
        {
            if (!glControlLoaded)
            {
                return;
            }

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.PointSize(3f);

            if (ready)
            {
                if (selectedParticleSystem.RenderFrame())
                {
                    frameCounter++;
                }
                else
                {
                    droppedFrames++;
                }
            }
            glControl.SwapBuffers();
        }

        private void InitializeProgram()
        {
            int vert, frag;

            idHolder.ProgId = GL.CreateProgram();
            LoadShader("vertex.glsl", ShaderType.VertexShader, idHolder.ProgId, out vert);
            LoadShader("fragment.glsl", ShaderType.FragmentShader, idHolder.ProgId, out frag);

            idHolder.VertexId = vert;
            idHolder.FragmentId = frag;

            GL.LinkProgram(idHolder.ProgId);
            Console.WriteLine(GL.GetProgramInfoLog(idHolder.ProgId));

            GL.UseProgram(idHolder.ProgId);

            GL.DetachShader(idHolder.ProgId, idHolder.VertexId);
            GL.DetachShader(idHolder.ProgId, idHolder.FragmentId);
        }

        /// <summary>
        /// Loads shader based on the provided input.
        /// </summary>
        /// <param name="filename">Source file of the shader (*.glsl). </param>
        /// <param name="type">ShaderType <seealso cref="ShaderType"/></param>
        /// <param name="program">Address of the program in which the shader will be run.</param>
        /// <param name="address">Address to which the compiled shader will be assigned.</param>
        private void LoadShader(String filename, ShaderType type, int program, out int address)
        {
            address = GL.CreateShader(type);
            using (StreamReader sr = new StreamReader(filename))
            {
                GL.ShaderSource(address, sr.ReadToEnd());
            }

            GL.CompileShader(address);
            GL.AttachShader(program, address);
            Console.WriteLine(GL.GetShaderInfoLog(address));
        }

        private void timerListener(object sender, EventArgs eventArgs)
        {
            glControl.Invalidate();
        }

        private void fpsTimerListener(object sender, EventArgs eventArgs)
        {
            FpsMeasurement = (FpsMeasurement * SMOOTHING) + (frameCounter * (1 - SMOOTHING));
            framesPerSecondOutput.Text = ((int)Math.Round(FpsMeasurement)).ToString();
            frameCounter = 0;
            Console.WriteLine("Dropped Frames: " + droppedFrames);
            droppedFrames = 0;
        }

        private void SetupViewport()
        {

            GL.Viewport(0, 0, idHolder.Width, idHolder.Height);
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

            Context context = new Context(idHolder);

            //TODO: read context ... 

            selectedParticleSystem.Init(particleSettings, context);
            ready = true;
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
            //disable general Settings if Wind Simulation is selected
            if(particleSystemSelection.SelectedIndex == 1)
            {
                generalSettings.Enabled = false;
            }
            Invalidate();
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
                //disable general Settings if Wind Simulation is selected
                if (particleSystemSelection.SelectedIndex == 1)
                {
                    generalSettings.Enabled = false;
                }else
                {
                    generalSettings.Enabled = true;
                }
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
            glControl.Invalidate();
        }
    }
}
