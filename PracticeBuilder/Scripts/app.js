var app = angular.module('practiceBuilder', []);


app.controller("practiceCtrl", function ($scope, $http) {
    $scope.current = {name:"ok", info:"yes"};

    $scope.popUpPose = function (pose) {
        $scope.current = pose;
    };

    $scope.practices =
    [
        {
            name: "Practice1",
            poses:
            [
                {
                    name: "Triangle",
                    breaths: 8,
                    side: "R",
                    thumb: "https://upload.wikimedia.org/wikipedia/commons/9/9d/Trikonasana_Yoga-Asana_Nina-Mel.jpg",
                    info: "looooooooorem ipsum"
                },
                {
                    name: "Triangle",
                    breaths: 8,
                    side: "R",
                    thumb: "https://upload.wikimedia.org/wikipedia/commons/9/9d/Trikonasana_Yoga-Asana_Nina-Mel.jpg",
                    info: "looooooooorem ipsum"
                },
                {
                    name: "Triangle",
                    breaths: 8,
                    side: "R",
                    thumb: "https://upload.wikimedia.org/wikipedia/commons/9/9d/Trikonasana_Yoga-Asana_Nina-Mel.jpg",
                    info: "looooooooorem ipsum"
                }
            ]
        },
        {
            name: "Practice2",
            poses:
            [
                {
                    name: "Triangle2",
                    breaths: 8,
                    side: "R",
                    thumb: "https://upload.wikimedia.org/wikipedia/commons/9/9d/Trikonasana_Yoga-Asana_Nina-Mel.jpg",
                    info: "looooooooorem ipsum"
                },
                {
                    name: "Triangle2",
                    breaths: 8,
                    side: "R",
                    thumb: "https://upload.wikimedia.org/wikipedia/commons/9/9d/Trikonasana_Yoga-Asana_Nina-Mel.jpg",
                    info: "looooooooorem ipsum"
                },
                {
                    name: "Triangle2",
                    breaths: 8,
                    side: "R",
                    thumb: "https://upload.wikimedia.org/wikipedia/commons/9/9d/Trikonasana_Yoga-Asana_Nina-Mel.jpg",
                    info: "looooooooorem ipsum"
                }
            ]
        },
        {
            name: "Practice3",
            poses:
            [
                {
                    name: "Triangle3",
                    breaths: 8,
                    side: "R",
                    thumb: "https://upload.wikimedia.org/wikipedia/commons/9/9d/Trikonasana_Yoga-Asana_Nina-Mel.jpg",
                    info: "looooooooorem ipsum"
                },
                {
                    name: "Triangle3",
                    breaths: 8,
                    side: "R",
                    thumb: "https://upload.wikimedia.org/wikipedia/commons/9/9d/Trikonasana_Yoga-Asana_Nina-Mel.jpg",
                    info: "looooooooorem ipsum"
                },
                {
                    name: "Triangle3",
                    breaths: 8,
                    side: "R",
                    thumb: "https://upload.wikimedia.org/wikipedia/commons/9/9d/Trikonasana_Yoga-Asana_Nina-Mel.jpg",
                    info: "looooooooorem ipsum"
                }
            ]
        }
    ]
    $scope.basePoses =
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

/*
app.controller("slideCtrl", function ($scope, $http) {

});

app.controller("formCtrl", function ($scope, $http) {

});

app.controller.("basePoseCtrl", function($scope, $http){

});*/