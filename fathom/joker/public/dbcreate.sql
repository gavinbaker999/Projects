CREATE DATABASE IF NOT EXISTS jokes;
USE jokes;
CREATE TABLE IF NOT EXISTS jsontest(
     rowid INT AUTO_INCREMENT NOT NULL UNIQUE,
     jsondata json
     );
LOAD DATA LOCAL INFILE 'jokes.json' into table jsontest(jsondata);
