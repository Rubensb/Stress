using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card_spawn_a : MonoBehaviour {
	//setting 52 prefabs
	public Transform club_2;
	public Transform club_3;
	public Transform club_4;
	public Transform club_5;
	public Transform club_6;
	public Transform club_7;
	public Transform club_8;
	public Transform club_9;
	public Transform club_10;
	public Transform club_11;
	public Transform club_12;
	public Transform club_13;
	public Transform club_14;
	public Transform diamond_2;
	public Transform diamond_3;
	public Transform diamond_4;
	public Transform diamond_5;
	public Transform diamond_6;
	public Transform diamond_7;
	public Transform diamond_8;
	public Transform diamond_9;
	public Transform diamond_10;
	public Transform diamond_11;
	public Transform diamond_12;
	public Transform diamond_13;
	public Transform diamond_14;
	public Transform heart_2;
	public Transform heart_3;
	public Transform heart_4;
	public Transform heart_5;
	public Transform heart_6;
	public Transform heart_7;
	public Transform heart_8;
	public Transform heart_9;
	public Transform heart_10;
	public Transform heart_11;
	public Transform heart_12;
	public Transform heart_13;
	public Transform heart_14;
	public Transform spades_2;
	public Transform spades_3;
	public Transform spades_4;
	public Transform spades_5;
	public Transform spades_6;
	public Transform spades_7;
	public Transform spades_8;
	public Transform spades_9;
	public Transform spades_10;
	public Transform spades_11;
	public Transform spades_12;
	public Transform spades_13;
	public Transform spades_14;
	//setting GameplayManager
	private GameplayManager gameplayManager;
	//a_cards
	private Transform a_card;
	//temp array
	private int[] TempA;

	void Start () {
		gameplayManager = GameObject.FindObjectOfType<GameplayManager>();
		TempA = new int[4] { 0, 0, 0, 0 };
	}

	void Update() {
		if (gameplayManager.updateDeck_A == 1) {
			//Debug.Log("--------NEW A HAND--------");
				//destroy old cards
			foreach (Transform a_card in transform) {
				GameObject.Destroy(a_card.gameObject);
			}
				//import a_hand
			TempA = gameplayManager.a_hand;
			int a_cardPos = 10;

				//check all 4 positions of a_hand
			for (int p = 0; p < 4; p++)
			{
					//Debug.Log("A: position " + p + " is " + TempA[p]);
						//define prefabs to his positions a_hand
					switch (TempA[p])
					{
							 case 2:
									 a_cardPos = p;
									 a_card = heart_2;
									 break;
							 case 3:
							 		 a_cardPos = p;
									 a_card = heart_3;
									 break;
							 case 4:
							 		 a_cardPos = p;
									 a_card = heart_4;
									 break;
							 case 5:
									 a_cardPos = p;
									 a_card = heart_5;
									 break;
							 case 6:
							 		 a_cardPos = p;
									 a_card = heart_6;
									 break;
							 case 7:
									 a_cardPos = p;
									 a_card = heart_7;
									 break;
							 case 8:
							 		 a_cardPos = p;
									 a_card = heart_8;
									 break;
							 case 9:
									 a_cardPos = p;
									 a_card = heart_9;
									 break;
							 case 10:
									 a_cardPos = p;
									 a_card = heart_10;

									 break;
							 case 11:
									 a_cardPos = p;
									 a_card = heart_11;
									 break;
							 case 12:
									 a_cardPos = p;
									 a_card = heart_12;
									 break;
							 case 13:
									 a_cardPos = p;
									 a_card = heart_13;
									 break;
							 case 14:
									 a_cardPos = p;
									 a_card = heart_14;
									 break;
							 default:
							 		 Debug.Log("a_hand ERROR");
									 break;
					}

						//a_hand position
					if (a_cardPos == 0){
						var child = Instantiate(a_card, new Vector3 (-2.1f , -4, -1), a_card.transform.rotation);
						child.transform.parent = transform;
				 	}
				 	if (a_cardPos == 1){
				 		var child = Instantiate(a_card, new Vector3 (-0.7f , -4, -1), a_card.transform.rotation);
						child.transform.parent = transform;
					}
				 	if (a_cardPos == 2){
				 		var child = Instantiate(a_card, new Vector3 (+0.7f , -4, -1), a_card.transform.rotation);
						child.transform.parent = transform;
					}
				 	if (a_cardPos == 3){
				 		var child = Instantiate(a_card, new Vector3 (+2.1f , -4, -1), a_card.transform.rotation);
						child.transform.parent = transform;
					}

			}
			gameplayManager.updateDeck_A = 0;
			gameplayManager.EndRound(0);
		}
	}
}
		/*
		 if (gameplayManager.initCards[p] == 2){
			 a_cardPos = p;
			 a_card = heart_2;
			 Debug.Log("HEART 2");
		 }
			if (c == 2){
				a_card_0 = diamond_2;
			}
			else {
				a_card_0 = club_2;
			}*/
		/*for (int i = -2; i < 2; i++)
		{
					Instantiate(card, new Vector3 (i , -4, -1), card.transform.rotation);
		}
		for (int i = 0; i < 4; i++)
		{
					Debug.Log(TempAnew[i]);
		}*/
