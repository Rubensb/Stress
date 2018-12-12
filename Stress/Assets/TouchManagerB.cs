using System.Collections;
using UnityEngine;
using UnityEngine.iOS;

public class TouchManagerB : MonoBehaviour {

	private Vector3 position;
	private float width;
	private float height;
	public float active_b;
	public int picked_card;
    private int tapcount;
	public Transform selectlight;
	private int pop;
	//setting GameplayManager
	private GameplayManager gameplayManager;

	void Start () {
		picked_card = -5;
		gameplayManager = GameObject.FindObjectOfType<GameplayManager>();
	}

	void Awake(){
		width = (float)Screen.width / 2.0f;
		height = (float)Screen.height / 2.0f;
		position = new Vector3(0.0f, 0.0f, 0.0f);
	}
    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) / height;
                position = new Vector3(pos.x, pos.y, 0.0f);

                if (position.y >= 0.01 && position.y <= 0.4)
                {
                    if (position.x >= -0.45 && position.x <= -0.05)
                    {
                        if (picked_card == gameplayManager.B_active[gameplayManager.TOPCARD_B] + 1 || picked_card == gameplayManager.B_active[gameplayManager.TOPCARD_B] - 1)
                        {
                            gameplayManager.B_active[gameplayManager.TOPCARD_B + 1] = picked_card;
                            gameplayManager.b_hand[pop] = gameplayManager.b_cards[gameplayManager.B_TOP];
                            gameplayManager.TOPCARDS(2);
                            Destroylight();
                            picked_card = -5;
                        }
                        else if (picked_card == 2)
                        {
                            if (gameplayManager.B_active[gameplayManager.TOPCARD_B] == 14)
                            {
                                gameplayManager.B_active[gameplayManager.TOPCARD_B + 1] = picked_card;
                                gameplayManager.b_hand[pop] = gameplayManager.b_cards[gameplayManager.B_TOP];
                                gameplayManager.TOPCARDS(2);
                                Destroylight();
                                picked_card = -5;
                            }
                        }
                        else if (picked_card == 14)
                        {
                            if (gameplayManager.B_active[gameplayManager.TOPCARD_B] == 2)
                            {
                                gameplayManager.B_active[gameplayManager.TOPCARD_B + 1] = picked_card;
                                gameplayManager.b_hand[pop] = gameplayManager.b_cards[gameplayManager.B_TOP];
                                gameplayManager.TOPCARDS(2);
                                Destroylight();
                                picked_card = -5;
                            }
                        }
                        else
                        {
                            Debug.Log("You cannot place this card!");
                        }
                    }
                    else if (position.x <= 0.45 && position.x >= 0.05)
                    {
                        if (picked_card == gameplayManager.A_active[gameplayManager.TOPCARD_A] + 1 || picked_card == gameplayManager.A_active[gameplayManager.TOPCARD_A] - 1)
                        {
                            gameplayManager.A_active[gameplayManager.TOPCARD_A + 1] = picked_card;
                            gameplayManager.b_hand[pop] = gameplayManager.b_cards[gameplayManager.B_TOP];
                            gameplayManager.TOPCARDS(2);
                            Destroylight();
                            picked_card = -5;
                        }
                        else if (picked_card == 2)
                        {
                            if (gameplayManager.A_active[gameplayManager.TOPCARD_A] == 14)
                            {
                                gameplayManager.A_active[gameplayManager.TOPCARD_A + 1] = picked_card;
                                gameplayManager.b_hand[pop] = gameplayManager.b_cards[gameplayManager.B_TOP];
                                gameplayManager.TOPCARDS(2);
                                Destroylight();
                                picked_card = -5;
                            }
                        }
                        else if (picked_card == 14)
                        {
                            if (gameplayManager.A_active[gameplayManager.TOPCARD_A] == 2)
                            {
                                gameplayManager.A_active[gameplayManager.TOPCARD_A + 1] = picked_card;
                                gameplayManager.b_hand[pop] = gameplayManager.b_cards[gameplayManager.B_TOP];
                                gameplayManager.TOPCARDS(2);
                                Destroylight();
                                picked_card = -5;
                            }
                        }
                        else
                        {
                            Debug.Log("You cannot place this card!");
                        }
                    }
                }

                //which area (pos) is tapped -> hand_b
                if (position.y >= 0.62)
                {
                    if (position.x <= -0.38 && position.x >= -0.75)
                    {
                        picked_card = gameplayManager.b_hand[0];
                        pop = 0;
                        Destroylight();
                        Spawnlight(-2.2f, 4, -1.1f);
                    }
                    else if (position.x <= -0.01 && position.x >= -0.36)
                    {
                        picked_card = gameplayManager.b_hand[1];
                        pop = 1;
                        Destroylight();
                        Spawnlight(-0.75f, 4, -1.1f);
                    }
                    else if (position.x >= +0.01 && position.x <= 0.36)
                    {
                        picked_card = gameplayManager.b_hand[2];
                        pop = 2;
                        Destroylight();
                        Spawnlight(0.75f, 4, -1.1f);
                    }
                    else if (position.x >= 0.38 && position.x <= 0.75)
                    {
                        picked_card = gameplayManager.b_hand[3];
                        pop = 3;
                        Destroylight();
                        Spawnlight(2.2f, 4, -1.1f);
                    }
                }
            }

            if (Input.touchCount == 2)
            {
                touch = Input.GetTouch(1);

                if (touch.phase == TouchPhase.Began)
                {
                    if (position.y >= 0.02 && position.y <= 0.5)
                    {
                        if (position.x <= -0.47 && position.x >= -1)
                        {
                            tapcount = tapcount + 1;
                            if (tapcount == 1)
                            {
                                StartCoroutine(Timer());
                            }
                            if (tapcount == 2)
                            {
                                if (gameplayManager.gameover == 1)
                                {
                                    gameplayManager.gameover = 0;
                                    gameplayManager.InitRound();
                                }
                                else
                                {
                                    gameplayManager.KNOCK(2);
                                    tapcount = 0;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
	void Destroylight(){
		foreach (Transform selectlight in transform) {
			GameObject.Destroy(selectlight.gameObject);
		}
	}

    void Spawnlight(float x, int y, float z){
	var child = Instantiate(selectlight, new Vector3 ( x , y , z ), selectlight.transform.rotation);
	child.transform.parent = transform;
	}

        IEnumerator Timer() {
	yield return new WaitForSeconds(1);
	tapcount = 0;
	}
}
