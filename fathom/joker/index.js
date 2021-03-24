/*!
 * Joker
 * Copyright(c) 2021 End House Software
 * 
 * Version 1.0.0  Initial Version
 */

'use strict'

var express = require('express');
var exphbs  = require('express-handlebars');
var mysql   = require('mysql');
var path    = require('path');
var settings = require('./public/js/settings');

var app = express();

// View Engine
app.set('views', path.join(__dirname, 'views'));
app.engine('handlebars', exphbs({defaultLayout:'layout'}));
app.set('view engine', 'handlebars');

// Set Static Folder
app.use(express.static(path.join(__dirname, 'public')));

// Provide access to node_modules folder from the client-side
app.use('/scripts', express.static(`${__dirname}/node_modules/`));

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
    res.render('index');
});

console.log('Admin email:' + settings.adminEmail);

// Set Port
app.set('port', (process.env.PORT || 3000));

app.listen(app.get('port'), function(){
	console.log('Server started on port '+app.get('port'));
});
