var multiset = (function () {

	// helper functions
	function swap(arr, i, j) {

		if ((i === j) || (arr[i] == arr[j])) {
			return;
		}

		var c = arr[i];
		arr[i] = arr[j];
		arr[j] = c;
	}
	
	// permutations generator
	function getPermutationsArray(array) {

		var permutations = [];

		function pushPermutations(arr, start, end, used) {

			var i,
				copiedArray;

			if (start === end) {
				permutations.push(arr);
				return;
			}

			for (i = start; i <= end; i++) {
				
				// if the the current element hasn't been used on this position
				if (used[start] !== arr[i]) {
					// mark it as used on this position for the current branch of the recursion
					used[start] = arr[i];
					
					copiedArray = arr.slice();
					swap(copiedArray, start, i);

					pushPermutations(copiedArray, start + 1, end, used.slice());
				}

			}
		}

		pushPermutations(array, 0, array.length - 1, []);

		return permutations;
	}

	return getPermutationsArray;
} ());

// var test = [1, 3, 5, 5],
//     test2 = [1, 5, 5, 5, 5, 5],
// 	   evlogiTest = [1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5];

// console.log(multiset(test));