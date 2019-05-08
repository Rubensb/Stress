from scene import *
from game_objects import Card
import sound
import random
import math
A = Action

class MyScene (Scene):


	def setup(self):
		w = self.size.w
		h = self.size.h
		print(w,h)
		self.positions = [[100, 100], [(w/3)+50, 100], [(w/2)+100, 100], [w-100, 100], [(w/2)-100, h/2], [(w/2)+100, h/2], [0, 0], [0, 0], [100, h-100], [(w/3)+50, h-100], [(w/2)+100, h-100], [w-100, h-100]]
		#print(positions)
		deck = []
		player_a = []
		player_b = []
		table_a = []
		table_b = []
		active_a = []
		active_b =[]

		for i in range(0, 4):
			for j in range(2, 15):
				deck.append(Card())
				deck[len(deck)-1].setSuit(j)
				deck[len(deck)-1].setSize(w/4, h/3)

		deck = deck * 2
		random.shuffle(deck)

		for i in range(0, 52):
			player_a.append(deck.pop(0))
			player_b.append(deck.pop(0))

		for j in range(0, 4):
			table_a.append(player_a.pop(0))
			table_b.append(player_b.pop(0))

		active_a.append(player_a.pop(0))
		active_b.append(player_b.pop(0))

		print('b:')
		for k in range(0, len(table_b)):
			print(table_b[k].getSuit())

		print('a:')
		for k in range(0, len(table_a)):
			print(table_a[k].getSuit())

		self.kids = Node(parent=self)
		for l in range(0, 4):
			table_a[l].setPosition(self.positions[l][0], self.positions[l][1])
			self.kids.add_child(table_a[l].sprite)

		for m in range(0, 4):
			table_b[m].setPosition(self.positions[m+8][0], self.positions[m+8][1])
			self.kids.add_child(table_b[m].sprite)

		active_a[0].setPosition(self.positions[4][0], self.positions[4][1])
		active_b[0].setPosition(self.positions[5][0], self.positions[5][1])

		print(active_a[0].getRec())
		self.kids.add_child(active_a[0].sprite)
		self.kids.add_child(active_b[0].sprite)

		#pass

	def rules(self, suit_a, suit_b):
		if suit_a==(suit_b+1) or suit_a==(suit_b-1):
			return True
		elif suit_a==14 and suit_b==2:
			return True
		elif suit_a==2 and suit_b==14:
			return True
		else:
			return False

	def did_change_size(self):
		pass

	def update(self):
		pass

	def touch_began(self, touch):
		self.x , self.y = touch.location
		for i in range(0, 12):
			if self.x < self.positions[i][0]+40 and self.x > self.positions[i][0]-40:
				#if self.y < self.positions[i][1]+50
				print(self.positions[i])
			else:
				pass

	def touch_moved(self, touch):
		pass

	def touch_ended(self, touch):
		pass


if __name__ == '__main__':
    run(MyScene(), show_fps=True)
