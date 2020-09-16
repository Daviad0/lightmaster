var bleno = require('bleno-mac');
const WebSocket = require('ws');
var usb = require('usb');

const wss = new WebSocket.Server({ port: 9959 })
console.log(wss.path);
var BlenoPrimaryService = bleno.PrimaryService;

var red1s = require('./red1');
var red2s = require('./red2');
var red3s = require('./red3');
var blue1s = require('./blue1');
var blue2s = require('./blue2');
var blue3s = require('./blue3');
var queue = require('./queue');

var sendback = "484920544845524521";

var sendingQueue = [];
let listOfCallbacks = new Map();
let toServerAwaiting = new Map();

console.log('Starting up Lighting Robotics Scouting Service');

function BufferQueue(identifier, buffer) {
  this.identifier = identifier;
  this.buffer = buffer;
}

function TabletIdentifier(tabletid, serverid) {
  this.tabletid = tabletid;
  this.serverid = serverid;
}

function WaitingTabletId(identifier, rawheader, rawmessage, messagesleft){
  this.identifier = identifier;
  this.rawheader = rawheader;
  this.rawmessage = rawmessage;
  this.messagesleft = messagesleft;
}


wss.on('connection', function connection(ws) {
  ws.on('message', function incoming(message) {
    sendingQueue.push(new BufferQueue(message.substring(4,14), toByteArray(message.substring(16))));
    //var bufferarraytouse = toByteArrayCallback(message);
  });
  ws.send('Connection Successfully Received! Client will now receive LIVE tablet updates!');
});

