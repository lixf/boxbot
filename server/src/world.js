/** world.js
 *  Handles world simulation and client request for world objects
 */

var _ = require('lodash');
var DB = require('./db.js');
var uuid = require('node-uuid');

var config = require('../config/config');

var db;

function startSimulation () {
  db = new DB(); 

  // set up simulation  
  _.map(config.world.regions, function (region) {
    _.map(config.item_prototypes, function (list, item_type) {
      // add new objects every 5 seconds
      setInterval(function () {
        populateRegion(region, list, item_type)
      }, 5000);
    });
  });
}

function random (low, high) {
  return Math.random() * (high - low) + low;
}

function randomInt (low, high) {
  return Math.floor(Math.random() * (high - low) + low);
}

function populateRegion(region, prototypes, item_type) {
  // sort by ascending probability
  prototypes = _.sortBy(prototypes, function (p) {
    return p.probability;
  });

  // create distribution
  var dist = _.map(_.range(0, prototypes.length), function (i) {
    if (i == 0) {
      prototypes[i].pvalue = prototypes[i].probability;
    } else {
      prototypes[i].pvalue = prototypes[i].probability + 
        prototypes[i-1].pvalue;
    }
    return prototypes[i];
  });

  // create random number of prototypes (up to 10)
  var num = randomInt(0, 10);

  // randomly generate locations and assign random item to each
  var new_items = [];
  for (var i = 0; i < num; i++) {
    // figure out what prototype to use
    var prob = Math.random(0, 1);
    var it = _.find(dist, function (p) {
      return prob <= p.pvalue;
    });

    // generate location
    it.lat = Math.random(region.start_lat, region.end_lat);
    it.lng = Math.random(region.start_lng, region.end_lng);

    // create item id
    it.iid = uuid.v4();
    
    new_items.push(it);
  }

  db.addItemsToRegion(region.rid, new_items);
}

// client handlers

function findItem (req, res) {
}

module.exports = {
  startSimulation: startSimulation
}
