/// <reference path="../scripts/test-items-creator.js" />
/// <reference path="qunit.js" />
(function () {
    module("Checkbox answer tests");

    var answer;
    QUnit.testStart(function () {
        answer = itemsCreator.newCheckboxAnswer("This is the answer", false);
    });

    test("answer.text test", function () {
        equal("This is the answer", answer.text);
    });

    test("answer.isTrue test", function () {
        equal(false, answer.isCorrect);
    });

    module("Questions tests");

    var question, firstanswer, secondanswer, thirdanswer, answers, picture;
    QUnit.testStart(function () {
        firstanswer = itemsCreator.newCheckboxAnswer("This is the answer", false);
        secondanswer = itemsCreator.newCheckboxAnswer("This is not the answer", false);
        thirdanswer = itemsCreator.newCheckboxAnswer("This is the correct answer", false);
        answers = [firstanswer, secondanswer, thirdanswer];
        picture = "images/one.gif";
        question = itemsCreator.newQuestion("A new question", answers, picture);
    });

    test("question.question test", function () {
        equal("A new question", question.question);
    });

    test("question.answers test", function () {
        deepEqual([firstanswer, secondanswer, thirdanswer], question.answers);
    });

    test("question.answers.firstanswer test", function () {
        deepEqual(firstanswer, question.answers[0]);
    });

    test("question.answers.secondanswer test", function () {
        deepEqual(secondanswer, question.answers[1]);
    });

    test("question.answers.thirdanswer test", function () {
        deepEqual(thirdanswer, question.answers[2]);
    });

    test("question.picture test", function () {
        equal("images/one.gif", question.picture);
    });

    module("Quiz-test class tests");

    var firstanswer, secondanswer, thirdanswer, answers1, answers2, answers3,
        picture1, picture2, picture3, question1, question2, question3, questions, quizTest;
    QUnit.testStart(function () {
        firstanswer = itemsCreator.newCheckboxAnswer("This is the answer", false);
        secondanswer = itemsCreator.newCheckboxAnswer("This is not the answer", false);
        thirdanswer = itemsCreator.newCheckboxAnswer("This is the correct answer", false);
        answers1 = [firstanswer, secondanswer, thirdanswer];
        answers2 = [secondanswer, firstanswer, thirdanswer];
        answers3 = [thirdanswer, firstanswer, secondanswer];
        picture1 = "images/one.gif";
        picture2 = "images/two.gif";
        picture3 = "images/three.gif";
        question1 = itemsCreator.newQuestion("First question", answers1, picture1);
        question2 = itemsCreator.newQuestion("Second question", answers2, picture2);
        question3 = itemsCreator.newQuestion("Third question", answers3, picture3);
        questions = [question1, question2, question3];
        quizTest = itemsCreator.newTest("This is a new test", questions)
    });

    test("quizTest.title test", function () {
        equal("This is a new test", quizTest.title);
    });

    test("quizTest.questions test", function () {
        equal(questions, quizTest.questions);
    });

    test("quizTest.questions. First question answers test", function () {
        equal(questions[0].answers, quizTest.questions[0].answers);
    });

    test("quizTest.questions. First question second answer test", function () {
        equal(questions[0].answers[1], quizTest.questions[0].answers[1]);
    });

    test("quizTest.questions. First question third answer picture test", function () {
        equal(questions[0].answers[2].picture, quizTest.questions[0].answers[2].picture);
    });

    test("quizTest addQuestion method test. Test the count", function () {
        var newQuestion = itemsCreator.newQuestion("New question", answers, picture3);
        questions.push(newQuestion);
        quizTest.addQuestion(newQuestion);
        equal(questions.length, quizTest.questions.length);
    });

    test("quizTest addQuestion method test. Test the content", function () {
        var newQuestion = itemsCreator.newQuestion("New question", answers, picture3);
        questions.push(newQuestion);
        quizTest.addQuestion(newQuestion);
        equal(questions, quizTest.questions);
        equal(questions[0].answers, quizTest.questions[0].answers);
        equal(questions[0].answers[1], quizTest.questions[0].answers[1]);
        equal(questions[0].answers[2].picture, quizTest.questions[0].answers[2].picture);
    });

    test("quizTest addScore method test. Test the count", function () {
        quizTest.addScore("Pesho", 20);
        equal(1, quizTest.scoreboard.length);
    });

    test("quizTest addScore method test. Test the content", function () {
        var score = itemsCreator.newScore("Pesho", 20);
        quizTest.addScore("Pesho", 20);
        deepEqual(score, quizTest.scoreboard[0]);
    });

    test("Test the sorting in the scoreboard", function () {
        var score1 = itemsCreator.newScore("Doncho", 30);
        var score2 = itemsCreator.newScore("Pesho", 20);
        var score3 = itemsCreator.newScore("Gosho", 12);
        var scores = [score1, score2, score3];
        quizTest.addScore("Pesho", 20);
        quizTest.addScore("Gosho", 12);
        quizTest.addScore("Doncho", 30);
        equal(score1.name, quizTest.scoreboard[0].name);
        equal(score1.points, quizTest.scoreboard[0].points);
        equal(score2.name, quizTest.scoreboard[1].name);
        equal(score2.points, quizTest.scoreboard[1].points);
        equal(score3.name, quizTest.scoreboard[2].name);
        equal(score3.points, quizTest.scoreboard[2].points);
        deepEqual(score1, quizTest.scoreboard[0]);
        deepEqual(score2, quizTest.scoreboard[1]);
        deepEqual(score3, quizTest.scoreboard[2]);
    });


    module("Score class tests");

    var score;
    QUnit.testStart(function () {
        score = itemsCreator.newScore("Pesho", 23);
    });

    test("Test score name.", function () {
        equal("Pesho", score.name);
    });

    test("Test score points.", function () {
        equal(23, score.points);
    });
})();