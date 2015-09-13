$(document).ready(function () {
    var HEADERS = {
        "X-Parse-Application-Id": "yecs8jNrBrCoe7BE1gjqjOFvpdWZWqWZfwxT3xSQ",
        "X-Parse-REST-API-Key": "qZ3cyrP9KfDHlr3LdeTYCDxE07jO9DfIBcJ4FYkX"
    }

    getCountries();
    notification("Click on country to view its' towns", 'information', 'bottom', 5000);
    
    $(document).on('click', '.country', function(){
        if ( $(this).parent().children('.towns').length > 0 ) {
            $(this).parent().children('.towns').slideToggle(); 
        } else {
            getTowns($(this).parent().data('country'), $(this));
        }
    });
    
    $(document).on('click', '#country-edit-section button', function(){
        var newValue = $('#edit-country').val();
        if (newValue) {
            var country = $(this).parent().parent().data('country');
            var element = $(this).parent().parent();

            updateCountry(newValue, country, element);
        } else {
            notification('Country cannot be empty.', 'warning', 'bottom', 3000);
        }
    });
    
    $(document).on('focusout', '#edit-country', function () {
        var el = $(this);
        $('#countries > li').trigger('mouseleave');
        setTimeout(function () {
            el.parent().remove();
        }, 100);
    });
    
    $(document).on('click', '.remove-country', function(){
        var el = $(this).parent().parent();
        var country = el.data('country');
        
        deleteCountry(country, el);
    });
    
    $(document).on('click', '.edit-country', function(){
        var country = $(this).parent().parent().data('country');
        var div = $('<div id="country-edit-section">');
        var input = $('<input id="edit-country">').val(country.name);
        var button = $('<button>').text('ok');
        div.append(input);
        div.append(button);
        $(this).parent().after(div);
        div.hide().slideToggle();
        input.focus().select();
    });
    
    $(document).on('mouseenter', '#countries > li', function () {
            $(this).find(".buttons").hide().fadeIn(100);
        }).on('mouseleave', '#countries > li', function () {
            $(this).find(".buttons").hide();
    });
    
    $(document).on('mouseenter', '.towns > li', function () {
            $(this).find(".town-buttons").hide().fadeIn(100);
        }).on('mouseleave', '.towns > li', function () {
            $(this).find(".town-buttons").hide();
    });
    
    $(document).on('click', '#country-add-button', function(){
        if ($(this).prev().val()) {
            addCountry($(this).prev().val());
        } else {
            notification('Country cannot be empty.', 'warning', 'bottom', 3000);
        };
    });

    $(document).on('click', '#town-add-section button', function () {
        var country = $(this).parent().parent().data('country');
        if ($(this).prev().val()) {
            addTown($(this).prev().val(), country, $(this).parent().parent());
        } else {
            notification('Town cannot be empty.', 'warning', 'bottom', 3000);
        };
    });

    $(document).on('click', '.add-town', function() {
        var div = $('<div id="town-add-section">');
        var input = $('<input id="add-town">');
        var button = $('<button>').text('ok');
        div.append(input);
        div.append(button);
        $(this).parent().after(div);
        div.hide().slideToggle();
        input.focus().select();
    });

    $(document).on('focusout', '#add-town', function () {
        var el = $(this);
        $('#countries > li').trigger('mouseleave');
        setTimeout(function () {
            el.parent().remove();
        }, 100);
    });

    $(document).on('click', '.edit-town', function () {
        var town = $(this).parent().parent().data('town');
        var div = $('<div id="town-edit-section">');
        var input = $('<input id="edit-town">').val(town.name);
        var button = $('<button>').text('ok');
        div.append(input);
        div.append(button);
        $(this).parent().after(div);
        div.hide().slideToggle();
        input.focus().select();
    });

    $(document).on('focusout', '#edit-town', function () {
        var el = $(this);
        $('#countries > li').trigger('mouseleave');
        setTimeout(function () {
            el.parent().remove();
        }, 100);
    });

    $(document).on('click', '#town-edit-section button', function () {
        var newValue = $('#edit-town').val();
        if (newValue) {
            var town = $(this).parent().parent().data('town');
            var element = $(this).parent().parent();

            updateTown(newValue, town, element);
        } else {
            notification('Town cannot be empty.', 'warning', 'bottom', 3000);
        }
    });

    $(document).on('click', '.remove-town', function () {
        var el = $(this).parent().parent();
        var town = el.data('town');

        deleteTown(town, el);
    });
    
    function getCountries() {
        $.ajax({
            method: "GET",
            headers: HEADERS,
            url: 'https://api.parse.com//1/classes/Country',
            success: loadContries,
            error: errorMessage
        });
        
        function loadContries(data){
            data.results.sort(function(a, b){
                return (a.name).localeCompare(b.name);
            });
            
            $.each($(data.results), function(key, country){
                var countryItem = $('<li>').data('country', country);
                $('<span>').addClass('country').text(country.name).appendTo(countryItem);
                var div = $('<span>').addClass('buttons').append($('<button class="add-town" title="add town">+</button><button class="edit-country" title="edit country">e</button><button class="remove-country" title="remove country">x</button>'));
                div.appendTo(countryItem);
                countryItem.hide().appendTo($("#countries")).fadeIn(500);
            });
        };
    };
    
    function addCountry(name){
        $.ajax({
            method: "POST",
            headers: HEADERS,
            data: JSON.stringify({
                'name': name
            }),
            contentType: "application/json",
            url: 'https://api.parse.com//1/classes/Country',
            success: addCountryNode,
            error: errorMessage
        });
        
        function addCountryNode(data){
            data.name = name;
            var li = $('<li>').data('country', data);
            li.append('<span class="country">' + data.name + '</span>');
            li.append('<span class="buttons"><button class="add-town">+</button><button class="edit-country">e</button><button class="remove-country">x</button></span>');
            li.append($('<ul>').addClass('towns'));
            li.appendTo('#countries');
            $('#country-input').val('');
            notification('Country "' + data.name + '" successfully added.', 'success', 'bottom', 3000);
        };
    }
    
    function updateCountry(newName, country, el) {
        $.ajax({
            method: "PUT",
            headers: HEADERS,
            data: JSON.stringify({
                'name': newName
            }),
            contentType: "application/json",
            url: 'https://api.parse.com//1/classes/Country/' + country.objectId,
            success: changeElement,
            error: errorMessage
        });
        
        function changeElement(){
            el.children('.country').text(newName);
            var data = el.data('country');
            data.name = newName;
            notification('Country successfully renamed to "' + data.name + '".', 'success', 'bottom', 3000);
        };
    };
    
    function deleteCountry(country, el){
        $.ajax({
            method: "DELETE",
            headers: HEADERS,
            url: 'https://api.parse.com/1/classes/Country/' + country.objectId,
            success: deleteElement,
            error: errorMessage
        });
        
        function deleteElement(){
            $(el).remove();
            notification('Country "' + country.name + '" successfully deleted.', 'success', 'bottom', 3000);
        }
    };
    
    
    function getTowns(country, el) {
        var path = 'https://api.parse.com//1/classes/Town?include=country&where='
        var countryData = {
            "country":{
                "__type":"Pointer",
                "className":"Country",
                "objectId": country.objectId
            }
        };
        
        $.ajax({
            method: "GET",
            headers: HEADERS,
            url: path + JSON.stringify(countryData),
            success: loadTowns,
            error: errorMessage
        });
        
        function loadTowns(data){
            $(this).empty();
            if (data.results) {
                var towns = $('<ul>').addClass('towns');
                
                $.each($(data.results), function (key, town) {
                    var townItem = $('<li>').data('town', town);
                    $('<span>').addClass('town').text(town.name).appendTo(townItem);
                    var div = $('<span>').addClass('town-buttons').append($('<button class="edit-town" title="edit town">e</button><button class="remove-town" title="remove town">x</button>'));
                    div.appendTo(townItem);
                    townItem.appendTo(towns);
                });
                
                towns.hide().appendTo(el.parent()).slideToggle();
            };
        };
    };

    function addTown(name, country, countryElement) {
        var countryObj = {
            "__type": "Pointer",
            "className": "Country",
            "objectId": country.objectId
        };
        $.ajax({
            method: "POST",
            headers: HEADERS,
            data: JSON.stringify({
                "name": name,
                'country': countryObj
            }),
            contentType: "application/json",
            url: 'https://api.parse.com//1/classes/Town',
            success: addElement,
            error: errorMessage
        });

        function addElement(town) {
            town.name = name;
            town.country = countryObj;
            if (!countryElement.children('.towns')) {
                countryElement.append($('<ul>').addClass('towns'));
            }
            var townItem = $('<li>').data('town', town);
            $('<span>').addClass('town').text(town.name).appendTo(townItem);
            var div = $('<span>').addClass('town-buttons').append($('<button class="edit-town">e</button><button class="remove-town">x</button>'));
            div.appendTo(townItem);
            townItem.appendTo(countryElement.children('.towns'));
            notification('Town "' + town.name + '" successfully added.', 'success', 'bottom', 3000);
        };
    }
    
    function updateTown(newName, town, el) {
        $.ajax({
            method: "PUT",
            headers: HEADERS,
            data: JSON.stringify({
                'name': newName
            }),
            contentType: "application/json",
            url: 'https://api.parse.com//1/classes/Town/' + town.objectId,
            success: changeElement,
            error: errorMessage
        });

        function changeElement() {
            el.children('.town').text(newName);
            var town = el.data('town');
            town.name = newName;
            notification('Town successfully renamed to "' + town.name + '".', 'success', 'bottom', 3000);
        };
    };

    function deleteTown(town, el) {
        $.ajax({
            method: "DELETE",
            headers: HEADERS,
            url: 'https://api.parse.com/1/classes/Town/' + town.objectId,
            success: deleteElement,
            error: errorMessage
        });

        function deleteElement() {
            $(el).remove();
            notification('Town "' + town.name + '" successfully deleted.', 'success', 'bottom', 3000);
        }
    };
    
    function notification(message, type, layout, timeout) {
        noty({
            text: message,
            type: type,
            layout: layout,
            timeout: timeout
        });
    }

    function errorMessage(err) {
        noty({
            text: 'Error: ' + err.status + ' ' + err.responseText,
            type: 'error',
            layout: 'bottom',
            timeout: 3000
        });
    }
});