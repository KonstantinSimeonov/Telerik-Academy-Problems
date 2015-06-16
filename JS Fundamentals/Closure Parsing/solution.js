function solve(params) {

	var funcs = [];

	var len = params.length;
	var inner, funcs = [];



	function evaluate(str) {

		var nested;

		if (str.length === 2 && typeof (str) !== typeof ('')) {
			nested = str[1];
		}

		if (typeof (str) !== typeof ('')) {
			str = str[0].split(' ');
		} else {
			str = str.split(' ');
		}


		var sum = 0, currentModel, cmd;
		var evaled;



		switch (str[0]) {
			case 'def':
				if (nested !== undefined) {
					evaled = evaluate(nested);
					if (evaled === 'Division by 0! At line:') {
						return evaled;
					}
					funcs[str[1]] = evaled;
				} else {

					if (isNaN(str[2] * 1)) {
						funcs[str[1]] = funcs[str[2]];
					} else {
						funcs[str[1]] = str[2] * 1;
					}

				}
				break;
			case '+':
				for (var i = 1; i < str.length; i += 1) {
					if (isNaN(str[i] * 1)) {
						sum += funcs[str[i]];
					} else {
						sum += str[i] * 1;
					}

				}
				return sum;
			case '-':
				sum = isNaN(str[1]) ? funcs[str[1]] : 1 * str[1];
				for (var i = 2; i < str.length; i += 1) {
					if (isNaN(str[i] * 1)) {
						sum -= funcs[str[i]];
					} else {
						sum -= str[i] * 1;
					}

				}
				return sum;
				break;
			case '/':
				sum = isNaN(str[1]) ? funcs[str[1]] : 1 * str[1];
				for (var i = 2; i < str.length; i += 1) {



					if (isNaN(str[i] * 1)) {
						if (funcs[str[i]] === 0) {
							return 'Division by 0! At line:';
						}
						sum /= funcs[str[i]];
					} else {
						sum /= str[i] * 1;
						if (str[i] * 1 === 0) {
							return 'Division by 0! At line:';
						}
					}
					sum = (sum | 0);
				}
				return sum;
				break;
			case '*':
				sum = isNaN(str[1]) ? funcs[str[1]] : 1 * str[1];

				for (var i = 2; i < str.length; i += 1) {

					if (isNaN(str[i] * 1)) {
						sum *= funcs[str[i]];
					} else {
						sum *= str[i] * 1;
					}

				}
				return (sum);
				break;

			default:
				break;
		}
	}

	for (var i = 0; i < len; i += 1) {
		params[i] = params[i].replace(/\(|\)/g, ' | ').replace(/\s\s+/g, ' ');
		params[i] = params[i].split(' | ');
		params[i] = params[i].slice(1, params[i].length - 1);
		console.log(params[i]);
		var pisnaMi = evaluate(params[i]);
		if (pisnaMi === 'Division by 0! At line:') {
			console.log('Division by zero! At Line:' + (i + 1));
			break;
		}

		if (i === len - 1) {
			console.log(pisnaMi);
		}



	}

}

var test = [
	"(def   func      10)",
	"(def newFunc (  +     func 2))",
	"(definition defResult -10)",
	"(def     sumFunc (+ func func   newFunc 0 0 0))",
	"(* sumFunc     2)"
];

var test1 = [
	"(def func -5)",
	"(definition defResult -10)",
	"(def func2 (/  10 3 2 0))",
	"(def func3 (* func))",
	"(+ func2)"
];

var testy = [
	"(def myFunc -5)",
	"(def myNewFunc myFunc)",
	"(def MyFunc (* 2  myNewFunc))",
	"(/   0  myFunc)"
];

var test10 = [
	"(+ 1 2)",
	"(+ -5 2 7 1)",
	"(- -5 2) ",
	"(- 4) ",
	"(/ 2)",
	"(+ -5 -3)"
];

solve(test);
