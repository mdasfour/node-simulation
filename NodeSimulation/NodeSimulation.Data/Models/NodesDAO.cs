using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodeSimulation.Data.Models
{
	public class NodesDAO
	{
		//public long Id { get; }
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
		public bool Deleted { get; set; }
	}
}