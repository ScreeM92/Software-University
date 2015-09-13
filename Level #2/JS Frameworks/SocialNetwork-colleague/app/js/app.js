var app = angular.module('SocialNetworkApp', ['ngAnimate', 'ngRoute', 'ngResource', 'infinite-scroll', 'ui.bootstrap', 'angularSpinner', 'rt.popup']);

app.config(function ($routeProvider, $httpProvider) {
    $httpProvider.interceptors.push('authHttpResponseInterceptor');

    $routeProvider
        .when('/login/', {
            templateUrl:'templates/login.html',
            controller: 'mainController',
            resolve:{
                isLogged: function($location){
                    if(localStorage.getItem('accessToken')){
                        $location.path('/');
                    }
                }
            }
        })
        .when('/register/', {
            templateUrl: 'templates/register.html',
            controller: 'mainController',
            resolve:{
                isLogged: function($location){
                    if(localStorage.getItem('accessToken')){
                        $location.path('/');
                    }
                }
            }
        })
        .when('/user/:username/wall/', {
            templateUrl: 'templates/wall.html',
            controller: 'mainController',
            resolve:{
                isLogged: function($location){
                    if(!localStorage.getItem('accessToken')){
                        $location.path('/');
                    }
                }
            }
        })
        .when('/settings/edit/details/', {
            templateUrl: 'templates/profile-details.html',
            controller: 'mainController',
            resolve:{
                isLogged: function($location){
                    if(!localStorage.getItem('accessToken')){
                        $location.path('/');
                    }
                }
            }
        })
        .when('/settings/edit/password/', {
            templateUrl: 'templates/profile-password.html',
            controller: 'mainController',
            resolve:{
                isLogged: function($location){
                    if(!localStorage.getItem('accessToken')){
                        $location.path('/');
                    }
                }
            }
        })
        .when('/user/:username/friends/', {
            templateUrl: 'templates/friends.html',
            controller: 'mainController',
            resolve:{
                isLogged: function($location){
                    if(!localStorage.getItem('accessToken')){
                        $location.path('/');
                    }
                }
            }
        })
        .when('/friends/requests/', {
            templateUrl: 'templates/pending-requests.html',
            controller: 'mainController',
            resolve:{
                isLogged: function($location){
                    if(!localStorage.getItem('accessToken')){
                        $location.path('/');
                    }
                }
            }
        })
        .when('/404/', {
            templateUrl: 'templates/not-found.html',
            controller: 'mainController',
            resolve:{
                isLogged: function($location){
                    if(!localStorage.getItem('accessToken')){
                        $location.path('/');
                    }
                }
            }
        })
        .when('/', {
            templateUrl: 'templates/home.html',
            controller: 'mainController'
        })
        .otherwise({redirectTo: '/'})
});

app.constant({
    'BASE_URL':'http://softuni-social-network.azurewebsites.net/api/',
    'PAGE_SIZE': 5,
    'DEFAULT_PROFILE_IMAGE': 'data:image/png;base64,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'
});
