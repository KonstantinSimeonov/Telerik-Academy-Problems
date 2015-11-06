var queens = (function (n) {
	
	// check out this awesome bitwise solution: http://gregtrowbridge.com/a-bitwise-solution-to-the-n-queens-problem-in-javascript/

	// cheap field representation: index means column, value means row
	var field = [],
		solutions = [];
	
	// 'fancy' chess board generator, ignore
	function getBoard() {
		
		var result = [],
			i,
			j;
			
		for (i = 0; i < n; i++) {
			
			result[i] = [];
			for (j = 0; j < n; j++) {
				result[i] += '   ' + ((i === field[j]) ? 'Q' : 'x');
			}
		}
		
		return result;
	}
	
	// magic
	function isChecked(q, p) {

		for (var i = 1; i <= q; i += 1) {
			// check row, column, and diagonals
			if (field[q - i] === p || field[q - i] === p + i || field[q - i] === p - i) {
				return true;
			}
		}

		return false;
	}

	function solve(k) {
		if (k === n) {
			solutions.push(getBoard());
			return;
		}
		
		for (var i = 0; i < n; i += 1) {
			
			if (!isChecked(k, i)) {
				// using k and i to avoid copying the array for calculations
				field[k] = i;
				solve(k + 1);
			}

		}
	}
	
	return function () {
		field = [];
		solutions = [];
		solve(0);
		
		return solutions;
	}
// put queens here
} (4));

// console.log(queens());