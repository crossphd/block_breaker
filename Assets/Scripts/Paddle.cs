using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false ;
	private Ball ball;
	
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		
	}
	
	// Update is called once per frame
	void Update () {
		print (ball.transform.position.x);
		if(!autoPlay) {
			MoveWithMouse();
		} else{
			AutoPlay();
		}
		
	}
	
	void MoveWithMouse(){
		float pos = (Input.mousePosition.x / Screen.width * 16);
		this.transform.position = new Vector3(Mathf.Clamp(pos, 1.03f, 15.03f), .5f, 0f);
	}
	
	void AutoPlay(){
		float pos = (ball.transform.position.x);
		this.transform.position = new Vector3(Mathf.Clamp(pos, 1.03f, 15.03f
		), .5f, 0f);
	}
}
