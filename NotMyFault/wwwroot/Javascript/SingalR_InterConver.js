let connection = new signalR.HubConnection('/devsHub'),
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

connection.start().then(() => connection.invoke('JoinGroup', groupName_interConver, userNickName));
window.onbeforeunload = function LeaveGroup()
{
    connection.invoke('LeaveGroup', groupName_interConver, userNickName);
}

function GroupMessage()
{
    var msg = input.value;
    connection.invoke('SendToGroup', groupName_interConver, msg, projId, userId, userNickName);
    input.value = null;
}

input.onkeypress = function (e)
{
    if (e.keyCode == 13)
        sendBtn.click();
};
