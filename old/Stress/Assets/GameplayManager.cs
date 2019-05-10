using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour {

    public int updateDeck_A;
    public int updateDeck_B;
    public int TOPCARD_A;
    public int TOPCARD_B;
    public int A_TOP;
    public int B_TOP;
    public int restart_a;
    public int restart_b;
    public int gameover;
    private int knock_true_a;
    private int knock_true_b;
    public int[] initCards;
    public int[] a_cards;
    public int[] b_cards;
    public int[] A_active;
    public int[] B_active;
    public int[] a_hand;
    public int[] b_hand;

    public Transform red_light;
    public Transform green_light;


    public int data;
    public int[] datatst;

    public void InitRound()
    {
      //108 karten -> 2 Decks
        initCards = new int[] {
            2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
            2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
            2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
            2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
            2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
            2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
            2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
            2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14
        };
        //alle 104 Stellen groß
        a_cards = new int[]
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
        };
        b_cards = new int[]
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
        };

        A_active = new int[]
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
        };
        B_active = new int[]
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
        };

        a_hand = new int[] { 0, 0, 0, 0 };
        b_hand = new int[] { 0, 0, 0, 0 };

        A_TOP = 103;
        B_TOP = 103;

        red_lights(2, 0, 0);
        ShuffleArray(initCards);
          //splitting initCards
        for (int i = 0; i <= 51; i++){
    			a_cards[i] = initCards[i];
          initCards[i] = 0;
    		}
        for (int i = 52; i <= 103; i++){
          b_cards[i - 52] = initCards[i];
          initCards[i] = 0;
        }
          //placing the first cards
        TOPCARDS(0);
        A_active[0] = a_cards[A_TOP];
        B_active[0] = b_cards[B_TOP];
        TOPCARDS(0);
        a_hand[0] = a_cards[A_TOP];
        b_hand[0] = b_cards[B_TOP];
        TOPCARDS(0);
        a_hand[1] = a_cards[A_TOP];
        b_hand[1] = b_cards[B_TOP];
        TOPCARDS(0);
        a_hand[2] = a_cards[A_TOP];
        b_hand[2] = b_cards[B_TOP];
        TOPCARDS(0);
        a_hand[3] = a_cards[A_TOP];
        b_hand[3] = b_cards[B_TOP];
        TOPCARDS(0);
        updateDeck_A = 1;
        updateDeck_B = 1;

        datatst = new int[] { 1, 2, 3, 4 };
    }

    void Start()
    {
        InitRound();
    }

    public void PrintArray(int[] arr, int mode)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (mode == 0) {
                Debug.Log(arr[i]);
            }
            else if (mode == 1)
            {
                Debug.LogWarning(arr[i]);
            }
            else
            {
                Debug.LogError("Mode is not available!");
            }
        }
    }

    public void ShuffleArray(int[] a)
    {
        int l = a.Length;
        System.Random rand = new System.Random();
        for (int i = 0; i < l; i++)
        {
            Swap(a, i, i + rand.Next(l - i));
        }
    }

    public void Swap(int[] arr, int a, int b)
    {
        int temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }

    //Test function for sharing data
    public int GetData(int pos)
    {
        data = datatst[pos];
        return data;
    }

    public int GetHandA(int pos)
    {
        data = a_hand[pos];
        return data;
    }

    //prefab_respawn data
    public int getA_hand (int pos)
    {
        return a_hand[pos];
    }
    public int getB_hand (int pos)
    {
        return b_hand[pos];
    }

    public int Pop(int[] array, int pos)
    {
        int val = array[pos];
        Array.Clear(array, pos, 1);
        return val;
    }

    public void TOPCARDS (int side) {
        if (side == 1) {
          a_cards[A_TOP] = 0;
        }
        else if (side == 2) {
          b_cards[B_TOP] = 0;
        }
        else if (side == 0){
          a_cards[A_TOP] = 0;
          b_cards[B_TOP] = 0;
        }
        A_TOP = -1;
        B_TOP = -1;
        for (int i = 0; i <= 103; i++){
    			if (a_cards[i] != 0) {
    				A_TOP = A_TOP + 1;
    			}
    			if (b_cards[i] != 0) {
    				B_TOP = B_TOP + 1;
    			}
    		}
        if (side == 1) {
          updateDeck_A = 1;
        }
        else if (side == 2) {
          updateDeck_B = 1;
        }
        else if (side == 0) {
          updateDeck_A = 1;
          updateDeck_B = 1;
        }
        //Debug.Log(A_TOP + " + " + B_TOP);
    }

    public void KNOCK(int knock) {
      if (knock == 1) {
        if ((A_active[TOPCARD_A] == B_active[TOPCARD_B]) && (knock_true_b == 0) && (knock_true_a == 0)) {
          Debug.Log("TRUE_A");
          green_lights(1, -3);
                knock_true_a = 1;
                gameover = 1;
          knock = 0;
                Debug.Log("knock A: " + knock_true_a);
            }
            else {
                if ((gameover == 1) && (knock_true_b == 0))
                {
                    gameover = 0;
                    knock_true_a = 0;
                    InitRound();
                }
                else
                {
                    Debug.Log("FALSE_A");
                    //InitRound();
                    knock = 0;
                }
        }
      }
      else if (knock == 2) {
        if ((A_active[TOPCARD_A] == B_active[TOPCARD_B]) && (knock_true_b == 0) && (knock_true_a != 1))
        {
                Debug.Log("TRUE_B");
                green_lights(1, 3);
                Debug.Log("knock A: " + knock_true_a);
                gameover = 1;
                knock_true_b = 1;
                knock = 0;
        }
        else
        {
                if (gameover == 1)
                {
                    if (knock_true_a == 0)
                    {
                        gameover = 0;
                        knock_true_b = 0;
                        InitRound();
                    }
                }
                else
                {
                    Debug.Log("FALSE_B");
                    //InitRound();
                    knock = 0;
                }
        }
      }
    }

    public void EndRound(int side) {
      if (side == 1 || side == 0) {
        restart_a = 1;
        for (int i = 0; i < 4; i++){
          if (restart_a == 1) {
      			if ((a_hand[i] == A_active[TOPCARD_A] + 1) || (a_hand[i] == A_active[TOPCARD_A] - 1)){
              restart_a = 0;
              //Debug.Log("A: " + (i + 1));
            }
            else if ((a_hand[i] == B_active[TOPCARD_B] + 1  ) || (a_hand[i] == B_active[TOPCARD_B] - 1)){
              restart_a = 0;
              //Debug.Log("B: " + (i + 1));
            }
            else if (a_hand[i] == 14 ) {
              if ((A_active[TOPCARD_A] == 2) || (B_active[TOPCARD_B] == 2)) {
                  restart_a = 0;
                  //Debug.Log("Ass -> 2");
              }
            }
            else if (a_hand[i] == 2) {
              if ((A_active[TOPCARD_A] == 14) || (B_active[TOPCARD_B] == 14)) {
                  restart_a = 0;
                  //Debug.Log("2 -> Ass");
              }
            }
          }
  		   }
         if (restart_a == 1) {
           //Debug.Log("A cannot play");
         }
      }
      if (side == 2 || side == 0) {
        restart_b = 1;
        for (int i = 0; i < 4; i++){
           if (restart_b == 1) {
       			if ((b_hand[i] == A_active[TOPCARD_A] + 1) || (b_hand[i] == A_active[TOPCARD_A] - 1)){
               restart_b = 0;
               //Debug.Log("A: " + (i + 1));
             }
             else if ((b_hand[i] == B_active[TOPCARD_B] + 1  ) || (b_hand[i] == B_active[TOPCARD_B] - 1)){
               restart_b = 0;
               //Debug.Log("B: " + (i + 1));
             }
             else if (b_hand[i] == 14 ) {
               if ((A_active[TOPCARD_A] == 2) || (B_active[TOPCARD_B] == 2)) {
                   restart_b = 0;
                   //Debug.Log("Ass -> 2");
               }
             }
             else if (b_hand[i] == 2) {
               if ((A_active[TOPCARD_A] == 14) || (B_active[TOPCARD_B] == 14)) {
                   restart_b = 0;
                   //Debug.Log("2 -> Ass");
               }
             }
           }
   		  }
        if (restart_b == 1) {
          //Debug.Log("B cannot play");
        }
      }
      if (restart_a == 1 && restart_b == 1) {
        Debug.Log("GAME OVER");
        gameover = 1;
        red_lights(1, 3, -3);
      }
    }

    public void red_lights(int on_off, int y1, int y2)
    {
        if (on_off == 1)
        {
            var child1 = Instantiate(red_light, new Vector3( 0, y1, -3 ), red_light.transform.rotation);
            child1.transform.parent = transform;
            var child2 = Instantiate(red_light, new Vector3(0, y2, -3), red_light.transform.rotation);
            child2.transform.parent = transform;
        }
        else if (on_off == 2)
        {
            foreach (Transform red_light in transform)
            {
                GameObject.Destroy(red_light.gameObject);
            }
            
        }
    }
    public void green_lights(int on_off, int y )
    {
        if (on_off == 1)
        {
            var child1 = Instantiate(green_light, new Vector3(0, y , -3), green_light.transform.rotation);
            child1.transform.parent = transform;
        }
        else if (on_off == 2)
        {
            foreach (Transform green_light in transform)
            {
                GameObject.Destroy(green_light.gameObject);
            }

        }
    }

    void Update (){

    }
}
