var combinations = (function () {

	function getCombinations(set, order) {
		
		// example: combination of order 3 from the set [1,2,3] is [1,2,3]
		if (order == set.length) {
			return [set];
		}
		
		// combination from order 1 consists of all single elements in the set
		// is also the recursion bottom
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
			
			// take an element
			head = set[i];
			// and get the possible combinations of the remaining elements
			// skip the already computed combinations by passing the remaining elements
			// but keep combinations like (2,2) ---> set.slice(i)
			tails = getCombinations(set.slice(i), order - 1);
			
			// combine them
			for (j = 0; j < tails.length; j++) {
				combs.push([head].concat(tails[j]));
			}
		}
		
		// return the combined results
		return combs;
	}

	return getCombinations;
} ());

// var test1 = [1, 2, 3],
// 	test2 = [6, 2, 4, 5, 6];
// 	
// console.log(combinations(test1, 2));
// console.log(combinations(test2, 3));