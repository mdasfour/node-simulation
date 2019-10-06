using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodeSimulation.Data.Models
{
	public class NodesDTO
	{
		public long Id { get; }
		public int NodeId { get; set; }
		public decimal? MaxUploadUtilization { get; set; }
		public decimal? MaxDownloadUtilization { get; set; }
		public decimal? MaxErrorRate { get; set; }
		public int? MaxConnectedClients { get; set; }
	}
}
