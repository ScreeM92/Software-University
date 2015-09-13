var toDo = toDo || {};

(function (scope) {
    var container,
        wrapper;

    var init = function () {
        container = new models.Container();
        wrapper = document.getElementById('wrapper');
        factory.loadHTML();
        addEventListeners();
    }

    var addEventListeners = function () {
        wrapper.addEventListener('click', function (ev) {
            if (ev.target.getAttribute('id') === 'section-add-button') {
                addSection(ev);
            };

            if (ev.target.getAttribute('class') === 'section-remove-button') {
                removeSection(ev);
            };

            if (ev.target.getAttribute('class') === 'item-add-button') {
                addItem(ev);
            };

            if (ev.target.getAttribute('class') === 'item-remove-button') {
                removeItem(ev);
            };

            if (ev.target.getAttribute('class') === 'checkbox') {
                changeStatus(ev);
            };
        });

        wrapper.addEventListener('change', function (ev) {
            if (ev.target.getAttribute('id') === 'title') {
                container.changeTitle(ev.target.value);
            };

            if (ev.target.getAttribute('class') === 'item-content') {
                changeContent(ev);
            };

            if (ev.target.getAttribute('class') === 'section-title') {
                changeTitle(ev);
            };
        });
    };

    var addSection = function (ev) {
        var title,
            newSection,
    		newSectionHTML;

        title = document.getElementById('section-add-title');
        newSection = new models.Section(title.value);
        title.value = '';
        container.addSection(newSection);
        newSectionHTML = factory.createSection(newSection);

        document.getElementById('sections').appendChild(newSectionHTML);
    }

    var removeSection = function (ev) {
        var sectionId,
            section;

        sectionId = parseInt(ev.target.getAttribute('remove-section-id'));
        section = document.querySelector('[section-id="' + sectionId + '"]');
        container.deleteSectionById(sectionId);
        section.parentElement.removeChild(section);
    }

    var addItem = function (ev) {
        var sectionId,
            content,
            itemsContainer,
            newItem,
            section,
            newItemHTML;

        sectionId = parseInt(ev.target.getAttribute('section-add-id'));
        content = document.querySelector('[section-id="' + sectionId + '"]').getElementsByClassName('item-content-input')[0];
        itemsContainer = document.querySelector('[section-id="' + sectionId + '"]').getElementsByClassName('items')[0];
        newItem = new models.Item(content.value);
        section = getSection(sectionId);
        section.addItem(newItem);
        newItemHTML = factory.createItem(newItem);
        itemsContainer.appendChild(newItemHTML);
        content.value = '';
    }

    var removeItem = function (ev) {
        var sectionId,
            itemId,
            section;

        sectionId = getSectionId(ev);
        itemId = parseInt(ev.target.getAttribute('remove-item-id'));
        ev.target.parentElement.parentElement.removeChild(ev.target.parentElement);
        section = getSection(sectionId);
        section.deleteItemById(itemId);
    }

    var changeStatus = function (ev) {
        var sectionId,
            itemId,
            section,
            item;

        sectionId = getSectionId(ev);
        itemId = parseInt(ev.target.parentElement.getAttribute('item-id'));
        section = getSection(sectionId);
        item = getItem(itemId, section);
        item.changeStatus(ev.target.checked);

        if (ev.target.checked) {
            ev.target.nextSibling.setAttribute('disabled', false);
        } else {
            ev.target.nextSibling.removeAttribute('disabled');
        }
    }

    var changeTitle = function (ev) {
        var sectionId,
            section;

        sectionId = getSectionId(ev);
        section = getSection(sectionId);
        section.changeTitle(ev.target.value);
    }

    var changeContent = function (ev) {
        var sectionId,
            itemId,
            section,
            item;

        sectionId = getSectionId(ev);
        itemId = parseInt(ev.target.parentElement.getAttribute('item-id'));
        section = getSection(sectionId);
        item = getItem(itemId, section);
        item.changeContent(ev.target.value);
    }

    var getSectionId = function (ev) {
        var parent = ev.target;

        while (parent.className !== 'section') {
            parent = parent.parentElement;
        }

        var sectionId = parseInt(parent.getAttribute('section-id'));

        return sectionId;
    }

    var getSection = function (sectionId) {
        var section = container.getSections().filter(function (section) {
            return section.getId() === sectionId;
        })[0];

        return section;
    }

    var getItem = function (itemId, section) {
        var item = section.getItems().filter(function (i) {
            return i.getId() === itemId;
        })[0];

        return item;
    }

    scope.init = init;
}(toDo));