var util = require('util');

var bleno = require('bleno-mac');



var BlenoCharacteristic = bleno.Characteristic;

var queue = function() {
    queue.super_.call(this, {
    uuid: '6ad0f836b49011eab3de0242ac130862',
    properties: ['read', 'write', 'notify'],
    value: null
  });

  this._value = new Buffer(0);
  this._updateValueCallback = null;
};

util.inherits(queue, BlenoCharacteristic);

queue.prototype.onReadRequest = function(offset, callback) {
  console.log('Q - onReadRequest: value = ' + this._value.toString('hex'));

  callback(this.RESULT_SUCCESS, this._value);
};



queue.prototype.onSubscribe = function(maxValueSize, updateValueCallback) {
  console.log('Q - onSubscribe');

  this._updateValueCallback = updateValueCallback;
};

queue.prototype.onUnsubscribe = function() {
  console.log('Q - onUnsubscribe');

  this._updateValueCallback = null;
};

module.exports = queue;