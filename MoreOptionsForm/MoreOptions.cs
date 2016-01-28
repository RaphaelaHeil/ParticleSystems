using System;
using System.Windows.Forms;

namespace ParticleSystems.MoreOptionsForm
{
    /// <summary>
    /// More-Options-Window class.
    /// Provide options to place an object in the graphic plane.
    /// </summary>
    class MoreOptionsWindow : Form
    {
        GroupBox placeObjectListBox;
        GroupBox placeObjectBox;
        Button placeButton;
        Label wLabel;
        Label hLabel;
        TextBox sizeW;
        TextBox sizeH;
        Label sizeLabel;
        Label yLabel;
        TextBox posY;
        Label xLabel;
        TextBox posX;
        Label positionLabel;
        ComboBox objectSelect;
        Label objectLabel;

        private CheckedListBox checkedListBox1;
        private Button removeButton;
        Context context;
        MainFrame MainFrame;

        /// <summary>
        /// Contructor for the More-Options-Window class.
        /// Initalizes context and the main frame object.
        /// Calls the InitializeComponent method.
        /// Calls the fillPlacedObjectListFromContext method, 
        /// to list the values of the plcable object, 
        /// wich are allready placed.
        /// </summary>
        /// <param name="mainFrame"></param>
        /// <param name="context"></param>
        public MoreOptionsWindow(MainFrame mainFrame, Context context)
        {
            this.context = context;
            MainFrame = mainFrame;
            InitializeComponent();
            fillPlacedObjectListFromContext();
        }

