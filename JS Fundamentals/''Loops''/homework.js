/* Problem 1 */
console.log("---------- Problem 1 ----------");

function printNumbers(last) {
	if(last === 0) {
		return;
	}
	printNumbers(last - 1)

	console.log(last);
}

var userInteger = 10;

printNumbers(userInteger);

/* Problem 2 */
console.log("---------- Problem 2 ----------");

function printDivisableNumbers(last) {
	if(last === 0) {
		return;
	}
	printDivisableNumbers(last - 1)
	
	if(last % 3 !== 0 && last % 7 !== 0) {
		console.log(last);
	}
}

printDivisableNumbers(30);

/* Problem 3 */
console.log("---------- Problem 3 ----------");

function getMinMax(array, min, max, index) {
	if(array.length === index - 1) {
		return [min, max];
	}
	
	if(array[index] > max) {
		max = array[index];
	}
	
	if(array[index] < min) {
		min = array[index];
	}
	
	return getMinMax(array, min, max, index + 1);
}

var numbers = [1, -4, 15, -300, 80, 2929292, 5, 11, 292993, -1111];

console.log(getMinMax(numbers, Number.MAX_VALUE, Number.MIN_VALUE, 0));

