var gulp = require('gulp');
var sass = require('gulp-sass');
var webserver = require('gulp-webserver');

gulp.task('connect', function() {
    connect.server({
        root: 'public',
        livereload: true
    });
});

gulp.task('sass', function (){
    return gulp.src('./sass/**/*.scss')
        .pipe(sass({includePaths: ['./public/bower_components/foundation-sites/scss']}).on('error', sass.logError))
        .pipe(gulp.dest('./public/css'));
});

gulp.task('webserver', function() {
  gulp.src('./public/')
    .pipe(webserver({
      livereload: true,
      open: true
    }));
});

gulp.task('watch', function (){
    gulp.watch('./sass/**/*.scss', ['sass']);
});

gulp.task('default', ['webserver', 'watch', 'sass']);
