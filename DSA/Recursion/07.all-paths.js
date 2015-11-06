var paths = (function () {

	var directions = [[0, 1], [0, -1], [1, 0], [-1, 0]],
		allPaths = [];
	
	// helpers
	function copyMatrix(matrix) {

		var result,
			copiedRow;

		result = matrix.map(function (row) {

			copiedRow = row.map(function (cell) {
				return cell;
			});

			return copiedRow;
		});

		return result;
	}
	
	// recursive dfs
	function getPaths(matrix, start, end, path) {

		var cellValue;

		matrix[start.y][start.x] = 'x';

		if (start.y === end.y && start.x === end.x) {
			allPaths.push(path);
			return;
		}

		directions.forEach(function (d) {
			
			var nextStart = {
					y: start.y + d[0],
					x: start.x + d[1]
				},
				newMatrix;

			cellValue = Array.isArray(matrix[nextStart.y]) ? matrix[nextStart.y][nextStart.x] : undefined;

			if (cellValue && cellValue !== 'x') {

				newMatrix = copyMatrix(matrix);

				getPaths(newMatrix, nextStart, end, path.concat(nextStart));
			}
		});
	}

	return function (matrix, start, end) {
		getPaths(matrix, start, end, [start]);

		return allPaths;
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

// console.log(paths(labyrinth, { y: 2, x: 1}, { y: 2, x: 3}));