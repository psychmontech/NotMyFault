(function () {
    var myHub = $.connection.devsHub;

    $('#send').on('click', function () {
        myHub.server.broadcast(document.getElementById('text').value);
        document.getElementById('text').value = null;
    });

    $.connection.hub.start()
        .done(function () {
            myHub.server.broadcast('joined in');
        })
        .fail(function () { display('error connection to signalR'); });

    myHub.client.broadcast = function (message) {
        display(message);
    };

    var display = function (s) {
        $('#display').append(s + '&#13;&#10;');
    }

})()

