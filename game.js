var deck = [];
var player_a = [];
var player_b = [];
var table_a = [];
var table_b = [];
var active_a = [];
var active_b = [];
var tempA = undefined;
var tempB = undefined;
var scorea = 0;
var scoreb = 0;


function setup() {
  for (let i = 0; i < 4; i++) {
    for (let j = 2; j < 15; j++) {
      deck.push(new Card(undefined, j));
    }
  }
  shuffle(deck);
  for (let i = 0; i < 26; i++) {
   player_a.push(deck.pop());
   player_b.push(deck.pop());
  }
  for (let j = 0; j < 4; j++) {
   table_a.push(player_a.pop());
   table_b.push(player_b.pop());
   table_a[j].setPosition(j+1);
   table_b[j].setPosition(j+7);
  }
  active_a.push(player_a.pop());
  active_b.push(player_b.pop());
  active_a[0].setPosition(5);
  active_b[0].setPosition(6);
}

function checkRules(a, b) {
  vala = a.getSuit();
  valb = b.getSuit();
  if (valb == vala+1 || valb == vala-1) {
    return true;
  }
  else if (valb == 14 && vala == 2){
    return true;
  }
  else if (valb == 2 && vala == 14){
    return true;
  }
  else {
    return false;
  }
}

function holdCard(stack, card) {
  if (stack == 0) {
    tempA = card;
    console.log("A");
    console.log(table_a[tempA]);
  }
  else if (stack == 1) {
    tempB = card;
    console.log("B");
    console.log(table_b[tempB]);
  }
  else {
    console.log("Stack must be defined!");
  }
}

function checkWin() {
  if (player_a.length == 0) {
    console.log("Player A winns!");
    scorea = scorea + 1;
    setup();
  }
  else if (player_b == 0) {
    console.log("Player B winns!");
    scoreb = scoreb + 1;
    setup();
  }
  else {
    return false;
  }

}

function checkSituation() {
  var check = [];
  for (let i = 0; i < 4; i++) {
    check.push(checkRules(active_a[0], table_a[i]));
    check.push(checkRules(active_a[0], table_b[i]));
    check.push(checkRules(active_b[0], table_a[i]));
    check.push(checkRules(active_b[0], table_b[i]));
  }
  let pos = check.indexOf(true);
  let len = undefined;
  if (pos == -1){
    len = active_a.length;
    for (let i = 0; i < len; i++) {
      active_a[0].setPosition(0);
      player_a.unshift(active_a.shift());
    }
    len = active_b.length;
    for (let j = 0; j < len; j++) {
      active_b[0].setPosition(0);
      player_b.unshift(active_b.shift());
    }
    shuffle(player_a);
    shuffle(player_b);
    active_a.unshift(player_a.pop());
    active_b.unshift(player_b.pop());
    active_a[0].setPosition(5);
    active_b[0].setPosition(6);
    console.log(player_a);
    console.log(player_b);
  }
  checkWin();
}

function shuffle(a) {
    for (let i = a.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [a[i], a[j]] = [a[j], a[i]];
    }
    return a;
}

setup();
checkSituation();

table_a[0].element.addEventListener("click", function(){ holdCard(0, 0); });
table_a[1].element.addEventListener("click", function(){ holdCard(0, 1); });
table_a[2].element.addEventListener("click", function(){ holdCard(0, 2); });
table_a[3].element.addEventListener("click", function(){ holdCard(0, 3); });

aa = document.getElementById('aa');
aa.addEventListener("click", function(){
  if (checkRules(active_a[0], table_a[tempA]) == true) {
    shuffle(player_a);
    active_a.unshift(table_a[tempA]);
    active_a[0].setPosition(5);
    table_a[tempA] = player_a.pop();
    table_a[tempA].setPosition(tempA+1);
    console.log(active_a);
    console.log(table_a);
  }
  checkSituation();
});

ab = document.getElementById('ab');
ab.addEventListener("click", function(){
  if (checkRules(active_a[0], table_b[tempB]) == true) {
    shuffle(player_a);
    active_a.unshift(table_b[tempB]);
    active_a[0].setPosition(5);
    table_b[tempB] = player_b.pop();
    table_b[tempB].setPosition(tempB+7);
    console.log(active_a);
    console.log(table_b);
  }
  checkSituation();
});

ba = document.getElementById('ba');
ba.addEventListener("click", function(){
  if (checkRules(active_b[0], table_a[tempA]) == true) {
    shuffle(player_b);
    active_b.unshift(table_a[tempA]);
    active_b[0].setPosition(6);
    table_a[tempA] = player_a.pop();
    table_a[tempA].setPosition(tempA+1);
    console.log(active_b);
    console.log(table_a);
  }
  checkSituation();
});

bb = document.getElementById('bb');
bb.addEventListener("click", function(){
  if (checkRules(active_b[0], table_b[tempB]) == true) {
    shuffle(player_b);
    active_b.unshift(table_b[tempB]);
    active_b[0].setPosition(6);
    table_b[tempB] = player_b.pop();
    table_b[tempB].setPosition(tempB+7);
    console.log(active_b);
    console.log(table_b);
  }
  checkSituation();
});

table_b[0].element.addEventListener("click", function(){ holdCard(1, 0); });
table_b[1].element.addEventListener("click", function(){ holdCard(1, 1); });
table_b[2].element.addEventListener("click", function(){ holdCard(1, 2); });
table_b[3].element.addEventListener("click", function(){ holdCard(1, 3); });
