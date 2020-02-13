# Node Simulation Web Application

## Description:

This application is based on a technical assessment that I was given.  Its goal was to build an application to simulate nodes on a network and to give the team that is in charge of monitoring these nodes the ability to do the following:

- Add/Remove Nodes.
- Bring a node online.
- Take a node offline.
- User can see if a node is online or offline.
- User can see the metrics of the node.
- User can set the maximum values for each metric of the node.
- An alarm that goes off if any of the metrics exceed the maximum limit set by the user.
- Build a UI that shows the functionality of the features above.

I was given non-functioning boilerplate console-based code written in C# using .Net Core 2.2.  I had the choice of whether to use or discard any or all of the code as I wished.  I took the boilerplate code and modified it where I saw fit.  Futhermore, I built the application as a web application from the ground up using the following technologies:

- .NET Core 2.2.402.
- Versioned API.
- Web API 2.
- Entity Framework Core.
- SQL Server Express.
- [Vue.js and Vuetify on the frontend.](https://github.com/mdasfour/node-simulation-ui/)

The project is divided into three separate projects that reference each other:

- NodeSimulation.Api - Contains the controller for the application.
- NodeSimulation.Data - The Data layer.  Contains the model files.
- NodeSimulation.Logic - The service layer. Contains the logic of the application.

This division keeps the project organized and gives the developer the ability to take any one of these projects and reuse it with another project should there be a need. Also, all SQL files are located in the SQL directory.

**NOTE: Although the default database used in this project is SQL Server Express (MSSQLLocalDB), should you need to change the database configuration, please do so in the `appsettings.json` file in both NodeSimulation.Api project and the NodeSimulation.Logic project.**

## How to run this project:

1. Open SQL Server Management Studio and login using your Windows authentication under Authentication and `(localdb)\MSSQLLocalDB` under Server Name. 

2. Go to File &rightarrow; Open &rightarrow; File. Choose the `NodeSimulationDatabase.sql` script file in the directory `SQL`, click on `Open` and then press `F5` to run it.

3. Go to File &rightarrow; Open &rightarrow; File. Choose the `NodesTable.sql` script file in the directory `SQL`, click on `Open` and then press `F5` to run it.

2. Go to File &rightarrow; Open &rightarrow; File. Choose the `NodesTableData.sql` script file in the directory `SQL`, click on `Open` and then press `F5` to run it.

3. Open the solution file `NodeSimulation.sln` located in the `NodeSimulation` directory, in Visual Studio. **NOTE: Please make sure that you have the option "Allow Nuget to download missing packages" enabled in order to download the Nuget packages used in this project. This can be enabled by going to Tools &rightarrow; Options &rightarrow; Nuget Package Manager &rightarrow; General.** Go to the Build menu &rightarrow; and click on Build Solution. Visual Studio should now start downloading any dependencies necessary to run the application.  If you get any errors after loading the project, go to the Build menu again &rightarrow; click on Clean Solution. Once Visual Studio has finished cleaning up the solution, go to the Build menu &rightarrow; and click on Rebuild Solution. Once that has been completed, press `CTRL + F5` in order to run the application.
