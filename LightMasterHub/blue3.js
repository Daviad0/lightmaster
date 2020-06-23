var util = require('util');

var bleno = require('bleno-mac');



var BlenoCharacteristic = bleno.Characteristic;

var blue3s = function() {
    blue3s.super_.call(this, {
    uuid: '6ad0f836b49011eab3de0242ac130006',
    properties: ['read', 'write', 'notify'],
    value: null
  });

  this._value = new Buffer(0);
  this._updateValueCallback = null;
};

util.inherits(blue3s, BlenoCharacteristic);

blue3s.prototype.onReadRequest = function(offset, callback) {
  console.log('Blue3 - onReadRequest: value = ' + this._value.toString('hex'));

  callback(this.RESULT_SUCCESS, this._value);
};



blue3s.prototype.onSubscribe = function(maxValueSize, updateValueCallback) {
  console.log('Blue3 - onSubscribe');

  this._updateValueCallback = updateValueCallback;
};

blue3s.prototype.onUnsubscribe = function() {
  console.log('Blue3 - onUnsubscribe');

  this._updateValueCallback = null;
};

module.exports = blue3s;