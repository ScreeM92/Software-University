var imdb = imdb || {};

(function (scope) {
	function loadHtml(selector, data) {
		var container = document.querySelector(selector),
			moviesContainer = document.getElementById('movies'),
			detailsContainer = document.getElementById('details'),
			genresUl = loadGenres(data);

		container.appendChild(genresUl);

		genresUl.addEventListener('click', function (ev) {
			if (ev.target.tagName === 'LI') {
				var genreId,
					genre,
					moviesHtml;

				genreId = parseInt(ev.target.getAttribute('data-id'));
				genre = data.filter(function (genre) {
					return genre._id === genreId;
				})[0];

				moviesHtml = loadMovies(genre.getMovies());
				detailsContainer.innerHTML = '';
				moviesContainer.innerHTML = moviesHtml.outerHTML;
				moviesContainer.setAttribute('data-genre-id', genreId);
			}
		});

		moviesContainer.addEventListener('click', function (ev) {
		    if (ev.target.tagName !== "UL") {
		        var parent = ev.target;
		        while (parent && parent.tagName !== 'LI') {
		            parent = parent.parentElement;
		        }

		        var genreId,
                    movieId,
                    movie,
                    reviewsHtml,
                    actorsHtml;

		        genreId = parseInt(moviesContainer.getAttribute('data-genre-id'));
		        movieId = parseInt(parent.getAttribute('data-id'));

		        movie = data
                    .filter(function (genre) { return genre._id === genreId; })[0].getMovies()
                    .filter(function (movie) { return movie._id === movieId; })[0];

		        actorsHtml = loadActors(movie.getActors());
		        reviewsHtml = loadReviews(movie.getReviews(), data);
		        detailsContainer.innerHTML = '';

		        if (actorsHtml instanceof Element) {
		            detailsContainer.appendChild(actorsHtml);
		        }

		        if (reviewsHtml instanceof Element) {
		            detailsContainer.appendChild(reviewsHtml);
		        }
		        
		        detailsContainer.setAttribute('data-movie-id', movieId);
		    }
	    });
	}

	function loadGenres(genres) {
		var genresUl = document.createElement('ul');
		genresUl.setAttribute('class', 'nav navbar-nav');
		genres.forEach(function (genre) {
			var liGenre = document.createElement('li');
			liGenre.innerHTML = genre.name;
			liGenre.setAttribute('data-id', genre._id);
			genresUl.appendChild(liGenre);
		});

		return genresUl;
	}

	function loadMovies(movies) {
		var moviesUl = document.createElement('ul');
		movies.forEach(function (movie) {
			var liMovie = document.createElement('li');
			liMovie.setAttribute('data-id', movie._id);

			liMovie.innerHTML = '<h3>' + movie.title + '</h3>';
			liMovie.innerHTML += '<div>Country: ' + movie.country + '</div>';
			liMovie.innerHTML += '<div>Time: ' + movie.length + '</div>';
			liMovie.innerHTML += '<div>Rating: ' + movie.rating + '</div>';
			liMovie.innerHTML += '<div>Actors: ' + movie._actors.length + '</div>';
			liMovie.innerHTML += '<div>Reviews: ' + movie._reviews.length + '</div>';
			
			moviesUl.appendChild(liMovie);
		});

		return moviesUl;
	}

	function loadActors(actors) {
        if (actors.length > 0) {
            var actorsSection = document.createElement('section');
            actorsSection.innerHTML = '<h3>Actors</h3>';
            actors.forEach(function(actor) {
                actorsSection.innerHTML += '<li><h4>' + actor.name + '</h4>';
                actorsSection.innerHTML += '<p>Bio:' + actor.bio + '</p>';
                actorsSection.innerHTML += '<p>Born:' + actor.born + '</p></li>';
            });

            return actorsSection;
        }

	    return '';
	}

    function loadReviews(reviews, data) {
        if (reviews.length > 0) {
            var reviewsSection,
                reviewsTitle,
                reviewLi,
                reviewAuthor,
                reviewContent,
                reviewDate,
                reviewDeleteButton,
                genreId;

            genreId = parseInt(document.getElementById('movies').getAttribute('data-genre-id'));
            
            reviewsSection = document.createElement('section');
            reviewsTitle = document.createElement('h3');
            reviewsTitle.innerHTML = 'Reviews';
            reviewsSection.appendChild(reviewsTitle);

            reviews.forEach(function (review) {
                reviewLi = document.createElement('li');
                reviewLi.setAttribute('review-id', review._id);

                reviewAuthor = document.createElement('h4');
                reviewAuthor.innerHTML = review.author;

                reviewContent = document.createElement('p');
                reviewContent.innerHTML = 'Content: ' + review.content;

                reviewDate = document.createElement('p');
                reviewDate.innerHTML = 'Date: ' + review.date;

                reviewDeleteButton = document.createElement('button');
                reviewDeleteButton.innerHTML = 'Delete review';
                reviewDeleteButton.addEventListener('click', function () {
                    this.parentElement.parentElement.removeChild(this.parentElement);
                    var movieId = parseInt(document.getElementById('details').getAttribute('data-movie-id'));

                    for (var i in data[genreId - 1]._movies) {
                        if (data[genreId - 1]._movies[i]._id === movieId) {
                            data[genreId - 1]._movies[i].deleteReviewById(review._id);
                        }
                    }
                });

                reviewLi.appendChild(reviewAuthor);
                reviewLi.appendChild(reviewContent);
                reviewLi.appendChild(reviewDate);
                reviewLi.appendChild(reviewDeleteButton);
                reviewsSection.appendChild(reviewLi);
            });

            return reviewsSection;
        }

        return '';
    }

	scope.loadHtml = loadHtml;
}(imdb));