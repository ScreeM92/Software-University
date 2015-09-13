$('.vote-stars').on('mouseenter', 'li', function () {

    var currentStarId = $(this).attr('id')
    var currentStar = parseInt(currentStarId
        .substring(currentStarId.lastIndexOf('-') + 1));

    var allStars = $(this).parent().children();
    for (var child = 0; child < currentStar; child++) {
        $(allStars[child]).attr('class', 'full-star-img');
    };

});

$('.vote-stars').on('mouseout', 'li', function () {
    
    var allStars = $(this).parent().children();
    for (var child = 0; child < allStars.length; child++) {
        $(allStars[child]).attr('class', 'empty-star-img');
    };

});

$('.vote-stars').on('click', 'li', function () {

    var currentStarId = $(this).attr('id')
    var currentStar = currentStarId.substring(currentStarId.lastIndexOf('-') + 1);
    $('#vote-value').val(currentStar);
    $('#vote-form').submit();

});