class Card {
  constructor(p, s) {
    this.pos = p;
    this.suit = s;
    this.sprite = `card_sprite_${this.suit}.jpg`
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
