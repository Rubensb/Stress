using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GM : MonoBehaviour {

    private Stack<int> CardsInit = new Stack<int>();

    private Stack<int> CardsA = new Stack<int>();
    private Stack<int> CardsB = new Stack<int>();

    private Stack<int> HandA = new Stack<int>();
    private Stack<int> HandB = new Stack<int>();

    private Stack<int> ActiveA = new Stack<int>();
    private Stack<int> ActiveB = new Stack<int>();

    private int[] tempArr;
    private int tempVal;

    private void initCards()
    {
        // Generate Deck
        for (int i = 0; i < 8; i++)
        {
            for (int e = 2; e < 15; e++)
            {
                CardsInit.Push(e);
            }     
        }
        CardsInit = ShuffleCards(CardsInit);
        //Debug.Log("Number of shuffled cards: " + CardsInit.Count);
        // Seperate Cards
        for (int i = 0; i < 52; i++)
        {
            CardsA.Push(CardsInit.Pop());
        }
        for (int i = 0; i < 52; i++)
        {
            CardsB.Push(CardsInit.Pop());
        }
    }

    public int GetCardValue(Stack<int> stack, int pos)
    {
        tempArr = stack.ToArray();
        tempVal = tempArr[pos];
        return tempVal;
    }

    public Stack<int> ShuffleCards(Stack<int> stack)
    {
        System.Random rand = new System.Random();
        int len = stack.Count;
        tempArr = stack.ToArray();
        stack.Clear();
        for (int i = 0; i < len; i++)
        {
            Swap(tempArr, i, i + rand.Next(len - i));
        }
        for (int v = 0; v < 104; v++)
        {
            stack.Push(tempArr[v]);
        }
        return stack;
    }

    public void Swap(int[] arr, int a, int b)
    {
        int temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }

    public void PrintArray(int[] arr, int mode)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (mode == 0)
            {
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

    public void PrintStack(Stack<int> stack, int mode)
    {
        tempArr = stack.ToArray();
        for (int i = 0; i < tempArr.Length; i++)
        {
            if (mode == 0)
            {
                Debug.Log(tempArr[i]);
            }
            else if (mode == 1)
            {
                Debug.LogWarning(tempArr[i]);
            }
            else
            {
                Debug.LogError("Mode is not available!");
            }
        }

    }

	// Use this for initialization
	void Start () {
        initCards();
        PrintStack(CardsA, 0);
        PrintStack(CardsB, 0);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
