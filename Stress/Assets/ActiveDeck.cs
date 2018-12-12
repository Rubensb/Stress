using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDeck : MonoBehaviour {
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

	private GameplayManager gameplayManager;
	private Transform a_card;
	private Transform b_card;
	public int topcard_a;
	private int topcard_b;
	private int Newtopcard_a;
	private int Newtopcard_b;


	void Start () {
		gameplayManager = GameObject.FindObjectOfType<GameplayManager>();
		topcard_a = -1;
		topcard_b = -1;
	}

	void Update () {
		Newtopcard_a = -1;
		Newtopcard_b = -1;
		for (int i = 0; i <= 103; i++){
			if ((gameplayManager.A_active[i] != 0)){
				Newtopcard_a = Newtopcard_a + 1;
			}
			if ((gameplayManager.B_active[i] != 0)){
				Newtopcard_b = Newtopcard_b + 1;
			}
		}
		gameplayManager.TOPCARD_A = Newtopcard_a;
		gameplayManager.TOPCARD_B = Newtopcard_b;
//		Debug.Log(Newtopcard_a);
//		Debug.Log(Newtopcard_b);
		if ((Newtopcard_a != topcard_a) || (Newtopcard_b != topcard_b)){
			//destroy old cards
			foreach (Transform a_card in transform) {
				GameObject.Destroy(a_card.gameObject);
			}
			foreach (Transform b_card in transform) {
				GameObject.Destroy(b_card.gameObject);
			}
			topcard_a = Newtopcard_a;
			topcard_b = Newtopcard_b;

			switch (gameplayManager.A_active[ topcard_a ])
			{
					 case 2:
							 a_card = heart_2;
							 break;
					 case 3:
							 a_card = heart_3;
							 break;
					 case 4:
							 a_card = heart_4;
							 break;
					 case 5:
							 a_card = heart_5;
							 break;
					 case 6:
							 a_card = heart_6;
							 break;
					 case 7:
							 a_card = heart_7;
							 break;
					 case 8:
							 a_card = heart_8;
							 break;
					 case 9:
							 a_card = heart_9;
							 break;
					 case 10:
							 a_card = heart_10;
							 break;
					 case 11:
							 a_card = heart_11;
							 break;
					 case 12:
							 a_card = heart_12;
							 break;
					 case 13:
							 a_card = heart_13;
							 break;
					 case 14:
							 a_card = heart_14;
							 break;
					 default:
							 Debug.Log("Active Deck A ERROR");
							 break;
			}

			switch (gameplayManager.B_active[ topcard_b ])
			{
					 case 2:
							 b_card = spades_2;
							 break;
					 case 3:
							 b_card = spades_3;
							 break;
					 case 4:
							 b_card = spades_4;
							 break;
					 case 5:
							 b_card = spades_5;
							 break;
					 case 6:
							 b_card = spades_6;
							 break;
					 case 7:
							 b_card = spades_7;
							 break;
					 case 8:
							 b_card = spades_8;
							 break;
					 case 9:
							 b_card = spades_9;
							 break;
					 case 10:
							 b_card = spades_10;
							 break;
					 case 11:
							 b_card = spades_11;
							 break;
					 case 12:
							 b_card = spades_12;
							 break;
					 case 13:
							 b_card = spades_13;
							 break;
					 case 14:
							 b_card = spades_14;
							 break;
					 default:
							 Debug.Log("Active Deck B ERROR");
							 break;
			}
				var child_a0 = Instantiate(a_card, new Vector3 (1 , -1 , -1), a_card.transform.rotation);
				child_a0.transform.parent = transform;
				var child_a1 = Instantiate(a_card, new Vector3 (1 , 1 , -1), a_card.transform.rotation);
				child_a1.transform.parent = transform;
				var child_b0 = Instantiate(b_card, new Vector3 (-1 , -1 , -1), b_card.transform.rotation);
				child_b0.transform.parent = transform;
				var child_b1 = Instantiate(b_card, new Vector3 (-1 , 1 , -1), b_card.transform.rotation);
				child_b1.transform.parent = transform;
		}
	}
}
