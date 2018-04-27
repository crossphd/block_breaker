using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false;
	public Vector3 paddleToBallVector;
	
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){
		// Lock ball relative to paddle until game starts with mouse click;
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			if (Input.GetMouseButtonDown(0)){				
				print ("Mouse Clicked");
				this.rigidbody2D.velocity = new Vector2(2f,10f);
				hasStarted = true;
			}
		}		
		
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		Vector2 tweak = new Vector2(Random.Range(-0.35f, 0.4f), Random.Range (-0.35f, 0.4f));
		if(hasStarted) {
			audio.Play();
			this.rigidbody2D.velocity += tweak;
		}
		
	}
}
