/*!
 * Joker
 * Copyright(c) 2021 End House Software
 * 
 * Version 1.0.0  Initial Version
 */

'use strict'

var express = require('express');
var mysql   = require('mysql');

var app = express();

//var connection = mysql.createConnection({
//  host     : 'localhost',
//  user     : 'me',
//  password : 'secret',
//  database : 'my_db'
//});
 
//connection.connect(function(err) {
//	if (err) {
//	  console.error('error connecting: ' + err.stack);
//	  return;
//	}   
//	console.log('connected as id ' + connection.threadId);
//}); 

//connection.query('SELECT 1 + 1 AS solution', function (error, results, fields) {
//  if (error) throw error;
//  console.log('The solution is: ', results[0].solution);
//});
 
//connection.end();

app.get('/', function(req,res) {
	res.send("Hello World!!!");
});

app.listen(4000,()=>console.log("Server started on port 4000"));
