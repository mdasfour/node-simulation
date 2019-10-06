using NodeSimulation.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NodeSimulation.Service
{
	public class NodeManagerService : INodeManager
	{
		private readonly List<INode> _nodes;

		public NodeManagerService()
		{
			_nodes = new List<INode>();
		}

		public List<NodesDAO> GetNodes(int? nodeId)
		{
			using (var context = new NodeSimulationContext())
			{
				var nodes = context.Nodes.Select(n => new NodesDAO
				{
					NodeId = n.NodeId,
					City = n.City,
					OnlineTime = n.OnlineTime,
					IsOnline = n.IsOnline,
					UploadUtilization = n.UploadUtilization,
					MaxUploadUtilization = n.MaxUploadUtilization,
					DownloadUtilization = n.DownloadUtilization,
					MaxDownloadUtilization = n.MaxDownloadUtilization,
					ErrorRate = n.ErrorRate,
					MaxErrorRate = n.MaxErrorRate,
					ConnectedClients = n.ConnectedClients,
					MaxConnectedClients = n.MaxConnectedClients,
					Deleted = n.Deleted
				}).Where(n => !n.Deleted && (!nodeId.HasValue || (n.NodeId == nodeId))).OrderBy(n => n.NodeId).ToList();


				return nodes;
			}
		}

		public void AddNode(INode node)
		{
			//Ask about Node constructor with parameters

			using (var context = new NodeSimulationContext())
			{
				//Check if the Node Id the user has chosen exists in the database before inserting
				var checkIfNodeIdExists = context.Nodes.Where(n => n.NodeId == node.NodeId).FirstOrDefault();

				if (checkIfNodeIdExists != null)
				{

					if ((!node.NodeId.Equals("") && node.NodeId > 0) && (!String.IsNullOrEmpty(node.City.Trim()) && !node.City.Trim().Equals("")))
					{
						//Node createNode = new Node(node.NodeId, node.City);

						//Metrics

					}
					else
					{
						throw new Exception(String.Format("A node must contain at a minimum a Node Id and a City.  Please make sure that you have entered a Node Id and City and then try again."));
					}

				}


			}
		}

		public string RemoveNode(int nodeId)
		{

			using (var context = new NodeSimulationContext())
			{
				string successMessage = string.Format("Node {0} has been successfully removed", nodeId);
				string nodeNotFound = string.Format("Cannot remove node. NodeId {0} does not exist", nodeId);

				try
				{
					var node = context.Nodes.Where(n => n.NodeId == nodeId && !n.Deleted).FirstOrDefault();

					if (node != null)
					{
						node.Deleted = true;

						node.DeletedDT = DateTime.Now;

						context.SaveChanges();

						return successMessage;
					}
					else
					{
						throw new Exception(nodeNotFound);
					}
				}
				catch (Exception ex)
				{
					return ex.Message;
				}

			}
		}

		public dynamic SetNodeOnline(int? nodeId)
		{
			string noNodeId = "Error! No Node Id.  Please make sure there is a Node Id before proceeding.";

			if (nodeId.HasValue)
			{
				using (var context = new NodeSimulationContext())
				{
					string successMessage = string.Format("Node {0} is online", nodeId);
					string nodeNotFound = string.Format("Error! NodeId {0} does not exist", nodeId);

					try
					{
						var node = context.Nodes.Where(n => n.NodeId == nodeId).FirstOrDefault();

						if (node != null)
						{

							
							
							Node setOnlineAndStats = new Node();

							setOnlineAndStats.SetOnline(node);

							 //node.IsOnline = setOnlineAndStats.SetOnline(node);
							//node.ConnectedClients = setOnlineAndStats.ConnectedClients;
							//node.DownloadUtilization = setOnlineAndStats.DownloadUtilization;



							//node.IsOnline = statsObject.SetOnline();
							//node.ConnectedClients = statsObject.ConnectedClients;
							//node.UploadUtilization = statsObject.UploadUtilization;
							//node.DownloadUtilization = statsObject.DownloadUtilization;
							//node.ErrorRate = statsObject.ErrorRate;

							//context.SaveChanges();

							//return successMessage;

							//return statsObject;
							//return setOnlineAndStats;
							return node;
						}
						else
						{
							throw new Exception(nodeNotFound);
						}
					}
					catch (Exception ex)
					{
						return ex.Message;
					}

				}
			}
			else
			{
				return noNodeId;
			}


		}

		//public string SetNodeOffline(int nodeId) { //Remember to call resetmetrics method when doing this}

		public string SetNodeMaxLimits(NodesDTO node)
		{
			string nodeObjectNull = string.Format("Error! Node object is null");

			if (node != null)
			{
				using(var context = new NodeSimulationContext())
				{
					try
					{
						string successMessage = string.Format("Max limits for Node {0} have been successfully set", node.NodeId);
						string nodeNotFound = string.Format("Error! NodeId {0} does not exist", node.NodeId);

						var getNode = context.Nodes.Where(n => n.NodeId == node.NodeId).FirstOrDefault();

						if (getNode != null)
						{
							if (getNode.MaxUploadUtilization != node.MaxUploadUtilization)
							{
								getNode.MaxUploadUtilization = node.MaxUploadUtilization;
							}

							if (getNode.MaxDownloadUtilization != node.MaxDownloadUtilization)
							{
								getNode.MaxDownloadUtilization = node.MaxDownloadUtilization;
							}

							if (getNode.MaxErrorRate != node.MaxErrorRate)
							{
								getNode.MaxErrorRate = node.MaxErrorRate;
							}

							if (getNode.MaxConnectedClients != node.MaxConnectedClients)
							{
								getNode.MaxConnectedClients = node.MaxConnectedClients;
							}

							context.SaveChanges();

							return successMessage;
						}
						else
						{
							throw new Exception(nodeNotFound);

						}
					
					}
					catch(Exception ex)
					{
						return ex.Message;
					}
				}
				
			}
			else
			{
				throw new Exception(nodeObjectNull);
			}

		}
	}








}

