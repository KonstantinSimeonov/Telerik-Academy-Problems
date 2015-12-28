(function () {
    'use strict';

    require('fs')
        .readdirSync('./data/models')
        .filter(f => f !== 'index.js')
        .forEach(f => require(`./models/${f}`));
} ());