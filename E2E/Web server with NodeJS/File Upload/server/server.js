(function () {
    'use strict';
    
    // should be moved to another file but it's too short
    function getExtension(fileName) {

        return fileName.substring(fileName.lastIndexOf('.'));
    }

    var http = require('http'),
        formidable = require('formidable'), // for file upload form
        fs = require('fs-extra'), // for copying
        uuid = require('uuid'); // for guid

    var port = 6969,
        uploadPath = './uploads';

    var server = http.createServer(function (req, res) {
        
        // server sends upload form as response on home route
        if (req.url === '/') {
            fs.readFile('./views/upload-form.html', function (error, html) {
                if (error) {
                    console.log(error);
                } else {
                    res.writeHead(200, { 'content-type': 'text/html' });
                    res.end(html);
                }
            });
        }
        
        // upload route
        if (req.url === '/upload' && req.method.toLowerCase() === 'post') {
            var form = new formidable.IncomingForm();
            
            // parse the form
            form.parse(req, function (error, fields, files) {

                fs.readFile('./views/successful-upload-form.html', function (error, html) {
                    if (error) {
                        console.log(error);
                    } else {
                        res.writeHead(200, { 'content-type': 'text/html' });
                        res.end(html);
                    }
                });

            });
            
            // on formidable request end
            form.on('end', function (fields, files) {

                var path = this.openedFiles[0].path,
                    name = uuid.v1() + getExtension(this.openedFiles[0].name);

                // copy the file with guid as name
                fs.copy(path, `${uploadPath}/${name}`, function (error) {
                    if (error) {
                        console.log(error);
                    } else {
                        console.log('success!');
                    }
                });
            });
        }

    });

    server.listen(port);
    console.log(`Server running on port ${port}`);
} ());