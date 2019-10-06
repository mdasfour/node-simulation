using NodeSimulation.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodeSimulation.Service
{
	public interface INodeManager
	{
		/// <summary>
		/// Add new node to the manager
		/// </summary>
		/// <param name="node"></param>
		void AddNode(INode node);

		/// <summary>
		/// Remove node from the manager
		/// </summary>
		/// <param name="nodeId">ID of the node to remove</param>
		string RemoveNode(int nodeId);

		/// <summary>
		/// Retrieve a managed node
		/// </summary>
		/// <param name="nodeId">ID of the node to retrieve</param>
		/// <returns></returns>
		//List<NodesDAO> GetNode(int nodeId);

		/// <summary>
		/// Retrieve all nodes added to the manager
		/// </summary>
		/// <returns></returns>
		List<NodesDAO> GetNodes(int? nodeId);
	}
}
