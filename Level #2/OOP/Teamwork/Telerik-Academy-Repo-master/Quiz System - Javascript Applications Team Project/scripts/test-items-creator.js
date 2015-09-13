var itemsCreator = (function () {

    var Test = Class.create({
        init: function (title, questions) {
            this.title = title;
            this.questions = questions;
            this.scoreboard = [];
        },

        addQuestion: function (question) {
            this.questions.push(question);
        },

        addScore: function (name, points) {
            var score = new Score(name, points);
            this.scoreboard.push(score);

            //Sort the scoreboard by given comparator (only by points)
            //TODO: add sorting also by name if the points are equal
            this.scoreboard.sort(function (el1, el2) {
                if (el1.points === el2.points) {
                    return 0;
                }
                else if (el1.points < el2.points) {
                    return 1;
                }
                else {
                    return -1;
                }
            })
        }
    });

    var Question = Class.create({
        init: function (question, answers,picture) {
            this.question = question;
            this.answers = answers;
             this.picture=picture||null;
        },

        addAnswer: function (answer) {
            this.answers.push(answer);
        }
    });

    var AbstractAnswer = Class.create({
        init: function (text, isCorrect) {
            this.text = text;
            this.isCorrect = isCorrect;
        }
    });

    //TODO: REMOVE LATER
    //var RadioBtnAnswer = Class.create({
    //    init: function (text, isCorrect, name) {
    //        this._super = new this._super(arguments);
    //        this._super.init.apply(this, arguments);

    //        this.name = name;
    //    }
    //});

    //RadioBtnAnswer.inherit(AbstractAnswer);

    var CheckboxAnswer = Class.create({
        init: function (text, isCorrect, name) {
            this._super = new this._super(arguments);
            this._super.init.apply(this, arguments);

            this.name = name;
        }
    });

    CheckboxAnswer.inherit(AbstractAnswer);

    var Score = Class.create({
        init: function (name, points) {
            this.name = name;
            this.points = points;
        }
    });

    return {
        newTest: function (title, questions) {
            return new Test(title, questions);
        },
        newRadioBtnAnswer: function (text, isCorrect, name) {
            return new RadioBtnAnswer(text, isCorrect, name);
        },
        newCheckboxAnswer: function (text, isCorrect, name) {
            return new CheckboxAnswer(text, isCorrect, name);
        },
        newQuestion: function (question, answers, picture) {
            return new Question(question, answers, picture);
        },
        newScore: function (name, points) {
            return new Score(name, points);
        }
    }
})();