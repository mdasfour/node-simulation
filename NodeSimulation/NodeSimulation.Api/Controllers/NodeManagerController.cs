using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NodeSimulation.Data.Models;
using NodeSimulation.Service;

namespace NodeSimulation.Api.Controllers
{
	[ApiVersion("1")]
	[Route("[controller]/v{version:apiVersion}/")]
	[ApiController]
	[DisableCors]
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
		[Route("AddNode")]
		public string AddNode(Nodes node)
		{
			NodeManagerService newNode = new NodeManagerService();

			return newNode.AddNode(node);
		}

		[HttpPost]
		[Route("RemoveNode")]
		public string RemoveNode(int nodeId)
		{
			NodeManagerService node = new NodeManagerService();

			return node.RemoveNode(nodeId);
		}

		[HttpPost]
		[Route("MaxLimits")]
		public string MaxLimits([FromBody]Nodes node)
		{
			NodeManagerService newNode = new NodeManagerService();

			return newNode.SetNodeMaxLimits(node);

		}

		[HttpPost]
		[Route("Online")]
		public string Online(int? nodeId)
		{
			NodeManagerService node = new NodeManagerService();

			return node.SetNodeOnline(nodeId);
		}

		[HttpPost]
		[Route("Offline")]
		public string Offline(int? nodeId)
		{
			NodeManagerService node = new NodeManagerService();

			return node.SetNodeOffline(nodeId);
		}
	}
}