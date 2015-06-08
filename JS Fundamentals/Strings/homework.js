/* Problem 1 */
console.log('--------- Problem 1 ---------');

var userString = 'atakuk uk uk otak';
var result = '';

for (var i = userString.length - 1; i >= 0; i-=1) {
	result+=userString[i];
	
}

console.log(result);

/* Problem 2 */
console.log('\n--------- Problem 2 ---------');

var expr = '((a+b)*(t))+(3)';
var expr2 = '((a+b)*(t))+(3))';

function validateBrackets(expression) {
	var stack = [];
	var len = expression.length;
	for (var i = 0; i < len; i+=1) {
		if(expression[i] === '(') {
			stack.push('(');
		}
		
		if(expression[i] === ')') {
			if(stack.length === 0) {
				return false;
			}
			
			stack.pop();
		}
		
	}
	
	return stack.length === 0;
}

console.log(validateBrackets(expr));
console.log(validateBrackets(expr2));

/* Problem 3 */
console.log('\n--------- Problem 3 ---------');

var test = "The text is as follows: We are living in an yellow submarine. We don't have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

function getSubstringOccurrences(substr, str) {
	return str.split(substr).length - 1;
}

console.log(getSubstringOccurrences('in', test));

/* Problem 4 */
console.log('\n--------- Problem 4 ---------');

function parseTag(html) {
	
	function toMixedCase(str) {
		var result = '';
		var words = str.split(' ');
		var len1 = words.length, len2;
		for (var i = 0; i < len1; i+=1) {
			len2 = words[i].length;
			for (var j = 0; j < len2; j+=1) {
				result += (j & 1) === 0 ? words[i][j].toUpperCase() : words[i][j].toLowerCase();
				
			}
			
			words[i] = result;
			result = '';
			
		}
		
		return words.join(' ');
	}
	
	var opened = 0;
	var currentStart = 0;
	var currentCase;
	var tags = [];
	var repTags = /<.+?>/g;
	var temp;
	var whitespace = /\s\s+/g;
	tags['u'] = 'upcase';
	tags['l'] = 'lowcase';
	tags['m'] = 'mixcase';
	
	for (var i = 0; i < html.length; i+=1) {
		while (html[i] !== '<' && i < html.length) {
			i+=1;
		}
		
		if(opened === 0) {
			currentStart = i;
			opened+=1;
			currentCase = tags[html[i+1]];
		} else if(html[i+1] === '/') {
			if(tags[html[i+2]] === currentCase) {
				opened-=1;
				
				if(opened === 0){
					temp = html.substring(currentStart, i + 3 + currentCase.length);
					switch (currentCase) {
						case 'upcase':
							html = html.replace(temp, temp.replace(repTags, '').toUpperCase());
							break;
						case 'lowcase':
							html = html.replace(temp, temp.replace(repTags, '').toLowerCase());
							break;
						case 'mixcase':
							html = html.replace(temp, toMixedCase(temp.replace(repTags, '')));
							break;
						default:
							break;
					}
					i = currentStart;
				}
			}
		} else if(tags[html[i+1]] === currentCase) {
			opened+=1;
		}
		
	}
	
	return html.replace(whitespace, ' ');
}
var kopon = "We are <mixcase>living </mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.";

console.log(parseTag(kopon));

/* Problem 5 */
console.log('\n--------- Problem 5 ---------');

function NBSP(html) { // too lazy to write adequate tests, sorrey
	return html.replace(String.fromCharCode(160), '&nbsp;');
}

/* Problem 6 */
console.log('\n--------- Problem 6 ---------');

var test6 = [
"<html>",
"  <head>",
"    <title>Sample site</title>",
"  </head>",
"  <body>",
"    <div>text",
"      <div>more text</div>",
"      and more...",
"    </div>",
"    in body",
"  </body>",
"</html>"
];

function getContent(html) {
	return html.join('\n').replace(/(^|\n)\s*/g, '').replace(/<.+?>/g, '');
}

console.log(getContent(test6));

/* Problem 7 */
console.log('\n--------- Problem 7 ---------');

var protocol = /.*:\/\//, server = /:\/\/.*?\//, rep = /.*\/\/.*?(?=\/)/, resource;

var url = 'http://telerikacademy.com/Courses/Courses/Details/239';

protocol = url.match(protocol)[0];
protocol = protocol.substring(0, protocol.length - 3);

