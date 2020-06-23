var util = require('util');

var bleno = require('bleno-mac');



var BlenoCharacteristic = bleno.Characteristic;

var blue1s = function() {
    blue1s.super_.call(this, {
    uuid: '6ad0f836b49011eab3de0242ac130004',
    properties: ['read', 'write', 'notify'],
    value: null
  });

  this._value = new Buffer(0);
  this._updateValueCallback = null;
};

util.inherits(blue1s, BlenoCharacteristic);

blue1s.prototype.onReadRequest = function(offset, callback) {
  console.log('Blue1 - onReadRequest: value = ' + this._value.toString('hex'));

  callback(this.RESULT_SUCCESS, this._value);
};



blue1s.prototype.onSubscribe = function(maxValueSize, updateValueCallback) {
  console.log('Blue1 - onSubscribe');

  this._updateValueCallback = updateValueCallback;
};

blue1s.prototype.onUnsubscribe = function() {
  console.log('Blue1 - onUnsubscribe');

  this._updateValueCallback = null;
};

module.exports = blue1s;