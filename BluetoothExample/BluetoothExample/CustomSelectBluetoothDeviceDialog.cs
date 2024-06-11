using InTheHand.Net;
using InTheHand.Net.Sockets;
using QRCoder;

namespace BluetoothExample
{

    public partial class CustomSelectBluetoothDeviceDialog : Form
    {
        public BluetoothDeviceInfo SelectedDevice { get; private set; } // What gets returned if device selected!
        //--------------------------------------------------------------------------------------------------------------
        public CustomSelectBluetoothDeviceDialog()
        {
            InitializeComponent();
            GenerateOnscreenBarcode();
        }
        //--------------------------------------------------------------------------------------------------------------
        private void SearchForDevices(bool fastMode)
        {
            try
            {
                EnableButtons(false);
                // Show Search                
                Application.DoEvents(); // Refresh the label

                // Search for Previously Paired?
                var client = new BluetoothClient();
                BluetoothDeviceInfo[] availableDevices;

                if (!fastMode) availableDevices = client.DiscoverDevices(); // I've found this to be SLOW!
                else availableDevices = client.DiscoverDevices(255, true, true, false); // This is fast

                // Halo is Name="Android Bluedroid", ClassOfDevice=5A020C
                // Authenticated = prevoiusly paried, Connected=currently connected to Windows?, DeviceAddress i.e. A028E5822F8, LastSeen: Date

                lstDevices.Clear();
                foreach (BluetoothDeviceInfo device in availableDevices)
                {

                    // Make sure Halo, or 509 etc.
                    if (device.ClassOfDevice.Value == 0x5A020C
                         && !BluetoothConnectionManager.IsDeviceConnected(device.DeviceAddress)
                         && !BluetoothReconnectionManager.InInReconnectionList(device.DeviceAddress))
                    {
                            ListViewItem x = new ListViewItem();
                            x.Text = device.DeviceAddress.ToString() + "\n" + device.DeviceName;
                            x.ImageIndex = 0;
                            x.Tag = device;
                            lstDevices.Items.Add(x);
                    }
                }
            }
            finally
            {
                EnableButtons(true);
            }

        }
        //--------------------------------------------------------------------------------------------------------------
        public void EnableButtons(bool x)
        {
            btnOK.Enabled = x;
            btnCancel.Enabled = x;
            btnSearch.Enabled = x;
            lblScanning.Visible = !x; // label comes on when buttons disabled
        }
        //--------------------------------------------------------------------------------------------------------------
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try { SearchForDevices(false); } catch { }
        }
        //--------------------------------------------------------------------------------------------------------------
        private void lstDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If they unselected a device
            if ( lstDevices.SelectedItems.Count <= 0) { btnOK.Enabled = false; SelectedDevice = null; return; }

            // Otherwise we have a new device
            SelectedDevice = (BluetoothDeviceInfo) lstDevices.SelectedItems[0].Tag;
            btnOK.Enabled = true;
        }
        //--------------------------------------------------------------------------------------------------------------
        public void GenerateOnscreenBarcode()
        {
            // Place a Config Barcode on Screen to put in SPP mode
            string payload = "{\"action\":\"config\",\"command\":{\"mode\":\"sppperipheral\",\"verbs\":[{\"name\":\"Scan\",\"mode\":1}]}}";
            // Draw the QR
            QRCodeGenerator.ECCLevel eccLevel = (QRCodeGenerator.ECCLevel)(3);
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, eccLevel))
            using (QRCode qrCode = new QRCode(qrCodeData))
            {
                /*
                var bmp = qrCode.GetGraphic(2, Color.Black, Color.White, null, (int)0);
                picQR.BackgroundImage = bmp;
                picQR.Size = bmp.Size;
                */
            }
        }
        //--------------------------------------------------------------------------------------------------------------
        private void CustomSelectBluetoothDeviceDialog_Shown(object sender, EventArgs e)
        {
            SearchForDevices(true);  // Fast Populate!
            if (lstDevices.Items.Count == 0) SearchForDevices(false);  // deeper look
        }
        //--------------------------------------------------------------------------------------------------------------
    }
}
