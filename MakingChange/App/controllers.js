'use strict';

// RouteCtrl - expose app.routes and the current route for the navbar
app.controller('RouteCtrl', function ($scope, $route) {
    $scope.$route = $route;
    $scope.links = app.routes;
});