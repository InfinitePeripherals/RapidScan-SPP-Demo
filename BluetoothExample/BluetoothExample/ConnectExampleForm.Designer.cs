namespace BluetoothExample
{
    partial class ConnectExampleForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ListViewItem listViewItem1 = new ListViewItem(new string[] { "", "Bluetooth", "xx:xx:xx:xx", "Connected", "0" }, 0);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectExampleForm));
            lstScanners = new ListView();
            colPicture = new ColumnHeader();
            colConnectionType = new ColumnHeader();
            colAddress = new ColumnHeader();
            colState = new ColumnHeader();
            colScans = new ColumnHeader();
            colLastBarcode = new ColumnHeader();
            imageListDevices = new ImageList(components);
            pnlFooter = new Panel();
            pnlHeader = new Panel();
            lblScanners = new Label();
            btnConnect = new Button();
            pnlFooter.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // lstScanners
            // 
            lstScanners.Columns.AddRange(new ColumnHeader[] { colPicture, colConnectionType, colAddress, colState, colScans, colLastBarcode });
            lstScanners.Dock = DockStyle.Fill;
            lstScanners.GridLines = true;
            lstScanners.Items.AddRange(new ListViewItem[] { listViewItem1 });
            lstScanners.LargeImageList = imageListDevices;
            lstScanners.Location = new Point(0, 0);
            lstScanners.Name = "lstScanners";
            lstScanners.Size = new Size(827, 403);
            lstScanners.SmallImageList = imageListDevices;
            lstScanners.TabIndex = 2;
            lstScanners.UseCompatibleStateImageBehavior = false;
            lstScanners.View = View.Details;
            // 
            // colPicture
            // 
            colPicture.Text = "Model";
            colPicture.Width = 80;
            // 
            // colConnectionType
            // 
            colConnectionType.Text = "Connection Type";
            colConnectionType.Width = 120;
            // 
            // colAddress
            // 
            colAddress.Text = "Address";
            colAddress.Width = 120;
            // 
            // colState
            // 
            colState.Text = "State";
            colState.Width = 120;
            // 
            // colScans
            // 
            colScans.Text = "#Scans";
            // 
            // colLastBarcode
            // 
            colLastBarcode.Text = "Last Barcode";
            colLastBarcode.Width = 300;
            // 
            // imageListDevices
            // 
            imageListDevices.ColorDepth = ColorDepth.Depth8Bit;
            imageListDevices.ImageStream = (ImageListStreamer)resources.GetObject("imageListDevices.ImageStream");
            imageListDevices.TransparentColor = Color.Transparent;
            imageListDevices.Images.SetKeyName(0, "HaloRingScanner2.png");
            // 
            // pnlFooter
            // 
            pnlFooter.Controls.Add(pnlHeader);
            pnlFooter.Controls.Add(btnConnect);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 364);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(827, 39);
            pnlFooter.TabIndex = 4;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.MediumBlue;
            pnlHeader.Controls.Add(lblScanners);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(752, 45);
            pnlHeader.TabIndex = 4;
            // 
            // lblScanners
            // 
            lblScanners.AutoSize = true;
            lblScanners.BackColor = Color.Transparent;
            lblScanners.Dock = DockStyle.Fill;
            lblScanners.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblScanners.ForeColor = Color.White;
            lblScanners.Location = new Point(0, 0);
            lblScanners.Name = "lblScanners";
            lblScanners.Size = new Size(298, 40);
            lblScanners.TabIndex = 2;
            lblScanners.Text = "0 Scanners Connected";
            // 
            // btnConnect
            // 
            btnConnect.Dock = DockStyle.Right;
            btnConnect.Location = new Point(752, 0);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 39);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += buttonConnect_Click;
            // 
            // ConnectExampleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(827, 403);
            Controls.Add(pnlFooter);
            Controls.Add(lstScanners);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ConnectExampleForm";
            Text = "Ring Scanner SPP with 32Feet.Net";
            FormClosed += ConnectExampleForm_FormClosed;
            pnlFooter.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ListView lstScanners;
        private ImageList imageListDevices;
        private Panel pnlFooter;
        private Button btnConnect;
        private ColumnHeader colPicture;
        private ColumnHeader colConnectionType;
        private ColumnHeader colAddress;
        private ColumnHeader colState;
        private ColumnHeader colScans;
        private Panel pnlHeader;
        private Label lblScanners;
        private ColumnHeader colLastBarcode;
    }
}