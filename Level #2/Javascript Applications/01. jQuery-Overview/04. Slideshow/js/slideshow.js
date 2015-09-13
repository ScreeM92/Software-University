$(document).ready(function () {
    var images = [];
    var carousel = $('#carousel-content');
    var timer;

    for (var i = 1, len = 3; i <= len; i += 1) {
        images.push('./images/carousel-' + i + '.jpg');
    }

    $.each($(images), function(i, el) {
        var img = createImageElement(el);

        $('#carousel-content').append(img);
    });
    $('#carousel-content img:eq(0)').show();

    startTimer();

    $('#left-arrow').click(slideLeft);
    $('#right-arrow').click(slideRight);

    function startTimer() {
        timer = setInterval(slideRight, 5000);
    };

    function stopTimer() {
        clearInterval(timer);
    };
    
    function createImageElement(el) {
        var img = $('<img>');
        img.attr('class', 'carousel-image');
        img.attr('src', el);
        img.css('display', 'none');

        return img;
    }   

    function slideLeft(){
    	var current = $('#carousel-content img:visible');
    	current.fadeOut(500);

    	if (current.is(':first-child')) {
    		setTimeout(function(){ $('#carousel-content img:last-child').fadeIn(1000); }, 500);
    	} else {    	
			setTimeout(function(){ current.prev().fadeIn(1000); }, 500);
    	}

        stopTimer();
        startTimer();
    }

    function slideRight(){
    	var current = $('#carousel-content img:visible');
    	current.fadeOut(500);

    	if (current.is(':last-child')) {
    		current.fadeOut(500);
    		setTimeout(function(){ $('#carousel-content img:first-child').fadeIn(500); }, 500);
    	} else {
    		setTimeout(function(){ current.next().fadeIn(500); }, 500);
    	}

        stopTimer();
        startTimer();
    }
});