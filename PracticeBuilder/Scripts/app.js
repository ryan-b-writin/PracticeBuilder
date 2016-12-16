var app = angular.module('practiceBuilder', []);


app.controller("practiceCtrl", function ($scope, $http) {

    $scope.practice =
    [
        { name: "Triangle", breaths: 8, side: "R", thumb: "https://upload.wikimedia.org/wikipedia/commons/9/9d/Trikonasana_Yoga-Asana_Nina-Mel.jpg" },
        { name: "Triangle", breaths: 8, side: "R", thumb: "https://upload.wikimedia.org/wikipedia/commons/9/9d/Trikonasana_Yoga-Asana_Nina-Mel.jpg" },
        { name: "Triangle", breaths: 8, side: "R", thumb: "https://upload.wikimedia.org/wikipedia/commons/9/9d/Trikonasana_Yoga-Asana_Nina-Mel.jpg" },
        { name: "Triangle", breaths: 8, side: "R", thumb: "https://upload.wikimedia.org/wikipedia/commons/9/9d/Trikonasana_Yoga-Asana_Nina-Mel.jpg" },
        { name: "Triangle", breaths: 8, side: "R", thumb: "https://upload.wikimedia.org/wikipedia/commons/9/9d/Trikonasana_Yoga-Asana_Nina-Mel.jpg" },
        { name: "Triangle", breaths: 8, side: "R", thumb: "https://upload.wikimedia.org/wikipedia/commons/9/9d/Trikonasana_Yoga-Asana_Nina-Mel.jpg" },
        { name: "Triangle", breaths: 8, side: "R", thumb: "https://upload.wikimedia.org/wikipedia/commons/9/9d/Trikonasana_Yoga-Asana_Nina-Mel.jpg" },
        { name: "Triangle", breaths: 8, side: "R", thumb: "https://upload.wikimedia.org/wikipedia/commons/9/9d/Trikonasana_Yoga-Asana_Nina-Mel.jpg" },
        { name: "Triangle", breaths: 8, side: "R", thumb: "https://upload.wikimedia.org/wikipedia/commons/9/9d/Trikonasana_Yoga-Asana_Nina-Mel.jpg" },
        { name: "Triangle", breaths: 8, side: "R", thumb: "https://upload.wikimedia.org/wikipedia/commons/9/9d/Trikonasana_Yoga-Asana_Nina-Mel.jpg" }
    ];
});

app.controller("slideCtrl", function ($scope, $http) {

});