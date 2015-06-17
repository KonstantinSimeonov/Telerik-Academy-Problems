function solve() {
	return function sol(start, end) {

		var len,
			isPrime,
			answer = [];

		if (start === undefined || end === undefined) {
			throw 'Error! At least one of the passed parameteres is undefined';
		}

		start = parseInt(start);
		end = parseInt(end);

		if (isNaN(start) || isNaN(end)) {
			throw 'Error! At least one of the passed parameteres is NaN';
		}

		if (start <= 2) { // if 2 is in the range, push it
			answer.push(2);
			start = 3;
		}

		if (start % 2 === 0) { // start from an odd number
			start += 1;
		}

		for (var i = start; i <= end; i += 2) { // need to check only the odd numbers

			isPrime = true;
			len = Math.sqrt(i);
			
			// do a prime check from 3 till sqrt of i
			
			for (var j = 3; j <= len; j += 2) {
				if (i % j === 0) {
					isPrime = false;
					break;
				}

			}

			if (isPrime) {
				answer.push(i);
			}

		}

		return answer;
	};
}