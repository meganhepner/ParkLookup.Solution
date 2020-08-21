# <h1 align = "center"> Park Lookup

## <h3 align = "center"> C#/.NET API,  8.21.20

## <h2 align = "center"> About

<p align = "center"> This is an API for State and National Parks

## **✅REQUIREMENTS**
* Install [Git v2.62.2+](https://git-scm.com/downloads/)
* Install [.NET version 3.1 SDK v2.2+](https://dotnet.microsoft.com/download/dotnet-core/2.2)
* Install [Visual Studio Code](https://code.visualstudio.com/)
* Install [MySql Workbench](https://www.mysql.com/products/workbench/)

## **💻SETUP**
* to clone this content, copy the url provided by the green 'Code' button in GitHub
* in command line use the command 'git clone (GitHub url)'
* open the program in a code editor
* navigate to the ParkLookup directory and type **dotnet build** in the command line to compile the code
* remaining in the BakeryPierre directory type **dotnet ef database update** to create the database
* type dotnet run in the command line to run the program


## Documentation

**HTTP Request**
| Request | National Parks | State Parks | Result |
| :---------- | ----- | ----- | -----: |
| GET | /api/nationalpark | /api/statepark | list of all national or state parks |
| POST | /api/nationalpark | /api/statepark | create a national or state park |
| GET | /api/nationalpark/{id} | /api/statepark{id} | show selected (by id) national or state park |
| PUT | /api/nationalpark/{id} | /api/statepark{id} | edit selected (by id) national or state park |
| DELETE | /api/nationalpark/{id} | /api/statepark{id} | delete selected (by id) national or state park |

**Path Parameters**
| Behavior    | Input | Output |
| :---------- | ----- | -----: |
| Program can create a Treat object | none | none |
| Treat object holds treat name, availability, price | none | none |
| Program can show list of all treats | none | list |
| Program can show treat details, including flavor profiles | none | none |

**Example Query**

**Sample JSON Response**

``` 
{
    "stateParkId": 5,
    "stateParkName": "Smith Rock",
    "stateParkState": "Oregon",
    "stateParkHighlight": "climbing",
    "stateParkCamping": true,
    "stateParkHiking": true,
    "stateParkFishing": true
}
 ```

## 🐛Known Bugs

_No known bugs_

## 📫Support and contact details

Contact : Megan Hepner

## 🔧Technologies Used

* C#
* ASP.NET MVC
* Entity
* MySql


## **📘 License**
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)