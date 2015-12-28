(function () {
    'use strict';

    module.exports = function (server) {
        require('fs')
        .readdirSync('./server/routers')
        .filter(f => f !== 'index.js')
        .forEach(f => require(`./${f}`)(server));
    }
} ());