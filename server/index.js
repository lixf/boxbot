var express = require('express');

var app = express();

app.get('/', function(req, res) {
  res.send('Welcome to the BoxBot Server');
});

app.listen(8080);
