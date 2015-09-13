$(document).ready(function () {
    $('#generator').click(function () {
        $("#cars").remove();
        
        if ($('#input').val() && $.parseJSON($('#input').val())) {
            var input = $.parseJSON($('#input').val());
            input = Array.isArray(input) ? input : [input];
            var table = createTable(input);

            if (table) {
                table.hide().appendTo($('#wrapper')).fadeIn(1500);
            }
        }

        ev.stopPropagation();
    });

    function createTable(input) {
        if (input.length) {
            var table = $('<table id="cars">');
            var thead = $('<thead>');
            var tbody = $('<tbody>');
            var tr = $('<tr>');

            $.each(input[0], function (key) {
                key = key.charAt(0).toUpperCase() + key.slice(1);
                var data = $('<th>');
                data.text(key);
                tr.append(data);
            });

            $.each(input, function (i) {
                var row = $('<tr>');
                $.each(input[i], function (key, val) {
                    var data = $('<td>');
                    data.text(val);
                    row.append(data);
                });
                tbody.append(row);
            });

            thead.append(tr);
            table.append(thead);
            table.append(tbody);

            return table;
        }

        return null;
    }
});