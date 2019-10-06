using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NodeSimulation.Data.Models;
using NodeSimulation.Service;

namespace NodeSimulation.Api.Controllers
{
	[ApiVersion("1")]
	[Route("[controller]/v{version:apiVersion}/")]
	[ApiController]
	public class NodeManagerController : ControllerBase
	{

		[HttpGet]
		[Route("Nodes")]
		public List<NodesDAO> Nodes(int? nodeId)
		{
			NodeManagerService node = new NodeManagerService();

			return node.GetNodes(nodeId);
		}


		[HttpPost]
		[Route("MaxLimits")]
		public string MaxLimits([FromBody]Nodes node)
		{
			NodeManagerService newNode = new NodeManagerService();

			return newNode.SetNodeMaxLimits(node);

		}

		[HttpPatch]
		[Route("Online")]
		public string Online(int? nodeId)
		{
			NodeManagerService node = new NodeManagerService();

			return node.SetNodeOnline(nodeId);
		}

		[HttpPatch]
		[Route("Offline")]
		public string Offline(int? nodeId)
		{
			NodeManagerService node = new NodeManagerService();

			return node.SetNodeOffline(nodeId);
		}

		[HttpDelete]
		[Route("Nodes")]
		public string Node(int nodeId)
		{
			NodeManagerService node = new NodeManagerService();

			return node.RemoveNode(nodeId);
		}




	}
}