using System.Collections;
using UnityEngine;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
public class ReadUDP : MonoBehaviour 
{
	// Port
	public int portLocal1 = 8000;

	// UDP client objects
	UdpClient client1;

	// Receiving Thread
	Thread receiveThread;
	private bool onReceive = true;

	private float timeshift = 0;
	public string data1hex;
	public float data1float, con;
	Encoding utf8 = Encoding.UTF8;

	void Start() 
	{
		init();
	}
	private void init() 
	{
		print(" UDP Object init");

		// Create local client
		client1 = new UdpClient(portLocal1);

		// Create new thread for reception of incoming data
		receiveThread = new Thread (
			new ThreadStart (ReceiveData));
		receiveThread.IsBackground = true;
		receiveThread.Start();
		print("ReadUDP is listening");
	}

	// Receive data, update received packages
	private void ReceiveData()
	{
		print("ReceiveData function");
		do
		{
			try
			{
				IPEndPoint IP8000 = new IPEndPoint(IPAddress.Any, portLocal1);
				//print("Pass IP");

				byte[] data1 = client1.Receive(ref IP8000);
				//print("Pass receiving data");

				data1hex = BitConverter.ToString(data1, 0); // hex string
				string data1utf8 = utf8.GetString(data1);	// dec string
				data1float = float.Parse(data1utf8); 		// float

				//print("Data1hex : " + data1hex);
				//print("Data1dec : " + data1utf8);
				print("Data1f : " + data1float);

				//print("Pass bit converter");
			}
			catch(Exception err)
			{
				print(err.ToString());
			}
		}while(onReceive);
	}
	void OnDisable()
	{
		onReceive = false;
		if(receiveThread != null)
			receiveThread.Abort();
		client1.Close();
		print("Close all");
	}
}
