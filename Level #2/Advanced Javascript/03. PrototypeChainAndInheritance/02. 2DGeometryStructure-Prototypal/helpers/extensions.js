(function() {
    Object.prototype.extends = function (properties) {
        function f() { }
        var prop;
        f.prototype = Object.create(this);
        for (prop in properties) {
            f.prototype[prop] = properties[prop];
        }

        f.prototype._super = this;
        return new f();
    };
}());
