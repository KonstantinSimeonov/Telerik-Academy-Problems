(function () {
    'use strict';
    
    let express = require('express'),
        server = express(),
        getHtmlForRoute = require('./html-provider'),
        port = 6969;
    
    server.get('/home', function (req, res) {
        getHtmlForRoute('home', res);
    });
    
    server.get('/phones', function (req, res) {
        getHtmlForRoute('smart-phones', res);
    });
    
    server.get('/tablets', function (req, res) {
        getHtmlForRoute('tablets', res);
    });
    
    server.get('/wearables', function (req, res) {
        getHtmlForRoute('wearables', res);
    });
    
    server.listen(port, () => console.log(`Server running on ${port}`));
} ());