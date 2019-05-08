class Card {
  constructor(p, s) {
    this.pos = p;
    this.suit = s;
    this.element = document.getElementById(`pos${this.pos}`);
    this.element.style.backgroundImage = "url('card_sprite_0.svg')";
  }

  setPosition(pos) {
    this.pos = pos;
    this.element = document.getElementById(`pos${this.pos}`);
    this.element.style.backgroundImage = `url(card_sprite_${this.suit}.svg)`;

  }

  getPosition() {
    return this.pos;
  }

  getSuit() {
    return this.suit;
  }

  getSprite() {
    return this.sprite;
  }

}
