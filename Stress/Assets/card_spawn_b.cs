using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card_spawn_b : MonoBehaviour {
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
	//b_cards
	private Transform b_card;
	//temp array
	private int[] TempB;

	void Start () {
		gameplayManager = GameObject.FindObjectOfType<GameplayManager>();
		TempB = new int[4] { 0, 0, 0, 0 };
        //Test sharring data Rubi ;)
        //Debug.LogWarning(gameplayManager.GetData(2));
    }

	void Update() {
		if (gameplayManager.updateDeck_B == 1) {
			//Debug.Log("--------NEW B HAND--------");
			//destroy old cards
			foreach (Transform a_card in transform) {
				GameObject.Destroy(a_card.gameObject);
			}
			//import b_hand
			TempB = gameplayManager.b_hand;
			int b_cardPos = 10;

			//check all 4 positions of b_hand
			for (int p = 0; p < 4; p++)
			{
					//Debug.Log("B: position " + p + " is " + TempB[p]);
						//define prefabs to his positions b_hand
					switch (TempB[p])
					{
							 case 2:
									 b_cardPos = p;
									 b_card = spades_2;
									 break;
							 case 3:
							 		 b_cardPos = p;
									 b_card = spades_3;
									 break;
							 case 4:
							 		 b_cardPos = p;
									 b_card = spades_4;
									 break;
							 case 5:
									 b_cardPos = p;
									 b_card = spades_5;
									 break;
							 case 6:
							 		 b_cardPos = p;
									 b_card = spades_6;
									 break;
							 case 7:
									 b_cardPos = p;
									 b_card = spades_7;
									 break;
							 case 8:
							 		 b_cardPos = p;
									 b_card = spades_8;
									 break;
							 case 9:
									 b_cardPos = p;
									 b_card = spades_9;
									 break;
							 case 10:
									 b_cardPos = p;
									 b_card = spades_10;

									 break;
							 case 11:
									 b_cardPos = p;
									 b_card = spades_11;
									 break;
							 case 12:
									 b_cardPos = p;
									 b_card = spades_12;
									 break;
							 case 13:
									 b_cardPos = p;
									 b_card = spades_13;
									 break;
							 case 14:
									 b_cardPos = p;
									 b_card = spades_14;
									 break;
							 default:
							 		 Debug.Log("b_hand ERROR");
									 break;
					}
						//b_hand positions
					if (b_cardPos == 0){
				 		var child = Instantiate(b_card, new Vector3 (-2.1f , +4, -1), b_card.transform.rotation);
						child.transform.parent = transform;
					}
				 	if (b_cardPos == 1){
				 		var child = Instantiate(b_card, new Vector3 (-0.7f , +4, -1), b_card.transform.rotation);
						child.transform.parent = transform;
					}
				 	if (b_cardPos == 2){
				 		var child = Instantiate(b_card, new Vector3 (+0.7f , +4, -1), b_card.transform.rotation);
						child.transform.parent = transform;
					}
				 	if (b_cardPos == 3){
				 		var child = Instantiate(b_card, new Vector3 (+2.1f , +4, -1), b_card.transform.rotation);
						child.transform.parent = transform;
					}
			}
			gameplayManager.updateDeck_B = 0;
			gameplayManager.EndRound(0);
		}
	}
}
