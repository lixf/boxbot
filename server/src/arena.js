/** arena.js
 *  Handles battle negotiation, winner calculation, and match recording.
 */

var _ = require('lodash');

var battle_queue = {};

function battle_outcome(uid1, uid2) {
  var winner, loser;
  if (Math.random < 0.5) {
    winner = uid1;
    loser = uid2;
  } else {
    winner = uid2;
    loser = uid1;
  }

  return {
    winner: {
      uid: winner,
      hp_loss: -1 * Math.random()
    },
    loser: {
      uid: loser,
      hp_loss: -1 * Math.random()
    }
  };

}

// holds onto response object until opponent agrees
function battle(req, res) {
  if (!req || !req.body || !req.body.uid || !req.body.opponent_uid) {
    res.status(400).end();
    return;
  }

  var uid = req.body.uid;
  var opponent_uid = req.body.opponent_uid;

  // check if opponent is in the same fight
  if (_.has(battle_queue, opponent_uid) && battle_queue[opponent_uid][uid]) {
    var o_res = battle_queue[opponent_uid][uid];
    if (o_res.connection.destroyed) {
      // opponent has left
      res.status(410).end();
      return;
    }

    // opponent has accepted 
    var outcome = battle_outcome(uid, opponent_uid);

    o_res.json(outcome);
    res.json(outcome);

    delete battle_queue[opponent_uid][uid];
  } else {
    if(!_.has(battle_queue, uid)) {
      battle_queue[uid] = {};
    }
    battle_queue[uid][opponent_uid] = res;
  }
}

module.exports = {
  battle: battle 
};