        /// <summary>
        /// Initializes the components on the More-Options-Window.
        /// </summary>
        private void InitializeComponent()
        {
            this.placeObjectListBox = new System.Windows.Forms.GroupBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.placeObjectBox = new System.Windows.Forms.GroupBox();
            this.placeButton = new System.Windows.Forms.Button();
            this.wLabel = new System.Windows.Forms.Label();
            this.hLabel = new System.Windows.Forms.Label();
            this.sizeW = new System.Windows.Forms.TextBox();
            this.sizeH = new System.Windows.Forms.TextBox();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.posY = new System.Windows.Forms.TextBox();
            this.xLabel = new System.Windows.Forms.Label();
            this.posX = new System.Windows.Forms.TextBox();
            this.positionLabel = new System.Windows.Forms.Label();
            this.objectSelect = new System.Windows.Forms.ComboBox();
            this.objectLabel = new System.Windows.Forms.Label();
            this.placeObjectListBox.SuspendLayout();
            this.placeObjectBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // placeObjectListBox
            // 
            this.placeObjectListBox.Controls.Add(this.removeButton);
            this.placeObjectListBox.Controls.Add(this.checkedListBox1);
            this.placeObjectListBox.Location = new System.Drawing.Point(185, 6);
            this.placeObjectListBox.Name = "placeObjectListBox";
            this.placeObjectListBox.Size = new System.Drawing.Size(290, 175);
            this.placeObjectListBox.TabIndex = 7;
            this.placeObjectListBox.TabStop = false;
            this.placeObjectListBox.Text = "Placed Object List";
            // 
            // button1
            // 
            this.removeButton.Location = new System.Drawing.Point(171, 146);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(113, 23);
            this.removeButton.TabIndex = 10;
            this.removeButton.Text = "Remove selected";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(6, 19);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(278, 124);
            this.checkedListBox1.TabIndex = 9;
            // 
            // placeObjectBox
            // 
            this.placeObjectBox.Controls.Add(this.placeButton);
            this.placeObjectBox.Controls.Add(this.wLabel);
            this.placeObjectBox.Controls.Add(this.hLabel);
            this.placeObjectBox.Controls.Add(this.sizeW);
            this.placeObjectBox.Controls.Add(this.sizeH);
            this.placeObjectBox.Controls.Add(this.sizeLabel);
            this.placeObjectBox.Controls.Add(this.yLabel);
            this.placeObjectBox.Controls.Add(this.posY);
            this.placeObjectBox.Controls.Add(this.xLabel);
            this.placeObjectBox.Controls.Add(this.posX);
            this.placeObjectBox.Controls.Add(this.positionLabel);
            this.placeObjectBox.Controls.Add(this.objectSelect);
            this.placeObjectBox.Controls.Add(this.objectLabel);
            this.placeObjectBox.Location = new System.Drawing.Point(6, 6);
            this.placeObjectBox.Name = "placeObjectBox";
            this.placeObjectBox.Size = new System.Drawing.Size(175, 175);
            this.placeObjectBox.TabIndex = 8;
            this.placeObjectBox.TabStop = false;
            this.placeObjectBox.Text = "Place Object";
            // 
            // placeButton
            // 
            this.placeButton.Enabled = true;
            this.placeButton.Location = new System.Drawing.Point(81, 142);
            this.placeButton.Name = "placeButton";
            this.placeButton.Size = new System.Drawing.Size(80, 23);
            this.placeButton.TabIndex = 20;
            this.placeButton.Text = "Place Object";
            this.placeButton.UseVisualStyleBackColor = true;
            this.placeButton.Click += new System.EventHandler(this.placeButton_Click);
            // 
            // wLabel
            // 
            this.wLabel.AutoSize = true;
            this.wLabel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.wLabel.Location = new System.Drawing.Point(58, 113);
            this.wLabel.Name = "wLabel";
            this.wLabel.Size = new System.Drawing.Size(21, 13);
            this.wLabel.TabIndex = 19;
            this.wLabel.Text = "W:";
            // 
            // hLabel
            // 
            this.hLabel.AutoSize = true;
            this.hLabel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.hLabel.Location = new System.Drawing.Point(61, 94);
            this.hLabel.Name = "hLabel";
            this.hLabel.Size = new System.Drawing.Size(18, 13);
            this.hLabel.TabIndex = 18;
            this.hLabel.Text = "H:";
            // 
            // sizeW
            // 
            this.sizeW.Enabled = false;
            this.sizeW.Location = new System.Drawing.Point(81, 110);
            this.sizeW.Name = "sizeW";
            this.sizeW.Size = new System.Drawing.Size(80, 20);
            this.sizeW.TabIndex = 17;
            this.sizeW.Text = "100";
            this.sizeW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sizeH
            // 
            this.sizeH.Location = new System.Drawing.Point(81, 91);
            this.sizeH.Name = "sizeH";
            this.sizeH.Size = new System.Drawing.Size(80, 20);
            this.sizeH.TabIndex = 16;
            this.sizeH.Text = "100";
            this.sizeH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(12, 95);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(30, 13);
            this.sizeLabel.TabIndex = 15;
            this.sizeLabel.Text = "Size:";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(62, 68);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(17, 13);
            this.yLabel.TabIndex = 14;
            this.yLabel.Text = "Y:";
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
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(62, 49);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(17, 13);
            this.xLabel.TabIndex = 12;
            this.xLabel.Text = "X:";
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
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Location = new System.Drawing.Point(12, 50);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(47, 13);
            this.positionLabel.TabIndex = 10;
            this.positionLabel.Text = "Position:";
            // 
            // objectSelect
            // 
            this.objectSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.objectSelect.FormattingEnabled = true;



            this.objectSelect.DataSource = Enum.GetValues(typeof(PlaceableObject.Shape));
            this.objectSelect.Location = new System.Drawing.Point(81, 17);
            this.objectSelect.Name = "objectSelect";
            this.objectSelect.Size = new System.Drawing.Size(80, 21);
            this.objectSelect.TabIndex = 9;
            this.objectSelect.SelectedIndexChanged += new System.EventHandler(this.objectSelect_SelectedIndexChanged);
            // 
            // objectLabel
            // 
            this.objectLabel.AutoSize = true;
            this.objectLabel.Location = new System.Drawing.Point(12, 21);
            this.objectLabel.Name = "objectLabel";
            this.objectLabel.Size = new System.Drawing.Size(41, 13);
            this.objectLabel.TabIndex = 8;
            this.objectLabel.Text = "Object:";
            // 
            // MoreOptionsWindow
            // 
            this.ClientSize = new System.Drawing.Size(482, 192);
            this.Controls.Add(this.placeObjectBox);
            this.Controls.Add(this.placeObjectListBox);
            this.Name = "MoreOptionsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "More Options";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MoreOptionsWindow_FormClosed);
            this.placeObjectListBox.ResumeLayout(false);
            this.placeObjectBox.ResumeLayout(false);
            this.placeObjectBox.PerformLayout();
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Handles the place object button click.
        /// Put the values of the placable object into the text list,
        /// and added a new placable object to the context.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void placeButton_Click(object sender, System.EventArgs e)
        {
            PlaceableObject.Shape objectShape = (PlaceableObject.Shape)objectSelect.SelectedItem;
            int positionX = int.Parse(posX.Text);
            int positionY = int.Parse(posY.Text);
            int sizeHeight = int.Parse(sizeH.Text);
            int sizeWidth = sizeHeight;
            if (objectShape == PlaceableObject.Shape.Rectangle)
            {
                sizeWidth = int.Parse(sizeW.Text);
            }

            PlaceableObject placeableObject = new PlaceableObject(objectShape, positionX, positionY, sizeHeight, sizeWidth);

            context.addPlacableObject(placeableObject);
            putVisibleObjectToGlControl(placeableObject);
        }

        /// <summary>
        /// Handles the object shape select.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void objectSelect_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            placeButton.Enabled = true;
            PlaceableObject.Shape objectShape = (PlaceableObject.Shape)objectSelect.SelectedItem;
            if (objectShape == PlaceableObject.Shape.Rectangle)
            {
                sizeW.Enabled = true;
            }
            else {
                sizeW.Enabled = false;
            }
        }

        /// <summary>
        /// Put the values of the allready exiting placable objects into the text list.
        /// </summary>
        private void fillPlacedObjectListFromContext()
        {
                checkedListBox1.Items.Clear();
                checkedListBox1.Items.AddRange(context.getPlacableObjects().ToArray());
        }

        /// <summary>
        /// Put the values of the placable object into the text list.
        /// </summary>
        /// <param name="placeableObject"></param>
        private void putVisibleObjectToGlControl(PlaceableObject placeableObject)
        {
            checkedListBox1.Items.Add(placeableObject);
        }

        /// <summary>
        /// Removes the values of the placable object from the text list,
        /// and deletes a placable object from the context.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            while (checkedListBox1.CheckedItems.Count > 0)
            {
                context.removePlaceableObject((PlaceableObject)checkedListBox1.CheckedItems[0]);
                checkedListBox1.Items.Remove(checkedListBox1.CheckedItems[0]);
            }
        }

        /// <summary>
        /// Handles the close event of the More-Options-Window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoreOptionsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainFrame.MoreOptionsFormClosed();
        }
    }
}
