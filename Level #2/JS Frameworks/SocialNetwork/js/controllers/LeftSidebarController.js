'use strict';

app.controller('LeftSidebarController', function ($scope, $rootScope) {
    $rootScope.selectedMenuItem = 'Home';
    $rootScope.adminAds = null;

    $scope.menuClick = function (option) {
        $rootScope.menuOption = option;
        $rootScope.pageTitle = option;
        $rootScope.selectedMenuItem = option;
        $rootScope.pageSubtitle = null;
    };

    $scope.myAdsMenuClick = function (option) {
        $scope.selectedMyAds = option;
        $rootScope.pageSubtitle = option;
    };

    $scope.adsTypeClicked = function (status) {
        $scope.statusClickedId = status;
        $rootScope.$broadcast("adsByType", status);
    };

    $scope.adminAdsMenuClick = function (option) {
        $scope.adminAdsMenuOption = option;
        $rootScope.$broadcast("adminAdsMenuClick", option);
    };

    $scope.adminAdmMenuClick = function (option) {
        $scope.adminAdmMenuOption = option;
        $rootScope.$broadcast("adminAdmMenuClick", option);
    };
});