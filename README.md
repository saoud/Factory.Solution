<div align="center">

# Dr. Sillystringz's Factory

</div>

<h3 align="center">Description of application, June-05-2021</h3>
<h4 align="center"> By Saoud Rana</h4>

## Description




## Specifications

## Setup/Installation Requirements
Go to `Factory.Solution` Folder and create a file called `appsettings.json` file and input the following script (note the name of the database below needs to match the name of the database you created) Also change `[ENTERPASSWORDHERE]` to the password you set prior.

```{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=saoud_rana;uid=root;pwd=[ENTERPASSWORDHERE];"
  }
}
```
##### Software Requirements

1. Internet browser
2. A code editor such as VSCode to view and edit the code
3. .NET or follow along with the Installing .NET instructions to install .NET

##### Open Locally

- Click on the link to my repository: [My Repository](https://github.com/saoud/Factory.Solution.git)
- Click on the green "Code" button and copy the repository URL
- Open your terminal and use the command `git clone https://github.com/saoud/Factory.Solution.git` into the directory you would like to clone the repository
- Open in text editor to view code and make changes

##### Installing .NET

In order to run the application, please install .NET for your computer to recognize the `dotnet` command.

1. Download [.NET Core SDK (Software Development Kit)](https://dotnet.microsoft.com/download/dotnet). Clicking this link will prompt a file download for your particular OS from Microsoft.
2. Open the file. Follow the installation steps.
3. Confirm the installation is successful by opening your terminal and running the command `dotnet --version`. The response should be something similar to this:`5.0.100`. This means it was successfully installed.

##### Installing MySQL

MySQL is a type of database software used to create, edit, query, and manage SQL data.

- For Mac Users please [Click Here](https://dev.mysql.com/downloads/file/?id=484914) to download MySQL Installer
- For Windows Users please [Click Here](https://dev.mysql.com/downloads/file/?id=484919)

- Verify MySQL installation by opening the terminal and entering the command `mysql -u[USERNAME] -p[THEPASSWORDYOUSELECTED]`
- If you gain access you will see see the MYSQL command line!

##### Installing MySQL Workbench

- Please [Click Here](https://dev.mysql.com/downloads/workbench/) to install the correct version for your machine
- Open MySQL Workbench and select `Local instance 3306 server`. You will need to enter the password you selected

##### Compiling

- Navigate to the Factory folder in the command line
- Use the command `dotnet build` to compile

##### Installing Packages

- Navigate to the Factory folder in the command line
- Use the command `dotnet restore`

<details>
### Update Database Using MySQL Workbench

1. Open MySQL Workbench
2. Click on Server > Data Import in the top navigation bar
3. Select `Import from Self-Contained File`
4. Select the `Default Target Schema` or create new schema
5. Select all Schema Objects you would like to import
6. Select `Dump Structure and Data`
7. Click `Start Import`

  <summary>Expand for Database Installation Essentials!</summary>

### Import Database Using Entity Framework Core

1. Navigate to Factory directory in terminal
2. Use the command `dotnet ef database update` to generate the database through Entity Framework Core

### Update Database Using Entity Framework Core

1. Write any new code you wish to add to the database. Use the command `dotnet build` to check for any compiling errors. If no errors, proceed to step 2.
2. To update the database with any changes made to the code, use the command `dotnet ef migrations add [MigrationsName]`
3. Use the command `dotnet ef database update` to update the database


</details>

##### View In Browser

- To view in browser, navigate to Factory folder in the command line
- Use the command `dotnet run` to execute the compiled code and start a localhost
- In browser navigate to http://localhost:5000
- Or Navigate to  https://localhost:5001 for the SSL version.

## Known Bugs

Currently getting a build error. 
`CSC : error CS5001: Program does not contain a static 'Main' method suitable for an entry point`

## Support and Contact Details

If any errors or bugs occur with installation, delete both bin and obj folders and follow the Compiling and Installing Packages instructions again. Get help or report a bug you have found in the .NET platform at [.NET Support](https://dotnet.microsoft.com/platform/support). Or please email me, <githubissues@saoud.dev>.

## Technologies Used
```
- .NET Core 5.0.1
- ASP.NET Core MVC
- ASP.NET Core Razor Pages
- Bootstrap
- C#
- CSS
- Entity Framework Core
- GitHub
- HTML
- MySQL
- MySQL Workbench
- VS Code
```
### License

* [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/saoud/csharp-TDD-template/blob/main/LICENSE)

Copyright (c) 2021 Saoud Rana
