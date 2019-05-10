import random as rd
from scene import *


class Card():
	def __init__(self):
		self.pos = [0, 0]
		self.suit = 1
		self.sprite = (SpriteNode('card:BackBlue5', position=(self.pos[0], self.pos[1])))


	def setPosition(self, x, y):
		self.pos[0] = x
		self.pos[1] = y

		#self.sprite.size=(20, 30)
		self.sprite.run_action(Action.move_to(self.pos[0], self.pos[1], 1, TIMING_EASE_OUT))

	def setSize(self, w, h):
		self.sprite.size=(w, h)

	def setSuit(self, suit):
		self.suit = suit
		if suit == 2:
			self.sprite = (SpriteNode('card:Clubs2'))
		elif suit == 3:
			self.sprite = (SpriteNode('card:Clubs3'))
		elif suit == 4:
			self.sprite = (SpriteNode('card:Clubs4'))
		elif suit == 5:
			self.sprite = (SpriteNode('card:Clubs5'))
		elif suit == 6:
			self.sprite = (SpriteNode('card:Clubs6'))
		elif suit == 7:
			self.sprite = (SpriteNode('card:Clubs7'))
		elif suit == 8:
			self.sprite = (SpriteNode('card:Clubs8'))
		elif suit == 9:
			self.sprite = (SpriteNode('card:Clubs9'))
		elif suit == 10:
			self.sprite = (SpriteNode('card:Clubs10'))
		elif suit == 11:
			self.sprite = (SpriteNode('card:ClubsJ'))
		elif suit == 12:
			self.sprite = (SpriteNode('card:ClubsQ'))
		elif suit == 13:
			self.sprite = (SpriteNode('card:ClubsK'))
		elif suit == 14:
			self.sprite = (SpriteNode('card:ClubsA'))
		else:
			print('err')

	def getPosition(self):
		return self.pos

	def getSuit(self):
		return self.suit

	def getRec(self):
return self.sprite.bbox
