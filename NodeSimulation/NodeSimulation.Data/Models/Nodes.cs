using System;
using System.ComponentModel.DataAnnotations;

namespace NodeSimulation.Data.Models
{
	public partial class Nodes
	{
		[Key]
		public long Id { get; set; }
		public int NodeId { get; set; }
		public string City { get; set; }
		public DateTime? OnlineTime { get; set; }
		public bool IsOnline { get; set; } = false;
		public decimal? UploadUtilization { get; set; }
		public decimal? MaxUploadUtilization { get; set; }
		public decimal? DownloadUtilization { get; set; }
		public decimal? MaxDownloadUtilization { get; set; }
		public decimal? ErrorRate { get; set; }
		public decimal? MaxErrorRate { get; set; }
		public int? ConnectedClients { get; set; }
		public int? MaxConnectedClients { get; set; }
		public bool Deleted { get; set; } = false;
		public DateTime InsertedDT { get; set; } = DateTime.Now;
		public DateTime? UpdatedDT { get; set; }
		public DateTime? DeletedDT { get; set; }
	}
}
