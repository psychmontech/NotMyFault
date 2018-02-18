let connection = new signalR.HubConnection('/negoHub'),
    input = document.getElementById('text'),
    sendBtn = document.getElementById('sendBtn'),
    display = document.getElementById('display'),
    newLine = '&#13;&#10;';

connection.on('Send', data =>
{
    var DisplayMessagesDiv = display;
    DisplayMessagesDiv.innerHTML += data + newLine;
    display.scrollTop = display.scrollHeight;
});

connection.start().then(() => connection.invoke('JoinGroup', groupName_negoConver, userNickName));
window.onbeforeunload = function LeaveGroup()
{
    connection.invoke('LeaveGroup', groupName_negoConver, userNickName);
}

function GroupMessage()
{
    var msg = input.value;
    if (msg)
    {
        connection.invoke('SendToGroup', groupName_negoConver, msg, projId, userId, userNickName);
    }
    input.value = null;
}

input.onkeypress = function (e)
{
    if (e.keyCode == 13)
        sendBtn.click();
};