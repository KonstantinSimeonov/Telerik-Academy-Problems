/* Problem 4 */
console.log("---------- Problem 4 ----------");

function getProperties(target){
	var keys = Object.keys(target);
	keys.sort();
	return [keys[0], keys[keys.length - 1]];
}

function solve() {
	console.log("first         last")
	console.log(getProperties(document));
	console.log(getProperties(window));
	console.log(getProperties(navigator));
}