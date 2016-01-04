(function () {
    'use strict';

    let jade = require('jade'),
        fs = require('fs'),
        db = require('./db'),
        layoutFilePath = './views/page-layout.jade',
        baseUrl = 'http://localhost:6969/',
        visualizationData = {
            phones: db.phones,
            tablets: db.tablets,
            wearables: db.wearables,
            links: [
                {
                    title: 'Home',
                    url: baseUrl + 'home'
                },
                {
                    title: 'Phones',
                    url: baseUrl + 'phones'
                },
                {
                    title: 'Tablets',
                    url: baseUrl + 'tablets'
                },
                {
                    title: 'Wearables',
                    url: baseUrl + 'wearables'
                },
            ]
        };

    function getHtmlForRoute(routeName, res) {

        fs.readFile(layoutFilePath, 'utf-8', function (error, layout) {
            if (error) {
                throw error;
            }

            fs.readFile(`./views/${routeName}.jade`, 'utf-8', function (err, content) {
                if (err) {
                    throw err;
                }

                let output = jade.compile(content)(visualizationData);

                let page = jade.compile(layout)({
                    links: visualizationData.links,
                    content: output
                });

                res.send(page);
                
            });
        });
    }

    module.exports = getHtmlForRoute;
} ());