(function () {
    'use strict';

    let data = require('../../data/data');

    module.exports = {
        byUsers: function (req, res) {

            let filters = {
                with: req.query.with,
                and: req.query.and
            };

            data.messages.filtered(filters)
                .then(function (response) {
                    res.status(200)
                        .json({
                            result: response
                        });
                }, function (error) {
                    res.status(400)
                        .json({
                            result: error
                        });
                });
        },
        all: function (req, res) {

            data.messages.all()
                .then(function (response) {
                    res.status(200)
                        .json({
                            result: response
                        });
                }, function (error) {
                    res.status(400)
                        .json({
                            result: error
                        });
                });
        },
        send: function (req, res) {
            
            req.body.sentOn = new Date();
            
            data.messages.add(req.body)
                .then(function (response) {
                    res.status(201)
                        .json({
                            result: response
                        });
                }, function (error) {
                    res.status(400)
                        .json({
                            result: error
                        });
                });
        }
    };
} ());