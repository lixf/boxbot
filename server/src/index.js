var express = require('express');

var world = require('./world.js');

// start world
world.startSimulation();

// set up server
var app = express();

// set up routes
app.get('/', function(req, res) {
  res.send('Welcome to the BoxBot Server');
});

app.listen(8080);
