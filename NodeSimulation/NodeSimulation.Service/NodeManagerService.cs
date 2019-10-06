using KellermanSoftware.CompareNetObjects;
using NodeSimulation.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace NodeSimulation.Service
{
	public class NodeManagerService : INodeManager
	{
		public List<NodesDAO> GetNodes(int? nodeId)
		{
			using (var context = new NodeSimulationContext())
			{
				var nodes = context.Nodes.Select(n => new NodesDAO
				{
					Id = n.Id,
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

		//public string AddNode(INode node)
		//{
		//	//Ask about Node constructor with parameters
		//	//Call resetMetrics after the creation of the node

		//	using (var context = new NodeSimulationContext())
		//	{
		//		//Check if the Node Id the user has chosen exists in the database before inserting
		//		var checkIfNodeIdExists = context.Nodes.Where(n => n.NodeId == node.NodeId).FirstOrDefault();

		//		if (checkIfNodeIdExists != null)
		//		{

		//			if ((!node.NodeId.Equals("") && node.NodeId > 0) && (!String.IsNullOrEmpty(node.City.Trim()) && !node.City.Trim().Equals("")))
		//			{
		//				//Node createNode = new Node(node.NodeId, node.City);

		//				Node createNode = new Node(node.NodeId, node.City);

		//				createNode.SetOffline();
		//				//Metrics


		//			}
		//			else
		//			{
		//				throw new Exception(String.Format("A node must contain at a minimum a Node Id and a City.  Please make sure that you have entered a Node Id and City and then try again."));
		//			}

		//		}


		//	}
		//}

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

		public string SetNodeOnline(int? nodeId)
		{
			string noNodeId = "Error! No Node Id.  Please make sure there is a Node Id before proceeding.";

			if (nodeId.HasValue)
			{
				using (var context = new NodeSimulationContext())
				{
					string successMessage = string.Format("Node {0} is online", nodeId);
					string nodeNotFound = string.Format("Error! Node {0} does not exist", nodeId);
					string notOnlineError = string.Format("Error! Could not switch Node {0} online.  Please try again.", nodeId);

					try
					{
						//Retrieve not from database
						var node = context.Nodes.Where(n => n.NodeId == nodeId).FirstOrDefault();

						if (node != null)
						{


							//Create an object from the Node class and instantiate it
							Node setOnlineAndStats = new Node(node.NodeId, node.City);

							//Set Online status to true and insert simulated metrics into node object
							setOnlineAndStats.SetOnline(node);



							if (node.IsOnline)
							{
								//Update the UpdateDT property in the object
								node.UpdatedDT = DateTime.Now;

								context.Update(node);

								context.SaveChanges();

								return successMessage;
							}
							else
							{
								throw new Exception(notOnlineError);
							}

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

		public string SetNodeOffline(int? nodeId)
		{
			string noNodeId = "Error! No Node Id.  Please make sure there is a Node Id before proceeding.";

			if (nodeId.HasValue)
			{
				using (var context = new NodeSimulationContext())
				{
					string successMessage = string.Format("Node {0} is offline", nodeId);
					string nodeNotFound = string.Format("Error! Node {0} does not exist", nodeId);
					string notOfflineError = string.Format("Error! Could not switch Node {0} offline.  Please try again.", nodeId);

					try
					{
						//Retrieve not from database
						var node = context.Nodes.Where(n => n.NodeId == nodeId).FirstOrDefault();

						if (node != null)
						{


							//Create an object from the Node class and instantiate it
							Node setOnlineAndStats = new Node(node.NodeId, node.City);

							//Set Online status to true and insert simulated metrics into node object
							setOnlineAndStats.SetOffline(node);

							if (!node.IsOnline)
							{
								//Update the UpdateDT property in the object
								node.UpdatedDT = DateTime.Now;

								context.Update(node);

								context.SaveChanges();

								return successMessage;
							}
							else
							{
								throw new Exception(notOfflineError);
							}

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

		public string SetNodeMaxLimits(Nodes node)
		{
			string nodeObjectNull = string.Format("Error! Node object is null");

			if (node != null)
			{
				using (var context = new NodeSimulationContext())
				{
					try
					{
						string successMessage = string.Format("Max limits for Node {0} have been successfully set", node.NodeId);
						string nodeNotFound = string.Format("Error! Node {0} does not exist", node.NodeId);
						string noUpdateMessage = string.Format("No change in information.  No information was updated");

						var getNode = context.Nodes.Where(n => n.NodeId == node.NodeId && !n.Deleted).FirstOrDefault();

						if (getNode != null)
						{

							//Using Compare-Net-Objects in order to compare the database query object to the object sent by the user.
							//Configuration below is to instantiate Compare-Net-Objects and to exclude object properties that are not needed for the comparison
							CompareLogic compare = new CompareLogic();
							compare.Config.MaxDifferences = 10;
							compare.Config.TypesToIgnore.Add(typeof(DateTime));
							compare.Config.TypesToIgnore.Add(typeof(bool));
							compare.Config.MembersToIgnore.Add("Nodes.City");
							compare.Config.MembersToIgnore.Add("Nodes.IsOnline");
							compare.Config.MembersToIgnore.Add("Nodes.UploadUtilization");
							compare.Config.MembersToIgnore.Add("Nodes.DownloadUtilization");
							compare.Config.MembersToIgnore.Add("Nodes.ErrorRate");
							compare.Config.MembersToIgnore.Add("Nodes.ConnectedClients");




							//Compare the database object to the object submitted by the user						   							 
							ComparisonResult result = compare.Compare(getNode, node);

							//If they are not equal, then proceed with updating the values in the table for the node
							if (!result.AreEqual)
							{
								getNode.MaxUploadUtilization = node.MaxUploadUtilization;

								getNode.MaxDownloadUtilization = node.MaxDownloadUtilization;

								getNode.MaxErrorRate = node.MaxErrorRate;

								getNode.MaxConnectedClients = node.MaxConnectedClients;

								context.Nodes.Update(getNode);

								context.SaveChanges();

								return successMessage;
							}
							else
							{
								return noUpdateMessage;
							}

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
				throw new Exception(nodeObjectNull);
			}

		}
	}
}

