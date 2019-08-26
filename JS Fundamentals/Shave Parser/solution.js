var jsonsmurdi = ["6",
"title:Telerik Academy",
"showSubtitle:true",
"subTitle:Free training",
"showMarks:false",
"marks:3,4,5,6",
"students:Pesho,Gosho,Ivan",
"42",
"@section menu {",
"<ul id=\"menu\">",
"    <li>Home</li>",
"    <li>About us</li>",
"</ul>",
"}",
"@section footer {",
"<footer>",
"    Copyright Telerik Academy 2014",
"</footer>",
"}",
"<!DOCTYPE html>",
"<html>",
"<head>",
"    <title>Telerik Academy</title>",
"</head>",
"<body>",
"    @renderSection(\"menu\")",
"",
"    <h1>@title</h1>",
"    @if (showSubtitle) {",
"        <h2>@subTitle</h2>",
"        <div>@@JustNormalTextWithDoubleKliomba ;)</div>",
"    }",
"",
"    <ul>",
"        @foreach (var student in students) {",
"            <li>",
"                @student ",
"            </li>",
"            <li>Multiline @title</li>",
"        }",
"    </ul>",
"    @if (showMarks) {",
"        <div>",
"            @marks ",
"        </div>",
"    }",
"",
"    @renderSection(\"footer\")",
"</body>",
"</html>"];

var oh = ["0",
"18",
"@section pesho {",
"kvo",
"}",
"<div>",
"    <p>",
"    @@if (pesho)",
"        @@escaped dude",
"    </p>",
"    <p>",
"    @@@renderSection(\"pesho\")",
"    </p>",
"    <p>",
"    @@foreach(var pesho in peshos)",
"        @@escaped in comment",
"    </p>",
"</div>"];

var boli = ["2",
"text:RandomText",
"anotherText:RandomTextAgain",
"10",
"<div>",
"    <div>",
"        @text ",
"    </div>",
"    <ul>",
"        <li>",
"             <span>@anotherText</span>",
"        </li>",
"    </ul>",
"</div>"];


var six = ["2",
"someNumbers:1,2,3,4,5",
"someTechs:asp.net,mvc,angular,node,c-sharp",
"14",
"<div>",
"    <span>Some bulsh*t text</span>",
"    <br />",
"    @foreach (var number in someNumbers) {",
"        <span>@number da ima</span>",
"        <span>only @number</span>",
"    }",
"    <br />",
"    <div>",
"        <span>More bulsh*t text</span>",
"        @foreach (var tech in someTechs) {",
"            <span>@tech is cool</span>",
"            <span>and @tech is mama</span>",
"        }",
"    <div>",
"</div>",]

var nine = [
	"5",
"pesho:gosho",
"gosho:pesho",
"if:gadno",
"foreach:hackvane",
"renderSection:ivaylo sucks ;D",
"8",
"<div>",
"    @@if (pesho)",
"    @if (pesho)",
"    @foreach (var nqma in nikoi)",
"    @pesho ",
"    @gosho ",
"    @renderSection ",
"</div>"
]

