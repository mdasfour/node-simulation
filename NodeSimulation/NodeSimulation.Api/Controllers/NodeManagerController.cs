using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
		[Route("Nodes")]
		public string Nodes([FromBody]NodesDTO node)
		{
			NodeManagerService newNode = new NodeManagerService();

			return newNode.SetNodeMaxLimits(node);
		}

		[HttpPatch]
		[Route("Online")]
		public dynamic Online(int? nodeId)
		{
			NodeManagerService node = new NodeManagerService();

			return node.SetNodeOnline(nodeId);
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