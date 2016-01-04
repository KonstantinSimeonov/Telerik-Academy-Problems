(function () {
    'use strict';
    
    // should be moved to another file but it's too short
    function getExtension(fileName) {

        return fileName.substring(fileName.lastIndexOf('.'));
    }

    let http = require('http'),
        formidable = require('formidable'), // for file upload form
        fs = require('fs-extra'), // for copying
        uuid = require('uuid'), // for guid
        jade = require('jade');

    let port = 6969,
        uploadPath = './uploads';

    let server = http.createServer(function (req, res) {
        
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
            let form = new formidable.IncomingForm();
            
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

                let path = this.openedFiles[0].path,
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
        
        // all files page
        if(req.url === '/files') {
            fs.readFile('./views/all-files.jade', function (err, jadeFile) {
                if(err) {
                    res.end(err);
                    return;
                }
                
                fs.readdir('./uploads/', function (error, files) {
                    if(error) {
                        res.end(error);
                        return;
                    }                    

                    let output = jade.compile(jadeFile)({
                       files: files.map(f => f.split('.')[0])
                    });
                    
                    res.end(output);
                })
            });
        }
        
        // download
        let splitUrl = req.url.split('/');

        if ((splitUrl[1] === 'files') && (splitUrl.length === 3)) {

            let guid = splitUrl[2];

            fs.readdir('./uploads/', function (err, files) {

                for (let i = 0, len = files.length; i < len; i += 1) {
                    let splitFileName = files[i].split('.');

                    if (guid === splitFileName[0]) {

                        res.writeHead(200, {
                            'Content-Disposition': `attachment; filename=${files[i]};`
                        });

                        let readStream = fs.createReadStream(`./uploads/${files[i]}`);
                        readStream.pipe(res);
                        return;

                    }
                }

                res.end('<p>File not found!</p>');

            });
        }

    });

    server.listen(port);
    console.log(`Server running on port ${port}`);
} ());