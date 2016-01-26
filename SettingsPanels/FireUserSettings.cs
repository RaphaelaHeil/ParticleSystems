using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ParticleSystems.SettingsPanels
{
	public partial class FireUserSettings : ParticleSystemSettingsPanel {
		

		public FireUserSettings()
		{
			InitializeComponent(); 
		}

		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.xMin = new System.Windows.Forms.TextBox();
            this.xMax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.einflussbereich = new System.Windows.Forms.TextBox();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wasserfall Startposition X-Achse";
            // 
            // xMin
            // 
            this.xMin.Location = new System.Drawing.Point(79, 84);
            this.xMin.Name = "xMin";
            this.xMin.Size = new System.Drawing.Size(100, 20);
            this.xMin.TabIndex = 2;
            this.xMin.Text = "260";
            // 
            // xMax
            // 
            this.xMax.Location = new System.Drawing.Point(79, 143);
            this.xMax.Name = "xMax";
            this.xMax.Size = new System.Drawing.Size(100, 20);
            this.xMax.TabIndex = 3;
            this.xMax.Text = "340";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Wasserfall Endposition X-Achse";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Einflussbereich Wasser";
            // 
            // einflussbereich
            // 
            this.einflussbereich.Location = new System.Drawing.Point(299, 83);
            this.einflussbereich.Name = "einflussbereich";
            this.einflussbereich.Size = new System.Drawing.Size(100, 20);
            this.einflussbereich.TabIndex = 7;
            this.einflussbereich.Text = "5";
            // 
            // FireUserSettings
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.einflussbereich);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.xMax);
            this.Controls.Add(this.xMin);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(6, 16);
            this.Name = "FireUserSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		public int GetXMin()
        {
            return int.Parse(xMin.Text);
        }

        public int GetXMax()
        {
            return int.Parse(xMax.Text);
        }

        public int GetRange()
        {
            return int.Parse(einflussbereich.Text);
        }
	
    }
}
