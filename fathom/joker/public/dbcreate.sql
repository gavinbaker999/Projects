CREATE DATABASE IF NOT EXISTS jokes;
USE jokes;
DROP TABLE IF EXISTS jokedata;
CREATE TABLE jokedata(
     jokeId INT NOT NULL UNIQUE,
     jokeType VARCHAR(50) NOT NULL,
     jokeSetup VARCHAR(200) NOT NULL,
     jokePunchline VARCHAR(200) NOT NULL,
     PRIMARY KEY (jokeId)
     );
LOAD DATA INFILE 'jokes.csv' 
  INTO TABLE discounts 
  FIELDS TERMINATED BY ',' 
  ENCLOSED BY '"'
  LINES TERMINATED BY '\n'
  IGNORE 1 ROWS
  (@jokeId,jokeType,jokeSetup,jokePunchLine)
  SET jokeId = CAST(@jokeId AS UNSIGNED);
