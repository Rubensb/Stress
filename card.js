class Card {
  constructor(p, s) {
    this.pos = p;
    this.suit = s;
  }

  setPosition(pos) {
    this.pos = pos;
    this.element = document.getElementById(`pos${this.pos}`);
    this.element.style.backgroundImage = `url(c_${this.suit}.svg)`;
  }

  getPosition() {
    return this.pos;
  }

  getSuit() {
    return this.suit;
  }

}
