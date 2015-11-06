var passables = (function () {

	// same as problem 9, but instead of storing only the maximal area,
	// all areas are stored and returned as a set of points

	var directions = [[0, 1], [1, 0], [0, -1], [-1, 0]],
		unpassable = {
			u: true,
			x: true
		},
		areas = [];

	function traverseArea(matrix, point, area) {

		var cellValue = Array.isArray(matrix[point.y]) ? matrix[point.y][point.x] : undefined;

		if (cellValue && !unpassable[cellValue]) {

			matrix[point.y][point.x] = 'u';

			area.hasCells = true;
			area.points.push(point);
			directions.forEach(function (d) {
				var nextPoint = { y: point.y + d[0], x: point.x + d[1] };
				traverseArea(matrix, nextPoint, area);
			});

		}
	}

	function getLargestConnectedArea(matrix) {

		var currentArea,
			currentPoint,
			rows,
			cols,
			i,
			j;

		for (i = 0, rows = matrix.length; i < rows; i++) {

			for (j = 0, cols = matrix[i].length; j < cols; j++) {

				currentPoint = {
					y: i,
					x: j
				};

				currentArea = {
					hasCells: false,
					points: []
				};

				traverseArea(matrix, currentPoint, currentArea);

				if (currentArea.hasCells) {
					
					areas.push(currentArea.points.map(function (point) {
						return point.y + ' ' + point.x;
					}));
				}
			}
		}

		return areas;
	}

	return getLargestConnectedArea;
} ());

// var matrix = [
// 	['x', '0', 'x'],
// 	['0', '0', '0'],
// 	['x', 'x', 'x'],
// 	['0', '0', '0']
// ];
// 
// console.log(passables(matrix));