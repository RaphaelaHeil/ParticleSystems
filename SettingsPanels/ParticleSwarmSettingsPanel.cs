using OpenTK;

namespace ParticleSystems.SettingsPanels
{
    class ParticleSwarmSettingsPanel : ParticleSystemSettingsPanel
    {
        public ParticleSwarmSettingsPanel()
        {
            InitializeComponent();
        }


        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox yInput;
        private System.Windows.Forms.TextBox xInput;
        private System.Windows.Forms.Label label1;

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.yInput = new System.Windows.Forms.TextBox();
            this.xInput = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "X";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.yInput);
            this.groupBox1.Controls.Add(this.xInput);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 80);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Optimum location";
            // 
            // yInput
            // 
            this.yInput.Location = new System.Drawing.Point(239, 33);
            this.yInput.Name = "yInput";
            this.yInput.Size = new System.Drawing.Size(66, 20);
            this.yInput.TabIndex = 3;
            this.yInput.Text = "300,0";
            this.yInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // xInput
            // 
            this.xInput.Location = new System.Drawing.Point(26, 30);
            this.xInput.Name = "xInput";
            this.xInput.Size = new System.Drawing.Size(55, 20);
            this.xInput.TabIndex = 2;
            this.xInput.Text = "300,0";
            this.xInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ParticleSwarmSettingsPanel
            // 
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ParticleSwarmSettingsPanel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        public Vector2d GetTargetPosition()
        {
            return new Vector2d(double.Parse(xInput.Text), double.Parse(yInput.Text));
        }
    }
}
