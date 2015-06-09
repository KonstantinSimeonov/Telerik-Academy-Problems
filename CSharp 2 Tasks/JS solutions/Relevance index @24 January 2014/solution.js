function solve(params) {
	
	var word = params[0];
	
	var result = [];
	
	var wordExp = new RegExp('(^|[^a-z])' + word + '(?=([^a-z]|$))', 'gi');
	
	for (var i = 2; i < params.length; i+=1) {
		result[i-2] = [i, params[i].match(wordExp).length];
		
	}
	
	function compareMyJunk(a, b) {
		if(a[1] > b[1]) {
			return 1;
		} else if(a[1] < b[1]) {
			return -1;
		} else return 0;
	}
	
	result.sort(compareMyJunk);
	
	for (var i = 0; i < result.length; i+=1) {
		console.log(params[result[i][0]].replace(new RegExp(word + '(?=([^a-z]|$))', 'gi'), word.toUpperCase()).replace(/,|\.|\!|\?|\.\.\.|(,\s)|;/g, '').replace(/-/g, ' '));
		
	}
	
}

var zeroTest = [
"text",
"5",
"if you have someone to text",
"but the text is more than text to text",
"and you need a better text to text",
"try to text what the text would want to text another text with text",
"cause this text is too much about text, and a text will never teach you how to text"
];

var zeroTest2 = [
"a",
"3",
"a b c",
"b a a",
"c a a a"
];

var test1 = [
"don't",
"4",
"you don't want don't forgiveness don't",
"and don't don't don't don't you want it cheep",
"i don't don't give redemption",
"rewards for the meek don't"
];

var test2 = [
"something",
"13",
"somethin2g something something something has actually convinced people ",
"that there's an invisible something something",
"-- living in the something something something -- ",
"who watches something you do, ",
"every minute of every day. something something something something something somethingsomething something something something something somethingsomething something something something something somethingsomething something something something something ",
"And the invisible man has a special list something something something something something somethingsomething something something something something somethingsomething something something something something somethingsomething something something someth",
" something something something something something something something something something somethingof ten things he does not want you to do. ",
"And if you do any of these something something something something something ten things, ",
" something something something something something something something something something something something something something something something something something something something he has a special place, ",
"something something something something something something something something something something full of fire and smoke and burning andtorture and anguish, ",
"where he will send  something something something something something something you to live and suffer and burn and choke ",
"and scream and cry forever and ever 'til the end of something something something something something something something something something something something something time! ",
"But He loves you  something something something something something something something something."
];

var test3 = [
"cow",
"4",
"how now brown cow?",
"cow, cow, cow,",
"it is not when a cow is a cow",
"but then a cow is the cow who cow-and-cow"
];

var test4 = [
"a",
"9",
"a",
"a a",
"a a a",
"a a a a",
"a a a a a",
"a a a a a a",
"a a a a a a a ",
"a a a aaa a a a a a a",
"a a a a a a a a a a a a  a aaa a a a aa a a a a a a a a a"
];


solve(test4);