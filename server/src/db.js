/** db.js
 *  Handles data storage and retrieval
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

DB.prototype.addItemsToRegion = function (rid, items) {
  region_items[rid] = region_items[rid].concat(items);
}

DB.prototype.removeItemFromRegion = function (rid, iid) {
  region_items[rid] = _.filter(region_items[rid], function (i) {
    return i.iid != iid; 
  });
}

module.exports = DB;
