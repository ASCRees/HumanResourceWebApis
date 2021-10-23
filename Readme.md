Human Resource
--------------

This is a simple MVC application that allows the user to view a list of employees in a sqlserver database. The user may filter and sort the returned records. Records may be added, updated or deleted from the view.

This has been built in a set of layers using both a front end MVC project as well as a set of Web Apis that in turn use a service and datalayer.

Access to the database is achieved via Entity Framework. The database is included in the project as an attached MDF file. There is also a SQL script to create the database if
it was required, called DatabaseCreation.sql. If a seperate database was used then the connection string in the App.config will need to be amended to point to the relevant location.

Unit testing is performed using XUnit and demonstrates the use of the MOQ framework. 

The web apis use swagger to document and make them visible within a browser.


## Running the Application

1. To run this open Visual Studio open the application in Visual Studio.
2. Rebuild the solution. If any required packages are missing you may need to install any missing packages using "Update-package -reinstall". Do not update any existing packages. For example if asked f you want to overwrite any existing items choose No. 

![image](https://user-images.githubusercontent.com/28151071/138554863-176c67e0-a3b0-439c-a2c3-37649f5f2ee1.png)

Note. Verify that the settings for the dependency resolution in the Defaultregistry.cs in both the HumanResources and HumandResourcesWebApi projects have not been destroyed. If so this is what they should look like.

#HumanResources - DefaultRegistry.cs

![image](https://user-images.githubusercontent.com/28151071/138554555-bf6a18a0-a0b4-4e6e-8b4f-c59d64b75d77.png)

#HumanResourcesWebApi - DefaultRegistry.cs

![image](https://user-images.githubusercontent.com/28151071/138554599-3ee9455b-06c4-4298-b620-1d584c8f6c7f.png)

4. Perform a Clean and the Rebuild.

5. Open the properties for the solution and set the two projects HumanResources and HumanResourcesWebApi to start.

![image](https://user-images.githubusercontent.com/28151071/138508911-192b9bd6-b08b-490c-a1f2-c432c44d4392.png)

6. Amend the file .\HumanResourceWebApis\HumanResourceWebApis\App_Start\WebApiConfig.cs to change the path in the line to the location of the project.

           AppDomain.CurrentDomain.SetData("DataDirectory", "C:\\Projects\\HumanResourceWebApis\\HumanResourcesWebApis.DataLayer\\");
		   
7. Start the project using F5.
8. This will start both the web api's and the mvc project in two browser windows. 
9. The Resource Name, Department Name and Status headers may be clicked on to sort by these fields. Sorting on Resource Name will sort by Surname only.
10. The user may filter based upon Department and/or Status using the drop downs visible in the header.
11. Altering the Total results per page value and clicking on refresh will cause the page to refresh and use that value to specify the maximum number of records on the page.
12. Clicking Add will open a page to allow a new record to be entered.
13. Clicking Edit will open the same page to edit the record.

## How this could be improved

1. Add additional unit testing to both the web api and the main mvc project
2. Add functional testing using selenium
3. Add a search function to search by name
4. Move the filtering from the ModelBuilder to the web api service layer enhancing the web apis

## Troubleshooting
If compiling gives an error related to either SQl server or not being able to copy files due to them being in use, make sure there is not a SQL Server process already running. If so terminate it.

## Screenshots
![image](https://user-images.githubusercontent.com/28151071/138509265-4749a861-550d-4aaa-8e5a-0ad01fa5c243.png)

![image](https://user-images.githubusercontent.com/28151071/138509364-060150f8-732f-453f-8c8f-4a058de7c8b2.png)




