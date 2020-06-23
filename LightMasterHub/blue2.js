var util = require('util');

var bleno = require('bleno-mac');



var BlenoCharacteristic = bleno.Characteristic;

var blue2s = function() {
    blue2s.super_.call(this, {
    uuid: '6ad0f836b49011eab3de0242ac130005',
    properties: ['read', 'write', 'notify'],
    value: null
  });

  this._value = new Buffer(0);
  this._updateValueCallback = null;
};

util.inherits(blue2s, BlenoCharacteristic);

blue2s.prototype.onReadRequest = function(offset, callback) {
  console.log('Blue2 - onReadRequest: value = ' + this._value.toString('hex'));

  callback(this.RESULT_SUCCESS, this._value);
};



blue2s.prototype.onSubscribe = function(maxValueSize, updateValueCallback) {
  console.log('Blue2 - onSubscribe');

  this._updateValueCallback = updateValueCallback;
};

blue2s.prototype.onUnsubscribe = function() {
  console.log('Blue2 - onUnsubscribe');

  this._updateValueCallback = null;
};

module.exports = blue2s;