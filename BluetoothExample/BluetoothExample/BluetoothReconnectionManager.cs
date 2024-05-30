using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace BluetoothExample
{
	public class BluetoothReconnectionManager
	{
		public static bool keepRunning { get; set; }
		private static List<BluetoothScanner> devicesToReconnect = new List<BluetoothScanner>();
		private static BluetoothScannerObserver observer = null;
		//------------------------------------------------------------------------------------------------------------
		static BluetoothReconnectionManager()
		{
			keepRunning = true;
			new Thread(BluetoothReconnectionManager.Monitor).Start();
		}
		//------------------------------------------------------------------------------------------------------------
		public static void SetObserver(BluetoothScannerObserver observer)
		{
			BluetoothReconnectionManager.observer = observer;
		}
		//------------------------------------------------------------------------------------------------------------
		public static void Close()
		{
			keepRunning = false;
		}
		//------------------------------------------------------------------------------------------------------------
		public static void AddDevice(BluetoothScanner x)
		{
			lock (devicesToReconnect)
			{
				//if (!x.DeviceName.Contains("Bluedroid") && (!x.DeviceName.Contains("Halo")) ) return;
				if (x.device.ClassOfDevice.Value != 0x5A020C) return;  // Not an SPP Scanner
				foreach (var y in devicesToReconnect)
					if (y.device.DeviceAddress == x.device.DeviceAddress) return; // already in the list

				devicesToReconnect.Add(x); // Add It!
			}
		}
		//------------------------------------------------------------------------------------------------------------
		public static void RemoveDevice(BluetoothScanner x)
		{
			lock (devicesToReconnect)
			{
				devicesToReconnect.Remove(x);
			}
		}
		//------------------------------------------------------------------------------------------------------------
		private static void Monitor()
		{
			while (keepRunning)
			{
				if (devicesToReconnect.Count > 0)
				{
					Queue<BluetoothScanner> ToDo = new Queue<BluetoothScanner>();

					lock (devicesToReconnect)
					{
						foreach (var scanner in devicesToReconnect) ToDo.Enqueue(scanner);
					}

					while (ToDo.Count > 0 && keepRunning)
					{
						try
						{
							var scanner= ToDo.Dequeue();
							var device = scanner.device;
							//var device2 = RefreshDeviceInfo(device.DeviceAddress);
							//if (device2 == null || !device2.Authenticated)
							//	BluetoothReconnectionManager.RemoveDevice(device); // i.e. system no longer remembers this device
							
							// Ok connect!
							BluetoothClient client = new BluetoothClient();
							scanner.status = "Reconnecting: " + DateTime.Now.ToString("hh:mm:ss");
							observer.UpdateUI(scanner); // Show the Reconnecting Message
							client.Connect(scanner.device.DeviceAddress, BluetoothService.SerialPort);
							new BluetoothScanner(client, scanner.device, observer); // take this bluetooth connection and monitor for incoming barcodes, process them, send RISL card out
							RemoveDevice(scanner);
						}
						catch (Exception ex){}
						Thread.Sleep(1000); // how often to try and reconnect???
					}
				}
				
			}
		}
		//------------------------------------------------------------------------------------------------------------
		public static BluetoothDeviceInfo RefreshDeviceInfo(BluetoothAddress addr)
        {
			// OK see if the status has changed - like if the user removed the device
			// Need to run a query to findout...
			var client = new BluetoothClient();
			var availableDevices = client.DiscoverDevices(255, true, true, false); // This is fast

			foreach( var device in availableDevices )
            {
				if (device.DeviceAddress == addr) return device;
            }
			return null; // They may have removed it!
		}
		//------------------------------------------------------------------------------------------------------------
		public static bool InInReconnectionList(BluetoothAddress deviceAddress)
		{
			lock (devicesToReconnect)
			{
				foreach (var scanner in devicesToReconnect)
				{
					if (scanner.device.DeviceAddress == deviceAddress) return true;
				}
			}
			return false;
		}
		//------------------------------------------------------------------------------------------------------------
		public static void ConnectOnStartup()
		{
			// Search for Previously Paired?
			var client = new BluetoothClient();
			BluetoothDeviceInfo[] availableDevices;

			availableDevices = client.DiscoverDevices(255, true, true, false); // This is fast

			foreach (BluetoothDeviceInfo device in availableDevices)
			{
				// Make sure Halo, or 509 etc.
				//if (device.ClassOfDevice.Value == 0x5A020C) BluetoothReconnectionManager.AddDevice(device);
			}
		}
		//------------------------------------------------------------------------------------------------------------

	}
}
