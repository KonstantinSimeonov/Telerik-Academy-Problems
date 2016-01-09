'use strict';

module.exports = function (grunt) {
    grunt.initConfig({
        pkg: grunt.file.readJSON("package.json"),
        // compilers
        coffee: {
            coffee_to_js: {
                options: {
                    bare: true,
                    sourceMap: false
                },
                expand: true,
                flatten: true,
                cwd: 'DEV',
                src: ["*.coffee"],
                dest: '<%= myTask.jsDest %>', // use global parameters to the task to make it reusable
                ext: ".js"
            }
        },
        jade: {
            compile: {
                options: {
                    pretty: true
                },
                cwd: 'DEV',
                src: ["*.jade"],
                dest: '<%= myTask.htmlDest %>',
                expand: true,
                ext: ".html"

            }
        },
        stylus: {
            compile: {
                options: {
                    bare: true
                },
                cwd: 'DEV',
                src: ["*.styl"],
                ext: '.css',
                expand: true,
                dest: '<%= myTask.cssDest %>'
            },
        },
        // hints
        jshint: {
            files: ['DEV/scripts/*.js']
        },
        csslint: {
            strict: {
                options: {
                    import: 2
                },
                src: ['DEV/*.css']
            },
            lax: {
                options: {
                    import: false
                },
                src: ['DEV/*.css']
            }
        },
        // copy
        copy: {
            copyToDev: {
                expand: true,
                dest: 'DEV/images',
                cwd: 'APP/images',
                src: ['*.*']
            },
            copyToDist: {
                expand: true,
                dest: 'DIST/images',
                cwd: 'APP/images',
                src: ['*.*']
            }
        },
        // minification
        concat: {
            js: {
                src: 'DEV/scripts/*.js',
                dest: 'DEV/scripts/concat.js'
            },
            css: {
                src: 'DEV/*.css',
                dest: 'DEV/concat.css'
            }
        },
        cssmin: {
            options: {
                shorthandCompacting: false,
                roundingPrecision: -1
            },
            target: {
                files: {
                    'DIST/styles.css': ['DEV/concat.css']
                }
            }
        },
        htmlmin: {
            dist: {
                options: {
                    removeComments: true,
                    collapseWhitespace: true
                },
                files: {
                    'DIST/index.html': 'DEV/index.html'
                }
            }
        },
        uglify: {
            my_target: {
                options: {
                    sourceMap: false
                },
                files: {
                    'DIST/scripts/main.min.js': ['DEV/scripts/concat.js'],
                },
            },
        },
        // server
        serve: {
            options: {
                port: 9578
            }
        },
        // reuse already configured tasks for watch
        watch: {
            stylus: {
                files: ['DEV/*.styl'],
                tasks: ['stylus:compile'],
                options: {
                    reload: true
                }
            },
            coffeescript: {
                files: ['DEV/*.coffee'],
                tasks: ['coffee:coffee_to_js'],
                options: {
                    reload: true
                }
            },
            jade: {
                files: ['DEV/*.jade'],
                tasks: ['jade:compile'],
                options: {
                    reload: true
                }
            }
        },
        // define server and watcher as parallel, so they run at the same time
        parallel: {
            serve: {
                options: {
                    grunt: true
                },
                tasks: ['serve', 'watch']
            }
        },

    });

    grunt.loadNpmTasks('grunt-contrib-coffee');
    grunt.loadNpmTasks('grunt-contrib-jade');
    grunt.loadNpmTasks('grunt-contrib-stylus');
    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-jshint');
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.loadNpmTasks('grunt-contrib-csslint');
    grunt.loadNpmTasks('grunt-contrib-htmlmin');
    grunt.loadNpmTasks('grunt-parallel');
    grunt.loadNpmTasks('grunt-serve');
    
    // set some parameters for more flexibility
    grunt.config.set('myTask.htmlDest', 'DEV');
    grunt.config.set('myTask.cssDest', 'DEV');
    grunt.config.set('myTask.jsDest', 'DEV/scripts');

    grunt.registerTask('compileFiles', ['coffee', 'jade', 'stylus', 'jshint', 'csslint']);
    grunt.registerTask('bundle', ['copy', 'concat', 'uglify', 'cssmin', 'htmlmin'])

    grunt.registerTask('Build', function () {
        grunt.task.run('compileFiles');
        grunt.task.run('bundle');
    });

    grunt.registerTask('Serve', function () {
        grunt.task.run('compileFiles');
        grunt.task.run('parallel:serve');
    });

    return null;
}