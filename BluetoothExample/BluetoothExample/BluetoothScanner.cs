using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System.Net.Sockets;
using System.Text;

namespace BluetoothExample
{
    //===============================================================================================================================
    public interface BluetoothScannerObserver
    {
        public void ScannerConnected(BluetoothScanner client);  // Let master know the client is active
        public void ScannerDisconnected(BluetoothScanner client); // Let master know the client is shutdown
        public void UpdateUI(BluetoothScanner client);  // Allow the frontend to update it's grid...
    }
    //===============================================================================================================================
    public class BluetoothScanner
    {
        static int id = 0;
        private int thisId;                  // Just a unique # for this scanner, not really usefule
        private BluetoothClient client;      // the class holding the stream to the device
        public  BluetoothDeviceInfo device;  // information about the device
        private NetworkStream clientStream;  // We'll need this to listen for barcodes and send messages to scanner
        private BluetoothScannerObserver observer;  // Simple Interface to let an observer know that the device has connected/disconnected/scan
        public int scanCount { get; private set; } 
        public string lastBarcode { get; private set; }
        public string status { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------\
        // An Instance: Every Scanner connected will have one of these to handle the incoming, outgoing messages
        // 1) Take the Bluetooth Connection and keep watch for incoming barcodes on a Thread
        // 2) Let Observer know if this scanner connects or disconnects (so it can be added to the ReconnectManager)
        // 3) Call the SomeBusinessLogic() function to illustrate where logic might plugin => returns an ECHO RISL Card
        //-------------------------------------------------------------------------------------------------------------------------
        public BluetoothScanner(BluetoothClient client, BluetoothDeviceInfo device, BluetoothScannerObserver observer)
        {
            bool error = false;
            thisId = id++;  // Sequential#
            status = "Connecting";
            lastBarcode = "";
            this.client = client;
            this.observer = observer;
            this.device = device;
            
            try { this.clientStream = client.GetStream(); } catch { error = true; }  // If Stream fails, let the constructor work and we'll catch it missing on the ReceiveBarcode Thread
            new Thread(ReceiveBarcode).Start();            
            try { observer.ScannerConnected(this); } catch { }
            SomeBusinessLogic("Connected!"); // send RISL Card
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public void Disconnect(bool notifyObserver)
        {
            try
            {
                status = "Disconnected";
                // might not want to notify, if for example, application is shutting down
                if (notifyObserver) try { observer.ScannerDisconnected(this); } catch { }
                try { client.Close(); } catch { }
                // we could notify tell the GUI Parent in case it is showing active connections...
            }
            catch { }
        }
        //-------------------------------------------------------------------------------------------------------------------------
        private void ReceiveBarcode()
        {            
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] message = new byte[32768]; // read in chunks of 2KB

            try
            {
                status = "Connected";
                observer.UpdateUI(this);

                while (client.Connected)
                {
                    int bytesRead = clientStream.Read(message, 0, message.Length);
                    if (bytesRead == 0) break;

                    string msg = encoder.GetString(message, 0, bytesRead);
                    string[] barcodes = msg.Split('\x03');  // in case of Out of distance, sometimes we can get more than one barcode at once when coming back into
                    foreach (string barcode in barcodes)
                    {
                        if (barcode.Length == 0) continue;
                        scanCount++;
                        lastBarcode = CleanBarcode(barcode); // Take out the invisible for now...
                        SomeBusinessLogic(lastBarcode); // Turn Barcode into a RISL Card after some processing...
                        if (observer != null) try { observer.UpdateUI(this); } catch { }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                Disconnect(true);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public string CleanBarcode(string msg)
        {
            StringBuilder buf = new StringBuilder();
            for (int i=0; i<msg.Length;i++)
            {
                if (msg[i] >= ' ' && msg[i] <= 'z') buf.Append(msg[i]);
            }
            return buf.ToString();
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public void SendMessageToScanner(string msg)
        {
            if (!client.Connected) return;
            try
            {
                clientStream.Write(Encoding.ASCII.GetBytes(msg), 0, msg.Length);
            }
            catch (Exception ex) {;}
        }
        //-------------------------------------------------------------------------------------------------------------------------
        private void SomeBusinessLogic(string barcode)
        {
            Random rnd = new Random(); // for random colored cards
            Color randomColor = Color.FromArgb(rnd.Next(128), rnd.Next(128), 255);
            string hexColor = ColorTranslator.ToHtml(randomColor);
            //string hexColor=#004F94
            string risl = "{\"action\": \"risl\",\"command\": \"^StartCard|290|160^CardBackColor|" + hexColor + "^Font|28|#FFFFFF^TextC|5|" + DateTime.Now.ToString("HH:mm:ss.fff") + "^Font|24|Bold|#FFFFFF^TextC|48|" + barcode + "^Font|28|#FFFFFF^TextC|115|Echo^PlaySound|Good^ShowCard\"}";
            SendMessageToScanner(risl);
        }
        //-------------------------------------------------------------------------------------------------------------------------

    }

}
