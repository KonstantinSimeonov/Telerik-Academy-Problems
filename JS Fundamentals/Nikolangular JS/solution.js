var zeroTest = [
"6",
"title-Telerik Academy",
"showSubtitle-true",
"subTitle-Free training",
"showMarks-false",
"marks-3;4;5;6",
"students-Ivan;Gosho;Pesho",
"42",
"<nk-template name=\"menu\">",
"    <ul id=\"menu\">",
"        <li>Home</li>",
"        <li>About us</li>",
"    </ul>",
"</nk-template>",
"<nk-template name=\"footer\">",
"    <footer>",
"        Copyright Telerik Academy 2014",
"    </footer>",
"</nk-template>",
"<!DOCTYPE html>",
"<html>",
"<head>",
"    <title>Telerik Academy</title>",
"</head>",
"<body>",
"    <nk-template render=\"menu\" />",
"",
"    <h1><nk-model>title</nk-model></h1>",
"    <nk-if condition=\"showSubtitle\">",
"        <h2><nk-model>subTitle</nk-model></h2>",
"        <div>{{<nk-model>subTitle</nk-model>}} ;)</div>",
"    </nk-if>",
"",
"    <ul>",
"        <nk-repeat for=\"student in students\">",
"            <li>",
"                <nk-model>student</nk-model>",
"            </li>",
"            <li>Multiline <nk-model>title</nk-model></li>",
"        </nk-repeat>",
"    </ul>",
"    <nk-if condition=\"showMarks\">",
"        <div>",
"            <nk-model>marks</nk-model> ",
"        </div>",
"    </nk-if>",
"",
"    <nk-template render=\"footer\" />",
"</body>",
"</html>"
];

var test1 = [
"0",
"15",
"<div>",
"    <p>",
"    {{<nk-if condition=\"pesho\">}}",
"        {{escaped}} dude",
"    </p>",
"    <p>",
"    {{<nk-template render=\"pesho\">}}",
"    </p>",
"    <p>",
"    {{<nk-repeat for=\"pesho in peshos\">}}",
"        {{escaped}} in comment",
"    </p>",
"</div>"
];

var test2 = [
"0",
"21",
"<nk-template name=\"first\">",
"    <ul>",
"        <li>",
"            In section UL",
"        </li>",
"        <li>",
"            Still in section UL",
"        </li>",
"    </ul>",
"</nk-template>",
"<nk-template name=\"second\">",
"    <div>",
"        Second section :)",
"    </div>",
"</nk-template>",
"<div>",
"    <nk-template render=\"first\" />",
"    <nk-template render=\"second\" />",
"</div>"
];

var test3 = [
"2",
"text-RandomText",
"anotherText-RandomTextAgain",
"10",
"<div>",
"    <div>",
"        <nk-model>text</nk-model>",
"    </div>",
"    <ul>",
"        <li>",
"             <span><nk-model>anotherText</nk-model></span>",
"        </li>",
"    </ul>",
"</div>"
];

var test4 = [
"2",
"passTheIf-true",
"doNotPassTheIf-false",
"14",
"<div>",
"    <p>Some bulsh*t text</p>",
"    <br />",
"    <nk-if condition=\"passTheIf\">",
"        <span>Passed</span>",
"    </nk-if>",
"    <br />",
"    <div>",
"        <span>More bulsh*t text</span>",
"        <nk-if condition=\"doNotPassTheIf\">",
"            <span>if this passes this is error</span>",
"        </nk-if>",
"    <div>",
"</div>"
];

var test5 = [
"4",
"passTheIf-true",
"doNotPassTheIf-false",
"pesho-na peshlqka modela",
"gosho-i gosho e tuka brato",
"14",
"<div>",
"    <p>Some bulsh*t text + <nk-model>pesho</nk-model> & <nk-model>gosho</nk-model></p>",
"    <br />",
"    <nk-if condition=\"passTheIf\">",
"        <span>Passed <nk-model>pesho</nk-model> and <nk-model>gosho</nk-model></span>",
"    </nk-if>",
"    <br />",
"    <div>",
"        <span>More bulsh*t text</span>",
"        <nk-if condition=\"doNotPassTheIf\">",
"            <span>if this passes this is error <nk-model>pesho</nk-model> and <nk-model>gosho</nk-model></span>",
"        </nk-if>",
"    <div>",
"</div>"
];

