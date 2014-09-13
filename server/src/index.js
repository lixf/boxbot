var express = require('express');
var bodyParser = require('body-parser');
var morgan = require('morgan');
var timeout = require('connect-timeout');

var world = require('./world.js');
var arena = require('./arena.js');

// start world
world.startSimulation();

// set up server
var app = express();

app.use(bodyParser.json());
app.use(morgan('combined'));
app.use(timeout(10000)); // 10 second timeout
app.use(function (err, req, res, next) {
  // catch middleware errors
  if (err) {
    res.send(400);
    return;
  }
  next();
});
app.use(function (req, res, next) {
  if (!req.timedout) {
    next();
  }
});

// set up routes
app.get('/', function(req, res) {
  res.send('Welcome to the BoxBot Server');
});
app.post('/api/getRegionItems', world.getRegionItems);
app.post('/api/claimItem', world.claimItem);
app.post('/api/battle', arena.battle);
app.post('/api/*', function (req, res) {
  res.send(404);
});

app.listen(8080);
