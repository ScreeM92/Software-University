(function() {
    document.addEventListener("deviceready", function() {
        var app = new kendo.mobile.Application(document.body);
        $("#devices-list").kendoMobileListView();    
        $(".listview").kendoMobileListView();
    }, false);
}());