app.controller('StudentController', function($scope){
    var students = [
        {
            "name": "Pesho",
            "photo": "http://d1ty0e8cxefhfl.cloudfront.net/images/profiles/profile-unknown-male.png",
            "grade": 6,
            "school": "High School of Mathematics",
            "teacher": "Gichka Pesheva"
        },
        {
            "name": "Gosho",
            "photo": "http://www.ctacis.com/member/Ctacis/profile/user.png",
            "grade": 3,
            "school": "High School of Music and art",
            "teacher": "Mara Ivanova"
        },
        {
            "name": "Tosho",
            "photo": "http://cdn.playbuzz.com/cdn/16bb5e45-03e9-433c-8f85-befc39203662/f361ac59-a81c-46e5-813a-4d622109e88d.png",
            "grade": 5,
            "school": "High School of Computers and technology",
            "teacher": "Penka Todorova"
        },
        {
            "name": "Ivan",
            "photo": "http://www.monarch-teaching-jobs.co.uk/wp-content/uploads/2011/11/middle-east-male-shirt.jpg",
            "grade": 2,
            "school": "High School of Business and finance",
            "teacher": "Ivan Ivanov"
        }
    ];

    $scope.students = students;
});