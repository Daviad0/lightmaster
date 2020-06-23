var util = require('util');

var bleno = require('bleno-mac');



var BlenoCharacteristic = bleno.Characteristic;

var red1s = function() {
    red1s.super_.call(this, {
    uuid: '6ad0f836b49011eab3de0242ac130001',
    properties: ['read', 'write', 'notify'],
    value: null
  });

  this._value = new Buffer(0);
  this._updateValueCallback = null;
};

util.inherits(red1s, BlenoCharacteristic);

red1s.prototype.onReadRequest = function(offset, callback) {
  console.log('Red1 - onReadRequest: value = ' + this._value.toString('hex'));

  callback(this.RESULT_SUCCESS, this._value);
};



red1s.prototype.onSubscribe = function(maxValueSize, updateValueCallback) {
  console.log('Red1 - onSubscribe');

  this._updateValueCallback = updateValueCallback;
};

red1s.prototype.onUnsubscribe = function() {
  console.log('Red1 - onUnsubscribe');

  this._updateValueCallback = null;
};

module.exports = red1s;