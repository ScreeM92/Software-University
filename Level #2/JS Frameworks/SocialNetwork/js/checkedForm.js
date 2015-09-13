function checkedForm(){
    var inputUsername = document.getElementById("inputUsername");
    var usernameMessage = document.getElementById("usernameMessage");

    if(inputUsername.value == "")
    {
        inputUsername.style.border = "red 1px solid";
        usernameMessage.style.display = "block";
    }else
    {
        inputUsername.style.border = "#bdb597 1px solid";
        usernameMessage.style.display = "none";
    }

    var inputPassword = document.getElementById("inputPassword");
    var passwordMessage = document.getElementById("pass1Message");

    if(inputPassword.value == "")
    {
        inputPassword.style.border = "red 1px solid";
        passwordMessage.style.display = "block";
    }else
    {
        inputPassword.style.border = "#bdb597 1px solid";
        passwordMessage.style.display = "none";
    }

    var pass2 = document.getElementById("inputPasswordConfirm");
    var pass2Message = document.getElementById("pass2Message");
    var pass2Invalid = document.getElementById("pass2Invalid");

    if(pass2.value == "")
    {
        pass2.style.border = "red 1px solid";
        pass2Message.style.display = "block";
    }else
    {
        pass2.style.border = "#bdb597 1px solid";
        pass2Message.style.display = "none";
    }
    if(!(pass2.value == "") && pass2.value != inputPassword.value)
    {
        pass2.style.border = "red 1px solid";
        pass2Invalid.style.display = "block";
    }else
    {
        pass2.style.border = "#bdb597 1px solid";
        pass2Invalid.style.display = "none";
    }

    var inputName = document.getElementById("inputName");
    var nameMessage = document.getElementById("nameMessage");

    if(inputName.value == "")
    {
        inputName.style.border = "red 1px solid";
        nameMessage.style.display = "block";
    }else
    {
        inputName.style.border = "#bdb597 1px solid";
        nameMessage.style.display = "none";
    }

    var inputPhone = document.getElementById("inputPhone");
    var phoneMessage = document.getElementById("phoneMessage");

    if(inputPhone.value == "")
    {
        inputPhone.style.border = "red 1px solid";
        phoneMessage.style.display = "block";
    }else
    {
        inputPhone.style.border = "#bdb597 1px solid";
        phoneMessage.style.display = "none";
    }

    var inputEmail = document.getElementById("inputEmail");
    var emailMessage = document.getElementById("emailMessage");

    if(inputEmail.value == "")
    {
        inputEmail.style.border = "red 1px solid";
        emailMessage.style.display = "block";
    }else
    {
        inputEmail.style.border = "#bdb597 1px solid";
        emailMessage.style.display = "none";
    }

    var inputTown = document.getElementById("inputTown");
    var townMessage = document.getElementById("townMessage");

    if(inputTown.value == "")
    {
        inputTown.style.border = "red 1px solid";
        townMessage.style.display = "block";
    }else
    {
        inputTown.style.border = "#bdb597 1px solid";
        townMessage.style.display = "none";
    }
}

function cancel(){
    //var cancel = document.getElementById("cancelReg");

    window.location.assign("http://localhost:36735/Exam/index.html#/")
}