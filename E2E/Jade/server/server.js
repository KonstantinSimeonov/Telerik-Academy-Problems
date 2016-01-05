(function () {
    'use strict';

    let express = require('express'),
        data = require('./data'),
        server = express(),
        port = 6969;
    
    // view engine config
    server.set('view engine', 'jade');
    server.set('views', './views');

    server.get('/*', function (req, res) {
        res.render(req.url.replace('/', ''), data);
    });

    server.listen(port, () => console.log(`Server running on ${port}`));
} ());