'use strict';

var app = angular.module('app', ['ngRoute', 'ngResource', 'ui.bootstrap.pagination']);

app.constant('baseServiceUrl', 'http://softuni-social-network.azurewebsites.net');
app.constant('pageSize', 2);

app.config(function ($routeProvider) {
    $routeProvider.when('/', {
        templateUrl: 'templates/home.html',
        controller: 'HomeController'
    });

    $routeProvider.when('/login', {
        templateUrl: 'templates/login.html',
        controller: 'LoginController'
    });

    $routeProvider.when('/register', {
        templateUrl: 'templates/register.html',
        controller: 'RegisterController'
    });

    $routeProvider.when('/user/friends', {
        templateUrl: 'templates/user/friends.html',
        controller: 'FriendsController'
    });

    $routeProvider.when('/user/ads', {
        templateUrl: 'templates/user/personal-ads.html',
        controller: 'UserAdsController'
    });

    $routeProvider.when('/user/profile', {
        templateUrl: 'templates/user/edit-profile.html',
        controller: 'EditProfileController'
    });

    $routeProvider.when('/profile', {
        templateUrl: 'templates/user/profile.html',
        controller: 'ProfileController'
    });

    $routeProvider.when('/user/password', {
        templateUrl: 'templates/user/change-password.html',
        controller: 'ChangePasswordController'
    });

    $routeProvider.when('/user/ads/:id', {
        templateUrl: 'templates/user/edit-ads.html',
        controller: 'EditAdsController'
    });

    $routeProvider.when('/user/ads/deactivate/:id', {
        templateUrl: 'templates/user/personal-ads.html',
        controller: 'UserAdsController'
    });

    $routeProvider.when('/user/ads/publishAgain/:id', {
        templateUrl: 'templates/user/personal-ads.html',
        controller: 'UserAdsController'
    });

    $routeProvider.when('/user/ads/delete/:id', {
        templateUrl: 'templates/user/confirm-delete.html',
        controller: 'DeleteAdController'
    });

    $routeProvider.when('/user/search/:searchTerm', {
        templateUrl: 'templates/partial/search.html', 
        controller: 'SearchController'
    });

    $routeProvider.otherwise(
        { redirectTo: '/' }
    );
});

app.run(function ($rootScope, $location, authService) {
    $rootScope.$on('$locationChangeStart', function (event) {
        if ($location.path().indexOf('/user/') != -1 && !authService.isLoggedIn()) {
            $location.path('/');
        }
    });
});