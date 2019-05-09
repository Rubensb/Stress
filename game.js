var deck = [];
var player_a = [];
var player_b = [];
var table_a = [];
var table_b = [];
var active_a = [];
var active_b = [];
var tempA = undefined;
var tempB = undefined;

function setup() {
  for (let h = 0; h < 2; h++) {
    for (let i = 0; i < 4; i++) {
      for (let j = 2; j < 15; j++) {
        deck.push(new Card(0, j));
      }
    }
  }
  shuffle(deck);
  for (let i = 0; i < 52; i++) {
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
  console.log(table_a);
  console.log(table_b);
}

function shuffle(a) {
    for (let i = a.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [a[i], a[j]] = [a[j], a[i]];
    }
    return a;
}

function printList(arr) {
  for (let k = 0; k < arr.length; k++) {
    document.write(`${arr[k].getSuit()}\n`);
  }
}

function checkRules(a, b) {
  vala = a.getSuit();
  valb = b.getSuit();
  if (valb == vala+1 || valb == vala-1 && valb != 14) {
    return true;
  }
  else if (valb == 14 && valb == 2){
    return true;
  }
  else if (valb == 2 && valb == 14){
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

setup();

table_a[0].element.addEventListener("click", function(){ holdCard(0, 0); });
table_a[1].element.addEventListener("click", function(){ holdCard(0, 1); });
table_a[2].element.addEventListener("click", function(){ holdCard(0, 2); });
table_a[3].element.addEventListener("click", function(){ holdCard(0, 3); });

active_a[0].element.addEventListener("click", function(){
  console.log(checkRules(active_a[0], table_a[tempA]));
  if (checkRules(active_a[0], table_a[tempA]) == true) {
    active_a.unshift(table_a[tempA]);
    active_a[0].setPosition(5);
    table_a[tempA] = player_a.pop();
    table_a[tempA].setPosition(tempA+1);
    console.log(active_a);
    console.log(table_a);
  }
});
active_b[0].element.addEventListener("click", function(){ holdCard(0, active_b[0]); });

table_b[0].element.addEventListener("click", function(){ holdCard(1, 0); });
table_b[1].element.addEventListener("click", function(){ holdCard(1, 1); });
table_b[2].element.addEventListener("click", function(){ holdCard(1, 2); });
table_b[3].element.addEventListener("click", function(){ holdCard(1, 3); });
