$(document).ready(function () {
    var ul = $('ul');
    var element = $("<li>Element</li>");
    ul.append(element);
    element.before("<li>Inserted before Element</li>");
    element.after("<li>Inserted after Element</li>");
});