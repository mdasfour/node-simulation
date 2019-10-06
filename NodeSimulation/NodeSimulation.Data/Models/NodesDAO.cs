using System;
using System.ComponentModel.DataAnnotations;

namespace NodeSimulation.Data.Models
{
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
		public bool? UploadUtilizationExceeded { get; }
		public decimal? DownloadUtilization { get; set; }
		public decimal? MaxDownloadUtilization { get; set; }
		public bool? DownloadUtilizationExceeded { get; }
		public decimal? ErrorRate { get; set; }
		public decimal? MaxErrorRate { get; set; }
		public bool? ErrorRateExceeded { get; }
		public int? ConnectedClients { get; set; }
		public int? MaxConnectedClients { get; set; }
		public bool? ConnectedClientsExceeded { get; }
		public bool Deleted { get; set; }
	}
}