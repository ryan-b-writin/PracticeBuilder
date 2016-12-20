var app = angular.module('practiceBuilder', []);


app.controller("practiceCtrl", function ($scope, $http) {

    //init ---------------------------------------------------------------------------

    GetAllPractices = function () {
        let arrayOfPractices = [];
        $http.get('/api/Practice')
            .success(function (response) {
                $scope.practices = response;
                for (singlePractice in response) {
                    console.log('response', response[singlePractice]);
                    let newPractice =
                    {
                        name: response[singlePractice].Name
                    };
                    console.log('new practice', newPractice);
                    arrayOfPractices.push(newPractice);
                }
                console.log('array', arrayOfPractices);
                return arrayOfPractices;
            })
        .error(function (response) {
            console.log('error!');
        });
    }

    $scope.practices = [];

    GetAllPractices()

    //GetAllPractices();

    //Yogi ----------------------------------------------------------------------------------

    $scope.generateNewPractice = function () {
        console.log("generating");
        $http({
            method: "POST",
            url: "/api/Practice",
            data: JSON.stringify({ practiceName: $scope.newPractice }),
            withCredentials:true
        })
        .success(function (response) {
            console.log("success!", $scope.newPractice);
        })
        .error(function (response) {
            console.log("error!");
        })
    }

    //Practice -----------------------------------------------------------------------
   
    /*GetAllPractices = function () {
        let ArrayOfPractices = [];
        $http.get('/api/Practice')
            .success(function (response) {
                for (singlePractice in response) {
                    console.log('response', response[singlePractice]);
                    let newPractice =
                    {
                        name: response[singlePractice].Name
                    }
                    console.log('new practice', newPractice);
                    ArrayOfPractices.push(newPractice);
                }
                console.log('array', ArrayOfPractices)
                return ArrayOfPractices;
            })
        .error(function (response) {
            console.log('error!');
        })
    }*/

    //$scope.practices = GetAllPractices();

    $scope.addToPractice = function (pose) {
        console.log($scope.selectedPractice, "selected practice")
        $http({
            method: "POST",
            url: "/api/Pose",
            data: JSON.stringify({ practiceName: $scope.selectedPractice.Name, poseName: pose.Name }),
            withCredentials:true
        })
       .success(function (response) {
           console.log("success!", $scope.newPractice);
       })
       .error(function (response) {
           console.log("error!");
       });

        /*let newPose = {
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
        */
    }

    $scope.remove = function (pose) {
        var index = $scope.selectedPractice.poses.indexOf(pose);
        $scope.selectedPractice.poses.splice(index, 1);
    }

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
        console.log($scope.current);
    };

    //User poses-------------------------------------------------------------------------------------------
    $scope.saveChanges = function (breaths, side) {
        $scope.current.breaths = breaths;
        $scope.current.side = side;
    }

    });

    /*[
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
   ]*/