var test6 = [
"2",
"someNumbers-1;2;3;4;5",
"someTechs-asp.net;mvc;angular;node;c sharp",
"14",
"<div>",
"    <span>Some bulsh*t text</span>",
"    <br />",
"    <nk-repeat for=\"number in someNumbers\">",
"        <span><nk-model>number</nk-model> da ima</span>",
"        <span>only <nk-model>number</nk-model></span>",
"    </nk-repeat>",
"    <br />",
"    <div>",
"        <span>More bulsh*t text</span>",
"        <nk-repeat for=\"tech in someTechs\">",
"            <span><nk-model>tech</nk-model> is cool</span>",
"            <span>and <nk-model>tech</nk-model> is mama</span>",
"        </nk-repeat>",
"    <div>",
"</div>"
];

var test7 = [
"4",
"someNumbersHere-1;2;3;4;5",
"someTechsHere-asp.net;mvc;angular;node;c sharp",
"kolio-nikolay",
"minkov-donchoviq",
"14",
"<div>",
"    <span>Some bulsh*t text</span>",
"    <br />",
"    <nk-repeat for=\"someNumber in someNumbersHere\">",
"        <span><nk-model>someNumber</nk-model> da ima</span>",
"        <span>only <nk-model>someNumber</nk-model></span>",
"        <strong><nk-model>kolio</nk-model></strong>",
"    </nk-repeat>",
"    <br />",
"    <div>",
"        <span>More bulsh*t text</span>",
"        <nk-repeat for=\"someTech in someTechsHere\">",
"            <span><nk-model>someTech</nk-model> is cool</span>",
"            <span>and <nk-model>someTech</nk-model> is mama</span>",
"            <strong><nk-model>minkov</nk-model></strong>",
"        </nk-repeat>",
"    <div>",
"</div>"
];

var test8 = [
"15",
"text-RandomText",
"anotherText-RandomTextAgain",
"passTheIf-true",
"doNotPassTheIf-false",
"passTheIf-true",
"doNotPassTheIf-false",
"pesho-na peshlqka modela",
"gosho-i gosho e tuka brato",
"someNumbers-1;2;3;4;5",
"someTechs-asp.net;mvc;angular;node;c sharp",
"someNumbersHere-1;2;3;4;5",
"someTechsHere-asp.net;mvc;angular;node;c sharp",
"kolio-nikolay",
"minkov-donchoviq",
"unused-just unused model",
"106",
"<nk-template name=\"first\">",
"    <ul>",
"        <li>",
"            In section UL",
"        </li>",
"        <li>",
"            Still in section UL",
"        </li>",
"    </ul>",
"</nk-template>",
"<nk-template name=\"second\">",
"    <div>",
"        Second section :)",
"    </div>",
"</nk-template>",
"<div>",
"    <p>",
"    {{<nk-if condition=\"pesho\">}}",
"        {{escaped}} dude",
"    </p>",
"    <p>",
"    {{<nk-template render=\"pesho\">}}",
"    </p>",
"    <p>",
"    {{<nk-repeat for=\"pesho in peshos\">}}",
"        {{escaped}} in comment",
"    </p>",
"</div>",
"<div>",
"    <nk-template render=\"first\" />",
"    <nk-template render=\"second\" />",
"</div>",
"<div>",
"    <div>",
"        <nk-model>text</nk-model>",
"    </div>",
"    <ul>",
"        <li>",
"             <span><nk-model>anotherText</nk-model></span>",
"        </li>",
"    </ul>",
"</div>",
"<div>",
"    <p>Some bulsh*t text</p>",
"    <br />",
"    <nk-if condition=\"passTheIf\">",
"        <span>Passed</span>",
"    </nk-if>",
"    <br />",
"    <div>",
"        <span>More bulsh*t text</span>",
"        <nk-if condition=\"doNotPassTheIf\">",
"            <span>if this passes this is error</span>",
"        </nk-if>",
"    <div>",
"</div>",
"<div>",
"    <p>Some bulsh*t text + <nk-model>pesho</nk-model> & <nk-model>gosho</nk-model></p>",
"    <br />",
"    <nk-if condition=\"passTheIf\">",
"        <span>Passed <nk-model>pesho</nk-model> and <nk-model>gosho</nk-model></span>",
"    </nk-if>",
"    <br />",
"    <div>",
"        <span>More bulsh*t text</span>",
"        <nk-if condition=\"doNotPassTheIf\">",
"            <span>if this passes this is error <nk-model>pesho</nk-model> and <nk-model>gosho</nk-model></span>",
"        </nk-if>",
"    <div>",
"</div>",
"<div>",
"    <span>Some bulsh*t text</span>",
"    <br />",
"    <nk-repeat for=\"number in someNumbers\">",
"        <span><nk-model>number</nk-model> da ima</span>",
"        <span>only <nk-model>number</nk-model></span>",
"    </nk-repeat>",
"    <br />",
"    <div>",
"        <span>More bulsh*t text</span>",
"        <nk-repeat for=\"tech in someTechs\">",
"            <span><nk-model>tech</nk-model> is cool</span>",
"            <span>and <nk-model>tech</nk-model> is mama</span>",
"        </nk-repeat>",
"    <div>",
"</div>",
"<div>",
"    <span>Some bulsh*t text</span>",
"    <br />",
"    <nk-repeat for=\"someNumber in someNumbersHere\">",
"        <span><nk-model>someNumber</nk-model> da ima</span>",
"        <span>only <nk-model>someNumber</nk-model></span>",
"        <strong><nk-model>kolio</nk-model></strong>",
"    </nk-repeat>",
"    <br />",
"    <div>",
"        <span>More bulsh*t text</span>",
"        <nk-repeat for=\"someTech in someTechsHere\">",
"            <span><nk-model>someTech</nk-model> is cool</span>",
"            <span>and <nk-model>someTech</nk-model> is mama</span>",
"            <strong><nk-model>minkov</nk-model></strong>",
"        </nk-repeat>",
"    <div>",
"</div>"
];

