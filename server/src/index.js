var express = require('express');
var bodyParser = require('body-parser');
var morgan = require('morgan');

var world = require('./world.js');

// start world
world.startSimulation();

// set up server
var app = express();

app.use(bodyParser.json());
app.use(morgan('combined'));
app.use(function (err, req, res, next) {
  // catch middleware errors
  if (err) {
    res.send(400);
    return;
  }
  next();
});

// set up routes
app.get('/', function(req, res) {
  res.send('Welcome to the BoxBot Server');
});
app.post('/api/getRegionItems', world.getRegionItems);
app.post('/api/claimItem', world.claimItem);
app.post('/api/*', function (req, res) {
  res.send(404);
});

app.listen(8080);
