using System;
using System.Drawing;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using System.IO;
using ParticleSystems.Systems;
using ParticleSystems.SettingsPanels;
using ParticleSystems.MoreOptionsForm;

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
        private ParticleSystemSettingsPanel panelSystemSettingsPanel;
        private Context context = new Context();
        private RenderHelper RenderHelper;

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

            RenderHelper = new RenderHelper(idHolder);

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
            GL.PointSize(4f);

            RenderHelper.RenderPlaceables(context.GetPlaceableObjectVertices());

            
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
          //  Console.WriteLine("Dropped Frames: " + droppedFrames);
            droppedFrames = 0;
        }

        private void SetupViewport()
        {
            GL.Viewport(0, 0, idHolder.Width, idHolder.Height);
        }

        private void initialiseBasedOnSelection()
        {
            ParticleSettings particleSettings = selectedParticleSystem.GetParticleSettings();


            particleSettings.WithInitialNumberOfParticles(Math.Abs(int.Parse(initialAmountInput.Text)));
            particleSettings.WithAgingVelocity(Math.Abs(int.Parse(agingVelocityInput.Text)));
            particleSettings.WithLifetime(Math.Abs(int.Parse(lifetimeInput.Text)));
            particleSettings.WithNewParticlesPerFrame(Math.Abs(int.Parse(newParticlesInput.Text)));
            particleSettings.WithVelocity(Math.Abs(int.Parse(velocityInput.Text)));

            particleSettings.WithAgingVelocityIsRandomlyGenerated(agingRand.Checked);
            particleSettings.WithLifetimeIsRandomlyGenerated(lifetimeRand.Checked);
            particleSettings.WithNumberOfNewParticlesIsRandomlyGenerated(newPerFrameRand.Checked);
            particleSettings.WithVelocityIsRandomlyGenerated(velocityRand.Checked);

            //change the Backgroundcolor of the glControl
            GL.ClearColor(particleSettings.getGlControlBackgroundColor());

            context.setIdHolder(idHolder);
            //TODO: read context ... 

            selectedParticleSystem.Init(context, RenderHelper);
            ready = true;
        }

        private void particleSystemSelected(object sender, EventArgs e)
        {
            if (particleSystemSelection.SelectedIndex >= 0)
            {
                frameControls.Enabled = true;
                selectedParticleSystem = particleSystemRegistration.GetParticleSystemInstance((string)particleSystemSelection.SelectedItem);
                panelSystemSettingsPanel = selectedParticleSystem.GetParticleSystemSettingsPanel();
                particleSystemDescription.Text = selectedParticleSystem.GetDescription();

                psSettings.Controls.Remove(particleSystemSettingsPanel);
                particleSystemSettingsPanel = selectedParticleSystem.GetParticleSystemSettingsPanel();
                psSettings.Controls.Add(particleSystemSettingsPanel);
                prepareGeneralSettingsPanel(true);
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
                generalSettings.Enabled = true;
                prepareGeneralSettingsPanel(false);
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

        private void prepareGeneralSettingsPanel(bool overwriteValues)
        {
            ParticleSettings particleSettings = selectedParticleSystem.GetParticleSettings();
            if (overwriteValues)
            {
                //set default values for TextBoxes
                agingVelocityInput.Text = particleSettings.GetAgingVelocity().ToString();
                initialAmountInput.Text = particleSettings.GetInitialNumberOfParticles().ToString();
                newParticlesInput.Text = particleSettings.GetNumberOfNewParticlesPerFrame().ToString();
                lifetimeInput.Text = particleSettings.GetLifetime().ToString();
                velocityInput.Text = particleSettings.GetVelocity().ToString();

                //set default selection for RadioButtons
                if (particleSettings.IsAgingVelocityRandomlyGenerated())
                {
                    agingRand.Checked = true;
                }
                else
                {
                    agingExact.Checked = true;
                }
                if (particleSettings.IsLifetimeRandomlyGenerated())
                {
                    lifetimeRand.Checked = true;
                }
                else
                {
                    lifetimeExact.Checked = true;
                }
                if (particleSettings.IsNumberOfNewParticlesRandomlyGenerated())
                {
                    newPerFrameRand.Checked = true;
                }
                else
                {
                    newPerFrameExact.Checked = true;
                }
                if (particleSettings.IsVelocityRandomlyGenerated())
                {
                    velocityRand.Checked = true;
                }
                else
                {
                    velocityExact.Checked = true;
                }
            }

            ageVelocityPanel.Enabled = particleSettings.IsAgingVelocityEnabled();
            amountPanel.Enabled = particleSettings.IsInitialNumberOfParticlesEnabled();
            lifetimePanel.Enabled = particleSettings.IsLifetimeEnabled();
            newPerFramePanel.Enabled = particleSettings.IsNewParticlesPerFrameEnabled();
            velocityPanel.Enabled =  particleSettings.IsVelocityEnabled();
           
        }

        private void frameButton_Click(object sender, EventArgs e)
        {
            glControl.Invalidate();
        }

        private void moreOptions_Click(object sender, EventArgs e) {
            MoreOptionsWindow moreOptions = new MoreOptionsWindow(this, context);
            moreOptions.Show();
        }

        public void MoreOptionsFormClosed()
        {
            glControl.Invalidate();
        }
    }
}
