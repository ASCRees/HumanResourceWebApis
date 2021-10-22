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
6. The Resource Name, Department Name and Status headers may be clicked on to sort by these fields. Sorting on Resource Name will sort by Surname only.
7. The user may filter based upon Department and/or Status using the drop downs visible in the header.
8. Altering the Total results per page value and clicking on refresh will cause the page to refresh and use that value to specify the maximum number of records on the page.
9. Clicking Add will open a page to allow a new record to be entered.
10. Clicking Edit will open the same page to edit the record.

## How this could be improved

1. Add additional unit testing to both the web api and the main mvc project
2. Add functional testing using selenium
3. Add a search function to search by name

## Troubleshooting
If comiling gives an error related to SQl server make sure there is not a SQL Server process already running. If so terminate it.

## Screenshots
![image](https://user-images.githubusercontent.com/28151071/138509265-4749a861-550d-4aaa-8e5a-0ad01fa5c243.png)

![image](https://user-images.githubusercontent.com/28151071/138509364-060150f8-732f-453f-8c8f-4a058de7c8b2.png)




