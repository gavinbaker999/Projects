CREATE DATABASE IF NOT EXISTS jokes;
USE jokes;
DROP TABLE IF EXISTS jokedata;
CREATE TABLE jokedata(
     jokeId INT NOT NULL,
     jokeType VARCHAR(50) NOT NULL,
     jokeSetup VARCHAR(200) NOT NULL,
     jokePunchline VARCHAR(200) NOT NULL
     );
LOAD DATA LOCAL INFILE 'jokes.csv' 
  INTO TABLE jokedata 
  FIELDS TERMINATED BY ',' 
  LINES TERMINATED BY '\n'
  IGNORE 1 ROWS;
