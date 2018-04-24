define('viewmodels/home', ['durandal/app', 'knockout', 'plugins/router', 'moment', 'models/user', 'dataservice'],
    function (app, ko, router, moment, User, dataservice) {
        var
            _viewModel = ko.observable(),
            _isSubmitting = ko.observable(false),
            _isSubmitted = ko.observable(false),
            _errorOccurred = ko.observable(false),
            _fatalErrorOccurred = ko.observable(false);


        return {
            activate: function () {
                _viewModel(new User());
            },
            viewModel: _viewModel,
            isSubmitting: _isSubmitting,
            isSubmitted: _isSubmitted,
            errorOccurred: _errorOccurred,
            fatalErrorOccurred: _fatalErrorOccurred,
            submit: function () {
                _isSubmitting(true);
                dataservice.saveUser(ko.toJS(_viewModel())).done(function (success) {
                    _isSubmitting(false);
                    if (success) {
                        _isSubmitted(true);
                    } else {
                        _errorOccurred(true);
                    }

                }).fail(function() {
                    _isSubmitting(false);
                    _fatalErrorOccurred(true);
                });
            },
            clear: function () {
                _viewModel(new User());
                _isSubmitting(false);
                _isSubmitted(false);
                _errorOccurred(false);
                _fatalErrorOccurred(false);
            }
        }
    });