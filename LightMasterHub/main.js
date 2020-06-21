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