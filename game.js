var deck = [];
var player_a = [];
var player_b = [];
var table_a = [];
var table_b = [];
var active_a = [];
var active_b = [];
var loc = [];
var tempA = undefined;
var tempB = undefined;

function setup() {
  document.getElementById('pos0').style.visibility = 'hidden';
  for (var i = 0; i < 10; i++) {
    loc.push(document.getElementById(`pos${i+1}`))
  }

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
  if (this.a == this.b) {
    return True;
  } else {
    return False;
  }
}

function holdCard(stack, card) {
  if (this.stack == 0) {
    tempA = card;
  }
  else if (this.stack == 1) {
    tempB = card;
  }
}

setup();