function solve(params) {
	
	var renderSection = '@renderSection';
	var foreach = '@foreach';
	var condition = '@if';
	
	function getSectionName(line) {
		return line.split(' ')[1];
	}
	
	function isLetter(char) {
		var code = char.charCodeAt(0);
		return (code >= 65 && code <= 90) || (code >= 97 && code <= 122);
	}
	
	var n = parseInt(params[0]);
	var models = [], sections = [], html = [], m, store = [];
	
	for (var i = 1; i <= n; i+=1) {
		store = params[i].split(':');
		models[store[0]] = store[1].split(',');
		
	}
	
	m = parseInt(params[n + 1]);

	var opened = false, atIndex, sectionName, sectionLength = 0;

	for (var k = n + 1; k < m && (opened || params[k][0] !== '<'); k+=1) {
		sectionLength+=1;
		if(params[k][0] === '@') {
			opened = true;
			sectionName = getSectionName(params[k]);
			sections[sectionName] = [];
		} else if(params[k][0] === '}') {
			opened = false;
		} else if(opened) {
			sections[sectionName].push(params[k]);
		}
	}
	
	html = params.slice(n + sectionLength + 1);
	
	var htmlLength = html.length;
	var currentLineLength, atCount = 1, cmd, cmdEnd, cmdStart, arg, start = 0, even = false, foreachCollection, placeholder, loopArr = [];
	
	for (var line = 0; line < html.length; line+=1) {
		
		atIndex = html[line].indexOf('@');
		
		while(atIndex !== -1) {
			
			if(html[line].indexOf('@@') !== -1) {
				html[line] = html[line].replace('@@', '@');				
				
			} else {
				
				cmdStart = atIndex;
				cmdEnd = cmdStart + 1;
				
				while(isLetter(html[line][cmdEnd]) && cmdEnd < html[line].length) {
					cmdEnd+=1;
				}
				
				cmd = html[line].substring(cmdStart, cmdEnd);

				switch (cmd) {
					case renderSection: 
						if(html[line][cmdEnd] === '(' && html[line][cmdEnd + 1] == '"') {
							var s = cmdEnd + 2;
							var e = s;
							while (html[line][e] !== '"') {
								e+=1;
							}
							arg = html[line].substring(s,e);
							html[line] = html[line].replace(renderSection + '("' + arg + '")', sections[arg].join('\n' + new Array(atIndex + 1).join(' ')));
						} else {

						html[line] = html[line].replace(cmd, models[cmd.substring(1, cmd.length)][0]);

					
						}
						
						break;
					case condition:
					if(html[line].indexOf('{') === -1) {
						html[line] = html[line].replace(cmd, models[cmd.substring(1, cmd.length)][0]);
						break;
					}
						e=0;
						if(html[line][cmdEnd + 1] === '(') {
							while(html[line][e] !== ')') {
								e+=1;
							}
							
							arg = html[line].substring(cmdEnd + 2, e);
							
							e = line;
							while(html[e].indexOf('}') ===-1) {
								e+=1;
							}
							
							if(models[arg][0] === 'true'){
								for (var i = line; i < e; i+=1) {
									html[i] = html[i].substring(4, html[i].length);

								}
								html.splice(e, 1);
								html.splice(line, 1);
								line-=2;
							} else {
								html.splice(line, e - line + 1);
								line -= e - line + 1;
							}
								
						
						
						}
						break;
					case foreach: 
					if(html[line].indexOf('{') === -1) {
						html[line] = html[line].replace(cmd, models[cmd.substring(1, cmd.length)][0]);
						break;
					}
						e = line;
						if(html[line][cmdEnd + 1] === '(') {
							var temp = html[line].substring(cmdEnd+1, html[line].indexOf(')', cmdEnd + 2)).split(' ');
							placeholder = temp[1];
							foreachCollection = temp[3];
							html.splice(line, 1);
							
							while(html[e].indexOf('}') === -1) {
								e+=1;
							}
							
							loopArr = html.splice(line, e - line);
							html.splice(line, 1);
							var kopon = loopArr.length;
							var kupon = models[foreachCollection].length;
							for (var k = 0, j = 1; k < kopon * kupon; k+=1) {
								if(loopArr[kopon - (k % kopon) - 1].indexOf('@'+placeholder) !== -1) {
									html.splice(line, 0, loopArr[kopon - (k % kopon) - 1].substring(4, loopArr[kopon - (k % kopon) - 1].length).replace('@' + placeholder, models[foreachCollection][kupon - j]));
									if((k+1) % kopon === 0) {
										j+=1;
									}
								} else {
									html.splice(line, 0, loopArr[kopon - (k % kopon) - 1].substring(4, loopArr[kopon - (k % kopon) - 1].length));
								}
									
							}
							
						}
						
						break;
				
					default:
					

							html[line] = html[line].replace(cmd, models[cmd.substring(1, cmd.length)][0]);
						
						break;
				}		
				
			}
			
			atIndex = html[line].indexOf('@', atIndex + 1);
			
		}
		atCount = 1;		
		
		
	}

	console.log(html.map(function (line){return line.trim()}).join('\n'));
	
}

solve(nine);