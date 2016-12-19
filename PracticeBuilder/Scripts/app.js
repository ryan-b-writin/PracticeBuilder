var app = angular.module('practiceBuilder', []);


app.controller("practiceCtrl", function ($scope, $http) {

    //Yogi ----------------------------------------------------------------------------------

    $scope.generateNewPractice = function () {
        $http({
            method: "POST",
            url: "/api/Practice",
            data: $scope.newPractice
        })
        .success(function (response) {
            console.log("success!", $scope.newPractice);
        })
        .error(function (response) {
            console.log("error!");
        })
    }

    //Practice -----------------------------------------------------------------------

    $scope.addToPractice = function (pose) {
        let newPose = {
            name: "",
            breaths: "",
            side: "",
            thumb: "",
            info: ""
        }
        newPose.name = pose.Name;
        newPose.breaths = pose.DurationSuggestion;
        newPose.side = "R";
        newPose.thumb = pose.ImageURL;
        newPose.info = pose.Info;
        $scope.selectedPractice.poses.push(newPose);
        console.log($scope.selectedPractice.poses)
    }

    $scope.remove = function (pose) {
        var index = $scope.selectedPractice.poses.indexOf(pose);
        $scope.selectedPractice.poses.splice(index, 1);
    }

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
                    breaths: 9,
                    side: "L",
                    thumb: "https://upload.wikimedia.org/wikipedia/commons/9/9d/Trikonasana_Yoga-Asana_Nina-Mel.jpg",
                    info: "looooooooorem ipsum"
                },
                {
                    name: "Triangle",
                    breaths: 3,
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

    //Base Poses --------------------------------------------------------------------------------
    $scope.basePoses = [];

    $scope.fetchBasePoses = function () {
        let ArrayOfBasePoses = [];
        $http.get('/api/Pose')
                .success(function (response) {
                    console.log(response);
                    for (singlePose in response) {
                        ArrayOfBasePoses.push(response[singlePose]);
                        $scope.basePoses = ArrayOfBasePoses;
                    }
                })
                .error(function (response) {
                    console.log("error!");
                })
    }

    $scope.current = {name:"ok", info:"yes"};

    $scope.popUpPose = function (pose) {
        $scope.current = pose;
    };

});

/*
app.controller("slideCtrl", function ($scope, $http) {

});

app.controller("formCtrl", function ($scope, $http) {

});

app.controller.("basePoseCtrl", function($scope, $http){

});*/