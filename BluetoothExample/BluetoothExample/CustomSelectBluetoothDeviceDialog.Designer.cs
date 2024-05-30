namespace BluetoothExample
{
    partial class CustomSelectBluetoothDeviceDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomSelectBluetoothDeviceDialog));
            btnSearch = new Button();
            btnOK = new Button();
            btnCancel = new Button();
            lblInstructions = new Label();
            lstDevices = new ListView();
            deviceImages = new ImageList(components);
            lblScanning = new Label();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(24, 415);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(121, 23);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "&Search Again";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Enabled = false;
            btnOK.Location = new Point(497, 415);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 1;
            btnOK.Text = "&OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(578, 415);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblInstructions
            // 
            lblInstructions.AutoSize = true;
            lblInstructions.Location = new Point(24, 363);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(558, 15);
            lblInstructions.TabIndex = 3;
            lblInstructions.Text = "If you don't see the Halo device you want to add, open the DSS app on the Halo, then click Search Again.";
            // 
            // lstDevices
            // 
            lstDevices.LargeImageList = deviceImages;
            lstDevices.Location = new Point(12, 12);
            lstDevices.Name = "lstDevices";
            lstDevices.Size = new Size(641, 338);
            lstDevices.TabIndex = 4;
            lstDevices.UseCompatibleStateImageBehavior = false;
            lstDevices.SelectedIndexChanged += lstDevices_SelectedIndexChanged;
            // 
            // deviceImages
            // 
            deviceImages.ColorDepth = ColorDepth.Depth8Bit;
            deviceImages.ImageStream = (ImageListStreamer)resources.GetObject("deviceImages.ImageStream");
            deviceImages.TransparentColor = Color.Transparent;
            deviceImages.Images.SetKeyName(0, "HaloRingScanner.png");
            // 
            // lblScanning
            // 
            lblScanning.AutoSize = true;
            lblScanning.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point);
            lblScanning.Location = new Point(132, 153);
            lblScanning.Name = "lblScanning";
            lblScanning.Size = new Size(338, 86);
            lblScanning.TabIndex = 5;
            lblScanning.Text = "Scanning...";
            lblScanning.Visible = false;
            // 
            // CustomSelectBluetoothDeviceDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(665, 450);
            Controls.Add(lblScanning);
            Controls.Add(lstDevices);
            Controls.Add(lblInstructions);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(btnSearch);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CustomSelectBluetoothDeviceDialog";
            Text = "Select Bluetooth Device";
            Shown += CustomSelectBluetoothDeviceDialog_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSearch;
        private Button btnOK;
        private Button btnCancel;
        private Label lblInstructions;
        private ListView lstDevices;
        private Label lblScanning;
        private ImageList deviceImages;
    }
}