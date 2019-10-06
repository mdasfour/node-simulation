using NodeSimulation.Data.Models;
using System.Collections.Generic;

namespace NodeSimulation.Service
{
	public interface INodeManager
	{
		/// <summary>
		/// Add new node to the manager
		/// </summary>
		/// <param name="node"></param>
		//string AddNode(INode node);

		/// <summary>
		/// Remove node from the manager
		/// </summary>
		/// <param name="nodeId">ID of the node to remove</param>
		/// <returns>Returns a message to the user whether it was successful in removing the node or not.  If there are any errors, it returns a message to the user</returns>
		string RemoveNode(int nodeId);


		/// <summary>
		/// Retrieve a node or all nodes added to the manager
		/// <param name="nodeId">ID of the node to retrieve (Optional)</param>
		/// </summary>
		/// <returns>The node or all the list of nodes that have not been deleted</returns>
		List<NodesDAO> GetNodes(int? nodeId);
	}
}
