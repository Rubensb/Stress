using UnityEngine;
using System.Collections;
using UnityEngine.iOS;

public class Multitouch : MonoBehaviour {

	private Vector3 position;
	private float width;
	private float height;
	private int tapcount;

	void Awake()
	{
			width = (float)Screen.width / 2.0f;
			height = (float)Screen.height / 2.0f;
			position = new Vector3(0.0f, 0.0f, 0.0f);
			tapcount = 0;
			Debug.Log("Awake");
	}

	void OnGUI()
	{
			// Compute a fontSize based on the size of the screen width.
			GUI.skin.label.fontSize = (int)(Screen.width / 25.0f);

			GUI.Label(new Rect(20, 20, width, height * 0.25f),
					"x = " + position.x.ToString("f2") +
					", y = " + position.y.ToString("f2"));
	}

	void Update() {
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began) {
					Vector2 pos = touch.position;
					pos.x = (pos.x - width) / width;
					pos.y = (pos.y - height) / height;
					position = new Vector3(pos.x, pos.y, 0.0f);
			}

			if (Input.touchCount == 2) {
	        touch = Input.GetTouch(1);

//	        if (touch.phase == TouchPhase.Began) {
	            // Halve the size of the cube.
//	            transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
//	        }

	        if (touch.phase == TouchPhase.Began) {
						tapcount = tapcount + 1;
						Debug.Log(tapcount);
						if (tapcount == 1) {
							StartCoroutine(Timer());
						}
						if (tapcount >= 2) {
							Debug.Log("Double Tap");
						}
							// Restore the regular size of the cube.
//	            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
	        }
	    }
			//StartCoroutine(Timer());
		}
	}

		IEnumerator Timer() {
			yield return new WaitForSeconds(1);
			Debug.Log("1 Second");
			tapcount = 0;
		}
}
