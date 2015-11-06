var variations = (function () {
	
	var allVariations;
	
	function pushVariations(order, set, variation) {
		
		var i,
			length;
		
		if(order === 0) {
			allVariations.push(variation);
			return;
		}
		
		for (i = 0, length = set.length; i < length; i++) {
			
			// take the variation we have this far append all different elements from the set
			variation[order - 1] = set[i];
			pushVariations(order - 1, set, variation.slice());
		}
	}
	
	return function (order, set) {
		allVariations = [];
		
		pushVariations(order, set, []);
		
		return allVariations;
	}
} ());

// console.log(variations(3, [3,4,5,6]));