bleno.on('stateChange', function(state) {
  console.log('on -> stateChange: ' + state);

  if (state === 'poweredOn') {
    bleno.startAdvertising('LRSS', ['6ad0f836b49011eab3de0242ac130000', '6ad0f836b49011eab3de0242ac130010']);
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
  var hextocheck = this._value.toString('hex');
  var rawstring = hex2a(hextocheck)
  if(rawstring.startsWith("L:"))
  {
    toServerAwaiting.set(rawstring.substring(2,12), new WaitingTabletId(rawstring.substring(2,12), rawstring.substring(0,21), "", parseInt(rawstring.substring(24))))
  }
  else if(rawstring.startsWith("F:")){
    var instanceToChange = toServerAwaiting.get(rawstring.substring(2,12));
    if(parseInt(rawstring.substring(13,15)) == 3)
    {
      var deletionsuccessful = toServerAwaiting.delete(rawstring.substring(2,12));
      if(!deletionsuccessful){
        console.log("Error deleting entry!");
        this._updateValueCallback(toByteArray("S!9^" + rawstring.substring(2,12) + ">>Cancel Failed"))
      }else{
        this._updateValueCallback(toByteArray("S!9^" + rawstring.substring(2,12) + ">>Cancel Completed"))
      }
    }
    else
    {
      instanceToChange.messagesleft = instanceToChange - 1;
      instanceToChange.rawmessage = instanceToChange.rawmessage + rawstring.substring(24)
      if(instanceToChange.messagesleft = 0){
        sendtomaster("R1", (instanceToChange.rawheader + ">>" + instanceToChange.rawmessage))
      }
    }
  }
  else
  {
    sendtomaster("R1",rawstring);
  }
  listOfCallbacks.set(rawstring.substring(2,12), this._updateValueCallback)

  callback(this.RESULT_SUCCESS);
};
red2s.prototype.onWriteRequest = function(data, offset, withoutResponse, callback) {
  this._value = data;
  var hextocheck = this._value.toString('hex');
  var rawstring = hex2a(hextocheck)
  if(rawstring.startsWith("L:"))
  {
    toServerAwaiting.set(rawstring.substring(2,12), new WaitingTabletId(rawstring.substring(2,12), rawstring.substring(0,21), "", parseInt(rawstring.substring(24))))
  }
  else if(rawstring.startsWith("F:")){
    var instanceToChange = toServerAwaiting.get(rawstring.substring(2,12));
    if(parseInt(rawstring.substring(13,15)) == 3)
    {
      var deletionsuccessful = toServerAwaiting.delete(rawstring.substring(2,12));
      if(!deletionsuccessful){
        console.log("Error deleting entry!");
        this._updateValueCallback(toByteArray("S!9^" + rawstring.substring(2,12) + ">>Cancel Failed"))
      }else{
        this._updateValueCallback(toByteArray("S!9^" + rawstring.substring(2,12) + ">>Cancel Completed"))
      }
    }
    else
    {
      instanceToChange.messagesleft = instanceToChange - 1;
      instanceToChange.rawmessage = instanceToChange.rawmessage + rawstring.substring(24)
      if(instanceToChange.messagesleft = 0){
        sendtomaster("R2", (instanceToChange.rawheader + ">>" + instanceToChange.rawmessage))
      }
    }
  }
  else
  {
    sendtomaster("R2",rawstring);
  }

  listOfCallbacks.set(rawstring.substring(2,12), this._updateValueCallback)

  callback(this.RESULT_SUCCESS);
};
red3s.prototype.onWriteRequest = function(data, offset, withoutResponse, callback) {
  this._value = data;
  var hextocheck = this._value.toString('hex');
  var rawstring = hex2a(hextocheck)
  if(rawstring.startsWith("L:"))
  {
    toServerAwaiting.set(rawstring.substring(2,12), new WaitingTabletId(rawstring.substring(2,12), rawstring.substring(0,21), "", parseInt(rawstring.substring(24))))
  }
  else if(rawstring.startsWith("F:")){
    var instanceToChange = toServerAwaiting.get(rawstring.substring(2,12));
    if(parseInt(rawstring.substring(13,15)) == 3)
    {
      var deletionsuccessful = toServerAwaiting.delete(rawstring.substring(2,12));
      if(!deletionsuccessful){
        console.log("Error deleting entry!");
        this._updateValueCallback(toByteArray("S!9^" + rawstring.substring(2,12) + ">>Cancel Failed"))
      }else{
        this._updateValueCallback(toByteArray("S!9^" + rawstring.substring(2,12) + ">>Cancel Completed"))
      }
    }
    else
    {
      instanceToChange.messagesleft = instanceToChange - 1;
      instanceToChange.rawmessage = instanceToChange.rawmessage + rawstring.substring(24)
      if(instanceToChange.messagesleft = 0){
        sendtomaster("R3", (instanceToChange.rawheader + ">>" + instanceToChange.rawmessage))
      }
    }
  }
  else
  {
    sendtomaster("R3",rawstring);
  }

  listOfCallbacks.set(rawstring.substring(2,12), this._updateValueCallback)

  callback(this.RESULT_SUCCESS);
};
blue1s.prototype.onWriteRequest = function(data, offset, withoutResponse, callback) {
  this._value = data;
  var hextocheck = this._value.toString('hex');
  var rawstring = hex2a(hextocheck)
  if(rawstring.startsWith("L:"))
  {
    toServerAwaiting.set(rawstring.substring(2,12), new WaitingTabletId(rawstring.substring(2,12), rawstring.substring(0,21), "", parseInt(rawstring.substring(24))))
  }
  else if(rawstring.startsWith("F:")){
    var instanceToChange = toServerAwaiting.get(rawstring.substring(2,12));
    if(parseInt(rawstring.substring(13,15)) == 3)
    {
      var deletionsuccessful = toServerAwaiting.delete(rawstring.substring(2,12));
      if(!deletionsuccessful){
        console.log("Error deleting entry!");
        this._updateValueCallback(toByteArray("S!9^" + rawstring.substring(2,12) + ">>Cancel Failed"))
      }else{
        this._updateValueCallback(toByteArray("S!9^" + rawstring.substring(2,12) + ">>Cancel Completed"))
      }
    }
    else
    {
      instanceToChange.messagesleft = instanceToChange - 1;
      instanceToChange.rawmessage = instanceToChange.rawmessage + rawstring.substring(24)
      if(instanceToChange.messagesleft = 0){
        sendtomaster("B1", (instanceToChange.rawheader + ">>" + instanceToChange.rawmessage))
      }
    }
  }
  else
  {
    sendtomaster("B1",rawstring);
  }

  listOfCallbacks.set(rawstring.substring(2,12), this._updateValueCallback)

  callback(this.RESULT_SUCCESS);
};
blue2s.prototype.onWriteRequest = function(data, offset, withoutResponse, callback) {
  this._value = data;
  var hextocheck = this._value.toString('hex');
  var rawstring = hex2a(hextocheck)
  if(rawstring.startsWith("L:"))
  {
    toServerAwaiting.set(rawstring.substring(2,12), new WaitingTabletId(rawstring.substring(2,12), rawstring.substring(0,21), "", parseInt(rawstring.substring(24))))
  }
  else if(rawstring.startsWith("F:")){
    var instanceToChange = toServerAwaiting.get(rawstring.substring(2,12));
    if(parseInt(rawstring.substring(13,15)) == 3)
    {
      var deletionsuccessful = toServerAwaiting.delete(rawstring.substring(2,12));
      if(!deletionsuccessful){
        console.log("Error deleting entry!");
        this._updateValueCallback(toByteArray("S!9^" + rawstring.substring(2,12) + ">>Cancel Failed"))
      }else{
        this._updateValueCallback(toByteArray("S!9^" + rawstring.substring(2,12) + ">>Cancel Completed"))
      }
    }
    else
    {
      instanceToChange.messagesleft = instanceToChange - 1;
      instanceToChange.rawmessage = instanceToChange.rawmessage + rawstring.substring(24)
      if(instanceToChange.messagesleft = 0){
        sendtomaster("B2", (instanceToChange.rawheader + ">>" + instanceToChange.rawmessage))
      }
    }
  }
  else
  {
    sendtomaster("B2",rawstring);
  }

  listOfCallbacks.set(rawstring.substring(2,12), this._updateValueCallback)

  callback(this.RESULT_SUCCESS);
};
blue3s.prototype.onWriteRequest = function(data, offset, withoutResponse, callback) {
  this._value = data;
  var hextocheck = this._value.toString('hex');
  var rawstring = hex2a(hextocheck)
  if(rawstring.startsWith("L:"))
  {
    toServerAwaiting.set(rawstring.substring(2,12), new WaitingTabletId(rawstring.substring(2,12), rawstring.substring(0,21), "", parseInt(rawstring.substring(24))))
  }
  else if(rawstring.startsWith("F:")){
    var instanceToChange = toServerAwaiting.get(rawstring.substring(2,12));
    if(parseInt(rawstring.substring(13,15)) == 3)
    {
      var deletionsuccessful = toServerAwaiting.delete(rawstring.substring(2,12));
      if(!deletionsuccessful){
        console.log("Error deleting entry!");
        this._updateValueCallback(toByteArray("S!9^" + rawstring.substring(2,12) + ">>Cancel Failed"))
      }else{
        this._updateValueCallback(toByteArray("S!9^" + rawstring.substring(2,12) + ">>Cancel Completed"))
      }
    }
    else
    {
      instanceToChange.messagesleft = instanceToChange - 1;
      instanceToChange.rawmessage = instanceToChange.rawmessage + rawstring.substring(24)
      if(instanceToChange.messagesleft = 0){
        sendtomaster("B3", (instanceToChange.rawheader + ">>" + instanceToChange.rawmessage))
      }
    }
  }
  else
  {
    sendtomaster("B3",rawstring);
  }

  listOfCallbacks.set(rawstring.substring(2,12), this._updateValueCallback)

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

function toByteArrayCallback(string){
  var bufferarray = [];
  if(string.length > 480){
    for (var i = 0; i < Math.ceil(string.length/480); i++){
      var thisstringtoconvert = string.substring(i*480, ((i+1)*480)-1);
      console.log('Taking string position from ' + i*480 + ' to ' + ((i+1)*480)-1);
      var thisbuffertopush = Buffer.from(thisstringtoconvert, "utf-8");
      bufferarray.push(thisbuffertopush);
    }
  }else{
    var onlybuffer = Buffer.from(string, "utf-8");
    bufferarray.push(onlybuffer);
  }
  return bufferarray;
}

function toByteArray(string){
  var buffer = Buffer.from(string, "utf-8");
  return buffer;
}
setInterval(() => {
  if(sendingQueue.length > 0){
    var updatevaluecallback = listOfCallbacks.get(sendingQueue[0].identifier)
    updatevaluecallback(sendingQueue[0].buffer);
    sendingQueue.splice(0, 1);
    console.log("MACSUCKSQUEUE: " + sendingQueue.length + " left in the queue!")
  }


}, 100);
