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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomSelectBluetoothDeviceDialog));
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.lstDevices = new System.Windows.Forms.ListView();
            this.deviceImages = new System.Windows.Forms.ImageList(this.components);
            this.lblScanning = new System.Windows.Forms.Label();
            this.picQR = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(24, 415);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(121, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "&Search Again";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(628, 415);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(713, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Location = new System.Drawing.Point(24, 363);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(660, 15);
            this.lblInstructions.TabIndex = 3;
            this.lblInstructions.Text = "If you don\'t see the Halo device you want to add, load AirScan on the device and " +
    "scan the QR Code  then click Search Again.";
            // 
            // lstDevices
            // 
            this.lstDevices.LargeImageList = this.deviceImages;
            this.lstDevices.Location = new System.Drawing.Point(12, 12);
            this.lstDevices.Name = "lstDevices";
            this.lstDevices.Size = new System.Drawing.Size(639, 338);
            this.lstDevices.TabIndex = 4;
            this.lstDevices.UseCompatibleStateImageBehavior = false;
            this.lstDevices.SelectedIndexChanged += new System.EventHandler(this.lstDevices_SelectedIndexChanged);
            // 
            // deviceImages
            // 
            this.deviceImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.deviceImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("deviceImages.ImageStream")));
            this.deviceImages.TransparentColor = System.Drawing.Color.Transparent;
            this.deviceImages.Images.SetKeyName(0, "HaloRingScanner.png");
            // 
            // lblScanning
            // 
            this.lblScanning.AutoSize = true;
            this.lblScanning.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblScanning.Location = new System.Drawing.Point(132, 153);
            this.lblScanning.Name = "lblScanning";
            this.lblScanning.Size = new System.Drawing.Size(338, 86);
            this.lblScanning.TabIndex = 5;
            this.lblScanning.Text = "Scanning...";
            this.lblScanning.Visible = false;
            // 
            // picQR
            // 
            this.picQR.BackColor = System.Drawing.Color.Silver;
            this.picQR.Location = new System.Drawing.Point(660, 31);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(128, 128);
            this.picQR.TabIndex = 6;
            this.picQR.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(675, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Airscan QR Code";
            // 
            // CustomSelectBluetoothDeviceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picQR);
            this.Controls.Add(this.lblScanning);
            this.Controls.Add(this.lstDevices);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSearch);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomSelectBluetoothDeviceDialog";
            this.Text = "Select Bluetooth Device";
            this.Shown += new System.EventHandler(this.CustomSelectBluetoothDeviceDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSearch;
        private Button btnOK;
        private Button btnCancel;
        private Label lblInstructions;
        private ListView lstDevices;
        private Label lblScanning;
        private ImageList deviceImages;
        private PictureBox picQR;
        private Label label1;
    }
}