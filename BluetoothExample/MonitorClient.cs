using System;

namespace BluetotConection
{
    public class MonitorClient
    {
        private BluetoothClient client;
        private NetworkStream stream;

        public MonitorClient(BluetoothClient client)
        {
            try
            {
                this.client = client;
                this.stream = client.GetStream();
                new Thread(DataMonitor).Start();
            }
            catch (Exception ex) { MessageBox.Show("Error Connecting:" + ex); }
        }

        private void DataMonitor()
        {
            try
            {
                while (client.)
        }
    }

    }
}
