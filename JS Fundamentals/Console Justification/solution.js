function solve(params) {
	var n = params[0] * 1, w = params[1] * 1;
	var result = [];
	var mirishe = 0;
	var text = [];
	var current;
	var gg = params.length, gg1;
	var wordCount = 0;
	for (var i = 2; i < gg; i+=1) {
		current = params[i].split(' ');
		gg1 = current.length;
		for (var j = 0; j < gg1; j+=1) {
			if(current[j] !== '') {
				text[wordCount] = current[j];
				wordCount+=1;
				
			}
			mirishe+=1;
		}
		mirishe+=1;
	}
	
	var i = 0, line = 0, len = text.length;
	var ind, currentLength = 0;
	
	
	
	while(i < len) {
		
		if(result[line] === undefined) {
			result[line] = [];
		}
		
		if(currentLength + text[i].length <= w) {
			if(currentLength !== 0 && currentLength !== w) {
				result[line].push(' ');
				currentLength+=1;
			}
				result[line].push(text[i]);
				currentLength+=text[i].length;
			i+=1;
			if(currentLength === w) {
				line+=1;
				currentLength = 0;
			}
			
		} else if(result[line].length === 1) {
			line+=1;
			currentLength = 0;
		} else if(currentLength < w) {
			ind = 0;
			
			var spaces = w - currentLength;
			var g = 1;
			
			while(spaces > 0) {	
				result[line][g]+=' ';
				g+=2;
				g%=result[line].length - 1;
				spaces-=1;
				mirishe+=1;
			}
			
			
			currentLength = 0;
			line+=1;
		}
		
		mirishe+=1;
		
	}
	
	console.log(result.map(function (arr){return arr.join('');}).join('\n'));
	console.log(mirishe);
}

var zeroTest1 = [
"5",
"20",
"We happy few        we band",
"of brothers for he who sheds",
"his blood",
"with",
"me shall be my brother"
];

var test = [
"10",
"18",
"Beer beer beer Im going for ",
"   a",
"beer",
"Beer beer beer Im gonna",
"drink some beer",
"I love drinkiiiiiiiiing ",
"beer",
"lovely ",
"lovely",
"beer"
];

solve(zeroTest1);

