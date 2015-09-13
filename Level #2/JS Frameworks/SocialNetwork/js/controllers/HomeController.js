'use strict';

app.controller('HomeController',
    function ($scope, $rootScope, $location, adsService, authService, adminAdsService, notifyService, pageSize, userService) {
        $scope.newsParams = {
            'startPage' : 1,
            'pageSize' : 5,
        };

        //$scope.newsParams.id = ($scope.newsParams.startPage * $scope.newsParams.pageSize) || 1;
        $scope.userData = authService.getCurrentUser();
        $scope.inputUser = ""; 
        $rootScope.ngViewSize = 'col-md-2';

        $scope.getUsersNews = function () {
            userService.getUsersNews(
                $scope.newsParams,
                function success (data) {
                    $scope.news = data;
                }, function error (error) {
                    notifyService.showError('Error: ' + error);
                }
            );
        };

        $scope.showComments = function (post) {
            userService.showComments(
                post.id, 
                function success (data) {
                    post.comments = data;
                }, 
                function error (error) {
                    notifyService.showError('Error: ' + error);
                });
        };

        $scope.commentPost = function (text, id) {
            userService.commentPost(
                text, 
                id,
                function success () {
                    notifyService.showInfo('Success: comment published!');
                }, 
                function error () {
                    notifyService.showError('Error');
                });
        };

        $scope.searchUsers = function (inputUser) {
            $location.path("/user/search/" + inputUser);
        };

        $scope.showFriends = function () {
            $location.path("/user/friends");
        };

       $scope.reloadNews = function() {
           userService.getUsersNews(
               $scope.newsParams,
               function success(data) {
                   $scope.news = data;
               },
               function error(err) {
                   notifyService.showError("Cannot load news", err);
               }
           );
       };

        //$scope.reloadAdminAds = function () {
        //    adminAdsService.getAdminAds(
        //        $scope.adsParams,
        //        function success(data) {
        //            $scope.ads = data;
        //        },
        //        function error(err) {
        //            notifyService.showError("Cannot load ads", err);
        //        }
        //    );
        //};
        //
        //$scope.approveAd = function (ad) {
        //    adminAdsService.approveAd(
        //        ad,
        //        function success () {
        //            notifyService.showInfo('Success: Ad approved!');
        //            ad.status = 'Published';
        //        }, function error () {
        //            notifyService.showError('Error');
        //        }
        //    );
        //};
        //
        //$scope.rejectAd = function (ad) {
        //    adminAdsService.rejectAd(
        //        ad,
        //        function success () {
        //            notifyService.showInfo('Success: Ad rejected!');
        //            ad.status = 'Rejected';
        //        }, function error () {
        //            notifyService.showError('Error');
        //        }
        //    );
        //};
        //
        //$scope.deleteAd = function (ad) {
        //    adminAdsService.deleteAd(
        //        ad,
        //        function success () {
        //            notifyService.showInfo('Success: Ad deleted!');
        //            $scope.reloadAdminAds();
        //        }, function error () {
        //            notifyService.showError('Error');
        //        }
        //    );
        //};

        if (authService.isAdmin()) {
            //$scope.reloadAdminAds();
        }
        if (authService.isLoggedIn()) {
            $scope.getUsersNews();
        }
        //
        //// This event is sent by RightSideBarController when the current category is changed
        //$scope.$on("categorySelectionChanged", function(event, selectedCategoryId) {
        //    $scope.adsParams.categoryId = selectedCategoryId;
        //    $scope.adsParams.startPage = 1;
        //    $scope.reloadAds();
        //});
        //
        //// This event is sent by RightSideBarController when the current town is changed
        //$scope.$on("townSelectionChanged", function(event, selectedTownId) {
        //    $scope.adsParams.townId = selectedTownId;
        //    $scope.adsParams.startPage = 1;
        //    $scope.reloadAds();
        //});
        //
        //$scope.$on("adminAdsMenuClick", function (event, option) {
        //    $scope.adsParams.status = option;
        //    $scope.adsParams.startPage = 1;
        //    $scope.reloadAdminAds();
        //});
    }
);
