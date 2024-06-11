using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using InTheHand.Windows.Forms;

// See: https://stackoverflow.com/questions/7773000/32feet-net-howto-discover-nearby-bluetooth-devices-async-in-c-sharp

namespace BluetoothExample
{
    public partial class ConnectExampleForm : Form, BluetoothScannerObserver
    {
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        BluetoothReconnectionManager reconnectionManager; // keeps track of devices that disconnected and need to be reconnected
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        public ConnectExampleForm()
        {
            InitializeComponent();
            BluetoothReconnectionManager.SetObserver(this);
            BluetoothReconnectionManager.ConnectOnStartup();  // Any devices already attached to Windows Bluetooth, add them automatically  (not needed but nice)
            lstScanners.Items.Clear();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                btnConnect.Enabled = false;

                // Custom Dialog to get a device through Bluetooth Discovery
                CustomSelectBluetoothDeviceDialog selectBluetoothDeviceDialog = new CustomSelectBluetoothDeviceDialog();

                // Get a Device from User
                BluetoothDeviceInfo selectedDevice = null;
                if (selectBluetoothDeviceDialog.ShowDialog() == DialogResult.OK)
                    selectedDevice = selectBluetoothDeviceDialog.SelectedDevice;

                // OK We have the device, see if we need to reconnect or new connect
                if (selectedDevice == null) return;

                // Try and Connect
                //if (selectedDevice.Authenticated) Connect(selectedDevice);
                //else PairThenConnect(selectedDevice);
                Connect(selectedDevice);
                //TestConnect(selectedDevice);
                //AsyncConnect(selectedDevice);
            }
            finally { btnConnect.Enabled = true; }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        // Connect to an already paired connect.  Windows may hold a Bluetooth Connection open between Debug Sessions etc.
        public void Connect(BluetoothDeviceInfo device)
        {
            try
            {
                BluetoothClient client = new BluetoothClient();
                client.Connect(device.DeviceAddress, BluetoothService.SerialPort);
                
                if (client.Connected) 
                  new BluetoothScanner(client, device, this); // take this bluetooth connection and monitor for incoming barcodes, process them, send RISL card out
            }
            catch (Exception ex) { 
                MessageBox.Show("Connection Timeout"); 
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        // If a Brand New Connection is needed
        public void PairThenConnect(BluetoothDeviceInfo x)
        {
            bool pairingSuccessful = BluetoothSecurity.PairRequest(x.DeviceAddress, null);
            if (pairingSuccessful) Connect(x);
            else MessageBox.Show("Paring Unsuccesful");
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        public void ScannerConnected(BluetoothScanner client)
        {
            // For now lets 
            BluetoothConnectionManager.AddConnection(client);
            ShowActiveScannerCount();
            UpdateGrid(client);
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        public void ScannerDisconnected(BluetoothScanner client)
        {
            BluetoothConnectionManager.RemoveConnection(client);
            ShowActiveScannerCount();

            BluetoothReconnectionManager.AddDevice(client);
            client.status = "Reconnecting";
            UpdateGrid(client);
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        public void UpdateUI(BluetoothScanner client)
        {
            UpdateGrid(client);
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        private void UpdateGrid( BluetoothScanner client)
        {
            // Is this client already in the list
            Action update = delegate {
                // See if it already exists
                ListViewItem item = lstScanners.FindItemWithText(client.device.DeviceAddress.ToString());
                if (item == null)
                {
                    item = new ListViewItem();
                    item.ImageIndex = 0;
                    item.SubItems.Add("Bluetooth");
                    item.SubItems.Add(client.device.DeviceAddress.ToString());
                    item.SubItems.Add(""); // status
                    item.SubItems.Add(""); // scan count
                    item.SubItems.Add(""); // last Barcode
                    lstScanners.Items.Add(item);                    
                }

                // Now update it!
                item.SubItems[3].Text = client.status;
                item.SubItems[4].Text = "" + client.scanCount;
                item.SubItems[5].Text = client.lastBarcode;
            };
            lstScanners.Invoke(update);
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        public void ShowActiveScannerCount()
        {
            lblScanners.Invoke(() => { lblScanners.Text = BluetoothConnectionManager.Count + " Scanners Connected"; });
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        private void CleanShutdown()
        {
            try { BluetoothReconnectionManager.keepRunning = false; } catch { };
            BluetoothConnectionManager.Close();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        private void ConnectExampleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CleanShutdown();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        public static bool IsConnectedOrReconnectQueue(BluetoothAddress deviceAddress)
        {
            // Windows may have the device connected, but not hooked to the application
            return BluetoothConnectionManager.IsDeviceConnected(deviceAddress) || BluetoothReconnectionManager.InInReconnectionList(deviceAddress);
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------

    }
}

// Standard Dialog but doesn't let you pick classes and such
//SelectBluetoothDeviceDialog selectBluetoothDeviceDialog = new SelectBluetoothDeviceDialog();
//selectBluetoothDeviceDialog.ShowDiscoverableOnly = true;
//selectBluetoothDeviceDialog.ShowUnknown = true;
//selectBluetoothDeviceDialog.ShowRemembered = true;
//selectBluetoothDeviceDialog.ShowAuthenticated = true;