var test9 = [
"5",
"pesho-gosho",
"gosho-pesho",
"if-gadno",
"repeat-hackvane",
"template-ivaylo sucks :D",
"8",
"<div>",
"    {{<nk-if condition=\"pesho\">}}",
"    <nk-model>if</nk-model> (pesho)",
"    <nk-model>repeat</nk-model> (var nqma in nikoi)",
"    <nk-model>pesho</nk-model>",
"    <nk-model>gosho</nk-model>",
"    <nk-model>template</nk-model>",
"</div>"
];

var test10 = [
"5",
"peshov-goshoviq",
"goshov-peshoviq",
"ifaylo-gadno a?",
"repeatable-hackvane ima tuk",
"templateable-ivaylo sucks more :D",
"8",
"<div>",
"    {{<nk-if condition=\"peshov\">}}",
"    <nk-model>ifaylo</nk-model> (peshov)",
"    <nk-model>repeatable</nk-model> (var nqma in nikoi)",
"    <nk-model>peshov</nk-model>",
"    <nk-model>goshov</nk-model>",
"    <nk-model>templateable</nk-model>",
"</div>"
];

function solve(params) {
	
	// process input
	
	var n = params[0] * 1;
	
	var models = [], sections = [], row;
	var modelKeys = [];
	
	for (var i = 1; i <= n; i+=1) {
		row = params[i].split('-');

		if(params[i].split(';').length === 1) {
			models[row[0]] = row[1];
		} else {
			models[row[0]] = row[1].split(';');
		}
		modelKeys.push(row[0]);
	}

	
	var m = params[n + 1] * 1, l = n+2;
	
	var opened = false;
	
	var niki = params[l].indexOf('<nk-template name="'), currentSection;
	var plen = params.length;
	
	while ((opened || niki !== -1) && l < plen - 1) {
		if(niki !== -1) {
			opened = true;
			currentSection = params[l].substring(params[l].indexOf('"') + 1, params[l].lastIndexOf('"'));
			sections[currentSection] = [];
		} else if (params[l].indexOf('</nk-template>') !== -1) {
			opened = false;
		} else {
			sections[currentSection].push(params[l]);
		}
		l+=1;
		niki = params[l].indexOf('<nk-template name="');
	}
	
	// start parsing
	
	var html = params.slice(l, plen).join('\n'); // get the html
	
	var contentreg = />.*?</; // regEx for getting the content of the model
	
	var rep = html.match(/(<nk-model>.*?<\/nk-model>)\s*?(?!\}\})/gi); // match models that aren't escaped on the right
	
	if(rep !== null) { // if any matches
		
		var len = rep.length;
	
		var currentModel;
		
		for (var i = 0; i < len; i+=1) { // for every match
			currentModel = rep[i].match(contentreg)[0]; // get the content(i.e. the key of the model)
			currentModel = currentModel.substring(1, currentModel.length - 1);
			
			if(models[currentModel] !== undefined) { // i should've put the loop parsing first
				html = html.replace(rep[i], models[currentModel]); // replace the match with the model
			}
			
		}
	}
	
	rep = html.match(/<nk-template render=".+?" \/>(?!\s*?\}\})/gi); // match templates
	if(rep !== null) {
		contentreg = /".+?"/; // get the template's name
		len = rep.length;
		
		for (var i = 0; i < len; i+=1) {
			currentModel = rep[i].match(contentreg)[0];
			currentModel = currentModel.substring(1, currentModel.length - 1);
			
			if(sections[currentModel] !== undefined) {
				html = html.replace('    '+rep[i], sections[currentModel].join('\n'));
			}
			
		}
		
	}
	
	rep = html.match(/\s*<nk-if condition=".+">(?!\s*?\}\})(.|\n)*?<\/nk-if>/gi); // match non-escaped ifs with the starting whitespaces
					// whitespaces + opening tag + not-esaped + content + closing tag
					
	contentreg = /".+?"/; // match bool model
	if(rep !== null) {
		len = rep.length;
		var splitCmd;
		var hack = 0;

		
		for (var i = 0; i < rep.length; i+=1) {
			currentModel = rep[i].match(contentreg)[0];
			currentModel = currentModel.substring(1, currentModel.length - 1);
			
			if(models[currentModel] !== undefined) {
				if(models[currentModel] === 'true') {
					splitCmd = rep[i].split('\n    ');
					hack+=splitCmd[0] === '' ? 1 : 0; // depending on input, split may produce an empty zero element
					splitCmd = splitCmd.slice(1 + hack, splitCmd.length - 1).join('\n'); // get the insides of the if
					
					if(rep[i][0] === '\n') {
						rep[i] = rep[i].substring(1, rep[i].length);
					}
					
					html = html.replace(rep[i], splitCmd);
				} else {
					html = html.replace(rep[i], '');
				}
				
			}
			
		}
	}
	
	
	
	
	rep = html.match(/<nk-repeat for=".+?">(?!\s*?\}\})(.|\n)*?<\/nk-repeat>/gi); // match loops that aren't escaped
	
	var len2;
	var toInsert; // append here
	var inside;
	
	var loopInfoString, placeholder, placeHolderReg;
	
	if(rep !== null) {
		len = rep.length;
		var spaces; // formatting helper
		for (var i = 0; i < len; i+=1) {
			
			toInsert = '';
			splitCmd = rep[i].split('\n    ');

			
			inside = splitCmd.slice(1, splitCmd.length - 1).join('\n');
			spaces = inside.match(/\s*/)[0];
			
			// contains model and placeholder
			loopInfoString = splitCmd[0].match(/".+?"/)[0];
			loopInfoString = loopInfoString.substring(1, loopInfoString.length - 1).split(' ');
			
			currentModel = loopInfoString[2];
			placeholder = loopInfoString[0];
			placeHolderReg = new RegExp('<nk-model>'+placeholder+'</nk-model>(?!\s*?\}\})', 'gi'); // match non-escaped stuff in loops
			
			len2 = models[currentModel].length;
			for (var j = 0; j < len2; j+=1) {
				toInsert+=inside.replace(placeHolderReg, models[currentModel][j]);
				if(j !== len2 - 1){
					toInsert+='\n';
				}
			}
			
			html = html.replace(spaces+rep[i], toInsert);
			
		}
		
		
	}
	
	html = html.replace(/\}\}/g, '').replace(/\{\{/g, ''); // get rid of escapes, it's kidna wrong though
	console.log(html);
	
};

solve(zeroTest);

