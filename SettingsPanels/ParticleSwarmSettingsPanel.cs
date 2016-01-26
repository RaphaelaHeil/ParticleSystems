using OpenTK;
using ParticleSystems.Systems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace ParticleSystems.SettingsPanels
{
    class ParticleSwarmSettingsPanel : ParticleSystemSettingsPanel
    {
        public ParticleSwarmSettingsPanel()
        {
            InitializeComponent();
            //TODO
            PopulateTopologySelection();
        }


        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox yInput;
        private System.Windows.Forms.TextBox xInput;
        private System.Windows.Forms.ComboBox topologySelection;
        private System.Windows.Forms.Button randomLocation;
        private System.Windows.Forms.Button removeSelectedOptima;
        private System.Windows.Forms.CheckedListBox optimaCheckedList;
        private System.Windows.Forms.Button addOptimum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;

        private HashSet<Vector2d> Optima = new HashSet<Vector2d>();

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.randomLocation = new System.Windows.Forms.Button();
            this.removeSelectedOptima = new System.Windows.Forms.Button();
            this.optimaCheckedList = new System.Windows.Forms.CheckedListBox();
            this.addOptimum = new System.Windows.Forms.Button();
            this.yInput = new System.Windows.Forms.TextBox();
            this.xInput = new System.Windows.Forms.TextBox();
            this.topologySelection = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "X";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.randomLocation);
            this.groupBox1.Controls.Add(this.removeSelectedOptima);
            this.groupBox1.Controls.Add(this.optimaCheckedList);
            this.groupBox1.Controls.Add(this.addOptimum);
            this.groupBox1.Controls.Add(this.yInput);
            this.groupBox1.Controls.Add(this.xInput);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 171);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Optimum location";
            // 
            // randomLocation
            // 
            this.randomLocation.Location = new System.Drawing.Point(108, 49);
            this.randomLocation.Name = "randomLocation";
            this.randomLocation.Size = new System.Drawing.Size(75, 39);
            this.randomLocation.TabIndex = 7;
            this.randomLocation.Text = "Random location";
            this.randomLocation.UseVisualStyleBackColor = true;
            this.randomLocation.Click += new System.EventHandler(this.randomLocation_Click);
            // 
            // removeSelectedOptima
            // 
            this.removeSelectedOptima.Location = new System.Drawing.Point(290, 136);
            this.removeSelectedOptima.Name = "removeSelectedOptima";
            this.removeSelectedOptima.Size = new System.Drawing.Size(134, 23);
            this.removeSelectedOptima.TabIndex = 6;
            this.removeSelectedOptima.Text = "Remove selected optima";
            this.removeSelectedOptima.UseVisualStyleBackColor = true;
            this.removeSelectedOptima.Click += new System.EventHandler(this.removeSelectedOptima_Click);
            // 
            // optimaCheckedList
            // 
            this.optimaCheckedList.FormattingEnabled = true;
            this.optimaCheckedList.Location = new System.Drawing.Point(211, 20);
            this.optimaCheckedList.Name = "optimaCheckedList";
            this.optimaCheckedList.Size = new System.Drawing.Size(214, 109);
            this.optimaCheckedList.TabIndex = 5;
            // 
            // addOptimum
            // 
            this.addOptimum.Location = new System.Drawing.Point(9, 106);
            this.addOptimum.Name = "addOptimum";
            this.addOptimum.Size = new System.Drawing.Size(153, 23);
            this.addOptimum.TabIndex = 4;
            this.addOptimum.Text = "Add optimum";
            this.addOptimum.UseVisualStyleBackColor = true;
            this.addOptimum.Click += new System.EventHandler(this.addOptimum_Click);
            // 
            // yInput
            // 
            this.yInput.Location = new System.Drawing.Point(26, 68);
            this.yInput.Name = "yInput";
            this.yInput.Size = new System.Drawing.Size(76, 20);
            this.yInput.TabIndex = 3;
            this.yInput.Text = "100";
            this.yInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // xInput
            // 
            this.xInput.Location = new System.Drawing.Point(26, 49);
            this.xInput.Name = "xInput";
            this.xInput.Size = new System.Drawing.Size(76, 20);
            this.xInput.TabIndex = 2;
            this.xInput.Text = "200";
            this.xInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // topologySelection
            // 
            this.topologySelection.FormattingEnabled = true;
            this.topologySelection.Location = new System.Drawing.Point(66, 8);
            this.topologySelection.Name = "topologySelection";
            this.topologySelection.Size = new System.Drawing.Size(121, 21);
            this.topologySelection.TabIndex = 3;

        


            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Topology";
            // 
            // ParticleSwarmSettingsPanel
            // 
            this.Controls.Add(this.label3);
            this.Controls.Add(this.topologySelection);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ParticleSwarmSettingsPanel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public Vector2d GetTargetPosition()
        {
            return new Vector2d(double.Parse(xInput.Text), double.Parse(yInput.Text));
        }

        public HashSet<Vector2d> GetOptima()
        {
            return Optima;
        }


        private void addOptimum_Click(object sender, EventArgs e)
        {
            Vector2d optimum = new Vector2d((int)double.Parse(xInput.Text), (int)double.Parse(yInput.Text));
            Optima.Add(optimum);
            optimaCheckedList.Items.Add(optimum);
        }

        private void randomLocation_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            xInput.Text = random.Next(600).ToString();
            yInput.Text = random.Next(600).ToString();
        }

        private void removeSelectedOptima_Click(object sender, EventArgs e)
        {
            while (optimaCheckedList.CheckedItems.Count > 0)
            {
                Optima.Remove((Vector2d)optimaCheckedList.CheckedItems[0]);
                optimaCheckedList.Items.Remove(optimaCheckedList.CheckedItems[0]);
            }
        }

        private void PopulateTopologySelection()
        {
            topologySelection.DataSource = Enum.GetValues(typeof(Topology));
        }

        public Topology GetSelectedTopology()
        {
            return (Topology)topologySelection.SelectedItem;
        }

    }
}
