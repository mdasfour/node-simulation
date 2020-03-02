using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NodeSimulation.Data.Models;
using NodeSimulation.Service;

namespace NodeSimulation.Api.Controllers
{
	//The controller of the NodeManager component
	[ApiVersion("1")]
	[Route("[controller]/v{version:apiVersion}/")]
	[ApiController]
	[DisableCors]
	public class NodeManagerController : ControllerBase
	{
		/*	Method: Nodes
		 *	Parameters: nodeId (Optional parameter)
		 *	Description: Endpoint for GetNodes method in NodeManagerService class
		 */
		[HttpGet]
		[Route("Nodes/{nodeId?}")]
		public List<NodesDAO> Nodes(int? nodeId)
		{
			//Create an instance of the NodeManagerService class
			NodeManagerService node = new NodeManagerService();

			//Returns the result(s) of the GetNodes method in the NodeManagerService class 
			return node.GetNodes(nodeId);
		}

		/*	Method: AddNode
		 *	Parameters: node object of type Nodes
		 *	Description: Endpoint for AddNode method in NodeManagerService class
		 */
		[HttpPost]
		[Route("AddNode")]
		public string AddNode(Nodes node)
		{
			//Create an instance of the NodeManagerService class
			NodeManagerService newNode = new NodeManagerService();

			//Returns the status of whether the node was created successfully or not from the AddNode method in the NodeManagerService class
			return newNode.AddNode(node);
		}

		/*	Method: RemoveNode
		 *	Parameters: nodeId
		 *	Description: Endpoint for RemoveNode method in NodeManagerService class
		 */
		[HttpDelete]
		[Route("RemoveNode/{nodeId}")]
		public string RemoveNode(int nodeId)
		{
			//Create an instance of the NodeManagerService class
			NodeManagerService node = new NodeManagerService();

			//Returns the status of whether the node was removed successfully or not from the RemoveNode method in the NodeManagerService class
			return node.RemoveNode(nodeId);

		}

		/*	Method: MaxLimits
		 *	Parameters: node object of type Nodes
		 *	Description: Endpoint for SetNodeMaxLimits method in NodeManagerService class
		 */

		[HttpPost]
		[Route("MaxLimits")]
		public string MaxLimits([FromBody]Nodes node)
		{
			//Create an instance of the NodeManagerService class
			NodeManagerService newNode = new NodeManagerService();

			//Returns the status of whether the node's max limits were set successfully or not from the SetNodeMaxLimits method in the NodeManagerService class
			return newNode.SetNodeMaxLimits(node);

		}

		/*	Method: Online
		 *	Parameters: nodeId
		 *	Description: Endpoint for SetNodeOnline method in NodeManagerService class
		 */
		[HttpPost]
		[Route("Online")]
		public string Online([FromBody]Nodes nodeObject)
		{
			//Create an instance of the NodeManagerService class
			NodeManagerService node = new NodeManagerService();

			//Returns the status of whether the node's status was set successfully to online or not from the SetNodeOnline method in the NodeManagerService class
			return node.SetNodeOnline(nodeObject);
		}

		/*	Method: Offline
		 *	Parameters: nodeId
		 *	Description: Endpoint for SetNodeOffline method in NodeManagerService class
		 */
		[HttpPost]
		[Route("Offline")]
		public string Offline([FromBody]Nodes nodeObject)
		{
			//Create an instance of the NodeManagerService class
			NodeManagerService node = new NodeManagerService();

			//Returns the status of whether the node's status was set successfully to offline or not from the SetNodeOffline method in the NodeManagerService class
			return node.SetNodeOffline(nodeObject);

		}
	}
}