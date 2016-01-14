using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ParticleSystems.SettingsPanels
{
    public partial class AirFlowUserSettings : ParticleSystemSettingsPanel {
        private List<PlaceableObject> placableObjectList = new List<PlaceableObject>();

        public AirFlowUserSettings()
        {
            InitializeComponent(); 
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.placeButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.sizeW = new System.Windows.Forms.TextBox();
            this.sizeH = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.posY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.posX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.objectSelect = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.colorIndicator = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.placeButton);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.sizeW);
            this.groupBox1.Controls.Add(this.sizeH);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.posY);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.posX);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.objectSelect);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(6, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 175);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Place Object";
            // 
            // placeButton
            // 
            this.placeButton.Location = new System.Drawing.Point(81, 142);
            this.placeButton.Name = "placeButton";
            this.placeButton.Size = new System.Drawing.Size(80, 23);
            this.placeButton.TabIndex = 20;
            this.placeButton.Text = "Place Object";
            this.placeButton.UseVisualStyleBackColor = true;
            this.placeButton.Click += new System.EventHandler(this.placeButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label7.Location = new System.Drawing.Point(58, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "W:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label9.Location = new System.Drawing.Point(61, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "H:";
            // 
            // sizeW
            // 
            this.sizeW.Enabled = false;
            this.sizeW.Location = new System.Drawing.Point(81, 110);
            this.sizeW.Name = "sizeW";
            this.sizeW.Size = new System.Drawing.Size(80, 20);
            this.sizeW.TabIndex = 17;
            this.sizeW.Text = "30";
            this.sizeW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sizeH
            // 
            this.sizeH.Location = new System.Drawing.Point(81, 91);
            this.sizeH.Name = "sizeH";
            this.sizeH.Size = new System.Drawing.Size(80, 20);
            this.sizeH.TabIndex = 16;
            this.sizeH.Text = "30";
            this.sizeH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Size:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Y:";
            // 
            // posY
            // 
            this.posY.Location = new System.Drawing.Point(81, 65);
            this.posY.Name = "posY";
            this.posY.Size = new System.Drawing.Size(80, 20);
            this.posY.TabIndex = 13;
            this.posY.Text = "300";
            this.posY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "X:";
            // 
            // posX
            // 
            this.posX.Location = new System.Drawing.Point(81, 46);
            this.posX.Name = "posX";
            this.posX.Size = new System.Drawing.Size(80, 20);
            this.posX.TabIndex = 11;
            this.posX.Text = "300";
            this.posX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Position:";
            // 
            // objectSelect
            // 
            this.objectSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.objectSelect.FormattingEnabled = true;
            this.objectSelect.Items.AddRange(new object[] {
            "Square"});
            this.objectSelect.Location = new System.Drawing.Point(81, 17);
            this.objectSelect.Name = "objectSelect";
            this.objectSelect.Size = new System.Drawing.Size(80, 21);
            this.objectSelect.TabIndex = 9;
            this.objectSelect.SelectedIndexChanged += new System.EventHandler(this.objectSelect_SelectedIndexChanged);
            this.objectSelect.SelectedIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Object:";
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
            // AirFlowUserSettings
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.colorIndicator);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(6, 16);
            this.Name = "AirFlowUserSettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorIndicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public Color getColor()
        {
            return this.colorIndicator.BackColor;
        }

        private void resetButton_MouseClick(object sender, MouseEventArgs e)
        {
            //ToDo: Reset the drawing-area
        }

        private void colorIndicator_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.colorIndicator.BackColor = this.colorDialog.Color;
            }
        }

        private void placeButton_Click(object sender, System.EventArgs e)
        {
            string objectShape = objectSelect.SelectedItem.ToString();
            int positionX = int.Parse(posX.Text);
            int positionY = int.Parse(posY.Text);
            int sizeHeight = int.Parse(sizeH.Text);
            int sizeWidth = sizeHeight;
            if (objectShape == "rectangle")
                sizeWidth = int.Parse(sizeW.Text);

            createObject(objectShape, positionX, positionY, sizeHeight, sizeWidth);
            putVisibleObjectToGlControl(objectShape, positionX, positionY, sizeHeight, sizeWidth);
        }

        private void objectSelect_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string objectShape = objectSelect.SelectedItem.ToString();
            if (objectShape == "rectangle")   
                sizeW.Enabled = true;
            else
                sizeW.Enabled = false;
        }

        private void createObject(string objectShape, int positionX, int positionY , int sizeHeight, int sizeWidth)
        {
            PlaceableObject po = new PlaceableObject(objectShape, positionX, positionY, sizeHeight, sizeWidth);
            PlacableObjectList.Add(po);
        }

        private void putVisibleObjectToGlControl(string objectShape, int positionX, int positionY, int sizeHeight, int sizeWidth)
        {

        }

        internal List<PlaceableObject> PlacableObjectList
        {
            get
            {
                return placableObjectList;
            }

            set
            {
                placableObjectList = value;
            }
        }
    }
}
