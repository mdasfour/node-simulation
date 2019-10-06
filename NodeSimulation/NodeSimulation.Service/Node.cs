using NodeSimulation.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodeSimulation.Service
{
	public class Node : INode
	{
		public readonly Random _rnd;

		#region Properties
		// Basic properties
		public int NodeId { get; set; }
		public string City { get; set; }

		// State
		public DateTime OnlineTime { get; set; }
		public bool IsOnline { get; set; }

		// Metrics
		public decimal UploadUtilization { get; set; }
		public decimal DownloadUtilization { get; set; }
		public decimal ErrorRate { get; set; }
		public int ConnectedClients { get; set; }
		#endregion

		#region Initialization
		//public Node(int nodeId, string city)
		//{

		//}
		//public Node(int nodeId, string city, Random rnd)
		//{
		//	_rnd = rnd;

		//	NodeId = nodeId;
		//	City = city;

		//	OnlineTime = DateTime.Now;

		//	IsOnline = false;

		//	ResetMetrics();
		//}

		#endregion

		#region Public Methods
		//public bool SetOnline()
		public Nodes SetOnline(Nodes node)
		{
			IsOnline = true;
			SimulateRandomMetrics();

			node.IsOnline = IsOnline;
			//node.UploadUtilization = this.UploadUtilization;
			//node.DownloadUtilization = this.DownloadUtilization;
			//node.ErrorRate = this.ErrorRate;
			//node.ConnectedClients = this.ConnectedClients;


			return node;

			//return IsOnline;

		}

		public void SetOffline()
		{
			IsOnline = false;

			ResetMetrics();
		}
		#endregion

		#region Private Methods
		private void ResetMetrics()
		{
			// Clear metrics back to 0.

			ConnectedClients = 0;

			UploadUtilization = 0.0M;
			DownloadUtilization = 0.0M;
			ErrorRate = 0.0M;
		}

		public void SimulateRandomMetrics()
		{
			// Generate random values to simulate metrics.

			ConnectedClients = _rnd.Next(1, 500);
			UploadUtilization = (decimal)_rnd.NextDouble();
			DownloadUtilization = (decimal)_rnd.NextDouble();
			ErrorRate = (decimal)_rnd.NextDouble();

		}
		#endregion
	}
}
