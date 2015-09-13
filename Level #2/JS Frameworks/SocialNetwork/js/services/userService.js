/**
 * Created by Dimitar on 6.1.2015 г..
 */
'use strict';

app.factory('userService',
    function ($http, baseServiceUrl, authService) {
        return {
            createNewAd: function (adData, success, error) {
                var request = {
                    method: 'POST',
                    url: baseServiceUrl + '/api/user/ads',
                    headers: authService.getAuthHeaders(),
                    data: adData
                };
                $http(request).success(success).error(error);
            },
            getUsersNews: function (params, success, error) {
                console.log(params.pageSize);
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/me/feed?StartPostId=&PageSize=' + params.pageSize,
                    headers: authService.getAuthHeaders(),
                };
                $http(request).success(success).error(error);
            },
            showComments: function (id, success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/posts/' + id + '/comments',
                    headers: authService.getAuthHeaders(),
                };
                $http(request).success(success).error(error);
            },
            commentPost: function (text, id, success, error) {
                var request = {
                    method: 'POST',
                    url: baseServiceUrl + '/api/posts/' + id +'/comments',
                    headers: authService.getAuthHeaders(),
                    data: {commentContent : text}
                };
                $http(request).success(success).error(error);
            },
            getUsersFriends: function (params, success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/me/friends',
                    headers: authService.getAuthHeaders(),
                    params: params
                };
                $http(request).success(success).error(error);
            },
            searchUsers: function (data, success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/users/search?searchTerm=' + data,
                    headers: authService.getAuthHeaders()
                };
                $http(request).success(success).error(error);
        },

            getUserData: function (params, success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/me',
                    headers: authService.getAuthHeaders(),
                    params: params
                };
                $http(request).success(success).error(error);
            },

            getCurrentAd: function (id, success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/user/ads/' + id,
                    headers: authService.getAuthHeaders()
                };
                $http(request).success(success).error(error);
            },

            deactivateAd: function (id, success, error) {
                var request = {
                    method: 'PUT',
                    url: baseServiceUrl + '/api/user/ads/deactivate/' + id,
                    headers: authService.getAuthHeaders()
                };
                $http(request).success(success).error(error);
            },

            publishAgainAd: function (id, success, error) {
                var request = {
                    method: 'PUT',
                    url: baseServiceUrl + '/api/user/ads/publishAgain/' + id,
                    headers: authService.getAuthHeaders()
                };
                $http(request).success(success).error(error);
            },

            deleteAd: function (id, success, error) {
                var request = {
                    method: 'DELETE',
                    url: baseServiceUrl + '/api/user/ads/' + id,
                    headers: authService.getAuthHeaders()
                };
                $http(request).success(success).error(error);
            }
        }
    }
);