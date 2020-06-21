var bleno = require('bleno-mac');
const WebSocket = require('ws');

const wss = new WebSocket.Server({ port: 8080 })
console.log(wss.path);
var BlenoPrimaryService = bleno.PrimaryService;

var EchoCharacteristic = require('./characteristic');

console.log('bleno - echo');


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
    bleno.startAdvertising('echo', ['50dae772d8aa43789602792b3e4c198d']);
  } else {
    bleno.stopAdvertising();
  }
});

bleno.on('advertisingStart', function(error) {
  console.log('on -> advertisingStart: ' + (error ? 'error ' + error : 'success'));

  if (!error) {
    bleno.setServices([
      new BlenoPrimaryService({
        uuid: '50dae772d8aa43789602792b3e4c198d',
        characteristics: [
          new EchoCharacteristic()
        ]
      })
    ]);
  }
});
EchoCharacteristic.prototype.onWriteRequest = function(data, offset, withoutResponse, callback) {
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
