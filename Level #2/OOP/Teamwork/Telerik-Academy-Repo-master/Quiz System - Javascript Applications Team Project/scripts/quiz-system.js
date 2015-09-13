var quizControls = (function () {

    // Contains all tests
    var data = [];

    // loops iterators
    var i, j;

    //The Main class - handle the test system

    var QuizSystem = Class.create({
        init: function (tests) {
            _self = this;
            data = tests;
            this.tests = data;
            this._testRenderer = new TestRenderer();
        },
		
		load: function () {
			this._testRenderer.renderTests("#tests-holder", this.tests);
			$("#tests-holder").on("click", "a", this._onTestClick);
			$("#tests-holder").on("click", "a", this._testRenderer.renderCountDown);
            $("#curr-test").on("click", "label, input", this._onAnswerClick);
		},

        // Render the clicked test and the scoreboard attached to the test
        _onTestClick: function (ev) {
            var $li = $(ev.target).parent();

            // Parse the number part of the id and use it as an index
			var elementClass = $li.attr("class");
            var index = _self.getClassNumberPart(elementClass);

            var returnedStringifiedScoarboardOjb = localStorage.getItem(data[index].title + "scoreboard");
            var board = JSON.parse(returnedStringifiedScoarboardOjb);
            _self._testRenderer.renderTest("#curr-test", data[index], index);
            _self._testRenderer.renderScoreboard("#scoreboard-holder", 
                board || data[index].scoreboard);

            //renders Countdown for test for the first time (made such because of library countdown.js specifications)
            _self._testRenderer.initalRenderCountDown();
        },

        // Sets the color of the answered question to light green
        _onAnswerClick: function () {
            var questionHolder = $(this).parent().parent().parent().prev("h3");
            questionHolder.css({
                "backgroundColor": "#F9F9F9",
                "borderBottom": "1px solid #005533"
            });
        },

        getClassNumberPart: function (identifier) {
            var numberStartIndex = identifier.indexOf("test") + 4;
            var indexAsString = identifier.substring(numberStartIndex).trim();
            var index = parseInt(indexAsString, 10);

            return index;
        }
    });

    //Test Renderer class - Render the tests (quizes) in the html document

    var TestRenderer = Class.create({
        init: function () {
            this._setDialogWinProperties();
        },

        // Function for rendering single test in the 'current test container'
        renderTest: function (wrapSelector, test, index) {
            var $currentTestHolder = $(wrapSelector)
                                    .removeClass() // Removes the old class name
                                    .addClass("test" + index) // Set new class name same as the test class in the tests list (test0, test2, test432, etc)
                                    .html("");  // Clean the current test holder
           
            // Set the current test title
            $currentTestHolder.prev().html(test.title);

            for (i = 0; i < test.questions.length; i++) {
                var currentQuestion = test.questions[i];
                var $questionHolder = $("<h3></h3>")
                                        .text(currentQuestion.question);
                var $answersHolder = $("<div></div>");
                var $ulHolder = $("<ul></ul>");

                //start added by Marieta 
                // This is attaching picture
                if (currentQuestion.picture!=null) {
                    var $picture=$("<img />")
                                        .attr("src", currentQuestion.picture);
                    $answersHolder.append($picture);
                }
                //end added by Marieta 

                this._renderQuestion(currentQuestion, $ulHolder);

                $answersHolder.append($ulHolder);
                $currentTestHolder.append($questionHolder, $answersHolder);

                //Hide the answer holder except the first one
                if (i > 0) {
                    $ulHolder.parent().hide();  
                }
				//Set the dialog error message display: none
				$("#length-error").hide();
            }

            // Set onclick handler on the question (h3 element) - set the accordion effect
            $currentTestHolder.on("click", "h3", function(ev){
                $(this).next().slideDown().siblings("div").slideUp();

                ev.preventDefault();
            });

            // Render button to calculate result and to set the dialog buttons properties
            this.renderFinishBtn($currentTestHolder);
            this._setDialogWinProperties();
        },

        _renderQuestion: function(currentQuestion, answersHolder) {
            for (j = 0; j < currentQuestion.answers.length; j++) {
                var $answer = $('<li></li>')
                                .addClass("answers")
                                .data("isTrue", currentQuestion.answers[j].isCorrect);

                var $label = $("<label></label>")
                                .attr("for", currentQuestion.answers[j].name + j)
                                .text(currentQuestion.answers[j].text);

                var $input = $("<input type='checkbox' />")
                                .attr( {
                                    name: currentQuestion.answers[j].name,
                                    id: currentQuestion.answers[j].name + j
                                });

                // Set attribute to li in order to check if the answer is correct
                $answer.append($input, $label);
                answersHolder.append($answer);
            }
        },

        // Function for rendering list of tests in the 'tests list container'
        renderTests: function (wrapSelector, list) {
            var $testsHolder = $(wrapSelector);

            for (i = 0; i < list.length; i++) {
                var $anchor = $("<a href='#'></a>")
                            .html(list[i].title + "<span>&raquo</span>");
                var $li = $("<li></li>")
                            .addClass("test" + i)
                            .append($anchor);
                $testsHolder.append($li);
            }
        },

        initalRenderCountDown: function () {
            var now = new Date();
            //now.setHours(now.getHours() + 2);
            //console.log(now);
            now.setSeconds(now.getSeconds() + 5);

            $('#test-countdown').countdown({
                until: now,
                format: "HMS",
                onExpiry: forcefullySubmitTest
            });

            function forcefullySubmitTest() {
                var elem = $("#finish-btn");
                elem.click();
            }
        },


        //Renders the countdown for the current test 
        renderCountDown: function () {
            var now = new Date();
            now.setHours(now.getHours() + 2);
            
            $('#test-countdown').countdown("option",{
                until: now,
                format: "HMS",
                onExpiry: forcefullySubmitTest
            });

            function forcefullySubmitTest() {
                var elem = $("#finish-btn");
                elem.click();
            }
        },

        // Function for rendering list of scores by given container selector and list of scores
        renderScoreboard: function (wrapSelector, list) {
            var $scoreboardHolder = $(wrapSelector).text("");

            for (i = 0; i < list.length; i++) {
                var scoreNumber = i + 1;
                var $li = $("<li></li>")
						.text(scoreNumber + ". " + list[i].name + ": ");
				$li.html($li.text() + "<span>" + list[i].points + " pts.</span>");
                $scoreboardHolder.append($li);
            }
        },

        renderFinishBtn: function (container) {
            var self = new TestRenderer();
            var $btnHolder = $("<button></button>")
                                .attr("id", "finish-btn")
                                .html("Finish test");
            
            $btnHolder.on("click", function () {
                $("#dialog-form").dialog("open");
            });
            $btnHolder.on("click", self._onCalculateResultBtnClick);
            
            container.append($btnHolder);

            // Get the dialog window ready for the initialize
            this._setDialogWinProperties();
        },

        renderTweetButton: function (score) {
            var $tweet = $("<a></a>");
            $tweet.attr({
                "href": "http://twitter.com/share",
                "data-text": "This is what we want to change dynamically",
                "data-count": "none",
                "data-via": "Raspberry Team Telerik Academy"
            }).addClass("twitter-share-button");

            $tweet.each(function(){
              $(this).attr('data-text', "Scored " + score + " points. ");
            });
            $.getScript('http://platform.twitter.com/widgets.js');
			
            return $tweet;
        },

        _onCalculateResultBtnClick: function (ev) {
            var self = new TestRenderer();
            var $currTestHolder = $("#curr-test");

            function CalculateCurrentResults(argument) {
                var $checkboxes = $('[type=checkbox]');
                var points = 0;

                // Get all input elements which are checked and increase or decrease the points
                for (i = 0; i < $checkboxes.length; i++) {
                    
                    var $currentCheckbox = $($checkboxes[i]);
                    var isCheckboxChecked = $currentCheckbox.is(":checked");
                    var isAnswerCorrect = $currentCheckbox.parent().data("isTrue");
                    
                    if (!isAnswerCorrect) {
                        $currentCheckbox.parent().css("background-color", "#EA0003");
                    }

                    //TODO: Choose between this construction and the commented construction below
                    if (isCheckboxChecked) {
                        isAnswerCorrect ? points += 1 : points -= 1;
                    }
                };

                //If the points are negative return 0 points
                if (points < 0) {
                    return 0;
                }
                return points;
            }

            var points = CalculateCurrentResults();

            // Set the dialog window måssàgå
            $(".validateTips").text("You have " + points + " points");

            // Set the dialog buttons and functions to them - the Add button add name and points to the scoreboard
            self._setDialogButtons(self, points, $currTestHolder);

            $("#test-countdown").countdown("destroy");

            var $currScoreHolder = $("<p></p>")
                                    .html("Share your result on " + points);
            $currTestHolder.append($currScoreHolder);

            $(this).hide();
            var tweetButton = self.renderTweetButton(points);
            $currTestHolder.append(tweetButton);
        },

        _setDialogWinProperties: function () {
            $("#dialog-form").dialog({
                autoOpen: false,
                height: 240,
                width: 250,
                modal: true
            });
        },

        _setDialogButtons: function (self, points, dialogHolder) {

            // Parse the number part of the class name and use it as an index 
            // to get the wanted test object from data
            var elementClass = dialogHolder.attr("class");
            var numberStartIndex = elementClass.indexOf("test") + 4;
            var indexAsString = elementClass.substring(numberStartIndex).trim();
            var index = parseInt(indexAsString, 10);

            $("#dialog-form").dialog({
                buttons: {
                    "Add": function () {
                        var name = $("#name").val();

                        if (name !== null && name.length > 1) {
                            //downloading board from localStorage
                            var returnedBoardStringifiedObj = localStorage.getItem(data[index].title + "scoreboard");
                            var board = JSON.parse(returnedBoardStringifiedObj);

                            // if localStorage doesn't return an object then data[index].board is set to empty array
                            data[index].scoreboard = board || []; 
                            data[index].addScore(name, points);

                            self.renderScoreboard("#scoreboard-holder",
                                data[index].scoreboard);

                            //upload board to localStorage
                            var stringifiedScoreBoard = JSON.stringify(data[index].scoreboard);
                            localStorage.setItem(data[index].title + "scoreboard", stringifiedScoreBoard);
							
							$("#name").val("");
							$(this).dialog("close");
                        }
						else {
							$("#length-error")
									.fadeOut("fast")
									.fadeIn("slow");
						}
                        // Clear the input field for the name and close the dialog
                        
                    },
                    "Cancel": function () {
                        $(this).dialog("close");
                    }
                }
            });
        }
    });

    return {
        newQuizSystem: function(tests) {
            return new QuizSystem(tests);
        }
    }
})();
