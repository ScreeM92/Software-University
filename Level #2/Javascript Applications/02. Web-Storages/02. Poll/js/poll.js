$(document).ready(function () {
    var poll = ['question-1', 'question-2', 'question-3'];
    var answers = {
        'question-1': 'Sofia',
        'question-2': 'Random access memory',
        'question-3': 'Kaka Ginka'
    }
    var DURATION = 300;
    var INTERVAL = 1000;
    var timer;

    (function init() {
        createTimer();
        checkAnswers();
    }());

    function checkAnswers() {
        $.each($(poll), function (key, val) {
            if (localStorage[val]) {
                
                $.each($('#' + val + ' > input'), function (prop, el) {
                    if (localStorage.getItem(val) === $(el).val()) {
                        el.setAttribute('checked', true);
                    }
                });
            }
        });
    }

    function createTimer() {
        if (!localStorage.timer) {
            localStorage.timer = DURATION;
        }

        var container = $('#timer').html(timeFormat(localStorage.timer));

        timer = setInterval(function () {
            if (localStorage.timer > 0) {
                localStorage.timer--;
                container.html(timeFormat(localStorage.timer));
            } else {
                clearInterval(timer);
                $('#submit').trigger('click');
            }
            
        }, INTERVAL);
    }

    function timeFormat(duration) {
        var minutes = parseInt(duration / 60);
        minutes = minutes < 10 ? '0' + minutes : minutes;
        duration = parseInt(duration % 60);
        var seconds = duration < 10  ? '0' + duration : duration;
        var time = minutes + ' : ' + seconds;

        return time;
    }

    $('#clear').click(function () {
        $.each($('.answer'), function(index, input) {
            $(input).prop('checked', false);
        });

        $.each($(poll), function (i, p) {
            localStorage.removeItem(p);
        });

        $('input[checked]').attr('checked', false);
        $('label').filter('.checked').removeClass('checked');
        $('.correct').removeClass('correct');
        $('#result').text('');
        clearInterval(timer);
        localStorage.timer = DURATION;
        createTimer();
    });

    $('#submit').click(function () {
        if (localStorage.timer > 0) {
            clearInterval(timer);
            localStorage.timer = 0;
            createTimer();

            $('input[checked]').next().addClass('checked');

            var correctAnswers = 0;

            $.each($(poll), function (key, val) {
                $.each($('#' + val + ' > input'), function (prop, el) {
                    if (answers[val] === $(el).val()) {
                        $(el).next().addClass('correct');
                    }
                });
            });

            $.each(answers, function (key, val) {
                if (localStorage[key] && answers[key] === localStorage[key]) {
                    correctAnswers++;
                }
            });

            $('#result').text('Result: ' + (correctAnswers / poll.length * 100).toFixed(2) + '%');
        }
    });

    $('.answer').click(function () {
        $(this).parent().children().filter('input[checked]').attr('checked', false);
        $(this).attr('checked', true);
        
        localStorage[$(this).attr('name')] = $(this).val();
    });
});