var bleno = require('bleno-mac');
const WebSocket = require('ws');

const wss = new WebSocket.Server({ port: 8080 })
console.log(wss.path);
var BlenoPrimaryService = bleno.PrimaryService;

var red1s = require('./red1');
var red2s = require('./red2');
var red3s = require('./red3');
var blue1s = require('./blue1');
var blue2s = require('./blue2');
var blue3s = require('./blue3');



console.log('Starting up Lighting Robotics Scouting Service');


wss.on('connection', function connection(ws) {
  ws.on('message', function incoming(message) {
    console.log('received: %s', message);
  });
  console.log('Received connection');
  ws.send('Connection Successfully Received! Client will now receive LIVE tablet updates!');
});

bleno.on('stateChange', function(state) {
  console.log('on -> stateChange: ' + state);

  if (state === 'poweredOn') {
    bleno.startAdvertising('Lightning Robotics Scouting Service', ['6ad0f836b49011eab3de0242ac130000', '6ad0f836b49011eab3de0242ac130010']);
  } else {
    bleno.stopAdvertising();
  }
});

bleno.on('accept', function(clientAddress){
  console.log("Client Accept: " + clientAddress);
});

bleno.on('advertisingStart', function(error) {
  console.log('on -> advertisingStart: ' + (error ? 'error ' + error : 'success'));

  if (!error) {
    bleno.setServices([
      new BlenoPrimaryService({
        uuid: '6ad0f836b49011eab3de0242ac130000',
        characteristics: [
          new red1s(),
          new red2s(),
          new red3s(),
          new blue1s(),
          new blue2s(),
          new blue3s()
        ]
      })
    ]);
  }
});
red1s.prototype.onWriteRequest = function(data, offset, withoutResponse, callback) {
  this._value = data;
  
  var hextocheck = this._value.toString('hex');

  console.log('R1 - onWriteRequest: value = ' + this._value.toString('hex'));

  sendtomaster("R1",hex2a(hextocheck));

  if (this._updateValueCallback) {
    console.log('R1 - onWriteRequest: notifying');

    this._updateValueCallback(this._value);
  }

  callback(this.RESULT_SUCCESS);
};
red2s.prototype.onWriteRequest = function(data, offset, withoutResponse, callback) {
  this._value = data;
  
  var hextocheck = this._value.toString('hex');

  console.log('R2 - onWriteRequest: value = ' + this._value.toString('hex'));

  sendtomaster("R2",hex2a(hextocheck));

  if (this._updateValueCallback) {
    console.log('R2 - onWriteRequest: notifying');

    this._updateValueCallback(this._value);
  }

  callback(this.RESULT_SUCCESS);
};
red3s.prototype.onWriteRequest = function(data, offset, withoutResponse, callback) {
  this._value = data;
  
  var hextocheck = this._value.toString('hex');

  console.log('R3 - onWriteRequest: value = ' + this._value.toString('hex'));

  sendtomaster("R3",hex2a(hextocheck));

  if (this._updateValueCallback) {
    console.log('R3 - onWriteRequest: notifying');

    this._updateValueCallback(this._value);
  }

  callback(this.RESULT_SUCCESS);
};
blue1s.prototype.onWriteRequest = function(data, offset, withoutResponse, callback) {
  this._value = data;
  
  var hextocheck = this._value.toString('hex');

  console.log('B1 - onWriteRequest: value = ' + this._value.toString('hex'));

  sendtomaster("B1",hex2a(hextocheck));

  if (this._updateValueCallback) {
    console.log('B1 - onWriteRequest: notifying');

    this._updateValueCallback(this._value);
  }

  callback(this.RESULT_SUCCESS);
};
blue2s.prototype.onWriteRequest = function(data, offset, withoutResponse, callback) {
  this._value = data;
  
  var hextocheck = this._value.toString('hex');

  console.log('B2 - onWriteRequest: value = ' + this._value.toString('hex'));

  sendtomaster("B2",hex2a(hextocheck));

  if (this._updateValueCallback) {
    console.log('B2 - onWriteRequest: notifying');

    this._updateValueCallback(this._value);
  }

  callback(this.RESULT_SUCCESS);
};
blue3s.prototype.onWriteRequest = function(data, offset, withoutResponse, callback) {
  this._value = data;
  
  var hextocheck = this._value.toString('hex');

  console.log('B3 - onWriteRequest: value = ' + this._value.toString('hex'));

  sendtomaster("B3",hex2a(hextocheck));

  if (this._updateValueCallback) {
    console.log('B3 - onWriteRequest: notifying');

    this._updateValueCallback(this._value);
  }

  callback(this.RESULT_SUCCESS);
};

function hex2a(hexx) {
  var hex = hexx.toString();//force conversion
  var str = '';
  for (var i = 0; (i < hex.length && hex.substr(i, 2) !== '00'); i += 2)
      str += String.fromCharCode(parseInt(hex.substr(i, 2), 16));
  return str;
}

function sendtomaster(colornum, data){
  wss.clients.forEach(function each(client) {
    if (client.readyState === WebSocket.OPEN) {
      client.send(colornum + " >>> " + data);
    }
  });
}