(function () {
    $(document).ready(function () {

        $.connection.hub.start(function () {
            $.connection.chat.server.joinRoom(projectId);
            $.connection.chat.server.loadMessages(projectId);            
        });

        var chat = $.connection.chat;
        var projectId = $("#projectId").val() | 0;       

        $('#send-message').click(function () {

            var msg = $('#message').val();
            var userId = $("#userId").val();
            chat.server.sendMessage(msg, projectId, userId);
        });

        chat.client.loadMessages = loadMessages;
        chat.client.addMessage = addMessage;
        
    });

    function loadMessages(messageData) {
        var username = $('#userNameChat').val();
        for (var i = 0; i < messageData.length; i++) {
            var chatSenderClass =
            username == messageData[i].SenderName ?
                "chat-sender-you" : "chat-sender";
            messageData[i].SenderName =
                username == messageData[i].SenderName ?
                    "Me" : messageData[i].SenderName;

            var messageHtml = '<li class="msg">' +
                '<span class="' + chatSenderClass + '">'
                    + messageData[i].SenderName + '</span><br/>' +
                '<span class="chat-msg">' + messageData[i].Message + '</span>' +
                '<span class="chat-post-date">' + messageData[i].PostDate + '</span></li><br />'

            $('#messages').append($(messageHtml));
            $('#message').val("");
        }

        $("#messages").scrollTop($("#messages")[0].scrollHeight);
    }

    function addMessage(messageData) {
        var username = $('#userNameChat').val();
        var chatSenderClass =
            username == messageData.SenderName ?
                "chat-sender-you" : "chat-sender";
        messageData.SenderName =
            username == messageData.SenderName ?
                "Me" : messageData.SenderName;

        var messageHtml = '<li class="msg">' +
            '<span class="' + chatSenderClass + '">'
                + messageData.SenderName + '</span><br/>' +
            '<span class="chat-msg">' + messageData.Message + '</span>' + 
            '<span class="chat-post-date">' + messageData.PostDate + '</span></li><br />'

        $('#messages').append($(messageHtml));
        $('#message').val("");

        $("#messages").scrollTop($("#messages")[0].scrollHeight);
    }

    

})();