server = url.match(server)[0];
server = server.substring(3, server.length - 1);

resource = url.replace(rep, '');

console.log('protocol: ' + protocol);
console.log('server: ' + server);
console.log('resource' + resource);


/* Problem 8 */
console.log('\n--------- Problem 8 ---------');

var testHtml = "<p>Please visit <a href=\"http://academy.telerik.com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";

var openingAnchor = /<a href=".*?">/g, closingAnchor = /<\/a>/g, href = /".+?"/, opening = '[URL=', right = ']', closing = '[/URL]';

testHtml = testHtml.replace(closingAnchor, closing);

var matches = testHtml.match(openingAnchor);
var len = matches.length, content;

for (var i = 0; i < len; i+=1) {
	content = matches[i].match(href)[0].replace(/"/g, '');
	testHtml = testHtml.replace(matches[i], opening + content + right);
}

console.log(testHtml);


/* Problem 9 */
console.log('\n--------- Problem 9 ---------');

// prepisah go kato kuche ot http://snipplr.com/view/26466/extract-email-from-bulk-text-with-regular-expressions-javascript--jquery/

function extractEmails (text){
	return text.match(/([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9._-]+)/gi);
}

var mailzText = 'kircho.dragoev@abv.bg mi e liubimiq email. gosho ot pochivka, javascript, php, mvc, gg. some text, moretext.com, some_mail@gmail.com fdgjkfdghdfkjgdhf@goshomail.com';

console.log(extractEmails(mailzText));

/* Problem 10 */
console.log('\n--------- Problem 10 ---------');

var testArray = ['gosho', 'radar', 'pesho', 'NaN', 'abcdcba', 'booooriiiiing', 'lol', 'yolo', 'svag', 'palindromeemordnilap', 'kopon'];

function isPalindrome(str) {
	
	function reverse(s) {
		var result = '', len = s.length;
		
		for (var i = 0; i < len; i+=1) {
			result+= s[len - 1 - i];
			
		}
		return result;
	}
	
	return str === reverse(str);
	
}

var palindromesKey = 'palindromes';
var nonPalindromesKey = 'non-palindromes';

var answer = [];
answer[palindromesKey] = [];
answer[nonPalindromesKey] = [];

for (var i = 0; i < testArray.length; i+=1) {
	answer[(isPalindrome(testArray[i]) ? palindromesKey : nonPalindromesKey)].push(testArray[i]);
	
}

console.log(answer);

/* Problem 11 */
console.log('\n--------- Problem 11 ---------');

function format() {
	var args = arguments, placeholder = /\{[0-9]*?\}/g;
	
	var placeholders = args[0].match(placeholder);
	
	var len = placeholders.length;
	
	for (var i = 0; i < len; i+=1) {
		args[0] = args[0].replace(placeholders[i], args[i+1]);
		
	}
	
	return args[0];
}

var gosho = format('{0} e {1}', 'gosho', 'pich');
console.log(gosho);

/* Problem 12 */
console.log('\n--------- Problem 12 ---------');

var sampleHtml = [
"<div data-type=\"template\" id=\"list-item\">",
" <strong>-{name}-</strong> <span>-{age}-</span>",
" <strong>-{name}-</strong> <span>-{age}-</span>",
"</div>"
];
var koponWe = [];
koponWe[0] = sampleHtml[0];
koponWe[1] = sampleHtml[sampleHtml.length - 1];
var people = [{name: 'pesho', age: 14}, {name: 'stamat', age: 29}, {name: 'penka', age: 6}];
var rows = sampleHtml.slice(1, sampleHtml.length - 1);
sampleHtml = sampleHtml.join('\n');

var matchPlaceholders = /-\{.+?\}-/g, placeholders = sampleHtml.match(matchPlaceholders);

var len = placeholders.length;

var list = '<ul>\n' + new Array(people.length + 1).join('    <li>'+rows.join('</li>\n    <li>')+'</li>\n') + '</ul>';
var key;
for (var i = 0; i < len; i+=1) {
	for (var j = 0; j < people.length; j+=1) {
		key = placeholders[i].substring(2, placeholders[i].length - 2);
		list = list.replace(placeholders[i], people[j][key]);
			
		
	}
	
}

console.log(koponWe.join('\n    ' + list.replace(/\n/g, '\n    ') + '\n'));