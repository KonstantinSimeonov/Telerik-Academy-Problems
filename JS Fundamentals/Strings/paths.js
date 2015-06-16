function solve(input) {
    var rowsCols = input[0].split(' ').map(Number),
        rows = parseInt(rowsCols[0]),
        cols = parseInt(rowsCols[1]),
        matrix = [],
        matrixOfNumbers = [],
        fill,
        currentCol = 0,
        currentRow = 0,
        currentSum = 0,
        directions = {
        dr: {
            rows: +1,
            cols: +1
        },
        ur: {
            rows: -1,
            cols: +1
        },
        ul: {
            rows: -1,
            cols: -1
        },
        dl: {
            rows: +1,
            cols: -1
        }
    }
 
    for (var i = 1; i < input.length; i += 1) {
        matrix[i - 1] = input[i].split(' ');
    }
    // the matrix of directions is ready
 
    for (var i = 0; i < rows; i += 1) {
        matrixOfNumbers[i] = [];
        if (i !== 0) {
            fill = i * 2;
        }
        else {
            fill = i * 2 + 1;
        }
       
        for (var j = 0; j < cols; j += 1) {
            matrixOfNumbers[i][j] = fill;
            fill += 1;
        }
    }
    // the matrix of numbers is ready
 	var currentCell;
 
    while (true) {
        currentCell = matrix[currentRow][currentCol];
        currentSum += matrixOfNumbers[currentRow][currentCol];
        matrix[currentRow][currentCol] = 'visited';
       
        var nextCol = currentCol + directions[currentCell].cols;
        var nextRow = currentRow + directions[currentCell].rows;
       
        if (nextCol < 0 || nextCol > cols || nextRow < 0 || nextRow > rows) {
            console.log('successed with ' + currentSum);
            return;
        }
 
        if (matrix[nextRow][nextCol] == 'visited') {
            console.log('failed at (' + nextRow + ', ' + nextCol + ')');
            return;
        }
 
        currentCol = nextCol;
        currentRow = nextRow;
    }
}

var args1 =[
  '3 5',
  'dr dl dr ur ul',
  'dr dr ul ur ur',
  'dl dr ur dl ur'   
];

var args = [
  '3 5',
  'dr dl dl ur ul',
  'dr dr ul ul ur',
  'dl dr ur dl ur'   
];


solve(args);

