function drawRatingInStars() {

    var allInfos = $('.user-info');
    console.log(allInfos.length);
    for (var i = 0; i < allInfos.length; i++) {
        var currentRating = parseInt(
            $(allInfos[i])
                .find('.ratingValue')
                .text());

        var currentStarsContainerstar = $(allInfos[i]).find('.stars');
        for (var star = 0; star < 5; star += 1) {
            if (star < currentRating) {
                currentStarsContainerstar.append('<span class="full-star-img"></span>');
            }
            else {
                currentStarsContainerstar.append('<span class="empty-star-img"></span>');
            }
        };
    };
}
setTimeout(function () {
    drawRatingInStars();
}, 500);