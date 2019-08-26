function solve(params) {
	var n = params[0] * 1, w = params[1] * 1;
	var result = [];
	var text = [];
	
	params.slice(2, params.length).map(function (row) {
		row.replace(/\s\s+/g, ' ').split(' ').map(function (word) {
			if(word !== '') {
				text.push(word);
			}
			
		})
	});

	
	var i = 0, line = 0,  len = text.length, currentLength = 0;
	
	while(i < len) {
		if(currentLength + text[i].length <= w) {
			if(result[line] === undefined) {
				result[line] = [];
			}
			
			if(currentLength !== 0 && currentLength + 1 < w && currentLength + text[i].length + 1 <= w){
				result[line].push(' ');
				currentLength+=1;
			}
			result[line].push(text[i]);
			currentLength+=text[i].length;
			i+=1;
			
		} else {
			line+=1;
			currentLength=0;
		}
	}
	
	Array.prototype.getLength = function () {
		var len = this.length;
		var Length = 0;
		for (var i = 0; i < len; i+=1) {
			Length+= this[i].length;
			
		}
		
		return Length;
	}

	
	line = 0;
	len = result.length;
	currentLength = 0;

	var currentSpace = 1, neededSpaces = 0, spaces = ' ';
	while(line < len) {
		currentLength = result[line].getLength();
		neededSpaces = w - currentLength;
		spaces = ' ';
		currentSpace = result[line].indexOf(spaces);
		
		while (neededSpaces > 0) {
			result[line][currentSpace]+=' ';
			neededSpaces-=1;
			currentSpace = result[line].indexOf(spaces);
			
			if(currentSpace === -1) {
				spaces+=' ';
				currentSpace = result[line].indexOf(spaces);
			}
		}
		
		line+=1;
	}
	
	console.log(result.map(function (arr) {
		return arr.join('');
	}).join('\n'));

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

var zeroTest2 = [
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

var test = [
"12",
"34",
"Dovahkiin Dovahkiin naal ok zin los vahriin    Wah dein vokul mahfaeraak ahst vaal    Ahrk fin norok paal graan fod nust hon",
"zindro zaan    Dovahkiin fah hin kogaan mu draal      Huzrah nu kul do od wah aan bok lingrah vod    Ahrk fin tey boziik fun do fin geinWo lostfron wah ney dov",
"ahrk fin reyliik do jul    Voth",
"aan suleyk wah ronit faal krein      Ahrk fin zul rok drey kod nau tol morokei frod    Rul lot Taazokaan motaad voth kein    Sahrot Thuum med aan tuz vey zeim hokoron pah    Ol fin Dovakiin komeyt ok rein      Chorus    Dovahkiin Dovahkiin naal ok zin lo",
"fod zeymah win kein meyz fuundein    Alduin feyn do jun kruziik vokun staadnav    Voth aan bahlok wah diivon fin lein      Nuz aan sul fent alok fod fin vul dovah nok    Fen kos nahlot mahfaeraak ahrk ruz    Paaz Keizaal fen kos stin nol bein Alduin jot ",
"  Chorus    Dovahkiin Dovahkiin naal ok zin los vahriin    Wah dein vokul mahfaeraak ahst vaal    Ahrk fin norok paal graan fod nust hon zindro zaan    Dovahkiin fah hin kogaan mu draa    Lyrics in English   From httpwwwelyricsnet   Dragonborn Dragonborn",
"did wield on that glorious field    When great Tamriel shuddered with war    Mighty Thuum like a blade cut through enemies all    As the Dragonborn issued his roar      Dragonborn Dragonborn by his honor is sworn    To keep",
"evil forever at bay    And the fiercest foes rout when they hear triumphs shout    Dragonborn for your blessing we pray    ",
" And the Scrolls have foretold of black wings in the cold    That when brothers wage war come unfurled    Alduin Bane of Kings ancient shadow unbound    With a hunger to swallow the world      But a day shall arise when the dark dragons lies    Will be s",
"keep evil forever at bay    And",
"the fiercest foes rout when they hear triumphs",
"shout    Dragonborn for your blessing we pray"
];

solve(zeroTest2);

