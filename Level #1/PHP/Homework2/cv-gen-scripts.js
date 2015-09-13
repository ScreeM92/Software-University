document.addEventListener("DOMContentLoaded", function () {
    var nextId = 1;

    document.getElementById("remove").onclick = function (e) {
        e.preventDefault();
        var lastChildId = document.getElementById('parent').lastChild.id;
        if (lastChildId != "language1") {
            document.getElementById('parent').lastChild.remove();
        }
    };

    document.getElementById("add").onclick = function (e) {
        e.preventDefault();
        nextId++;
        var inputDiv = document.createElement("div");
        inputDiv.setAttribute("id", "language" + nextId);
        inputDiv.innerHTML =
            "<input type=\"text\" id=\"languages\" name=\"languages[]\">" +
                "<select name=\"progLangLevels[]\">" +
                "<option value=\"Beginner\">Beginner</option>" +
                "<option value=\"Programmer\">Programmer</option>" +
                "<option value=\"Ninja\">Ninja</option>" +
                "</select>";
        document.getElementById('parent').appendChild(inputDiv);
    };
});

document.addEventListener("DOMContentLoaded", function () {
    var nextId = 1;

    document.getElementById("removeOther").onclick = function (e) {
        e.preventDefault();
        var lastChildId = document.getElementById('parent1').lastChild.id;
        if (lastChildId != "otherLanguages0") {
            document.getElementById('parent1').lastChild.remove();
        }
    };

    document.getElementById("addOther").onclick = function (e) {
        e.preventDefault();
        nextId++;
        var inputDiv = document.createElement("div");
        inputDiv.setAttribute("id", "languageOther" + nextId);
        inputDiv.innerHTML =
            "<input type=\"text\" id=\"otherLanguages1\" name=\"otherLanguages[]\">" +
                "<select name=\"comprehension[]\">" +
                "<option value=\"comprehension\" disabled=\"disabled\" selected=\"selected\">-Comprehension-</option>" +
                "<option value=\"intermediate\">intermediate</option>" +
                "<option value=\"advanced\">advanced</option>" +
                "<option value=\"beginner\">beginner</option>" +
                "</select>" +
                "<select name=\"reading[]\">" +
                "<option value=\"reading\" disabled=\"disabled\" selected=\"selected\">-Reading-</option>" +
                "<option value=\"intermediate\">intermediate</option>" +
                "<option value=\"advanced\">advanced</option>" +
                "<option value=\"beginner\">beginner</option>" +
                "</select>" +
                "<select name=\"writing[]\">" +
                "<option value=\"writing\" disabled=\"disabled\" selected=\"selected\">-Writing-</option>" +
                "<option value=\"intermediate\">intermediate</option>" +
                "<option value=\"advanced\">advanced</option>" +
                "<option value=\"beginner\">beginner</option>" +
                "</select>"
        document.getElementById('parent1').appendChild(inputDiv);
    };
});