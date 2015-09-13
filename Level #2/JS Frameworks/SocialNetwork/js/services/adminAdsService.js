/**
 * Created by Dimitar on 11.1.2015 г..
 */
'use strict';

app.factory('adminAdsService',
    function ($resource, $http, baseServiceUrl, authService) {
        var adminAdsResource = $resource(
            baseServiceUrl + '/api/admin/ads',
            null,
            {
                'getAll': {method: 'GET',
                    headers: authService.getAuthHeaders()}
            }
        );

        return {
            getAdminAds: function (params, success, error) {
                return adminAdsResource.getAll(params, success, error);
            },

            rejectAd: function (ad, success, error) {
                var request = {
                    method: 'PUT',
                    url: baseServiceUrl + '/api/admin/ads/reject/' + ad.id,
                    headers: authService.getAuthHeaders()
                };
                $http(request).success(success).error(error);
            },

            approveAd: function (ad, success, error) {
                var request = {
                    method: 'PUT',
                    url: baseServiceUrl + '/api/admin/ads/approve/' + ad.id,
                    headers: authService.getAuthHeaders()
                };
                $http(request).success(success).error(error);
            },

            deleteAd: function (ad, success, error) {
                var request = {
                    method: 'DELETE',
                    url: baseServiceUrl + '/api/admin/ads/' + ad.id,
                    headers: authService.getAuthHeaders()
                };
                $http(request).success(success).error(error);
            }
        }
    }
);