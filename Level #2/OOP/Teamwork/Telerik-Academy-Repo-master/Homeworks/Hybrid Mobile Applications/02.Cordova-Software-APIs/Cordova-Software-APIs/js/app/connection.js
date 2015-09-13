var app = app || {};

(function(a) {
    var states = null;
    function initStates() {
        states = {};
        states[Connection.UNKNOWN] = 'Unknown connection';
        states[Connection.ETHERNET] = 'Ethernet connection';
        states[Connection.WIFI] = 'WiFi connection';
        states[Connection.CELL_2G] = 'Cell 2G connection';
        states[Connection.CELL_3G] = 'Cell 3G connection';
        states[Connection.CELL_4G] = 'Cell 4G connection';
        states[Connection.CELL] = 'Cell generic connection';
        states[Connection.NONE] = 'No network connection';
    }
    var connectionAPI = {
        init: function(e) {
            if (!states) {
                initStates();
            }
            var vm = kendo.observable({
                state:"",
                update:function() {
                    var networkState = navigator.connection.type;
                    vm.set("state", states[networkState]);
                }
            });
            connectionAPI.timer = setInterval(vm.update, 1000);            
            kendo.bind(e.view.element, vm, kendo.mobile.ui);       
        },
        close: function() {
            clearInterval(connectionAPI.timer);
        }
    }
    
    a.connectionApi = connectionAPI;
}(app));