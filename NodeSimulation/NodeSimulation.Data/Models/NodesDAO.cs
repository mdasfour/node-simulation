using System;
using System.ComponentModel.DataAnnotations;

namespace NodeSimulation.Data.Models
{
	//Model file of what parameters to return to the frontend
	public class NodesDAO
	{
		[Key]
		public long Id { get; set; }
		public int NodeId { get; set; }
		public string City { get; set; }
		public DateTime? OnlineTime { get; set; }
		public bool IsOnline { get; set; } = false;
		public decimal? UploadUtilization { get; set; }
		public decimal? MaxUploadUtilization { get; set; }
		public bool? UploadUtilizationExceeded { get; set; }
		public decimal? DownloadUtilization { get; set; }
		public decimal? MaxDownloadUtilization { get; set; }
		public bool? DownloadUtilizationExceeded { get; set; }
		public decimal? ErrorRate { get; set; }
		public decimal? MaxErrorRate { get; set; }
		public bool? ErrorRateExceeded { get; set; }
		public int? ConnectedClients { get; set; }
		public int? MaxConnectedClients { get; set; }
		public bool? ConnectedClientsExceeded { get; set; }
		public bool Deleted { get; set; } = false;
	}
}