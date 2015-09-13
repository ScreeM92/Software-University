var specialConsole = function() {
    function getToString(obj) {
        return obj instanceof String ? obj : obj.toString();
    }

    function getUniqueArray(array) {
        if (array !== null && array !== undefined) {
            return array.reverse().filter(function (e, i, arr) {
                return arr.indexOf(e, i + 1) === -1;
            }).reverse();
        }

        return null;
    }

    function replaceAll(find, replace, str) {
        return str.replace(find, getToString(replace));
    }

    function replacePlaceholders(arg) {
        var placeholders = getUniqueArray(arg[0].match(/{(.*?)}/g));

        if (placeholders === null || placeholders.length !== arg.length - 1) {
            return "Error: Incorrect placeholders format.";
        }

        for (var i = 0; i < placeholders.length; i++) {
            var regExp = /{(\d+)}/g;
            var match = regExp.exec(placeholders[i]);

            if (match === null || match[1] >= arg.length - 1) {
                return "Invalid placeholders";
            }
            
            var pattern = "\\{" + match[1] + "\\}";
            var regex = new RegExp(pattern, "g");
            var index = parseInt(match[1]) + 1;

            arg[0] = replaceAll(regex, arg[index], arg[0]);
        }

        return arg[0];

    }

    function getArguments(arg) {
        if (arg.length === 1) {
            return getToString(arg[0]);
        }

        if (arg.length > 1) {
            return replacePlaceholders(arg);
        }

        return "";
    }
    
    function writeLine() {
        console.log(getArguments(arguments));
    }

    function writeWarning() {
        console.warn(getArguments(arguments));
    }

    function writeError() {
        console.error(getArguments(arguments));
    }

    function writeInfo() {
        console.info(getArguments(arguments));
    }

    return {
        writeLine: writeLine,
        writeWarning: writeWarning,
        writeError: writeError,
        writeInfo: writeInfo
    }
}();

specialConsole.writeLine("Message: hello");
specialConsole.writeLine("Message: {0}", "hello");
specialConsole.writeLine("Object: {0}", { name: "Gosho", toString: function() { return this.name } });
specialConsole.writeError("Error: {0}", "A fatal error has occurred.");
specialConsole.writeWarning("Warning: {0}", "You are not allowed to do that!");
specialConsole.writeInfo("Info: {0}", "Hi there! Here is some info for you.");
specialConsole.writeError("Error object: {0}", { msg: "An error happened", toString: function() { return this.msg } });