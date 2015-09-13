var factory = factory || {};

(function (scope) {
    var REMOVE_BUTTON_TEXT = 'x';
    var ADD_BUTTON_TEXT = '+';

    var loadHTML = function () {
        var wrapper = document.getElementById('wrapper');
        wrapper.innerHTML =
            '<input id="title" placeholder="Enter ToDo title..." />' +
            createSectionsContainer().outerHTML +
            createAddSection().outerHTML;
    }

    var createSectionsContainer = function () {
        var sectionContainer = document.createElement('div');
        sectionContainer.setAttribute('id', 'sections');

        return sectionContainer;
    }

    var createAddSection = function () {
        var addSectionContainer = document.createElement('div');
        addSectionContainer.setAttribute('id', 'build-section');
        addSectionContainer.innerHTML =
            '<input type="text" id="section-add-title" placeholder="Enter section title..." />' +
            '<button id="section-add-button">Add section</button>';

        return addSectionContainer;
    }

    var createSection = function (section) {
        var sectionContainer = document.createElement('section');
        sectionContainer.setAttribute('class', 'section');
        sectionContainer.setAttribute('section-id', section.getId());
        sectionContainer.innerHTML =
            '<button class="section-remove-button" remove-section-id="' + section.getId() + '" title="remove section">'
            + REMOVE_BUTTON_TEXT + '</button>' +
            '<input type="text" class="section-title" value="' + section.getTitle() + '" placeholder="Enter title..."/>' +
            '<div class="items"></div>' +
            '<div class="item-add">' +
            '<input type="text" class="item-content-input" placeholder="Item content..."/>' +
            '<button class="item-add-button" section-add-id="' + section.getId() + '" title="Add item">' + ADD_BUTTON_TEXT + '</button>' +
            '</div>';

        return sectionContainer;
    }

    var createItem = function (item) {
        var itemContainer = document.createElement('div');
        itemContainer.setAttribute('class', 'item');
        itemContainer.setAttribute('item-id', item.getId());
        itemContainer.innerHTML =
            '<input type="checkbox" class="checkbox"/>' +
            '<input type="text" class="item-content" item-content-id="' + item.getId() + '" value="' + item.getContent() + '"/>' +
            '<button class="item-remove-button" remove-item-id="' + item.getId() + '" title="remove item">' + REMOVE_BUTTON_TEXT + '</button>';

        return itemContainer;
    }

    scope.loadHTML = loadHTML;
    scope.createSectionsContainer = createSectionsContainer;
    scope.createAddSection = createAddSection;
    scope.createSection = createSection;
    scope.createItem = createItem;
}(factory));
