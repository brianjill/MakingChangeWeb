'use strict';

app.controller('ProjectCtrl', ['$scope', function ($scope) {

    $scope.projects = $scope.projects || [];

    app.dataservice.getProjects()
        .then(querySucceeded)
        .fail(queryFailed);

    //#region private functions
    function querySucceeded(data) {
        $scope.projects = data.results;
        $scope.$apply();
        app.logger.info("Fetched " + data.results.length + " Projects ");
    }

    function queryFailed(error) {
        logger.error(error.message, "Query failed");
    }

}]);
