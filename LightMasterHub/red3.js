var util = require('util');

var bleno = require('bleno-mac');



var BlenoCharacteristic = bleno.Characteristic;

var red3s = function() {
    red3s.super_.call(this, {
    uuid: '6ad0f836b49011eab3de0242ac130003',
    properties: ['read', 'write', 'notify'],
    value: null
  });

  this._value = new Buffer(0);
  this._updateValueCallback = null;
};

util.inherits(red3s, BlenoCharacteristic);

red3s.prototype.onReadRequest = function(offset, callback) {
  console.log('Red3 - onReadRequest: value = ' + this._value.toString('hex'));

  callback(this.RESULT_SUCCESS, this._value);
};



red3s.prototype.onSubscribe = function(maxValueSize, updateValueCallback) {
  console.log('Red3 - onSubscribe');

  this._updateValueCallback = updateValueCallback;
};

red3s.prototype.onUnsubscribe = function() {
  console.log('Red3 - onUnsubscribe');

  this._updateValueCallback = null;
};

module.exports = red3s;