var area = (function () {

	var directions = [[0, 1], [1, 0], [0, -1], [-1, 0]],
		unpassable = {
			u: true,
			x: true
		};
		
	// revursive dfs, increment a counter for each traversed neighbor, and marked it as visited
	function traverseArea(matrix, point, area) {

		var cellValue = Array.isArray(matrix[point.y]) ? matrix[point.y][point.x] : undefined;
		
		// if the cell is passable and is inside the matrix
		if (cellValue && !unpassable[cellValue]) {
			
			// mark as visited
			matrix[point.y][point.x] = 'u';

			area.cellCount++;

			directions.forEach(function (d) {
				traverseArea(matrix, { y: point.y + d[0], x: point.x + d[1] }, area);
			});

		}
	}

	function getLargestConnectedArea(matrix) {

		var currentArea,
			currentPoint,
			maxArea = {
				cellCount: 0
			},
			rows,
			cols,
			i,
			j;
		
		// traverse the whole matrix
		for (i = 0, rows = matrix.length; i < rows; i++) {

			for (j = 0, cols = matrix[i].length; j < cols; j++) {

				currentArea = {
					cellCount: 0
				};

				currentPoint = {
					y: i,
					x: j
				};
				
				// for each passable/not visited cell in the matrix, traverse the area it belongs to
				traverseArea(matrix, currentPoint, currentArea);

				if (currentArea.cellCount > maxArea.cellCount) {

					maxArea = {
						point: currentPoint,
						cellCount: currentArea
					};

				}
			}
		}
		
		// return the maximal area as an object with length and a point that is contained in that area
		return maxArea;
	}

	return getLargestConnectedArea;
} ());

// var matrix = [
// 	['x', '0', 'x'],
// 	['0', '0', '0'],
// 	['x', 'x', 'x'],
// 	['0', '0', '0']
// ];

// console.log(area(matrix));