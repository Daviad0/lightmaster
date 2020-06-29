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

var sendback = "484920544845524521";

var r1messagesleft = 0;
var r2messagesleft = 0;
var r3messagesleft = 0;
var b1messagesleft = 0;
var b2messagesleft = 0;
var b3messagesleft = 0;

var r1combinedstring = "";
var r2combinedstring = "";
var r3combinedstring = "";
var b1combinedstring = "";
var b2combinedstring = "";
var b3combinedstring = "";

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

bleno.onDisconnect(function(clientAddress){
  console.log("Disconnect: " + clientAddress)
});

bleno.onAccept(function(clientAddress){
  console.log("Accept: " + clientAddress)
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
  console.log(this._value);
  var hextocheck = this._value.toString('hex');

  
  if(hex2a(hextocheck).startsWith("MM:"))
  {
    console.log('R1 START IDENTIFIER!')
    r1messagesleft = parseInt(hex2a(hextocheck).substring(3));
    r1combinedstring = "";
  }
  else
  {
    console.log('R1 - onWriteRequest: value = ' + this._value.toString('hex'));
    if(r1messagesleft > 0){
      r1messagesleft--;
      r1combinedstring = r1combinedstring + hex2a(hextocheck);
      if(r1messagesleft == 0){
        sendtomaster("R1",r1combinedstring);
      }
    }else{
      sendtomaster("R1",hex2a(hextocheck));
    }
  }
  

  this._updateValueCallback(toByteArray("Hi There"));

  callback(this.RESULT_SUCCESS);
};
red2s.prototype.onWriteRequest = function(data, offset, withoutResponse, callback) {
  this._value = data;
  console.log(this._value);
  var hextocheck = this._value.toString('hex');

  if(hex2a(hextocheck).startsWith("MM:"))
  {
    console.log('R2 START IDENTIFIER!')
    r2messagesleft = parseInt(hex2a(hextocheck).substring(3));
    r2combinedstring = "";
  }
  else
  {
    console.log('R2 - onWriteRequest: value = ' + this._value.toString('hex'));
    if(r2messagesleft > 0){
      r2messagesleft--;
      r2combinedstring = r2combinedstring + hex2a(hextocheck);
      if(r2messagesleft == 0){
        sendtomaster("R2",r2combinedstring);
      }
    }else{
      sendtomaster("R2",hex2a(hextocheck));
    }
  }

  this._updateValueCallback(toByteArray("Hi There"));

  callback(this.RESULT_SUCCESS);
};
red3s.prototype.onWriteRequest = function(data, offset, withoutResponse, callback) {
  this._value = data;
  console.log(this._value);
  var hextocheck = this._value.toString('hex');

  if(hex2a(hextocheck).startsWith("MM:"))
  {
    console.log('R3 START IDENTIFIER!')
    r3messagesleft = parseInt(hex2a(hextocheck).substring(3));
    r3combinedstring = "";
  }
  else
  {
    console.log('R3 - onWriteRequest: value = ' + this._value.toString('hex'));
    if(r3messagesleft > 0){
      r3messagesleft--;
      r3combinedstring = r3combinedstring + hex2a(hextocheck);
      if(r3messagesleft == 0){
        sendtomaster("R3",r3combinedstring);
      }
    }else{
      sendtomaster("R3",hex2a(hextocheck));
    }
  }

  this._updateValueCallback(toByteArray("Hi There"));

  callback(this.RESULT_SUCCESS);
};
blue1s.prototype.onWriteRequest = function(data, offset, withoutResponse, callback) {
  this._value = data;
  console.log(this._value);
  var hextocheck = this._value.toString('hex');

  if(hex2a(hextocheck).startsWith("MM:"))
  {
    console.log('B1 START IDENTIFIER!')
    b1messagesleft = parseInt(hex2a(hextocheck).substring(3));
    b1combinedstring = "";
  }
  else
  {
    console.log('B1 - onWriteRequest: value = ' + this._value.toString('hex'));
    if(b1messagesleft > 0){
      b1messagesleft--;
      b1combinedstring = b1combinedstring + hex2a(hextocheck);
      if(b1messagesleft == 0){
        sendtomaster("B1",b1combinedstring);
      }
    }else{
      sendtomaster("B1",hex2a(hextocheck));
    }
  }

  this._updateValueCallback(toByteArray("Hi There"));

  callback(this.RESULT_SUCCESS);
};
blue2s.prototype.onWriteRequest = function(data, offset, withoutResponse, callback) {
  this._value = data;
  console.log(this._value);
  var hextocheck = this._value.toString('hex');

  if(hex2a(hextocheck).startsWith("MM:"))
  {
    console.log('B2 START IDENTIFIER!')
    b2messagesleft = parseInt(hex2a(hextocheck).substring(3));
    b2combinedstring = "";
  }
  else
  {
    console.log('B2 - onWriteRequest: value = ' + this._value.toString('hex'));
    if(b2messagesleft > 0){
      b2messagesleft--;
      b2combinedstring = b2combinedstring + hex2a(hextocheck);
      if(b2messagesleft == 0){
        sendtomaster("B2",b2combinedstring);
      }
    }else{
      sendtomaster("B2",hex2a(hextocheck));
    }
  }

  this._updateValueCallback(toByteArray("Hi There"));

  callback(this.RESULT_SUCCESS);
};
blue3s.prototype.onWriteRequest = function(data, offset, withoutResponse, callback) {
  this._value = data;
  console.log(this._value);
  var hextocheck = this._value.toString('hex');

  if(hex2a(hextocheck).startsWith("MM:"))
  {
    console.log('B3 START IDENTIFIER!')
    b3messagesleft = parseInt(hex2a(hextocheck).substring(3));
    b3combinedstring = "";
  }
  else
  {
    console.log('B3 - onWriteRequest: value = ' + this._value.toString('hex'));
    if(b3messagesleft > 0){
      b3messagesleft--;
      b3combinedstring = b3combinedstring + hex2a(hextocheck);
      if(b3messagesleft == 0){
        sendtomaster("B3",b3combinedstring);
      }
    }else{
      sendtomaster("B3",hex2a(hextocheck));
    }
  }

  this._updateValueCallback(toByteArray("Hi There"));

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
      client.send(colornum + ":" + data);
    }
  });
}

function toByteArray(string){
  var buffer = Buffer.from(string, "utf-8");
  return buffer;
}