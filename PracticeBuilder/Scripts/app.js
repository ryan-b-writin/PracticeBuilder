var app = angular.module('practiceBuilder', []);


app.controller("practiceCtrl", function ($scope, $http) {

    //init ---------------------------------------------------------------------------

    GetAllPractices = function () {
        let arrayOfPractices = [];
        $http.get('/api/Practice')
            .success(function (response) {
                $scope.practices = response;
            })
        .error(function (response) {
            console.log('error!');
        });
    };

    $scope.practices = [];

    GetAllPractices();

    //GetAllPractices();

    //Yogi ----------------------------------------------------------------------------------

    $scope.generateNewPractice = function () {
        console.log("generating");
        $http({
            method: "POST",
            url: "/api/Practice",
            data: JSON.stringify({ practiceName: $scope.newPractice }),
            withCredentials: true
        })
        .success(function (response) {
            console.log("success!", $scope.newPractice);
        })
        .error(function (response) {
            console.log("error!");
        });
    };

    //Practice -----------------------------------------------------------------------

    $scope.addToPractice = function (pose) {
        console.log($scope.selectedPractice, "selected practice");
        $http({
            method: "POST",
            url: "/api/Pose",
            data: JSON.stringify({ practiceName: $scope.selectedPractice.Name, poseName: pose.Name }),
            withCredentials: true
        })
       .success(function (response) {
           console.log("success!", $scope.newPractice);
       })
       .error(function (response) {
           console.log("error!");
       });
    };

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
                });
    };

    $scope.current = {name:"ok", info:"yes"};

    $scope.popUpPose = function (pose) {
        $scope.current = pose;
        console.log($scope.current);
    };

    //User poses-------------------------------------------------------------------------------------------
    $scope.saveChanges = function (breaths, side) {
        $scope.current.breaths = breaths;
        $scope.current.side = side;
    }

    $scope.remove = function (pose) {
        /*var index = $scope.selectedPractice.poses.indexOf(pose);
        $scope.selectedPractice.poses.splice(index, 1);*/
        console.log($scope.selectedPractice, "selected practice");
        $http({
            method: "DELETE",
            url: "/api/Pose",
            data: JSON.stringify({ practiceName: $scope.selectedPractice.Name, poseName: pose.Name }),
            withCredentials: true
        })
       .success(function (response) {
           console.log("success!", $scope.newPractice);
       })
       .error(function (response) {
           console.log("error!");
       });
    }

});