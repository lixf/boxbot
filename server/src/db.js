/** db.js
 *  Handles data storage and retrieval
 *  Currently only a mock, not backed up by real database.
 */

var _ = require('lodash');

var config = require('../config/config');

var region_items = {};

function DB () {
  // set up database connection
  region_items = _.object(_.pluck(config.world.regions, 'rid'), 
    _.map(_.range(0, config.world.regions.length), function () {
      return [];
    })
  );
}

DB.prototype.addItemsToRegion = function (rid, items, callback) {
  region_items[rid] = region_items[rid].concat(items);
  callback(null);
};

DB.prototype.removeItemFromRegion = function (rid, iid, callback) {
  region_items[rid] = _.filter(region_items[rid], function (i) {
    return i.iid != iid; 
  });
  callback(null);
};

DB.prototype.getRegionItems = function (rid, callback) {
  return callback(null, region_items[rid]);
};

DB.prototype.getRegionByPosition = function (lat, lng, callback) {
  var region = _.find(config.world.regions, function (r) {
    // TODO: won't work for places that cross signs for longitude or lattitude
    return r.start_lat <= lat && r.end_lat >= lat &&
      r.start_lng <= lng && r.end_lng >= lng;
  });
  callback(null, region);
};

module.exports = DB;
