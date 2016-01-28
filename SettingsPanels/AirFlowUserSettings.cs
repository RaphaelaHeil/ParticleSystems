using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ParticleSystems.SettingsPanels
{
    /// <summary>
    /// Settings-Pnael for the Airflow Particle System.
    /// Some unique setting for the Airflow system can be made here.
    /// </summary>
    public partial class AirFlowUserSettings : ParticleSystemSettingsPanel
    {

        /// <summary>
        /// Contructor for the Airflow settings.
        /// Call the initalize method.
        /// </summary>
        public AirFlowUserSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the components on the settings panel.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.colorIndicator = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkVortex = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkInteraction = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rangeText = new System.Windows.Forms.TextBox();
            this.repelText = new System.Windows.Forms.TextBox();
            this.randomRepelCheck = new System.Windows.Forms.CheckBox();
            this.randomRangeCheckt = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.colorIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // colorDialog
            // 
            this.colorDialog.Color = System.Drawing.Color.Gray;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "! The background assumes the complementary color !";
            // 
            // colorIndicator
            // 
            this.colorIndicator.BackColor = this.colorDialog.Color;
            this.colorIndicator.Location = new System.Drawing.Point(45, 5);
            this.colorIndicator.Name = "colorIndicator";
            this.colorIndicator.Size = new System.Drawing.Size(20, 20);
            this.colorIndicator.TabIndex = 2;
            this.colorIndicator.TabStop = false;
            this.colorIndicator.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorIndicator_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Color:";
            // 
            // checkVortex
            // 
            this.checkVortex.AutoSize = true;
            this.checkVortex.Location = new System.Drawing.Point(13, 31);
            this.checkVortex.Name = "checkVortex";
            this.checkVortex.Size = new System.Drawing.Size(56, 17);
            this.checkVortex.TabIndex = 6;
            this.checkVortex.Text = "Vortex";
            this.checkVortex.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // checkInteraction
            // 
            this.checkInteraction.AutoSize = true;
            this.checkInteraction.Checked = true;
            this.checkInteraction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkInteraction.Location = new System.Drawing.Point(13, 54);
            this.checkInteraction.Name = "checkInteraction";
            this.checkInteraction.Size = new System.Drawing.Size(76, 17);
            this.checkInteraction.TabIndex = 7;
            this.checkInteraction.Text = "Interaction";
            this.checkInteraction.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Particle Interaction Range:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(122, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Repel distance:";
            // 
            // rangeText
            // 
            this.rangeText.Location = new System.Drawing.Point(261, 32);
            this.rangeText.Name = "rangeText";
            this.rangeText.Size = new System.Drawing.Size(43, 20);
            this.rangeText.TabIndex = 10;
            this.rangeText.Text = "4";
            this.rangeText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // repelText
            // 
            this.repelText.Location = new System.Drawing.Point(261, 58);
            this.repelText.Name = "repelText";
            this.repelText.Size = new System.Drawing.Size(43, 20);
            this.repelText.TabIndex = 11;
            this.repelText.Text = "4";
            this.repelText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // randomRepelCheck
            // 
            this.randomRepelCheck.AutoSize = true;
            this.randomRepelCheck.Location = new System.Drawing.Point(310, 60);
            this.randomRepelCheck.Name = "randomRepelCheck";
            this.randomRepelCheck.Size = new System.Drawing.Size(66, 17);
            this.randomRepelCheck.TabIndex = 12;
            this.randomRepelCheck.Text = "Random";
            this.randomRepelCheck.UseVisualStyleBackColor = true;
            // 
            // randomRangeCheckt
            // 
            this.randomRangeCheckt.AutoSize = true;
            this.randomRangeCheckt.Location = new System.Drawing.Point(310, 34);
            this.randomRangeCheckt.Name = "randomRangeCheckt";
            this.randomRangeCheckt.Size = new System.Drawing.Size(66, 17);
            this.randomRangeCheckt.TabIndex = 13;
            this.randomRangeCheckt.Text = "Random";
            this.randomRangeCheckt.UseVisualStyleBackColor = true;
            // 
            // AirFlowUserSettings
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.randomRangeCheckt);
            this.Controls.Add(this.randomRepelCheck);
            this.Controls.Add(this.repelText);
            this.Controls.Add(this.rangeText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkInteraction);
            this.Controls.Add(this.checkVortex);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.colorIndicator);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(6, 16);
            this.Name = "AirFlowUserSettings";
            ((System.ComponentModel.ISupportInitialize)(this.colorIndicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// Returns the colour, which is picked in the color picker
        /// </summary>
        /// <returns></returns>
        public Color getColor()
        {
            return this.colorIndicator.BackColor;
        }

        /// <summary>
        /// Returns true if the Vortex-Check-Box is checked. False if not.
        /// </summary>
        /// <returns></returns>
        public bool GetVortex()
        {
            if (this.checkVortex.Checked)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Returns true if the Interaction-Check-Box is checked. False if not.
        /// </summary>
        /// <returns></returns>
        public bool GetInteraction()
        {
            if (this.checkInteraction.Checked)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Returns the range in witch the particles will be interact.
        /// </summary>
        /// <returns></returns>
        public int getRange()
        {
            return int.Parse(this.rangeText.Text);
        }

        /// <summary>
        /// Returns the distance the particle will be moved if the interaction takes place.
        /// </summary>
        /// <returns></returns>
        public int getRepel()
        {
            return int.Parse(this.repelText.Text);
        }

        /// <summary>
        /// Returns true if the Random-Repel-Check-Box is checked. False if not.
        /// The repel distance will be random generated.
        /// </summary>
        /// <returns></returns>
        public bool getRandomRepel()
        {
            return this.randomRepelCheck.Checked;
        }

        /// <summary>
        /// Returns true if the Random-Range-Check-Box is checked. False if not.
        /// The interaction range will be random generated.
        /// </summary>
        /// <returns></returns>
        public bool getRandomRange()
        {
            return this.randomRangeCheckt.Checked;
        }

        /// <summary>
        /// Handle colur picker mouse click and opens the colour picker-dialoge,
        /// to choose a colour for the particles.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorIndicator_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.colorIndicator.BackColor = this.colorDialog.Color;
            }
        }
    }
}
