
//alert("alert service");

console.log("alert service");

angular.module('codeProject').service('alertService', ['$rootScope', function ($rootScope) {

    $rootScope.alerts = [];
    $rootScope.messageBox = "";

    var _alerts = [];
    var _messageBox = "";

    this.setValidationErrors = function (scope, validationErrors) {

        for (var prop in validationErrors) {
            var property = prop + "InputError";
            scope[property] = true;
        }

    }

    this.returnFormattedMessage = function () {
        return _messageBox;
    }

    this.returnAlerts = function () {
        return _alerts;
    }

    this.renderErrorMessage = function (message) {

        var messageBox = formatMessage(message);
    
        _alerts = [];
        _messageBox = messageBox;
        _alerts.push({ 'type': 'danger', 'msg': '' });

    };

    this.renderSuccessMessage = function (message) {

        var messageBox = formatMessage(message);

        _alerts = [];
        _messageBox = messageBox;
        _alerts.push({ 'type': 'success', 'msg': '' });
       
    };

    this.renderWarningMessage = function (message) {

        var messageBox = formatMessage(message);
   
        _alerts = [];
        _messageBox = messageBox;
        _alerts.push({ 'type': 'warning', 'msg': '' });
     
    };

    this.renderInformationalMessage = function (message) {

        var messageBox = formatMessage(message);

        _alerts = [];
        _messageBox = messageBox;
        _alerts.push({ 'type': 'info', 'msg': '' });
              
    };

    function formatMessage(message) {
        var messageBox = "";
        if (angular.isArray(message) == true) {
            for (var i = 0; i < message.length; i++) {
                messageBox = messageBox + message[i] + "<br/>";
            }
        }
        else {
            messageBox = message;
        }

        return messageBox;

    }

   
}]);
