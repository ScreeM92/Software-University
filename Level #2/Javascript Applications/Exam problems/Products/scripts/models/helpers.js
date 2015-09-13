var app = app || {};

app.helpers = (function(){
    function formatDate(isoString){
        var timestamp = new Date(Date.parse(isoString)),
            months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
            hours = timestamp.getHours() > 9 ? timestamp.getHours() : '0' + timestamp.getHours(),
            minutes = timestamp.getMinutes() > 9 ? timestamp.getMinutes() : '0' + timestamp.getMinutes();

        return timestamp.getDate() + '-' + months[timestamp.getMonth()] + '-' + timestamp.getFullYear()
            + ' ' + hours  + ':' + minutes;
    }

    return {
        formatDate: formatDate
    }
}());