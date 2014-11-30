window.TRENDIE = window.TRENDIE || {};
window.TRENDIE.CUSTOM = window.TRENDIE.CUSTOM || {};

window.TRENDIE.CUSTOM.Effects = function () {
    "use strict";
    
    var Country = null;

    var configureNavBarLinks = function () {
        $('body').scrollspy({
            target: '.navbar-custom',
            offset: 50
        });

        $('a[href*=#]').bind("click", function (e) {
            var anchor = $(this);
            $('html, body').stop().animate({
                scrollTop: $(anchor.attr('href')).offset().top
            }, 1000);
            e.preventDefault();
        });
    };

    var configureNavBarStyles = function () {
        var navbar = $('.navbar');
        var navHeight = navbar.height();

        $(window).scroll(function () {
            if ($(this).scrollTop() >= navHeight) {
                navbar.addClass('navbar-color');
            }
            else {
                navbar.removeClass('navbar-color');
            }
        });

        if ($(window).width() <= 767) {
            navbar.addClass('custom-collapse');
        }

        $(window).resize(function () {
            if ($(this).width() <= 767) {
                navbar.addClass('custom-collapse');
            }
            else {
                navbar.removeClass('custom-collapse');
            }
        });
    };

    var configureHeroImage = function () {
        var imagePath = 'Content/assets/images/' + Country + '.jpg'
        $('#intro').backstretch([imagePath], { centeredY: true });
    };

    var configureIntroText = function () {
        $(".rotate").textrotator({
            animation: "dissolve",
            separator: "|",
            speed: 3000
        });
    };

    return {
        init: function (args) {
            args = args || {};
            Country = args.Country || 'default';

            $(document).ready(function () {
                configureNavBarLinks();
                configureNavBarStyles();
                configureHeroImage();
                configureIntroText();
            });
        }
    };
}();
