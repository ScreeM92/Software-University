var parseControls = (function ($) {
    
    var Parser = Class.create({
        init: function (url) {
            this.success = true;
            this.url = url;
        },

        parseObjects: function () {
            var self = this;
            $.getJSON(this.url).done(new Parser().parseTests)
                .error(function (jqxhr, textStatus, error) {
                    var err = textStatus + ', ' + error;
                    console.log("Request Failed: " + err);
                    self.success = false;
                });

            return this;
        },

        parseTests: function (data) {
            var resultTests = [];
            for (var i = 0; i < data.length; i++) {
                var currTitle = data[i].title;
                var currQuestions = new Parser().parseQuestions(data[i].questions);
                var currTest = itemsCreator.newTest(currTitle, currQuestions);
                resultTests.push(currTest);
            }

            var quiz = quizControls.newQuizSystem(resultTests);
			quiz.load();

            return resultTests;
        },

        parseQuestions: function (questions) {
            var resultQuestions = [];
            for (var i = 0; i < questions.length; i++) {
                var questionTitle = questions[i].question;
                var answers = new Parser().parseAnswers(questions[i].answers);
                var picture = questions[i].picture;
                var currQuestion = itemsCreator.newQuestion(questionTitle, answers, picture);
                resultQuestions.push(currQuestion);
            }

            return resultQuestions;
        },

        parseAnswers: function (answers) {
            var resultAnswers = [];
            for (var i = 0; i < answers.length; i++) {
                var text = answers[i].text;
                var isCorrect = answers[i].isCorrect;
                var name = answers[i].name;
                var currAnswer = itemsCreator.newCheckboxAnswer(text, isCorrect, name);
                resultAnswers.push(currAnswer);
            }

            return resultAnswers;
        }
    });

    return {
        newParser: function (url) {
            return new Parser(url);
        }
    };
})(jQuery);