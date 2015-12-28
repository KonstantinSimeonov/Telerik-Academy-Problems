(function () {
    'use strict';

    let mongoose = require('mongoose'),
        User = mongoose.model('User'),
        Message = mongoose.model('Message');

    module.exports = {

        users: {
            register: function (user) {

                let dbUser = new User(user);

                let promise = new Promise(function (resolve, reject) {

                    User.find({ name: user.name }, function (error, users) {
                        if (error || users.length) {
                            reject(error || { error: 'username already taken' });
                            return;
                        }

                        dbUser.save(function (saveError) {
                            if (saveError) {
                                reject(saveError);
                                return;
                            }

                            resolve(dbUser);
                        });
                    });
                });

                return promise;
            },
            all: function () {

                let promise = new Promise(function (resolve, reject) {
                    User.find({}, function (error, users) {
                        if (error) {
                            reject(error);
                            return;
                        }

                        resolve(users);
                    });
                })

                return promise;
            }
        },
        messages: {
            add: function (message) {

                let dbMsg = new Message(message);

                let promise = new Promise(function (resolve, reject) {

                    User.find({ $or: [{ name: message.from }, { name: message.to }] }, function (error, users) {
                        if (error || !users.length) {
                            reject(error || { error: 'at least one of the users does not exist' });
                            return;
                        }

                        dbMsg.save(function (saveError) {
                            if (saveError) {
                                reject(saveError);
                                return;
                            }

                            resolve(dbMsg);
                        });
                    });

                })

                return promise;
            },
            filtered: function (filters) {

                let promise = new Promise(function (resolve, reject) {

                    let first = filters.with || false,
                        second = filters.and || false;

                    Message.find({})
                        .and([{ from: { $in: [first, second] }, to: { $in: [first, second] } }])
                        .exec(function (err, data) {
                            if (err) {
                                reject(err);
                                return;
                            }

                            resolve(data);
                        });
                });
                return promise;
            },
            all: function () {

                let promise = new Promise(function (resolve, reject) {
                    Message.find({}, function (error, data) {
                        if (error) {
                            reject(error);
                            return;
                        }

                        resolve(data);
                    });
                });

                return promise;
            }
        }
    };
} ());