/// <reference path="../scripts/test-items-creator.js" />
/// <reference path="../scripts/objectParser.js" />
/// <reference path="qunit.js" />
(function () {
    module("Test Parse Answers");

    var firstanswer, secondanswer, thirdanswer, answers, expected, parser, actual;
    QUnit.testStart(function () {
        answers = [
            { text: "This is the answer", isCorrect: false },
            { text: "This is not the answer", isCorrect: true },
            { text: "This is the correct answer", isCorrect: false }];

        firstanswer = itemsCreator.newCheckboxAnswer("This is the answer", false);
        secondanswer = itemsCreator.newCheckboxAnswer("This is not the answer", true);
        thirdanswer = itemsCreator.newCheckboxAnswer("This is the correct answer", false);
        expected = [firstanswer, secondanswer, thirdanswer];
        parser = parseControls.newParser();
        actual = parser.parseAnswers(answers);
    });

    test("Test parse answers. Check the count.", function () {
        equal(actual.length, expected.length);
    });

    test("Test parse answers. Check the content.", function () {
        equal(actual[0].text, expected[0].text);
        equal(actual[0].isCorrect, expected[0].isCorrect);
        equal(actual[1].text, expected[1].text);
        equal(actual[1].isCorrect, expected[1].isCorrect);
        equal(actual[2].text, expected[2].text);
        equal(actual[2].isCorrect, expected[2].isCorrect);
    });

    module("Test Parse Questions");

    var actualQuestions, expectedQuestions, questions, firstQuestion, secondQuestion, question1, question2,
        answer1, answer2, answer3, answer4, answers1, answers2, picture1, picture2;
    QUnit.testStart(function () {
        questions = [
            {
                question: "First question",
                answers: [
                { text: "Yes", "isCorrect": false, name: "question10" },
                { text: "No", "isCorrect": true, name: "question10" }

                ],
                picture: "images/question10.jpg"
            },
            {
                question: "Second question",
                answers: [
                  { text: "Sure", isCorrect: false, name: "question3" },
                  { text: "Nope", isCorrect: false, name: "question3" }
                ],
                picture: "images/question3.jpg"
            }
        ]

        question1 = "First question";
        question2 = "Second question";
        answer1 = itemsCreator.newCheckboxAnswer("Yes", false, "question10");
        answer2 = itemsCreator.newCheckboxAnswer("No", true, "question10");
        answer3 = itemsCreator.newCheckboxAnswer("Sure", false, "question3");
        answer4 = itemsCreator.newCheckboxAnswer("Nope", false, "question3");
        picture1 = "images/question10.jpg";
        picture2 = "images/question3.jpg";
        answers1 = [answer1, answer2];
        answers2 = [answer3, answer4];
        firstQuestion = itemsCreator.newQuestion(question1, answers1, picture1);
        secondQuestion = itemsCreator.newQuestion(question2, answers2, picture2);
        expectedQuestions = [firstQuestion, secondQuestion];

        parser = parseControls.newParser();
        actualQuestions = parser.parseQuestions(questions);
    });

    test("Test parse questions. Check the count.", function () {
        equal(actualQuestions.length, expectedQuestions.length);
    });

    test("Test parse questions. Check the answers.", function () {
        deepEqual(actualQuestions[0].answers, expectedQuestions[0].answers);
        deepEqual(actualQuestions[1].answers, expectedQuestions[1].answers);
    });

    test("Test parse questions. Check the answers text.", function () {
        equal(actualQuestions[1].answers[1].text, expectedQuestions[1].answers[1].text);
        equal(actualQuestions[1].answers[0].text, expectedQuestions[1].answers[0].text);
        equal(actualQuestions[0].answers[1].text, expectedQuestions[0].answers[1].text);
        equal(actualQuestions[0].answers[0].text, expectedQuestions[0].answers[0].text);
    });

    test("Test parse questions. Check the answers isCorrect property.", function () {
        equal(actualQuestions[1].answers[1].isCorrect, expectedQuestions[1].answers[1].isCorrect);
        equal(actualQuestions[1].answers[1].isCorrect, expectedQuestions[1].answers[1].isCorrect);
        equal(actualQuestions[1].answers[0].isCorrect, expectedQuestions[1].answers[0].isCorrect);
        equal(actualQuestions[0].answers[1].isCorrect, expectedQuestions[0].answers[1].isCorrect);
        equal(actualQuestions[0].answers[0].isCorrect, expectedQuestions[0].answers[0].isCorrect);
    });

    test("Test parse questions. Check the questions title.", function () {
        equal(actualQuestions[0].question, expectedQuestions[0].question);
        equal(actualQuestions[1].question, expectedQuestions[1].question);
    });

    test("Test parse questions. Check the questions pictures.", function () {
        equal(actualQuestions[0].picture, expectedQuestions[0].picture);
        equal(actualQuestions[1].picture, expectedQuestions[1].picture);
    });

    module("Construcotor tests");

    test("Regular url", function () {
        var url = "demo.js"
        parser = parseControls.newParser(url);
        equal(parser.url, url);
    });

    test("empty url", function () {
        var url = "demo.js"
        parser = parseControls.newParser();
        equal(parser.url, undefined);
        notEqual(parser.url, url);
    });

    module("Parse Quiz-Test tests");

    var expectedQuizTests, actualQuizTests, JSONQuizTests;
    QUnit.testStart(function () {
        question1 = "First question";
        question2 = "Second question";
        answer1 = itemsCreator.newCheckboxAnswer("Yes", false);
        answer2 = itemsCreator.newCheckboxAnswer("No", true);
        answer3 = itemsCreator.newCheckboxAnswer("Sure", false);
        answer4 = itemsCreator.newCheckboxAnswer("Nope", false);
        picture1 = "images/question10.jpg";
        picture2 = "images/question3.jpg";
        answers1 = [answer1, answer2];
        answers2 = [answer3, answer4];
        firstQuestion = itemsCreator.newQuestion(question1, answers1, picture1);
        secondQuestion = itemsCreator.newQuestion(question2, answers2, picture2);
        questions = [firstQuestion, secondQuestion];

        expectedQuizTests = [itemsCreator.newTest("Test 1", questions)];

        JSONQuizTests = [{
            title: "Test 1",
            questions: [
                {
                    question: "First question",
                    answers: [
                    { text: "Yes", "isCorrect": false, name: "question10" },
                    { text: "No", "isCorrect": true, name: "question10" }

                    ],
                    picture: "images/question10.jpg"
                },
                {
                    question: "Second question",
                    answers: [
                      { text: "Sure", isCorrect: false, name: "question3" },
                      { text: "Nope", isCorrect: false, name: "question3" }
                    ],
                    picture: "images/question3.jpg"
                }
            ]
        }];

        parser = parseControls.newParser();
        actualQuizTests = parser.parseTests(JSONQuizTests);
    });

    test("Test QuizTests count", function () {
        equal(expectedQuizTests.length, actualQuizTests.length);
    });

    test("Test QuizTests title", function () {
        equal(expectedQuizTests[0].title, actualQuizTests[0].title);
    });

    test("Test QuizTests questions length", function () {
        equal(expectedQuizTests[0].questions.length, actualQuizTests[0].questions.length);
    });

    test("Test QuizTests questions->pictures content", function () {
        equal(expectedQuizTests[0].questions[0].picture, actualQuizTests[0].questions[0].picture);
        equal(expectedQuizTests[0].questions[1].picture, actualQuizTests[0].questions[1].picture);
    });

    test("Test QuizTests questions->answers count", function () {
        equal(expectedQuizTests[0].questions[0].answers.length, actualQuizTests[0].questions[0].answers.length);
        equal(expectedQuizTests[0].questions[1].answers.length, actualQuizTests[0].questions[1].answers.length);
    });

    test("Test QuizTests questions->answers->text", function () {
        equal(expectedQuizTests[0].questions[0].answers[0].text, actualQuizTests[0].questions[0].answers[0].text);
        equal(expectedQuizTests[0].questions[1].answers[0].text, actualQuizTests[0].questions[1].answers[0].text);
        equal(expectedQuizTests[0].questions[0].answers[1].text, actualQuizTests[0].questions[0].answers[1].text);
        equal(expectedQuizTests[0].questions[1].answers[1].text, actualQuizTests[0].questions[1].answers[1].text);
    });

    test("Test QuizTests questions->answers->isCorrect property", function () {
        equal(expectedQuizTests[0].questions[0].answers[0].isCorrect, actualQuizTests[0].questions[0].answers[0].isCorrect);
        equal(expectedQuizTests[0].questions[1].answers[0].isCorrect, actualQuizTests[0].questions[1].answers[0].isCorrect);
        equal(expectedQuizTests[0].questions[0].answers[1].isCorrect, actualQuizTests[0].questions[0].answers[1].isCorrect);
        equal(expectedQuizTests[0].questions[1].answers[1].isCorrect, actualQuizTests[0].questions[1].answers[1].isCorrect);
    });

    module("Tests for getting object from file");

    asyncTest("Get JSON success", function () {
        var success = false;
        var url = "dataJSON.js";

        $.getJSON(url, function (data) {
            success = true;
            ok(success);
            start();
        });
    });

    asyncTest("Get JSON success with parsing our local DataBase", function () {
        var url = "dataJSON.js";
        parser = parseControls.newParser(url);
        parser.parseObjects();

        start();
        ok(parser.success);
    });
})();