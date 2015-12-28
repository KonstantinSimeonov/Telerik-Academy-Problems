(function () {
    'use strict';
    
    let express = require('express'),
        router = express.Router(),
        usersController = require('../controllers/users-controller');
        
    router.post('/register', usersController.register)
          .get('/', usersController.all);
        
    module.exports = function (server) {
        server.use('/api/users', router);
    }
} ());