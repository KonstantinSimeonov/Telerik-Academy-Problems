(function () {
    'use strict';

    let data = require('../../data/data');

    module.exports = {
        register: function (req, res) {

            data.users.register(req.body)
                .then(function (response) {
                    res.status(201)
                        .json({
                            result: response
                        });
                }, function (err) {
                    res.status(400)
                        .json({
                            result: err
                        });
                })

        },
        all: function (req, res) {

            data.users.all()
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
                })
        }
    };
} ());