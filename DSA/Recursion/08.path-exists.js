var getPath = (function () {

	var directions = [[0, 1], [1, 0], [0, -1], [-1, 0]],
		firstPath;
	
	// same as all paths, but stops execution if a path is found
	function getSinglePath(matrix, start, end, path) {

		var nextStart,
			cellValue;

		matrix[start.y][start.x] = 'x';

		if (start.y === end.y && start.x === end.x) {
			firstPath = path;
			return;
		}
		
		if (!firstPath) {
			directions.forEach(function (d) {

				nextStart = {
					y: start.y + d[0],
					x: start.x + d[1]
				};

				cellValue = Array.isArray(matrix[nextStart.y]) ? matrix[nextStart.y][nextStart.x] : undefined;

				if (cellValue && cellValue !== 'x') {
					getSinglePath(matrix, nextStart, end, path.concat(nextStart));
				}
			});
		}
	}

	return function (matrix, start, end) {

		firstPath = undefined;
		getSinglePath(matrix, start, end, [start]);

		return firstPath;
	};
} ());

// var labyrinth = [
// 	['0', '0', '0', 'x', '0', 'x'],
// 	['0', 'x', '0', '0', '0', 'x'],
// 	['0', '0', 'x', '0', 'x', '0'],
// 	['0', 'x', '0', '0', '0', '0'],
// 	['0', '0', '0', 'x', 'x', '0'],
// 	['0', '0', '0', 'x', '0', 'x'],
// ];
// 
// var hugeEmptyLabyrinth = (function (rows, columns) {
// 	var laby = [];
// 
// 	for (var i = 0; i < rows; i++) {
// 		laby[i] = [];
// 		for (var j = 0; j < columns; j++) {
// 			laby[i][j] = '0';
// 		}
// 
// 	}
// 
// 	return laby;
// } (100, 100));

// console.log(getPath(hugeEmptyLabyrinth, { y: 0, x: 0 }, { y: 99, x: 99 }));