##Human Resource
--------------

This is a simple MVC application that allows the user to view a list of employees in a sqlserver database. The user may filter and sort the returned records. Records may be added, updated or deleted from the view.

This has been built in a set of layers using both a front end MVC project as well as a set of Web Apis that in turn use a service and datalayer.

Access to the database is achieved via Entity Framework.

Unit testing is performed using XUnit and demonstrates the use of the MOQ framework. 



## Running the Application

1. To run this open Visual Studio open the application in Visual Studio.
2. In Package Manager console run "Update-package -reinstall". 
3. Open the properties for the solution and set the two projects HumanResources and HumanResourcesWebApi to start.
3. Amend the file .\HumanResourceWebApis\HumanResourceWebApis\App_Start\WebApiConfig.cs to change the path in the line to the location of the project.

           AppDomain.CurrentDomain.SetData("DataDirectory", "C:\\Projects\\HumanResourceWebApis\\HumanResourcesWebApis.DataLayer\\");
		   
4. Start the project using F5.


## How this could be improved

1. Add additional unit testing to both the web api and the main mvc project
2. Add functional testing using selenium
3. Add a search function to search by name




