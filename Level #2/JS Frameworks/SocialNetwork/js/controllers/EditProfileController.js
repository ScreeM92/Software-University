/**
 * Created by Dimitar on 7.1.2015 г..
 */
app.controller('EditProfileController', function ($scope, $rootScope, notifyService, userService,
                                                  editService, townsService) {
    $rootScope.showRightSidebar = false;
    $rootScope.ngViewSize = 'col-md-10';
    $scope.userData = {};

    userService.getUserData(
           null,
           function (data) {
                $scope.userData = data;
           },
           function (err) {
               console.log('Error getting user data: ' + err);
           }
       );

    $scope.editProfile = function (data) {
        editService.editProfile(data,
        function success () {
            notifyService.showInfo('Success: profile edited!');
        }, function error (err) {
            if(err.message != null)
            {
                err = err.message;
            }
            notifyService.showError('Error: ' + err);
        });
    };

    $scope.fileSelected = function(fileInputField) {
        delete $scope.userData.profileImageData;
        var file = fileInputField.files[0];
        if (file.type.match(/image\/.*/)) {
            var reader = new FileReader();
            reader.onload = function() {
                $scope.userData.profileImageData = reader.result;
                $(".image-box").html("<img src='" + reader.result + "'>");
            };
            reader.readAsDataURL(file);
        } else {
            $(".image-box").html("<p>File type not supported!</p>");
        }
    };

    $scope.fileCoverSelected = function(fileInputField) {
            delete $scope.userData.coverImageData;
            var file = fileInputField.files[0];
            if (file.type.match(/image\/.*/)) {
                var reader = new FileReader();
                reader.onload = function() {
                    $scope.userData.coverImageData = reader.result;
                    $(".image-box-cover").html("<img src='" + reader.result + "'>");
                };
                reader.readAsDataURL(file);
            } else {
                $(".image-box-cover").html("<p>File type not supported!</p>");
            }
        };
});