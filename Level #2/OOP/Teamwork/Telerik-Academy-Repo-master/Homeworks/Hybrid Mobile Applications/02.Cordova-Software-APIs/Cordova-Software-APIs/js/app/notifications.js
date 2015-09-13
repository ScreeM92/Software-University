var app = app || {};

(function(a) {    
    a.notifications = {
        init:function() {
        },
        close: function() {            
        },
        alert: function() {
            navigator.notification.alert("Alert!");
        },
        confirm: function() {
            navigator.notification.confirm("Are you sure?!");
        },
        prompt:function() {
            navigator.notification.prompt("How old are you", function(result) {               
                navigator.notification.alert(result); 
            });
        },
        beep: function() {
            navigator.notification.beep(3);
        },
        vibrate: function() {
            navigator.notification.vibrate(2000);
        }
    };
}(app));