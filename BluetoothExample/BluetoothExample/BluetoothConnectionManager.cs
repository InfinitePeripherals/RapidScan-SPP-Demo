using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace BluetoothExample
{
	public class BluetoothConnectionManager
	{
		static List<BluetoothScanner> activeScanners = new List<BluetoothScanner>();
		//------------------------------------------------------------------------------------------------------------
		public static int Count
        {
			get
            {
				lock (activeScanners)
                {
					return activeScanners.Count;
                }
            }
        }
		//------------------------------------------------------------------------------------------------------------
		public static void AddConnection(BluetoothScanner client)
        {
			lock (activeScanners)
            {
				activeScanners.Add(client);
			}
        }
		//------------------------------------------------------------------------------------------------------------
		public static void RemoveConnection(BluetoothScanner client)
        {
			lock(activeScanners)
            {
				activeScanners.Remove(client);
            }
        }
		//------------------------------------------------------------------------------------------------------------
		public static bool IsDeviceConnected(BluetoothAddress deviceAddress)
        {
			lock (activeScanners) {
				foreach (BluetoothScanner x in activeScanners)
					if (x.device.DeviceAddress == deviceAddress) return true;
			}
			return false;
		}
		//------------------------------------------------------------------------------------------------------------
		public static void Close()
        {
			foreach (BluetoothScanner x in activeScanners) try { x.Disconnect(false); } catch { }
		}
		//------------------------------------------------------------------------------------------------------------

	}
}
