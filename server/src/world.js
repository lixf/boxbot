/** world.js
 *  Handles world simulation and client request for world objects
 */

var _ = require('lodash');

var config = require('../config/config');

// stores items currently in pittsburgh
var pittsburgh = {
  "armour": [],
  "weapon": []
};

function startSimulation () {
  // set up simulation  
  _.map(config.world.regions, function (region) {
    _.map(config.items, function (list, item_type) {
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

function populateRegion(region, items, item_type) {
  // sort by ascending probability
  var items = _.sortBy(items, function (p) {
    return p.probability;
  });

  // create distribution
  var dist = _.map(_.range(0, items.length), function (i) {
    if (i == 0) {
      return items[i];
    } else {
      items[i].probability += items[i-1].probability;
      return items[i];
    }
  });

  // create random number of items (up to 10)
  var num = randomInt(0, 10);

  // randomly generate locations and assign random item to each
  var new_items = _.map(_.range(0, num), function (i) {
    // figure out what prototype to use
    var prob = Math.random(0, 1);
    var i = _.find(dist, function (p) {
      return prob <= p.probability;
    });

    // generate location
    var lat = Math.random(region.start_lat, region.end_lat);
    var lng = Math.random(region.start_lng, region.end_lng);

    return {
      'lat': lat,
      'lng': lng,
      'item': i
    };
  });

  pittsburgh[item_type] = pittsburgh[item_type].concat(new_items);
}

// client handlers

function findItem (req, res) {
}

module.exports = {
  startSimulation: startSimulation
}
