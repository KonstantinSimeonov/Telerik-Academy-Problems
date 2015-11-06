var permutations = (function () {

	// helper functions
	function swap(arr, i, j) {

		if ((i === j) || (arr[i] == arr[j])) {
			return;
		}

		var c = arr[i];
		arr[i] = arr[j];
		arr[j] = c;
	}

	function getNumbers(n) {
		var result = [],
		i;

		for (i = 0; i < n; i++) {
			result[i] = i + 1;
		}

		return result;
	}
	
	// permutations generator
	function getPermutationsArray(array) {

		var permutations = [],
			used = {};

		function pushPermutations(arr, start, end) {
			
			var i,
				copiedArray;
			
			if (start === end) {

				if (used[arr.toString()]) {
					return;
				}

				permutations.push(arr);
				used[arr.toString()] = true;

				return;
			}

			for (i = start; i <= end; i++) {

				copiedArray = arr.slice();
				swap(copiedArray, start, i);

				pushPermutations(copiedArray, start + 1, end);
			}
		}

		pushPermutations(array, 0, array.length - 1);

		return permutations;
	}
	
	return function (n) {
		return getPermutationsArray(getNumbers(n));
	};
} ());

// console.log(permutations(3));