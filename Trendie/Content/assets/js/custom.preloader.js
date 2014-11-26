window.TRENDIE = window.TRENDIE || {};
window.TRENDIE.CUSTOM = window.TRENDIE.CUSTOM || {};

window.TRENDIE.CUSTOM.PreLoader = function () {
    "use strict";

    var displayPreLoader = function () {
        $('#status').fadeOut();
        $('#preloader').delay(350).fadeOut('slow');
    };

    return {
        init: function () {
            $(window).ready(function () {
                displayPreLoader();
            });
        }
    };
}();
