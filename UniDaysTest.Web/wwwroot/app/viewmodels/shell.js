 define('viewmodels/shell', ['durandal/app', 'plugins/router', 'durandal/viewEngine', 'knockout'],
 function (app, router, viewEngine, ko) {

     return {
         activate: function () {

             router.makeRelative({ moduleId: 'viewmodels' }).map([
                 {
                     route: '',
                     moduleId: 'home',
                     title: 'home'
                 },
                 {
                     route: 'home',
                     moduleId: 'home',
                     title: 'home'
                 }
             ]);

             router.mapUnknownRoutes(function (instruction) {
                 instruction.config.moduleId = "404";
             });

             return router.activate({ pushState: true });

         },
         router: router
     }
 });