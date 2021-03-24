# Joker

Fathom full stack developer task.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

To run locally you need the [MySQL server](https://dev.mysql.com/downloads/) to be installed. 

### Database Structure

Use the **classes/common/dbcreate.sql** file to create the **MySQL** database and tables (you will need to edit the **dbcreate.sql** file to change the database name), and then place the database name, username and password in the following environment variables **LOCALDBNAME**, **LOCALDBUSER** and **LOCALDBPASSWORD**. Note: The database host is assumed to be **localhost** and the database table names can not be changed.

## Build Procedures

The following describes the build procedures.

### Command Line Build:

	$npm install

To run the application,

	$npm start
    
    Use your web browser to view http://localhost:3000

## Built With

* [Visual Studio Code](https://code.visualstudio.com/
) - IDE enviroment.

## Versioning

We use [SemVer](http://semver.org/) for versioning.  

## Authors

* **Gavin Baker** - *Initial work* - [End House Software](endhousesoftware.byethost11.com).
