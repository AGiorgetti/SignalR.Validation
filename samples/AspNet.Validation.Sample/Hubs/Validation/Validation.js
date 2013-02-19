/// <reference path="../../Scripts/jquery-1.9.1.intellisense.js" />
/// <reference path="../../Scripts/jquery.signalR-1.0.0.js" />

$(function () {

    var personHub = $.connection.personHub;

    $.connection.hub.start(

        function () {

            personHub.server.funcWithoutValidation({  })
            .done(function (result) {
                $("#funcWithoutValidation").html("function called succesfully!");
            })
            .fail(function (result) {
                $("#funcWithoutValidation").html(result);
            });

            personHub.server.funcWithValidation({})
            .done(function (result) {
                $("#funcWithValidation").html(result);
            })
            .fail(function (result) {
                $("#funcWithValidation").html(result);
            });

        }
    );

});