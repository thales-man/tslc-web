"use strict";

var stateManager = (function () {
    var state = null;
    var dotNet = null;

    var resizePage = function () {
        if (window.innerWidth < 768
            && state !== "Mobile") {
            displayMobile();
        }
        else if (window.innerWidth > 767
            && window.innerWidth < 922
            && state !== "Tablet") {
            displayTablet();
        }
        else if (window.innerWidth > 921
            && state !== "Desktop") {
            displayDesktop();
        }

        notifyResize();
    };

    var getDimensions = function () {
        return {
            width: window.innerWidth,
            height: window.innerHeight
        };
    };

    var displayMobile = function () {
        state = "Mobile";
        dotNet.invokeMethodAsync("ChangeMedia", state);
    };

    var displayTablet = function () {
        state = "Tablet";
        dotNet.invokeMethodAsync("ChangeMedia", state);
    };

    var displayDesktop = function () {
        state = "Desktop";
        dotNet.invokeMethodAsync("ChangeMedia", state);
    };

    var notifyResize = function () {
        dotNet.invokeMethodAsync("ChangeSize", getDimensions());
    };

    return {
        init: function (dotNetObject) {
            dotNet = dotNetObject;
            resizePage();
            window.addEventListener('resize', resizePage);
        }
    };
}());
