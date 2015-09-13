$(document).ready(function () {
    $(".collaborator").on("click", removeColl);
    $(".skill").on("click", removeSkill);
});

function removeColl(e) {
    e.preventDefault();

    var collaborator = $(e.currentTarget).data("collaborator");
    var projectId = $("#Id").val();

    $.ajax({
        url: "/Admin/Projects/RemoveCollaborator",
        type: "post",
        data: {
            collaborator: collaborator,
            projectId: projectId
        }
    }).then(function () {
        var collaboratorElement = document.getElementById("collaborator-" + collaborator);
        collaboratorElement.parentElement.removeChild(collaboratorElement);
    }, function () {
        $("#error-notifier-coll").text("Error removing the selected collaborator.");
    });

    return false;
}

function removeSkill(e) {
    e.preventDefault();

    var skill = $(e.currentTarget).data("skill");
    var projectId = $("#Id").val();

    $.ajax({
        url: "/Admin/Projects/RemoveSkill",
        type: "post",
        data: {
            skillName: skill,
            projectId: projectId
        }
    }).then(function () {
        var skillElement = document.getElementById("skill-" + skill);
        skillElement.parentElement.removeChild(skillElement);
    }, function () {
        $("#error-notifier-skill").text("Error removing the selected skill.");
    });

    return false;
}

function getUsernameInput() {
    return {
        projectId: $("#Id").val(),
        text: $("#Collaborators").val()
    }
}

function getSkillInput() {
    return {
        projectId: $("#Id").val(),
        text: $("#RequiredSkills").val()
    }
}

function addSkill(e, projectId) {
    e.preventDefault();
    var skill = $("#RequiredSkills").val();
    clearMessagesSkill();

    $.ajax({
        url: "/Admin/Projects/AddSkill",
        data: { name: skill, projectId: projectId },
        type: "post"
    }).then(function () {
        $("#success-notifier-skill").text("Skill added!");
        var skillWrapper = document.createElement("span");
        skillWrapper.innerHTML = '<span class="tag label label-info" id="skill-' + skill + '">'
                                    + '<a style="color:white" href="#" class="skill" data-skill="' + skill + '">x</a> ' + skill
                                    + '</span>'

        $("#skills-wrapper").append($(skillWrapper.firstChild));
        $(".skill").click(removeSkill);
    }, function (data) {
        $("#error-notifier-skill").text(data.statusText);
    });

    return false;
}

function categoryChange(data) {
    var selectedCategory = data.sender._selectedValue;
    $("#CategoryName").val(selectedCategory);
}

function clearMessagesSkill() {
    $("#success-notifier-skill").text("");
    $("#error-notifier-skill").text("");
    $("#RequiredSkills").val("");
}

function clearMessagesCollab() {
    $("#success-notifier-coll").text("");
    $("#error-notifier-coll").text("");
    $("#Collaborators").val("");
}

function addCollab(e, projectId) {
    e.preventDefault();
    var collaborator = $("#Collaborators").val();
    clearMessagesCollab();

    $.ajax({
        url: "/Admin/Projects/AddCollaborator",
        data: { name: collaborator, projectId: projectId },
        type: "post"
    }).then(function () {
        $("#success-notifier-coll").text("Collaborator added!");
        var collWrapper = document.createElement("span");
        collWrapper.innerHTML = '<span class="tag label label-info" id="collaborator-' + collaborator + '">'
                                    + '<a style="color:white" href="#" class="collaborator" data-collaborator="' + collaborator + '">x</a> ' + collaborator
                                    + '</span>'

        $("#collaborators-wrapper").append($(collWrapper.firstChild));
        $(".collaborator").click(removeColl);
    }, function (data) {
        $("#error-notifier-coll").text(data.statusText);
    });

    return false;
}