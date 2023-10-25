// wwwroot/chat.js
const socket = new WebSocket('ws://localhost:5265/chat');

socket.onmessage = function (event) {
    let messages = document.getElementById('messages');
    let li = document.createElement('li');
    li.appendChild(document.createTextNode(event.data));
    messages.appendChild(li);
};

document.querySelector('button').onclick = function () {
    let input = document.getElementById('message');

    var invocationDescriptor = {
        methodName: "ABC",
        arguments: [input.value]
    };
    socket.send(JSON.stringify(invocationDescriptor));
    input.value = '';
};
