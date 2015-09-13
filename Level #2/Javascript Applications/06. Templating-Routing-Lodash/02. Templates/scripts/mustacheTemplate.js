var data = {
    tableData:
    [
        {
            name: 'Garry Finch',
            jobTitle: 'Front End Technical Lead',
            website: 'http://website.com'
        },
        {
            name: 'Garry Finch',
            jobTitle: 'Front End Technical Lead',
            website: 'http://website.com'
        },
        {
            name: 'Garry Finch',
            jobTitle: 'Front End Technical Lead',
            website: 'http://website.com'
        }
    ]
};

var app = app || {};

app.tableView = (function () {
    function TableView(selector, data) {
        $(selector).empty();

        $.get('templates/table.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).append(output);
        });
    }

    return {
        load: function (selector, data) {
            return new TableView(selector, data);
        }
    }
    
}());

app.tableView.load($('#table'), data);