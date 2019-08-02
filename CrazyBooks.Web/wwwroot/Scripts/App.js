var app = angular.module('CrazyBooksApp', ['ngAnimate', 'ngRoute', 'ui.grid', 'ui.bootstrap', 'ngFileUpload']);

app.config( function ( $routeProvider, $locationProvider ) 
{
    $routeProvider.when('/admins',
        {
            template: '<admins></admins>'
        });

    $routeProvider.when('/members',
        {
            template: '<members></members>'
        });

    $routeProvider.when( '/books',
        {
            template: '<books></books>'
        });

    $routeProvider.when('/login',
        {
            template: '<login></login>'
        });

    $routeProvider.when('/loading',
        {
            template: '<loading></loading>'
        });


    $routeProvider.when('/lends',
        {
            template: '<lends></lends>'
        });
    // use the HTML5 History API
    $locationProvider.html5Mode(true);
});
