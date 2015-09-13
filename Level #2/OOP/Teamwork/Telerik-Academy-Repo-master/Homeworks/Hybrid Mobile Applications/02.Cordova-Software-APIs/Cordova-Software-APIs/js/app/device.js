var app = app || {};

(function(a) {    
    var deviceInfo = kendo.observable({
        init:function(e) {
            var vm = kendo.observable({
                "name" : device.name,
                "cordova": device.cordova,
                "platform": device.platform,
                "uuid" : device.uuid,
                "model" : device.model,
                "version" : device.version,
            });
            kendo.bind(e.view.element, vm, kendo.mobile.ui)
        },
        close: function() {            
        }        
    });
    a.deviceInfo = deviceInfo;
}(app));