const gulp = require('gulp')
    , sass = require('gulp-sass')(require('sass'))
    , cssmin = require('gulp-cssmin')
    , jsmin = require('gulp-jsmin')
    , rename = require('gulp-rename')
    , concat = require('gulp-concat')
    , suffix = '.beta-0.0.0.min';

gulp.task('css',
    /**
     * Compiles the sass to min.css.
     * @returns {css};
     * */
    function () {
        return gulp.src('./Style/*.scss')
            .pipe(sass().on('error', sass.logError))
            .pipe(cssmin())
            .pipe(rename({ suffix: suffix }))
            .pipe(gulp.dest('./wwwroot/css'));
    });

gulp.task('watch-sass',
    /**
     * Watches for changes in te 'Style' folder.
     * When a changes has bin saved te 'sass' is called.
     * */
    function () {
        gulp.watch('./Style/**/*.scss', gulp.series('css'));
    });

gulp.task('js',
    /**
     * Compiles js  to min.js.
     * */
    function () {
        return gulp.src('./wwwroot/js/components/*.js')
            //.pipe(jsmin())
            .pipe(concat('shithead.js'))
            .pipe(rename({ suffix: suffix }))
            .pipe(gulp.dest('./wwwroot/js'));
    });