using UnityEngine;
using System.Collections;
using UnityEngine.iOS;

public class TouchManagerA : MonoBehaviour
{
    private Vector3 position;
    private float width;
    private float height;
    public float active_a;
    public int picked_card;
    public Transform selectlight;
    private int tapcount;
    private int pop;
    //setting GameplayManager
  	private GameplayManager gameplayManager;

    void Start() {
      picked_card = -5;
      gameplayManager = GameObject.FindObjectOfType<GameplayManager>();
    }

    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;
        position = new Vector3(0.0f, 0.0f, 0.0f);
        tapcount = 0;
        pop = -5;
    }

    
    void OnGUI()
    {
        // Compute a fontSize based on the size of the screen width.
        GUI.skin.label.fontSize = (int)(Screen.width / 25.0f);
        GUI.Label(new Rect((width * 2) - 150, (height * 2) - 150, width, height * 0.25f),
            " " + gameplayManager.B_TOP);
        GUI.skin.label.fontSize = (int)(Screen.width / 25.0f);
        GUI.Label(new Rect(50, 80, width, height * 0.25f),
            " " + gameplayManager.A_TOP);

        //"x = " + position.x.ToString("f2") +
        //", y = " + position.y.ToString("f2"));
    }
    

    void Update()
    {
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) / height;
                position = new Vector3(pos.x, pos.y, 0.0f);

                if (position.y <= -0.01 && position.y >= -0.4){
                  if (position.x >= -0.45 && position.x <= -0.05){
                    if (picked_card == gameplayManager.B_active[gameplayManager.TOPCARD_B] + 1 || picked_card == gameplayManager.B_active[gameplayManager.TOPCARD_B] -1){
                      gameplayManager.B_active[gameplayManager.TOPCARD_B + 1] = picked_card;
                      Destroylight();
                      gameplayManager.a_hand[pop] = gameplayManager.a_cards[gameplayManager.A_TOP];
                      gameplayManager.TOPCARDS(1);
                      pop = -5;
                      //Debug.Log(gameplayManager.a_hand[0]);
                      picked_card = -5;
                    }
                    else if (picked_card == 2 ){
    									if (gameplayManager.B_active[gameplayManager.TOPCARD_B] == 14){
    										gameplayManager.B_active[gameplayManager.TOPCARD_B + 1] = picked_card;
    										Destroylight();
                        gameplayManager.a_hand[pop] = gameplayManager.a_cards[gameplayManager.A_TOP];
                        gameplayManager.TOPCARDS(1);
                        picked_card = -5;
    									}
    								}
    								else if (picked_card == 14 ){
    									if (gameplayManager.B_active[gameplayManager.TOPCARD_B] == 2){
    										gameplayManager.B_active[gameplayManager.TOPCARD_B + 1] = picked_card;
    										Destroylight();
                        gameplayManager.a_hand[pop] = gameplayManager.a_cards[gameplayManager.A_TOP];
                        gameplayManager.TOPCARDS(1);
                        picked_card = -5;
    									}
    								}
                    else {
                      Debug.Log("You cannot place this card!");
                    }
                  }
                  else if (position.x <= 0.45 && position.x >= 0.05){
                    if (picked_card == gameplayManager.A_active[gameplayManager.TOPCARD_A] + 1 || picked_card == gameplayManager.A_active[gameplayManager.TOPCARD_A] -1){
                      gameplayManager.A_active[gameplayManager.TOPCARD_A + 1] = picked_card;
                      Destroylight();
                      gameplayManager.a_hand[pop] = gameplayManager.a_cards[gameplayManager.A_TOP];
                      gameplayManager.TOPCARDS(1);
                      //Debug.Log(gameplayManager.a_hand[0]);
                      pop = -5;
                      picked_card = -5;
                    }
                    else if (picked_card == 2 ){
    									if (gameplayManager.A_active[gameplayManager.TOPCARD_A] == 14){
    										gameplayManager.A_active[gameplayManager.TOPCARD_A + 1] = picked_card;
                        gameplayManager.a_hand[pop] = gameplayManager.a_cards[gameplayManager.A_TOP];
                        gameplayManager.TOPCARDS(1);
                        Destroylight();
    										picked_card = -5;
    									}
    								}
    								else if (picked_card == 14 ){
    									if (gameplayManager.A_active[gameplayManager.TOPCARD_A] == 2){
    										gameplayManager.A_active[gameplayManager.TOPCARD_A + 1] = picked_card;
    										Destroylight();
                        gameplayManager.a_hand[pop] = gameplayManager.a_cards[gameplayManager.A_TOP];
                        gameplayManager.TOPCARDS(1);
    										picked_card = -5;
    									}
    								}
                    else {
                      Debug.Log("You cannot place this card!");
                    }
                  }
                }

                //which area (pos) is tapped -> hand_a
                if (position.y <= -0.62){
                  if (position.x <= -0.38 && position.x >= -0.75){
                    picked_card = gameplayManager.a_hand[0];
                    pop = 0;
                    Destroylight();
                    Spawnlight( -2.2f, -4, -1.1f );
                  }
                  else if (position.x <= -0.01 && position.x >= -0.36){
                    picked_card = gameplayManager.a_hand[1];
                    pop = 1;
                    Destroylight();
                    Spawnlight( -0.75f, -4, -1.1f );
                  }
                  else if (position.x >= +0.01 && position.x <= 0.36){
                    picked_card = gameplayManager.a_hand[2];
                    Destroylight();
                    pop = 2;
                    Spawnlight( 0.75f, -4, -1.1f );
                  }
                  else if (position.x >= 0.38 && position.x <= 0.75){
                    picked_card = gameplayManager.a_hand[3];
                    pop = 3;
                    Destroylight();
                    Spawnlight( 2.2f, -4, -1.1f );
                  }
                }
            }

            if (Input.touchCount == 2)
            {
                touch = Input.GetTouch(1);

                if (touch.phase == TouchPhase.Began) {
                    if (position.y <= -0.02 && position.y >= -0.5){
                        if (position.x >= 0.47 && position.x <= 1){
                            tapcount = tapcount + 1;
                			    if (tapcount == 1) {
                				    StartCoroutine(Timer());
                			    }
                			    if (tapcount == 2) {
                  					gameplayManager.KNOCK(1);
                                    tapcount = 0;
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
