$(document).ready(function () {
    var classes = [];

    $('ul').children().each(function (index, el) {
        if ($(el).attr('class')) {
            classes.push($(el).attr('class'));
        }
    });

    $('#available-classes').text($('#available-classes').text() + classes.join(', '));

    $(classes).each(function(index, el) {
        $('#classes-select').append('<option value="' + el + '">' + el + '</option>');
    });

    $('.paint-button:eq(0)').click(function () {
        var className = '.' + $("#classes-select").val();
        var color = $('.color:eq(0)').val();
        $(className).css('background', color);
    });

    $('.paint-button:eq(1)').click(function () {
        var className = $("#class-input").val();
        var color = $('.color:eq(1)').val();
        if (className) {
            $('.' + className).css('background', color);
        }
    });
    
    $('#clear-button').click(function() {
        $('li').css('background', 'none');
    });

});