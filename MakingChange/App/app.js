'use strict';

// Declare app level module which depends ngGrid
var app = angular.module('MakingChange', ['ngGrid', 'ngRoute']);

// Define route objects, which are used by the routeProvider (for loading ng-view) and by the RouteCtrl (for displaying navigation bar)
app.routes = [
    { path: '/', name: 'Home', templateUrl: 'App/home/home.html', controller: 'HomeCtrl' },
    { path: '/project', name: 'Project', templateUrl: 'App/project/project.html', controller: 'ProjectCtrl' },
    { path: '/department', name: 'Department', templateUrl: 'App/department/department.html', controller: 'DepartmentCtrl' },
    { path: '/task', name: 'Task', templateUrl: 'App/task/task.html', controller: 'TaskCtrl' },
    { path: '/person', name: 'Person', templateUrl: 'App/person/Person.html', controller: 'PersonCtrl' }
];

// Configure the routeProvider, which displays a view in the ng-view div in index.html, based on the URI path (e.g. /customers)
app.config(['$routeProvider', function ($routeProvider) {

    var len = app.routes.length;
    for (var i = 0; i < len; i++) {
        var rt = app.routes[i];
        $routeProvider.when(rt.path, rt);
    }
    $routeProvider.otherwise({ redirectTo: '/' });
}]);