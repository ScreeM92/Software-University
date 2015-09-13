function traverse(node) {
    var elements = document.querySelectorAll(node);

    if (elements.nodeType === document.HTMLElement) {
        for (var i = 0, elLen = elements.length; i < elLen; i += 1) {
            changeInnerHtml("<span style=\"color:red\"><b>Element: " + (i + 1) + "</b></span>");
            traverseNode(elements[i], '');
        }
    }

    function traverseNode(node, spacing) {
        spacing = spacing || '  ';
        var output = spacing + node.nodeName.toLowerCase() + ":";
        var elId = node.getAttribute('id');
        var elClass = node.getAttribute('class');

        if (elId != null) {
            output += " id=\"" + elId + "\"";
        }

        if (elClass != null) {
            output += " class=\"" + elClass + "\"";
        }

        changeInnerHtml(output);
        
        for (var j = 0, len = node.childNodes.length; j < len; j += 1) {
            var child = node.childNodes[j];
            if (child.nodeType === document.ELEMENT_NODE) {
                traverseNode(child, spacing + '  ');
            }
        }
    }
    
    function changeInnerHtml(innerHtml) {
        var element = document.getElementById("js");
        element.innerHTML += innerHtml + "</br>";
    }
}

var selector = ".birds";
traverse(selector);