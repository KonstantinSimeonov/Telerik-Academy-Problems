var combinations = (function () {

	function getCombinations(set, order) {

		if (order == set.length) {
			return [set];
		}

		if (order == 1) {
			return set.map(function (x) {
				return [x];
			});
		}

		var head,
			tails,
			combs = [],
			i,
			j;

		for (i = 0, length = set.length; i < length; i++) {

			head = set[i];
			// only difference is that you don't start slicing from i, but from i + 1 to exclude cases like (1, 1)
			tails = getCombinations(set.slice(i + 1), order - 1);

			for (j = 0; j < tails.length; j++) {
				combs.push([head].concat(tails[j]));
			}
		}

		return combs;
	}

	return getCombinations;
} ());

// var test1 = [1, 2, 3],
// 	test2 = [6, 2, 4, 5, 6];
// 	
// console.log(combinations(test1, 2));
// console.log(combinations(test2, 3));