(function () {
    'use strict';
    
    let mongoose = require('mongoose'),
        schema = new mongoose.Schema({
            name: {
                type: String,
                required: true,
                min: 2
            },
            password: {
                type: String,
                required: true,
                min: 5
            }
        });
    
    mongoose.model('User', schema);
} ());