using NodeSimulation.Data.Models;
using System;

namespace NodeSimulation.Service
{
	public interface INode
	{
		/// <summary>
		/// Class variable for nodeId
		/// </summary>
		int NodeId { get; }

		/// <summary>
		/// Class variable for city
		/// </summary>
		string City { get; }

		/// <summary>
		/// Timestamp of the node's last online time
		/// </summary>
		DateTime OnlineTime { get; }

		/// <summary>
		/// State of node
		/// </summary>
		bool IsOnline { get; }

		/// <summary>
		/// Current % of upstream bandwidth utilization
		/// </summary>
		decimal UploadUtilization { get; }

		/// <summary>
		/// Current % of downstream bandwidth utilization
		/// </summary>
		decimal DownloadUtilization { get; }

		/// <summary>
		/// Current % of network transfer errors 
		/// </summary>
		decimal ErrorRate { get; }

		/// <summary>
		/// Number of clients connected to this node
		/// </summary>
		int ConnectedClients { get; }

		/// <summary>
		/// Bring the node online
		/// </summary>
		Nodes SetOnline(Nodes node);

		/// <summary>
		/// Bring the node offline
		/// </summary>
		/// <returns></returns>
		Nodes SetOffline(Nodes node);
	}
}
