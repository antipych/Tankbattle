/// <binding />
var gulp = require('gulp'),
	spritesmith = require("gulp.spritesmith");

var paths = {
    webroot: "./TileMapSource/build/",
    src: "./TileMapSource/src/",
    sprites32: "./TileMapSource/src/Sprites/32x32/",
};

gulp.task('tilemap32', function () {
	var spriteData = gulp.src([
		paths.sprites32 + 'player.png',
		paths.sprites32 + 'player_position2.png',
		paths.sprites32 + 'bullet.png',
		paths.sprites32 + 'tower_base.png',
		paths.sprites32 + 'tower_canon.png',
        paths.sprites32 + 'area.png',
        paths.sprites32 + 'bush_small.png',
        paths.sprites32 + 'bush_small_smashed.png',
        paths.sprites32 + 'block.png',
        paths.sprites32 + 'grass.png',
        paths.sprites32 + 'rocks_small.png',
        paths.sprites32 + 'stonebig.png',
		paths.sprites32 + 'ball1.png',
		paths.sprites32 + 'ball2.png',
		paths.sprites32 + 'ball3.png',
		paths.sprites32 + 'ball4.png',
		paths.sprites32 + 'block_down.png',
		paths.sprites32 + 'block2.png',
		paths.sprites32 + 'block2_down.png',
		paths.sprites32 + 'crater.png',
		paths.sprites32 + 'dust.png',
		paths.sprites32 + 'fuel.png',
		paths.sprites32 + 'gem.png',
		paths.sprites32 + 'gem_free.png',
		paths.sprites32 + 'hole.png',
		paths.sprites32 + 'hole_birth.png',
		paths.sprites32 + 'pit.png',
		paths.sprites32 + 'wall1_horizontal_bottom.png',
		paths.sprites32 + 'wall1_left_bottom_corner.png',
		paths.sprites32 + 'wall1_left_top_corner.png',
		paths.sprites32 + 'wall1_right_bottom_corner.png',
		paths.sprites32 + 'wall1_right_top_corner.png',
		paths.sprites32 + 'wall1_vertical_left.png',
		paths.sprites32 + 'wall1_vertical_right.png'
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