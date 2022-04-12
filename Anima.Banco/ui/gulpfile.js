const gulp = require('gulp')
const concat = require('gulp-concat')

var src = './js/app/**/*.js'

gulp.task('build', () => {
    return gulp
    .src(src)
    .pipe(concat('all.js'))
    .pipe(gulp.dest('./js/dist'))
})

// gulp.task('build-watch', () =>{
//     gulp.watch([src], ['build'])
// })