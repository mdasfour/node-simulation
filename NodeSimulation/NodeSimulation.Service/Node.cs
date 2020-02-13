using NodeSimulation.Data.Models;
using System;

namespace NodeSimulation.Service
{
	public class Node : INode
	{
		private readonly Random _rnd;

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
		public Node(int nodeId, string city)
		{


			_rnd = new Random();

			NodeId = nodeId;
			City = city;

			OnlineTime = DateTime.Now;

			IsOnline = false;

			ResetMetrics();
		}

		#endregion

		#region Public Methods
		public Nodes SetOnline(Nodes node)
		{

			node.IsOnline = true;
			node = SimulateRandomMetrics(node);

			return node;

		}

		public Nodes SetOffline(Nodes node)
		{

			node.IsOnline = false;

			node = ResetMetrics(node);

			return node;
		}
		#endregion

		#region Private Methods
		/*	Method: ResetMetrics
		 *	Parameters: None
		 *	Description: Sets metrics for a newly created node.
		 */
		private void ResetMetrics()
		{
			UploadUtilization = 0.0M;
			DownloadUtilization = 0.0M;
			ErrorRate = 0.0M;
			ConnectedClients = 0;

		}

		/*	Method: ResetMetrics
		 *	Parameters: node object of type Nodes
		 *	Description: Sets metrics for an existing node to 0 after setting its status to offline.
		 */
		private Nodes ResetMetrics(Nodes node)
		{
			if (node != null)
			{
				// Clear metrics back to 0.
				node.UploadUtilization = 0.0M;
				node.DownloadUtilization = 0.0M;
				node.ErrorRate = 0.0M;
				node.ConnectedClients = 0;


			}

			return node;

		}

		/*	Method: SimulateRandomMetrics
		 *	Parameters: node object of type Nodes
		 *	Description: Sets metrics for a node when its online status is set to true.
		 */
		public Nodes SimulateRandomMetrics(Nodes node)
		{
			// Generate random values to simulate metrics.
			if (node != null)
			{
				node.ConnectedClients = _rnd.Next(1, 500);
				node.UploadUtilization = (decimal)_rnd.NextDouble() * 100;
				node.DownloadUtilization = (decimal)_rnd.NextDouble() * 100;
				node.ErrorRate = (decimal)_rnd.NextDouble() * 100;
			}

			return node;
		}
		#endregion
	}
}
