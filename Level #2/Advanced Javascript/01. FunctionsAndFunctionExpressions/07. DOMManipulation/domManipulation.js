var domModule = function () {
    function appendChild(child, parent) {
        this.parent = retrieveElements(parent);
        this.child = createElement(child);
        
        if (this.parent !== null) {
            for (var i = 0, len = this.parent.length; i < len; i += 1) {
                this.parent[i].appendChild(this.child.cloneNode(true));
            }
        }
    }

    function removeChild(parent, selector) {
        this.parent = retrieveElements(parent);

        if (this.parent !== null) {
            for (var i = 0, len = this.parent.length; i < len; i += 1) {
                this.children = getChildren(this.parent[i], selector);
                for (var j = 0, childrenLen = this.children.length; j < childrenLen; j += 1) {
                    this.parent[i].removeChild(this.children[j]);
                }
            }
        }
    }

    function addHandler(element, chileventType, eventHandler) {
        this.parent = retrieveElements(element);
        if (this.parent !== null) {
            for (var i = 0, len = this.parent.length; i < len; i += 1) {
                this.parent[i].addEventListener(chileventType, eventHandler);
            }
        }
    }

    function retrieveElements(element) {
        if (element.nodeType !== document.ELEMENT_NODE) {
            var domElement = document.querySelectorAll(element);

            return domElement;
        }

        return element;
    }

    function createElement(element) {
        if (element.nodeType !== document.ELEMENT_NODE) {
            var newElement = document.createElement(element);

            return newElement;
        }

        return element;
    }

    function getChildren(parent, selector) {
        var children = parent.querySelectorAll(":scope > " + selector);

        return children;
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        retrieveElements: retrieveElements
    };
}();

// Appends a list item to ul.birds-list
var liElement = document.createElement("li");
liElement.innerHTML = "New LI element added with javascript";
liElement.style.color = "red";
domModule.appendChild(liElement, ".birds-list");

// Removes the first li child from the bird list
domModule.removeChild("ul.birds-list", "li:first-child");

// Retrives all elements of class "bird"
var elements = domModule.retrieveElements(".bird");

// Adds a click event to all bird list items
domModule.addHandler("li.bird", 'click', function () { alert("I'm a bird!") });