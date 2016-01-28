using OpenTK;
using ParticleSystems.Strategies;
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
        
            PopulateTopologySelection();
            
            Location = new System.Drawing.Point(9, 16);
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
        private System.Windows.Forms.TextBox weightInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ignoreWeights;
        private IContainer components;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox neighbourhoodInput;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox yMaxInput;
        private System.Windows.Forms.TextBox yMinInput;
        private System.Windows.Forms.TextBox xMinInput;
        private System.Windows.Forms.TextBox xMaxInput;
        private HashSet<SwarmOptimum> Optima = new HashSet<SwarmOptimum>();

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ignoreWeights = new System.Windows.Forms.CheckBox();
            this.weightInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.randomLocation = new System.Windows.Forms.Button();
            this.removeSelectedOptima = new System.Windows.Forms.Button();
            this.optimaCheckedList = new System.Windows.Forms.CheckedListBox();
            this.addOptimum = new System.Windows.Forms.Button();
            this.yInput = new System.Windows.Forms.TextBox();
            this.xInput = new System.Windows.Forms.TextBox();
            this.topologySelection = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.neighbourhoodInput = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.yMaxInput = new System.Windows.Forms.TextBox();
            this.yMinInput = new System.Windows.Forms.TextBox();
            this.xMinInput = new System.Windows.Forms.TextBox();
            this.xMaxInput = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "X";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ignoreWeights);
            this.groupBox1.Controls.Add(this.weightInput);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.randomLocation);
            this.groupBox1.Controls.Add(this.removeSelectedOptima);
            this.groupBox1.Controls.Add(this.optimaCheckedList);
            this.groupBox1.Controls.Add(this.addOptimum);
            this.groupBox1.Controls.Add(this.yInput);
            this.groupBox1.Controls.Add(this.xInput);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 141);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Optima";
            // 
            // ignoreWeights
            // 
            this.ignoreWeights.AutoSize = true;
            this.ignoreWeights.Location = new System.Drawing.Point(6, 90);
            this.ignoreWeights.Name = "ignoreWeights";
            this.ignoreWeights.Size = new System.Drawing.Size(134, 17);
            this.ignoreWeights.TabIndex = 8;
            this.ignoreWeights.Text = "Ignore Optima Weights";
            this.toolTip1.SetToolTip(this.ignoreWeights, "Ignore the assigned weights when calculating a particle\'s fitness");
            this.ignoreWeights.UseVisualStyleBackColor = true;
            // 
            // weightInput
            // 
            this.weightInput.Location = new System.Drawing.Point(54, 64);
            this.weightInput.Name = "weightInput";
            this.weightInput.Size = new System.Drawing.Size(48, 20);
            this.weightInput.TabIndex = 9;
            this.weightInput.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Weight";
            // 
            // randomLocation
            // 
            this.randomLocation.Location = new System.Drawing.Point(108, 19);
            this.randomLocation.Name = "randomLocation";
            this.randomLocation.Size = new System.Drawing.Size(75, 39);
            this.randomLocation.TabIndex = 7;
            this.randomLocation.Text = "Random location";
            this.randomLocation.UseVisualStyleBackColor = true;
            this.randomLocation.Click += new System.EventHandler(this.randomLocation_Click);
            // 
            // removeSelectedOptima
            // 
            this.removeSelectedOptima.Location = new System.Drawing.Point(290, 113);
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
            this.optimaCheckedList.Location = new System.Drawing.Point(210, 19);
            this.optimaCheckedList.Name = "optimaCheckedList";
            this.optimaCheckedList.Size = new System.Drawing.Size(214, 79);
            this.optimaCheckedList.TabIndex = 5;
            // 
            // addOptimum
            // 
            this.addOptimum.Location = new System.Drawing.Point(30, 113);
            this.addOptimum.Name = "addOptimum";
            this.addOptimum.Size = new System.Drawing.Size(153, 23);
            this.addOptimum.TabIndex = 4;
            this.addOptimum.Text = "Add optimum";
            this.addOptimum.UseVisualStyleBackColor = true;
            this.addOptimum.Click += new System.EventHandler(this.addOptimum_Click);
            // 
            // yInput
            // 
            this.yInput.Location = new System.Drawing.Point(26, 38);
            this.yInput.Name = "yInput";
            this.yInput.Size = new System.Drawing.Size(76, 20);
            this.yInput.TabIndex = 3;
            this.yInput.Text = "100";
            this.yInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // xInput
            // 
            this.xInput.Location = new System.Drawing.Point(26, 19);
            this.xInput.Name = "xInput";
            this.xInput.Size = new System.Drawing.Size(76, 20);
            this.xInput.TabIndex = 2;
            this.xInput.Text = "200";
            this.xInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // topologySelection
            // 
            this.topologySelection.FormattingEnabled = true;
            this.topologySelection.Location = new System.Drawing.Point(57, 8);
            this.topologySelection.Name = "topologySelection";
            this.topologySelection.Size = new System.Drawing.Size(121, 21);
            this.topologySelection.TabIndex = 3;
            this.topologySelection.SelectedValueChanged += new System.EventHandler(this.topologySelection_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Topology";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Neighbourhood size";
            this.toolTip1.SetToolTip(this.label6, "Ring: # of adjacent particles to consider\r\nMesh: grid cell size");
            // 
            // neighbourhoodInput
            // 
            this.neighbourhoodInput.Location = new System.Drawing.Point(116, 32);
            this.neighbourhoodInput.Name = "neighbourhoodInput";
            this.neighbourhoodInput.Size = new System.Drawing.Size(62, 20);
            this.neighbourhoodInput.TabIndex = 8;
            this.neighbourhoodInput.Text = "5";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.yMaxInput);
            this.groupBox2.Controls.Add(this.yMinInput);
            this.groupBox2.Controls.Add(this.xMinInput);
            this.groupBox2.Controls.Add(this.xMaxInput);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(192, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 68);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Particle Generation Area";
            // 
            // yMaxInput
            // 
            this.yMaxInput.Location = new System.Drawing.Point(179, 39);
            this.yMaxInput.Name = "yMaxInput";
            this.yMaxInput.Size = new System.Drawing.Size(56, 20);
            this.yMaxInput.TabIndex = 7;
            this.yMaxInput.Text = "600";
            // 
            // yMinInput
            // 
            this.yMinInput.Location = new System.Drawing.Point(41, 39);
            this.yMinInput.Name = "yMinInput";
            this.yMinInput.Size = new System.Drawing.Size(56, 20);
            this.yMinInput.TabIndex = 6;
            this.yMinInput.Text = "0";
            // 
            // xMinInput
            // 
            this.xMinInput.Location = new System.Drawing.Point(41, 13);
            this.xMinInput.Name = "xMinInput";
            this.xMinInput.Size = new System.Drawing.Size(56, 20);
            this.xMinInput.TabIndex = 5;
            this.xMinInput.Text = "0";
            // 
            // xMaxInput
            // 
            this.xMaxInput.Location = new System.Drawing.Point(179, 13);
            this.xMaxInput.Name = "xMaxInput";
            this.xMaxInput.Size = new System.Drawing.Size(56, 20);
            this.xMaxInput.TabIndex = 4;
            this.xMaxInput.Text = "600";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(141, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "yMax";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(141, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "xMax";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "xMin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "yMin";
            // 
            // ParticleSwarmSettingsPanel
            // 
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.neighbourhoodInput);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.topologySelection);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ParticleSwarmSettingsPanel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public Vector2d GetTargetPosition()
        {
            return new Vector2d(double.Parse(xInput.Text), double.Parse(yInput.Text));
        }

        public HashSet<SwarmOptimum> GetOptima()
        {
            return Optima;
        }


        private void addOptimum_Click(object sender, EventArgs e)
        {
            Vector2d position = new Vector2d(int.Parse(xInput.Text), int.Parse(yInput.Text));
            int weight = int.Parse(weightInput.Text);
            if (weight <= 0)
            {
                weight = 1;
            }
            SwarmOptimum optimum = new SwarmOptimum(position, weight);

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
                Optima.Remove((SwarmOptimum)optimaCheckedList.CheckedItems[0]);
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

        private void topologySelection_SelectedValueChanged(object sender, EventArgs e)
        {
            if(GetSelectedTopology() == Topology.Global)
            {
                neighbourhoodInput.Enabled = false;
            }
            else
            {
                neighbourhoodInput.Enabled = true;
            }
        }

        public int GetXMin()
        {
            return int.Parse(xMinInput.Text);
        }

        public int GetXMax()
        {
            return int.Parse(xMaxInput.Text);
        }

        public int GetyMin()
        {
            return int.Parse(yMinInput.Text);
        }

        public int GetYMax()
        {
            return int.Parse(yMaxInput.Text);
        }

        public int GetNeighbourhoodSize()
        {
            return int.Parse(neighbourhoodInput.Text);
        }

        public bool AreWeightsIgnored()
        {
            return ignoreWeights.Checked;
        }

    }
}
