function solve() {
	return function sum(arr) {
		var sum = 0;

		if (arr === undefined) {
			throw Error;
		}

		if (arr.length === 0) {
			return null;
		}

		arr.map(Number).forEach(function (element) {
			if (isNaN(element)) {
				throw Error;
			}

			sum += element;

		}, this);

		return sum;
	};
}

console.log((solve())([1, 2, 3, 4, 5, -6]));