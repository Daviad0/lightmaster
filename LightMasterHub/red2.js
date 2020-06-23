var util = require('util');

var bleno = require('bleno-mac');



var BlenoCharacteristic = bleno.Characteristic;

var red2s = function() {
    red2s.super_.call(this, {
    uuid: '6ad0f836b49011eab3de0242ac130002',
    properties: ['read', 'write', 'notify'],
    value: null
  });

  this._value = new Buffer(0);
  this._updateValueCallback = null;
};

util.inherits(red2s, BlenoCharacteristic);

red2s.prototype.onReadRequest = function(offset, callback) {
  console.log('Red2 - onReadRequest: value = ' + this._value.toString('hex'));

  callback(this.RESULT_SUCCESS, this._value);
};



red2s.prototype.onSubscribe = function(maxValueSize, updateValueCallback) {
  console.log('Red2 - onSubscribe');

  this._updateValueCallback = updateValueCallback;
};

red2s.prototype.onUnsubscribe = function() {
  console.log('Red2 - onUnsubscribe');

  this._updateValueCallback = null;
};

module.exports = red2s;