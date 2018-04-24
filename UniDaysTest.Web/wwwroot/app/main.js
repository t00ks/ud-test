requirejs.config({
    paths: {
        'text': '../lib/text',
        'durandal': '../lib/durandal',
        'plugins': '../lib/durandal/plugins',
        'transitions': '../lib/durandal/transitions',
    },
    enforceDefine: true // required so we can detect load failure in IE
});

define('jquery', function () { return jQuery; });
define('knockout', function () { return ko; });
define('moment', function () { return moment; });


define(['durandal/system', 'durandal/app', 'durandal/viewLocator', 'plugins/router', 'durandal/binder', 'jquery'],
    function (system, app, viewLocator, router, binder, $) {

        app.title = 'User Registration';

        app.configurePlugins({
            router: true,
            dialog: true,
            widget: true
        });

        system.debug(true);

        app.start().then(function () {
            viewLocator.useConvention();
            app.setRoot('viewmodels/shell', 'entrance');
        });
    });