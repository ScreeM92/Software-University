var app = app || {};
validation = {
    header: {
        'X-Parse-Application-Id': 'gBxtJ8j1z5sRZhOgtAstvprePygEIvYTxY4VNQOY',
        'X-Parse-REST-API-Key': 'CLU5dIerpE1k9zX06HiR3RxJQA3Vob2NgJarCl4z',
        'Content-Type': 'application/json'
    },

    hideRegistrationButton: function () {
        $('body').find('#reg-btn').attr('disabled','disabled');
    },

    showRegistrationButton: function () {
        $('body').find('#reg-btn').removeAttr('disabled');
    },

    checkUsernameForLength: function (userName) {
        return userName.isLongEnough();
    },

    checkIfPasswordsMatch: function(password, repeatPassword) {
        return password === repeatPassword;
    },

    checkEmail: function(email) {
        var regExp = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
        return (email.match(regExp));
    },

    checkPasswordStrength: function(password) {
        var strength = 0;
        if(password.length > 6) {
            strength += 1;
        }

        if(password.match(/[A-Z]+/g)) {
            strength += 1;
        }

        if(password.match(/[a-z]+/g)) {
            strength += 1;
        }

        if(password.match(/[!,@,#,$,%,^,&,*,(,),{,},?,~,=,_,\+,\.,\[,\],\<,\>]+/g)) {
            strength += 1;
        }

        switch (strength) {
            case 0:
                return 'weak';
                break;

            case 1:
                return 'medium';
                break;

            case 2:
                return 'good';
                break;

            case 3:
                return 'strong';
                break;

            case 4:
                return 'excellent';
                break;
        }
    }
};

String.prototype.isAlphaNumeric = function() {
    var regExp = /^[A-Za-z0-9]+$/;
    return (this.match(regExp));
};

String.prototype.isLongEnough = function () {
    return this.length >= 5;
};