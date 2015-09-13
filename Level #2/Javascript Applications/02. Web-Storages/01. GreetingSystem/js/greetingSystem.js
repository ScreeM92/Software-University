$(document).ready(function () {
    function createStorageObject() {
        if (!localStorage.greetingSystem) {
            localStorage.setItem('greetingSystem', JSON.stringify({ totalVisits: 0 }));
        }
        if (!sessionStorage.greetingSystem) {
            sessionStorage.setItem('greetingSystem', JSON.stringify({ visits: 0 }));
        }
    };

    function welcome() {
        var storageGreetingSystem = JSON.parse(localStorage.getItem('greetingSystem'));
        if (storageGreetingSystem.name) {
            $('#welcome-message').text('Welcome, ' + storageGreetingSystem.name);
            $('#name-enter').hide().next().show();
        } else {
            $('#welcome-message').text('');
            $('#logout').hide().prev().show();
        }
    }

    function showVisits() {
        var sessionGreetingSystem = JSON.parse(sessionStorage.getItem('greetingSystem'));
        var visits = 'Visits ' + (sessionGreetingSystem ? sessionGreetingSystem.visits : 0);
        $('#visits').html(visits);

        var storageGreetingSystem = JSON.parse(localStorage.getItem('greetingSystem'));
        var totalVisits = 'Total visits ' + (storageGreetingSystem ? storageGreetingSystem.totalVisits : 0);
        $('#total-visits').html(totalVisits);
    };

    function updateVisits() {
        var storageGreetingSystem = JSON.parse(localStorage.getItem('greetingSystem'));
        storageGreetingSystem.totalVisits++;
        localStorage.setItem('greetingSystem', JSON.stringify(storageGreetingSystem));

        var sessionGreetingSystem = JSON.parse(sessionStorage.getItem('greetingSystem'));
        sessionGreetingSystem.visits++;
        sessionStorage.setItem('greetingSystem', JSON.stringify(sessionGreetingSystem));
    };

    (function init() {
        createStorageObject();
        welcome();
        updateVisits();
        showVisits();
    }());

    $('#clearLocalStorage').click(function () {
        localStorage.clear();
        createStorageObject();
        showVisits();
    });

    $('#clearSessionStorage').click(function () {
        sessionStorage.clear();
        createStorageObject();
        showVisits();
    });

    $('#name-send').click(function () {
        var name = $('#name-input').val();

        if (name) {
            var storageGreetingSystem = JSON.parse(localStorage.getItem('greetingSystem'));

            storageGreetingSystem.name = name;
            localStorage.setItem('greetingSystem', JSON.stringify(storageGreetingSystem));

            welcome();
        }
    });

    $('#logout-button').click(function() {
        var storageGreetingSystem = JSON.parse(localStorage.getItem('greetingSystem'));
        delete storageGreetingSystem.name;
        localStorage.setItem('greetingSystem', JSON.stringify(storageGreetingSystem));
        $('#name-input').val('');

        welcome();
    });
});