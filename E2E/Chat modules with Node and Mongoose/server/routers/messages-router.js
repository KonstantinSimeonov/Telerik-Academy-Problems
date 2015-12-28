(function () {
    'use strict';
    
    let express = require('express'),
        router = express.Router(),
        messagesController = require('../controllers/messages-controller');
        
    router.post('/', messagesController.send)
          .get('/', messagesController.byUsers);
        
    module.exports = function (server) {
        server.use('/api/messages', router);
    }
} ());