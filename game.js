var deck = [];
var player_a = [];
var player_b = [];
var table_a = [];
var table_b = [];
var active_a = [];
var active_b = [];

function setup() {
  for (var i = 0; i < 2; i++) {
    for (let i = 0; i < 4; i++) {
      for (let j = 2; j < 15; j++) {
        deck.push(new Card(0, j));
        console.log(j);
      }
    }
  }

  console.log(deck.length);

  for (let k = 0; k < deck.length; k++) {
    document.write(`${deck[k].getSuit()}\n`);
  }

}

setup();
