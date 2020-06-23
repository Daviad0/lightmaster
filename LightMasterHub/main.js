var bleno = require('bleno-mac');
const WebSocket = require('ws');

const wss = new WebSocket.Server({ port: 8080 })
console.log(wss.path);
var BlenoPrimaryService = bleno.PrimaryService;

var EchoCharacteristic = require('./characteristic');

var red1s = new EchoCharacteristic()
red1s.uuid = '6ad0f836b49011eab3de0242ac130001';
var red2s = new EchoCharacteristic()
red2s.uuid = '6ad0f836b49011eab3de0242ac130002';
var red3s = new EchoCharacteristic()
red3s.uuid = '6ad0f836b49011eab3de0242ac130003';
var blue1s = new EchoCharacteristic()
blue1s.uuid = '6ad0f836b49011eab3de0242ac130004';
var blue2s = new EchoCharacteristic()
blue2s.uuid = '6ad0f836b49011eab3de0242ac130005';
var blue3s = new EchoCharacteristic()
blue3s.uuid = '6ad0f836b49011eab3de0242ac130006';

var red1c = new EchoCharacteristic()
red1c.uuid = '6ad0f836b49011eab3de0242ac130011';
var red2c = new EchoCharacteristic()
red2c.uuid = '6ad0f836b49011eab3de0242ac130012';
var red3c = new EchoCharacteristic()
red3c.uuid = '6ad0f836b49011eab3de0242ac130013';
var blue1c = new EchoCharacteristic()
blue1c.uuid = '6ad0f836b49011eab3de0242ac130014';
var blue2c = new EchoCharacteristic()
blue2c.uuid = '6ad0f836b49011eab3de0242ac130015';
var blue3c = new EchoCharacteristic()
blue3c.uuid = '6ad0f836b49011eab3de0242ac130016';


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
          red1s, red2s, red3s, blue1s, blue2s, blue3s
        ]
      }),
      new BlenoPrimaryService({
        uuid: '6ad0f836b49011eab3de0242ac130010',
        characteristics: [
          red1c, red2c, red3c, blue1c, blue2c, blue3c
        ]
      })
    ]);
  }
});
red1s.prototype.onWriteRequest = function(data, offset, withoutResponse, callback) {
  this._value = data;
  
  var hextocheck = this._value.toString('hex');

  console.log('EchoCharacteristic - onWriteRequest: value = ' + this._value.toString('hex'));

  wss.clients.forEach(function each(client) {
    if (client.readyState === WebSocket.OPEN) {
      client.send(hex2a(hextocheck));
    }
  });

  if (this._updateValueCallback) {
    console.log('EchoCharacteristic - onWriteRequest: notifying');

    this._updateValueCallback(this._value);
  }

  callback(this.RESULT_SUCCESS);
};
red2s.prototype.onWriteRequest = function(data, offset, withoutResponse, callback) {
  this._value = data;
  
  var hextocheck = this._value.toString('hex');

  console.log('EchoCharacteristic - onWriteRequest: value = ' + this._value.toString('hex'));

  wss.clients.forEach(function each(client) {
    if (client.readyState === WebSocket.OPEN) {
      client.send(hex2a(hextocheck));
    }
  });

  if (this._updateValueCallback) {
    console.log('EchoCharacteristic - onWriteRequest: notifying');

    this._updateValueCallback(this._value);
  }

  callback(this.RESULT_SUCCESS);
};
red3s.prototype.onWriteRequest = function(data, offset, withoutResponse, callback) {
  this._value = data;
  
  var hextocheck = this._value.toString('hex');

  console.log('EchoCharacteristic - onWriteRequest: value = ' + this._value.toString('hex'));

  wss.clients.forEach(function each(client) {
    if (client.readyState === WebSocket.OPEN) {
      client.send(hex2a(hextocheck));
    }
  });

  if (this._updateValueCallback) {
    console.log('EchoCharacteristic - onWriteRequest: notifying');

    this._updateValueCallback(this._value);
  }

  callback(this.RESULT_SUCCESS);
};
blue1s.prototype.onWriteRequest = function(data, offset, withoutResponse, callback) {
  this._value = data;
  
  var hextocheck = this._value.toString('hex');

  console.log('EchoCharacteristic - onWriteRequest: value = ' + this._value.toString('hex'));

  wss.clients.forEach(function each(client) {
    if (client.readyState === WebSocket.OPEN) {
      client.send(hex2a(hextocheck));
    }
  });

  if (this._updateValueCallback) {
    console.log('EchoCharacteristic - onWriteRequest: notifying');

    this._updateValueCallback(this._value);
  }

  callback(this.RESULT_SUCCESS);
};
blue2s.prototype.onWriteRequest = function(data, offset, withoutResponse, callback) {
  this._value = data;
  
  var hextocheck = this._value.toString('hex');

  console.log('EchoCharacteristic - onWriteRequest: value = ' + this._value.toString('hex'));

  wss.clients.forEach(function each(client) {
    if (client.readyState === WebSocket.OPEN) {
      client.send(hex2a(hextocheck));
    }
  });

  if (this._updateValueCallback) {
    console.log('EchoCharacteristic - onWriteRequest: notifying');

    this._updateValueCallback(this._value);
  }

  callback(this.RESULT_SUCCESS);
};
blue3s.prototype.onWriteRequest = function(data, offset, withoutResponse, callback) {
  this._value = data;
  
  var hextocheck = this._value.toString('hex');

  console.log('EchoCharacteristic - onWriteRequest: value = ' + this._value.toString('hex'));

  wss.clients.forEach(function each(client) {
    if (client.readyState === WebSocket.OPEN) {
      client.send(hex2a(hextocheck));
    }
  });

  if (this._updateValueCallback) {
    console.log('EchoCharacteristic - onWriteRequest: notifying');

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
