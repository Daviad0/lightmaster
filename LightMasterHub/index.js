var bleno = require('bleno');
var name = 'ThisDoesntWork';

var Characteristic = bleno.Characteristic;

var characteristic = new Characteristic({
    uuid: '980826f2486e48888c3524fc131a6190', // or 'fff1' for 16-bit
    properties: [ 'read', 'write' ], // can be a combination of 'read', 'write', 'writeWithoutResponse', 'notify', 'indicate'
    secure: [ 'read', 'write' ], // enable security for properties, can be a combination of 'read', 'write', 'writeWithoutResponse', 'notify', 'indicate'
    value: null, // optional static value, must be of type Buffer - for read only characteristics
    descriptors: [
        // see Descriptor for data type
    ],
    onReadRequest: null, // optional read request handler, function(offset, callback) { ... }
    onWriteRequest: null, // optional write request handler, function(data, offset, withoutResponse, callback) { ...}
    onSubscribe: null, // optional notify/indicate subscribe handler, function(maxValueSize, updateValueCallback) { ...}
    onUnsubscribe: null, // optional notify/indicate unsubscribe handler, function() { ...}
    onNotify: null, // optional notify sent handler, function() { ...}
    onIndicate: null // optional indicate confirmation received handler, function() { ...}
});

var PrimaryService = bleno.PrimaryService;

var primaryService = new PrimaryService({
    uuid: '980826f2486e48888c3524fc131a618f', // or 'fff0' for 16-bit
    characteristics: [
        characteristic
    ]
});
 
bleno.on('stateChange', function(state) {
    if (state === 'poweredOn') {
        //
        // We will also advertise the service ID in the advertising packet,
        // so it's easier to find.
        //
        bleno.startAdvertising(name, [primaryService.uuid], function(err) {
            if (err) {
                console.log(err);
            }
        });
        console.log('we got here yay');
    }
    else {
        bleno.stopAdvertising();
    }
});

bleno.on('advertisingStart', function(err) {
    if (!err) {
        console.log('advertising...');
        //
        // Once we are advertising, it's time to set up our services,
        // along with our characteristics.
        //
        bleno.setServices([
            primaryService
        ]);
    }
});