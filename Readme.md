Human Resource
--------------

This is a simple MVC application that allows the user to view a list of employees in a sqlserver database. The user may filter and sort the returned records. Records may be added, updated or deleted from the view.

This has been built in a set of layers using both a front end MVC project as well as a set of Web Apis that in turn use a service and datalayer.

Access to the database is achieved via Entity Framework. the database is included in the project as an attached MDF file. There is also a SQL script to create the database if
it was required called DatabaseCreation.sql. If a seperate database was used then the connection string in the App.config will need to be amended to point to the relevant location.

Unit testing is performed using XUnit and demonstrates the use of the MOQ framework. 

The web apis use swagger to document and make them visible within a browser.


## Running the Application

1. To run this open Visual Studio open the application in Visual Studio.
2. In Package Manager console run "Update-package -reinstall". 
3. Open the properties for the solution and set the two projects HumanResources and HumanResourcesWebApi to start.

![image](https://user-images.githubusercontent.com/28151071/138508911-192b9bd6-b08b-490c-a1f2-c432c44d4392.png)

5. Amend the file .\HumanResourceWebApis\HumanResourceWebApis\App_Start\WebApiConfig.cs to change the path in the line to the location of the project.

           AppDomain.CurrentDomain.SetData("DataDirectory", "C:\\Projects\\HumanResourceWebApis\\HumanResourcesWebApis.DataLayer\\");
		   
4. Start the project using F5.
5. This will start both the web api's and the mvc project in two browser windows. 


## How this could be improved

1. Add additional unit testing to both the web api and the main mvc project
2. Add functional testing using selenium
3. Add a search function to search by name




