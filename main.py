import random
import math

num_decks = 2
a_points = 10
b_points = 10

def newDeck():
    std_deck = [
		  # 2  3  4  5  6  7  8  9  10  J   Q   K   A
			2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
			2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
			2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
			2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
		]

    std_deck = std_deck * num_decks
    random.shuffle(std_deck)
    return std_deck[:]

def playGame():
    deck = newDeck()

    a_cards = []
    b_cards = []

    a_hand = []
    b_hand = []

    def initRound():
        for i in range(0, 52):
            a_cards.append(deck.pop(0))
            b_cards.append(deck.pop(0))

        for i in range(0, 4):
            a_hand.append(a_cards.pop(0))
            b_hand.append(b_cards.pop(0))

        print('Cards a', a_cards)
        print('Cards b', b_cards)

    initRound()

    def playRound():
        a_deck_active = []
        b_deck_active = []
        updateDeck(a_cards, a_deck_active, 0)
        updateDeck(b_cards, b_deck_active, 0)

        while 1 == 1:
            print('Hand 0', a_hand)
            print('Hand 1', b_hand)
            print(a_deck_active, b_deck_active)

            player = int(input('Player: '))
            if player == 2:
                return 0
            if player == 3:
                for i in range(0, (len(a_deck_active)-1)):
                    updateDeck(a_deck_active, a_cards, i)
                for i in range(0, (len(b_deck_active)-1)):
                    updateDeck(b_deck_active, b_cards, i)
                print('Cards a', a_cards)
                print('Cards b', b_cards)
                return 0

            direction = int(input('Stack: '))
            action = int(input('Card: '))

            print(action)

            if player == 0:
                card_position = (findPosition(a_hand, action))
                print('pos',card_position)
                if card_position != 20:
                    if direction == 0:
                        playCard(a_hand, a_deck_active, card_position, a_cards)
                    if direction == 1:
                        playCard(a_hand, b_deck_active, card_position, a_cards)
            if player == 1:
                card_position = (findPosition(b_hand, action))
                print('pos',card_position)
                if card_position != 20:
                    if direction == 0:
                        playCard(b_hand, a_deck_active, card_position, b_cards)
                    if direction == 1:
                        playCard(b_hand, b_deck_active, card_position, b_cards)
            if card_position == 20:
                print('Card does not exist!')


    def playCard(player_hand, active_deck, position, player_cards):
        if player_hand[position] == (active_deck[(len(active_deck)-1)] + 1) or player_hand[position] == (active_deck[(len(active_deck)-1)] - 1) and player_hand[position] != 14 and player_hand[position] != 2:
            active_deck.append(player_hand.pop(position))
            player_hand.append(player_cards.pop(0))
        elif player_hand[position] == 14 and active_deck[(len(active_deck)-1)] == 13 or active_deck[(len(active_deck)-1)] == 2:
            active_deck.append(player_hand.pop(position))
            player_hand.append(player_cards.pop(0))
        elif player_hand[position] == 2 and active_deck[(len(active_deck)-1)] == 3 or active_deck[(len(active_deck)-1)] == 14:
            active_deck.append(player_hand.pop(position))
            player_hand.append(player_cards.pop(0))
        else:
            print ('You cannot play this card!')
        winner = checkWin(a_cards, b_cards)

    #find Positions of Card in Hand
    def findPosition(hand, action):
        position = 20
        for i in range(0, 4):
            if action == hand[i]:
                position = i
        return position

    #push cards from one deck to another
    def updateDeck(o_deck, n_deck, position):
        n_deck.append(o_deck.pop(position))
        #return n_deck[:]

    def checkWin(a_deck, b_deck):
        if len(a_deck) == 0:
            win = True
            a_points = a_points + 1
            b_points = b_points - 1
        elif len(b_deck) == 0:
            win = True
            b_points = b_points + 1
            a_points = a_points - 1
        else:
            win = False
        return win


    '''def restartRound(a_deck_active, b_deck_active, a_hand, b_hand):
            for i in range(0, 4):
                    if == (active_deck[(len(active_deck)-1)] + 1) or a_hand[position] == (active_deck[(len(active_deck)-1)] - 1):
                        proof = True'''

    playRound()

print('---Stress by Rubens Bandelin 2018---')
playGame()
print('---Wie bin ich hier her gekommen? - Ende---')
