# Joker

Fathom full stack developer task.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

To run locally you need the [MySQL server](https://dev.mysql.com/downloads/) to be installed  - note the password you set for the user root. 

### Database Structure

To import joke data into database and create the jokedata table,

    $mysql --local_infile=1 -u root -p < dbcreate.sql

Note: If you recieve an error importing the joke data, you may have to check if the local_infile global variable is disabled. To enable local_infile,

    mysql> SET GLOBAL local_infile=1;
    Query OK, 0 rows affected (0.00 sec)

The database host is assumed to be **localhost** and the database table name can not be changed.

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
