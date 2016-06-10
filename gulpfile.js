﻿/// <binding />
var gulp = require('gulp'),
	spritesmith = require("gulp.spritesmith");

var paths = {
    webroot: "./TileMapSource/build/",
    src: "./TileMapSource/src/"
};

gulp.task('tilemap32', function () {
	var spriteData = gulp.src([
		paths.src + 'Sprites/32x32/player.png',
		paths.src + 'Sprites/32x32/player_position2.png',
		paths.src + 'Sprites/32x32/bullet.png',
		paths.src + 'Sprites/32x32/tower_base.png',
		paths.src + 'Sprites/32x32/tower_canon.png',
		])
        .pipe(spritesmith({
		imgName: 'tilemap32.png',
		algorithm: 'left-right',
		cssName: 'sprite32.css',
		cssFormat: 'css',
		imgPath: '/tilemaps/tilemap32.png'
	}));
	
	return spriteData.img.pipe(gulp.dest(paths.webroot + "tilemaps/"));
});

gulp.task('tilemap64', function () {
	var spriteData = gulp.src(paths.src + 'Sprites/64x64/*.*')
        .pipe(spritesmith({
		imgName: 'tilemap64.png',
		algorithm: 'left-right',
		cssName: 'sprite32.css',
		cssFormat: 'css',
		imgPath: '/tilemaps/tilemap64.png'
	}));
	
	return spriteData.img.pipe(gulp.dest(paths.webroot + "tilemaps/"));
});

gulp.task('build', ['tilemap32', 'tilemap64'], function () {
});

gulp.task('default', ['build'], function () {
    // place code for your default task here
});