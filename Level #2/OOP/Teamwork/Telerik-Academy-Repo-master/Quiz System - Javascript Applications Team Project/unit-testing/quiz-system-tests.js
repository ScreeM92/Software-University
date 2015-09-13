/// <reference path="../scripts/test-items-creator.js" />
/// <reference path="../scripts/quiz-system.js" />
/// <reference path="qunit.js" />
(function () {
    module("Quiz System Constructor tests");

    var quizTests, question1, question2, answer1, answer2, answer3, answer4, picture1, picture2, 
        answers1, answers2, firstQuestion, secondQuestion, questions, quizSystem;
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

        quizTests = [itemsCreator.newTest("Test 1", questions)];

        quizSystem = quizControls.newQuizSystem(quizTests);
    });

    test("Test the count of the quiz-tests in the quiz system.", function () {
        equal(quizSystem.tests.length, quizTests.length);
    });

    test("Test the quiz-tests in the quiz system title", function () {
        equal(quizSystem.tests[0].title, quizTests[0].title);
    });

    test("Test quiz-tests in the quiz system questions length", function () {
        equal(quizSystem.tests[0].questions.length, quizTests[0].questions.length);
    });

    test("Test quiz-tests in the quiz system questions->pictures content", function () {
        equal(quizSystem.tests[0].questions[0].picture, quizTests[0].questions[0].picture);
        equal(quizSystem.tests[0].questions[1].picture, quizTests[0].questions[1].picture);
    });

    test("Test quiz-tests in the quiz system questions->answers count", function () {
        equal(quizSystem.tests[0].questions[0].answers.length, quizTests[0].questions[0].answers.length);
        equal(quizSystem.tests[0].questions[1].answers.length, quizTests[0].questions[1].answers.length);
    });

    test("Test quiz-tests in the quiz system questions->answers->text", function () {
        equal(quizSystem.tests[0].questions[0].answers[0].text, quizTests[0].questions[0].answers[0].text);
        equal(quizSystem.tests[0].questions[1].answers[0].text, quizTests[0].questions[1].answers[0].text);
        equal(quizSystem.tests[0].questions[0].answers[1].text, quizTests[0].questions[0].answers[1].text);
        equal(quizSystem.tests[0].questions[1].answers[1].text, quizTests[0].questions[1].answers[1].text);
    });

    test("Test quiz-tests in the quiz system questions->answers->isCorrect property", function () {
        equal(quizSystem.tests[0].questions[0].answers[0].isCorrect, quizTests[0].questions[0].answers[0].isCorrect);
        equal(quizSystem.tests[0].questions[1].answers[0].isCorrect, quizTests[0].questions[1].answers[0].isCorrect);
        equal(quizSystem.tests[0].questions[0].answers[1].isCorrect, quizTests[0].questions[0].answers[1].isCorrect);
        equal(quizSystem.tests[0].questions[1].answers[1].isCorrect, quizTests[0].questions[1].answers[1].isCorrect);
    });

    test("Test quiz-tests getClassNumberPart method", function () {
        var classNumberPart = quizSystem.getClassNumberPart("test23");
        equal(classNumberPart, 23, "Tests equals 23");
        classNumberPart = quizSystem.getClassNumberPart("test0");
        equal(classNumberPart, 0, "Tests equals 0");
        classNumberPart = quizSystem.getClassNumberPart("test");
        ok(isNaN(classNumberPart), "Tests equals NaN")
    });

    module("Test quizSystem _onAnswerClick method");

    QUnit.testStart(function () {
        
    });

    test("test background color _onAnswerClick on h3 element", function () {
        var $container = $("<div></div>");
        var $answerContainer = $("<div></div>");
        $answerContainer.append("<h3 class='target'>This is h3</h3>");
        var $firstIn = $("<div class='firstIn'></div>");
        var $secondIn = $("<div class='secondIn'></div>");
        var $thirdIn = $("<div class='thirdIn'></div>");
        $firstIn.append($secondIn);
        $secondIn.append($thirdIn);
        $answerContainer.append($firstIn);

        console.log($answerContainer[0]);

        $container.append($answerContainer);
        $("#qunit-fixture").append($container);

        var $elementToClick = $("<div></div>").addClass("clickable");
        $(".thirdIn").append($elementToClick);
        $("#qunit-fixture").on("click", "div.clickable", quizSystem._onAnswerClick);

        $("div.clickable").trigger("click");
        var $h3 = $("#qunit-fixture").find("h3.target");
        equal($h3.css("backgroundColor"), "rgb(36, 143, 36)");
    })

    test("test borderBottom _onAnswerClick on h3 element", function () {
        var $container = $("<div></div>");
        var $answerContainer = $("<div></div>");
        $answerContainer.append("<h3 class='target'>This is h3</h3>");
        var $firstIn = $("<div class='firstIn'></div>");
        var $secondIn = $("<div class='secondIn'></div>");
        var $thirdIn = $("<div class='thirdIn'></div>");
        $firstIn.append($secondIn);
        $secondIn.append($thirdIn);
        $answerContainer.append($firstIn);

        console.log($answerContainer[0]);

        $container.append($answerContainer);
        $("#qunit-fixture").append($container);

        var $elementToClick = $("<div></div>").addClass("clickable");
        $(".thirdIn").append($elementToClick);
        $("#qunit-fixture").on("click", "div.clickable", quizSystem._onAnswerClick);

        $("div.clickable").trigger("click");
        var $h3 = $("#qunit-fixture").find("h3.target");
        equal($h3.css("borderBottom"), "1px solid rgb(0, 85, 51)");
    })

    module("Quiz-test renderer tests. Dom testing");

    QUnit.testStart(function () {
        quizSystem._testRenderer.renderTests("#qunit-fixture", quizTests);
    });
    
    test("Test the img length in the tests", function () {
        equal($("#qunit-fixture").find("a")[0].innerHTML, "Test 1");
    });

    test("Test the quiz-tests length", function () {
        equal($(".test0").length, 1);
    });

    test("Test the quiz-tests length", function () {
        equal($(".test1").length, 0);
    });

    module("Quiz-test renderer question. Dom testing");

    QUnit.testStart(function () {
        var answerHolder = $("#qunit-fixture");
        quizSystem._testRenderer._renderQuestion(firstQuestion, answerHolder);
    });

    test("Test the label length in the tests", function () {
        equal($("#qunit-fixture").find("label").length, 2);
    });

    test("Test the list items length in the tests", function () {
        equal($("#qunit-fixture").find("li").length, 3);
    });

    test("Test the first list item with class answers in the tests", function () {
        ok($("#qunit-fixture").find("li").next().hasClass("answers"));
    });

    test("Test the input type checkbox length in the tests", function () {
        equal($("#qunit-fixture").find("input[type='checkbox']").length, 2);
    });

    module("Quiz-test renderer finish button. Dom testing");

    QUnit.testStart(function () {
        var container = $("#qunit-fixture");
        quizSystem._testRenderer.renderFinishBtn(container);
    });

    test("Test the button length in the tests", function () {
        equal($("#qunit-fixture").find("button").length, 1);
    });

    test("Test the button id in the tests", function () {
        equal($("#qunit-fixture").find("button").attr("id"), "finish-btn");
    });

    test("Test the button inner html in the tests", function () {
        equal($("#qunit-fixture").find("button").html(), "Finish test");
    });
})();