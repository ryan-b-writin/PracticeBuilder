var app = angular.module('practiceBuilder', []);


app.controller("practiceCtrl", function ($scope, $http) {

    //init ---------------------------------------------------------------------------
    //--------------------------------------------------------------------------------

    getAllPractices = function () {
        let arrayOfPractices = [];
        $http.get('/api/Practice')
            .success(function (response) {
                $scope.practices = response;
            })
        .error(function (response) {
            console.log('error!');
        });
    };

    getUserPoses = function () {
        console.log("fetching user poses");
        $http({
            method: "GET",
            url: "/api/Practice",
            withCredentials: true
        })
        .success(function (response) {
            for (practice in response)
                if (response[practice].Name === $scope.selectedPractice.Name) {
                    $scope.selectedPractice.Poses = response[practice].Poses;
                }
        })
       .error(function (response) {
           console.log("error!");
       });
    };

    $scope.practices = [];

    $scope.current = { name: "ok", info: "yes" };

    getAllPractices();

    //Yogi ----------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------


    //Practice -----------------------------------------------------------------------
    //--------------------------------------------------------------------------------

    $scope.generateNewPractice = function () {
        console.log("generating");
        $http({
            method: "POST",
            url: "/api/Practice",
            data: JSON.stringify({ practiceName: $scope.newPractice }),
            withCredentials: true
        })
        .success(function (response) {
            getAllPractices();
        })
        .error(function (response) {
            console.log("error!");
        });
    };

    $scope.deletePractice = function() {
        $http({
            method: "POST",
            url: "/api/ManagePractice",
            data: JSON.stringify({ practiceName: $scope.selectedPractice.Name }),
            withCredentials: true
        })
       .success(function (response) {
           getAllPractices();
       })
       .error(function (response) {
           console.log("error!");
       });
    };

    //Base Poses --------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------

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

    //User poses-------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------


    $scope.popUpPose = function (pose) {
        $scope.current = pose;
    };

    $scope.addToPractice = function (pose) {
        $http({
            method: "POST",
            url: "/api/Pose",
            data: JSON.stringify({ practiceName: $scope.selectedPractice.Name, poseName: pose.Name }),
            withCredentials: true
        })
       .success(function (response) {
           getUserPoses();
       })
       .error(function (response) {
           console.log("error!");
       });
    };

    $scope.saveChanges = function () {
        $http({
            method: "PUT",
            url: "/api/Pose",
            data: JSON.stringify({
                practiceName: $scope.selectedPractice.Name,
                poseName: $scope.current.Name,
                poseSide: $scope.current.Side,
                poseDuration: $scope.current.Duration
            }),
            withCredentials: true
        })
       .success(function (response) {
           getUserPoses();
       })
       .error(function (response) {
           console.log("error!");
       });
    };

    $scope.remove = function (pose) {
        var index = $scope.selectedPractice.Poses.indexOf(pose);
        
        $http({
            method: "POST",
            url: "/api/UserPose",
            data: JSON.stringify({ practiceName: $scope.selectedPractice.Name, poseName: pose.Name }),
            withCredentials: true
        })
       .success(function (response) {
           getUserPoses();
       })
       .error(function (response) {
           console.log("error!");
       });
    };

});