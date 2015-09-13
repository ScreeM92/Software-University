describe('#registrationValidation', function () {
    /* email function test*/
    it('when only first name is entered expect email function to return null', function () {
        var actual = validation.checkEmail('georgi');
        var expected = null;
        expect(actual).to.equal(expected);
    });
    it('when only first name and last name are entered expect email function to return null', function () {
        var actual = validation.checkEmail('georgi iliev');
        var expected = null;
        expect(actual).to.equal(expected);
    });
    it('when only first name, last name and @ are entered expect email function to return null', function () {
        var actual = validation.checkEmail('georgi_iliev@');
        var expected = null;
        expect(actual).to.equal(expected);
    });
    it('when only first name, last name, @ and .  are entered expect email function to return null', function () {
        var actual = validation.checkEmail('georgi_iliev@.');
        var expected = null;
        expect(actual).to.equal(expected);
    });

    it('when valid email is entered do not expect email function to return null', function () {
        var actual = validation.checkEmail('georgi_iliev@yahoo.com');
        var expected = null;
        expect(actual).not.to.equal(expected);
    });

    /*checkIfPasswordsMatch function test */
    it('if the same strings are entered the function should return true', function () {
        var actual = validation.checkIfPasswordsMatch('javascriptRules', 'javascriptRules');
        var expected = true;
        expect(actual).to.equal(expected);
    });
    it('if different strings are entered the function should return false', function () {
        var actual = validation.checkIfPasswordsMatch('javascriptRuleZ', 'javascriptRules');
        var expected = false;
        expect(actual).to.equal(expected);
    });

    /* checkUsernameForLength function test */
    it('if a string is 5 chars long return true', function () {
        var actual = validation.checkUsernameForLength('12345');
        var expected = true;
        expect(actual).to.equal(expected);
    });
    it('if a string is more than 5 chars long return true', function () {
        var actual = validation.checkUsernameForLength('123456');
        var expected = true;
        expect(actual).to.equal(expected);
    });
    it('if a string is less than 5 chars long return false', function () {
        var actual = validation.checkUsernameForLength('1234');
        var expected = false;
        expect(actual).to.equal(expected);
    });

    /* check password strength function */
    it('if a string is 6 characters long return weak', function () {
        var actual = validation.checkPasswordStrength('123456');
        var expected = 'weak';
        expect(actual).to.equal(expected);
    });
    it('if a string is more than 6 characters long(not containing symbol, uppercase, lowercase) return medium', function () {
        var actual = validation.checkPasswordStrength('1234567');
        var expected = 'medium';
        expect(actual).to.equal(expected);
    });
    it('if a string is more than 6 characters long plus symbol return good', function () {
        var actual = validation.checkPasswordStrength('1234567!');
        var expected = 'good';
        expect(actual).to.equal(expected);
    });
    it('if a string is more than 6 characters long plus symbol and a lowercase char return strong', function () {
        var actual = validation.checkPasswordStrength('1234567!a');
        var expected = 'strong';
        expect(actual).to.equal(expected);
    });

    it('if a string is more than 6 characters long plus symbol,lowercase and uppercase char return strong', function () {
        var actual = validation.checkPasswordStrength('1234567!aA');
        var expected = 'excellent';
        expect(actual).to.equal(expected);
    });
});