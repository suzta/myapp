(function () {
    'use strict';
    window.APP = window.APP || {};
    APP.NAME = "Myapp";
    angular
        .module(APP.NAME, ['ui.router', APP.NAME + '.routes', 'angular-img-cropper']);

})();