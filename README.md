# Shop Bridge

**Shop Bridge** is a web application that helps track the different items they have for sale.

[![HitCount](http://hits.dwyl.com/kunalfrk/ShopBridge.svg)](http://hits.dwyl.com/kunalfrk/ShopBridge)

[![Shop Bridge Image](https://github.com/kunalfrk/ShopBridge/blob/master/ShopBridge.Web/Content/ShopBridge.jpg)]()

## 📒 Table of Contents 

- [System Requirements](#-system-requirements)
- [Setup](#-setup)
- [Run Project](#-run-project)
- [Usage](#-usage)
- [Run Tests](#-run-tests)
- [Build](#-build)
- [Time Tracking](#-time-tracking)
- [License](#-license)

## ⚙ System Requirements

* IDE Framework - **Visual Studio 2019 or higher**
* Database - **SQL Server 2012 or higher**
* OS - **Windows 8 or higher**
* **IIS** should be installed.
---
## 🛠 Setup

1. Pull the code.
2. Open **ShopBridge.sln** file via Visual Studio.
3. Insert connectionString in the _**App.config**_ file of **ShopBridge.Database** project as shown below :

```
<connectionStrings>
    <add name="ShopBridgeConnection" connectionString="Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=ShopBridgeDB;Integrated Security=True"
      providerName="System.Data.SqlClient" />
  </connectionStrings>
```
4. Open **Package Manager Console** in Visual Studio _(**Tools > NuGet Package Manager > Package Manager Console**)_
5. In the Package Manager Console, select Default Project as **ShopBridge.Database**.
6. Run these commands in the console as shown below :

    > NOTE : Press Enter after writing each of these commands.
    
* `PM > enable-migrations `
* `PM > add-migration initialized`
* `PM > update-database`

7. Right-click **ShopBridge.WebAPI** in Visual Studio.Then go to _**Properties > Web >** Copy the specified **Project Url**_.
8. Now in Web.Config of **ShopBridge.Web** project, paste and replace the `http://localhost:17476/` part of `<add key="serviceBaseUri" value="http://localhost:17476/api/"/>` with your copied Project Url.
---
## ⌛ Run Project

* Run the project by pressing **F5** in the keyboard.
---
## ✔ Usage

* User can add items in the **Create Inventory Item** section of the page.
* The added items are listed below in the **List Inventory Items** section of the page.
* User can view the **item details** by clicking on each Items.
* Items can also be deleted from the specified **Delete** action button.

![Recordit GIF](http://g.recordit.co/TTxe3vfM8I.gif)
---
## 🧪 Run Tests

* Go to _**Test > Test Explorer**_.
* Click on **Run All Test** icon.
---
## 🌐 Build

* In the Build Menu, change Configuration Manager from Debug to **Release**.
* Right-click on **ShopBridge.Web** project. Select **Publish**.
* Select **Folder** from list of Hosting options. Click **Next**.
* Choose a publishing directory. 
* Click **Finish**.
---
## 🕔 Time Tracking

* Backend Functionality - 6 hours
* Frontend Functionality - 2 hours
* Frontend Presentation - 1 hour
* Backend-Frontend Integration - 5 hours
* Unit Test Coverage - 3 hours

---
## 📑 License

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/kunalfrk/ShopBridge/blob/master/LICENSE)

[Shop Bridge](#shop-bridge) is under the **MIT license**. See the [LICENSE](https://github.com/kunalfrk/ShopBridge/blob/master/LICENSE) for more information.


