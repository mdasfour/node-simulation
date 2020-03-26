using KellermanSoftware.CompareNetObjects;
using NodeSimulation.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace NodeSimulation.Service
{
	//The logic layer of the Node Simulation Web Application
	public class NodeManagerService : INodeManager
	{
		/*	Method: Nodes
		 *	Parameters: nodeId (Optional parameter)
		 *	Description: Retrieves a node in the Nodes table if a nodeId is passed or all the nodes in the nodes table if no nodeId is passed that have not been deleted (soft deleted).
		 */
		public List<NodesDAO> GetNodes(int? nodeId)
		{
			//Create an instance of the NodeSimulationContext class and dispose of object properly after use by using 'using' keyword
			using (var context = new NodeSimulationContext())
			{
				//Retrieve the node or nodes from the database and return the parameters below to the user
				var nodes = context.Nodes.Select(n => new NodesDAO
				{
					Id = n.Id,
					NodeId = n.NodeId,
					City = n.City,
					OnlineTime = n.OnlineTime,
					IsOnline = n.IsOnline,
					UploadUtilization = n.UploadUtilization,
					MaxUploadUtilization = n.MaxUploadUtilization,
					UploadUtilizationExceeded = n.UploadUtilizationExceeded,
					DownloadUtilization = n.DownloadUtilization,
					MaxDownloadUtilization = n.MaxDownloadUtilization,
					DownloadUtilizationExceeded = n.DownloadUtilizationExceeded,
					ErrorRate = n.ErrorRate,
					MaxErrorRate = n.MaxErrorRate,
					ErrorRateExceeded = n.ErrorRateExceeded,
					ConnectedClients = n.ConnectedClients,
					MaxConnectedClients = n.MaxConnectedClients,
					ConnectedClientsExceeded = n.ConnectedClientsExceeded,
					Deleted = n.Deleted
				}).Where(n => !n.Deleted && (!nodeId.HasValue || (n.NodeId == nodeId))).OrderBy(n => n.NodeId).ToList();

				//Return the node(s) to the user
				return nodes;
			}
		}

		/*	Method: AddNode
		 *	Parameters: node object of type Nodes
		 *	Description: Creates a node in the Nodes tables
		 */
		public string AddNode(Nodes node)
		{

			try
			{
				//Create an instance of the NodeSimulationContext class and dispose of object properly after use by using 'using' keyword
				using (var context = new NodeSimulationContext())
				{
					//If no node exists, display the message to the user
					string nodeExistsMessage = string.Format("Error! Node {0} exists.  Please choose a different Node Id and try again", node.NodeId);

					//Check if the Node Id the user has chosen exists in the database before inserting into the database
					var checkIfNodeExists = context.Nodes.Where(n => n.NodeId == node.NodeId).FirstOrDefault();

					//If the node Id does not exist, then proceed to create one
					if (checkIfNodeExists == null)
					{
						//Success message to display to user
						string successMessage = string.Format("Node {0} has been successfully created", node.NodeId);

						//If node object is null, display message to user
						string nodeNullObjectMessage = string.Format("Error! Could not create Node {0}.  Please try again", node.NodeId);

						//Check to make sure that the parameters required in order to create a new node are not 0, null or empty, before proceeding to create a new node
						if ((!node.NodeId.Equals("") && node.NodeId > 0) && (!String.IsNullOrEmpty(node.City.Trim()) && !node.City.Trim().Equals("")))
						{
							//Create an object of the node class and instantiate with the node Id and City that the user has chosen
							Node createNode = new Node(node.NodeId, node.City);

							//Create an object of the model class and instantiate it
							Nodes newNode = new Nodes();

							//If the node object has been created successfully, create the node
							if (createNode != null)
							{
								newNode.NodeId = createNode.NodeId;
								newNode.City = createNode.City;
								newNode.OnlineTime = createNode.OnlineTime;
								newNode.IsOnline = createNode.IsOnline;
								newNode.UploadUtilization = createNode.UploadUtilization;
								newNode.MaxUploadUtilization = node.MaxUploadUtilization;
								newNode.DownloadUtilization = createNode.DownloadUtilization;
								newNode.MaxDownloadUtilization = node.MaxDownloadUtilization;
								newNode.ErrorRate = createNode.ErrorRate;
								newNode.MaxErrorRate = node.MaxErrorRate;
								newNode.ConnectedClients = createNode.ConnectedClients;
								newNode.MaxConnectedClients = node.MaxConnectedClients;
								newNode.Deleted = false;
								newNode.InsertedDT = DateTime.Now;

								//Save the node to the database
								context.Add(newNode);
								context.SaveChanges();

								//Return the success message to the user
								return successMessage;

							}
							//If the node object is null, throw an exception and return the error message to the user
							else
							{
								throw new Exception(nodeNullObjectMessage);
							}
						}
						//If no node Id and city is entered by the user, display the message below to the user
						else
						{
							throw new Exception(String.Format("A node must contain at minimum a Node Id and a City.  Please make sure that you have entered a Node Id and City and then try again."));
						}

					}
					//Return message to the user if the nodeId already exists
					else
					{

						return nodeExistsMessage;
					}


				}
			}
			//If an exception is thrown, display message to the user
			catch (Exception ex)
			{
				return ex.Message;
			}

		}

		/*	Method: RemoveNode
		 *	Parameters: nodeId
		 *	Description: Soft deletes a node from the Nodes table
		 */
		public string RemoveNode(int nodeId)
		{
			//Create an instance of the NodeSimulationContext class and dispose of object properly after use by using 'using' keyword
			using (var context = new NodeSimulationContext())
			{
				//Success message to display to the user, once the node has been removed
				string successMessage = string.Format("Node {0} has been successfully removed", nodeId);

				//Message to display to the user if the node is not found
				string nodeNotFound = string.Format("Cannot remove node. NodeId {0} does not exist", nodeId);

				try
				{
					//Query the Nodes table for the node
					var node = context.Nodes.Where(n => n.NodeId == nodeId && !n.Deleted).FirstOrDefault();

					//If the node has been found, set the value of the Deleted column to true, insert the date and time of the DeletedDT column, save the changes to the database and return a success message to the user
					if (node != null)
					{
						node.Deleted = true;

						node.DeletedDT = DateTime.Now;

						context.SaveChanges();

						return successMessage;
					}
					//Throw an exception if the node has not been found
					else
					{
						throw new Exception(nodeNotFound);
					}
				}
				//If an exception is thrown, display message to the user
				catch (Exception ex)
				{
					return ex.Message;
				}

			}
		}

		/*	Method: SetNodeOnline
		 *	Parameters: nodeId
		 *	Description: Sets the node status in the column IsOnline to true and assigns metrics to the node.
		 */
		public string SetNodeOnline(int nodeId)
		{

			//Create an instance of the NodeSimulationContext class and dispose of object properly after use by using 'using' keyword
			using (var context = new NodeSimulationContext())
			{
				//Messages to return to the frontend
				string successMessage = string.Format("Node {0} is online", nodeId);
				string nodeNotFound = string.Format("Error! Node {0} does not exist", nodeId);
				string notOnlineError = string.Format("Error! Could not switch Node {0} online.  Please try again.", nodeId);

				try
				{
					//Retrieve node from database
					var node = context.Nodes.Where(n => n.NodeId == nodeId).FirstOrDefault();

					//If the node has been found, proceed to update
					if (node != null)
					{


						//Create an object from the Node class and instantiate it
						Node setOnlineAndStats = new Node(node.NodeId, node.City);

						//Set Online status to true and insert simulated metrics into node object
						setOnlineAndStats.SetOnline(node);


						//If the node has an online status of true, update the node object and save it to the database
						if (node.IsOnline)
						{
							//Update the UpdateDT property in the object
							node.UpdatedDT = DateTime.Now;

							context.Update(node);

							context.SaveChanges();

							return successMessage;
						}
						//If the node is not online, throw an exception and return a message that the node is not online
						else
						{
							throw new Exception(notOnlineError);
						}

					}
					//If the node was not found, throw an exception and return error message to the frontend
					else
					{
						throw new Exception(nodeNotFound);
					}
				}
				//If an exception is thrown, display message to the user
				catch (Exception ex)
				{
					return ex.Message;
				}

			}

		}

		/*	Method: SetNodeOffline
		 *	Parameters: nodeId
		 *	Description: Sets the node status to offline
		 */
		public string SetNodeOffline(int nodeId)
		{

			//Create an instance of the NodeSimulationContext class and dispose of object properly after use by using 'using' keyword
			using (var context = new NodeSimulationContext())
			{
				//Messages to return to the frontend
				string successMessage = string.Format("Node {0} is offline", nodeId);
				string nodeNotFound = string.Format("Error! Node {0} does not exist", nodeId);
				string notOfflineError = string.Format("Error! Could not switch Node {0} offline.  Please try again.", nodeId);

				try
				{

					//Retrieve node from database
					var node = context.Nodes.Where(n => n.NodeId == nodeId).FirstOrDefault();

					//If node is not null, then proceed to set the node to offline
					if (node != null)
					{


						//Create an object from the Node class and instantiate it
						Node setOnlineAndStats = new Node(node.NodeId, node.City);

						//Set Online status to true and insert simulated metrics into node object
						setOnlineAndStats.SetOffline(node);

						//If the node is offline, update the node object and save it in the database and return success message to the frontend
						if (!setOnlineAndStats.IsOnline)
						{
							node.UpdatedDT = DateTime.Now;

							context.Update(node);

							context.SaveChanges();

							return successMessage;
						}
						//If the node is online throw an exception and return message to the frontend
						else
						{
							throw new Exception(notOfflineError);
						}

					}
					//If the node has not been found in the database, throw an exception and return message to the frontend
					else
					{
						throw new Exception(nodeNotFound);
					}
				}
				//If an exception is thrown, display message to the user
				catch (Exception ex)
				{
					return ex.Message;
				}

			}
		}

		/*	Method: SetNodeMaxLimits
		 *	Parameters: node object of type Nodes
		 *	Description: Sets the maximum limits for a node for the following properties: Upload utilization, Download utilization, Error rate, and Connected clients
		 */
		public string SetNodeMaxLimits(Nodes node)
		{
			//Message to return to the frontend if the node object is null
			string nodeObjectNull = string.Format("Error! Node object is null");

			//If the node object is not null proceed with setting the maximum limits for the node
			if (node != null)
			{
				//Create an instance of the NodeSimulationContext class and dispose of object properly after use by using 'using' keyword
				using (var context = new NodeSimulationContext())
				{
					try
					{
						//Messages to return to the frontend depending on status
						string successMessage = string.Format("Max limits for Node {0} have been successfully set", node.NodeId);
						string nodeNotFound = string.Format("Error! Node {0} does not exist", node.NodeId);
						string noUpdateMessage = string.Format("No change in information.  No information was updated");

						//Retrieve the node from the database
						var getNode = context.Nodes.Where(n => n.NodeId == node.NodeId && !n.Deleted).FirstOrDefault();

						//If the node exists in the database, then proceed to set the maximum limits for the node
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

							//If they are not equal, then proceed with updating the values in the database for the node and return success message to the frontend
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
							//If the information submitted by the user is the same as what is in the database, return a message that nothing has been updated
							else
							{
								return noUpdateMessage;
							}

						}
						//Throw an exception if the node is not found
						else
						{
							throw new Exception(nodeNotFound);

						}

					}
					//If an exception is thrown, display message to the user
					catch (Exception ex)
					{
						return ex.Message;
					}
				}

			}
			//Throw an exception if the node object is null
			else
			{
				throw new Exception(nodeObjectNull);
			}

		}
	}
}

