define('models/user', ['moment', 'knockout'],
    function (moment, ko) {

        return function (dto) {
            var self = this;

            this.email = ko.observable(dto ? dto.email : '');
            this.password = ko.observable(dto ? dto.detailUid : '');

            this.isValidEmail = function () {
                return /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(self.email())
            }

            this.isValidPassword = function () {
                return self.password().length > 8;
            }

            this.displayError = function (prop) {
                switch (prop) {
                    case 'email':
                        return self.email().length != 0 && !self.isValidEmail();
                    case 'password':
                        return self.password().length != 0 && !self.isValidPassword();
                    default:
                        return false;
                }
            }

            this.canSubmit = ko.computed(function () {
                return self.email().length > 0 &&
                    self.password().length > 0 &&
                    self.isValidEmail() && self.isValidPassword();
            });
        }
    });