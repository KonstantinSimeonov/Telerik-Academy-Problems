(function () {
    'use strict';

    let mongoose = require('mongoose');
    
    mongoose.connect('mongodb://localhost:27017/chat');
    
    // load models
    require('../data/index');
    
    let express = require('express'),
        bodyParser = require('body-parser'),
        server = express(),
        port = 6969;
    
    server.use(bodyParser.json());
    
    // plug routers
    require('./routers/index')(server);
    
    server.listen(port, () => console.log(`Server running at ${port}`));
} ());