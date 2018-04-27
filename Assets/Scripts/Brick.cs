using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private int timesHit;
	private LevelManager levelManager;
	public Sprite[] hitSprites;
	public AudioClip crack;
	public static int breakableCount = 0;
	private bool isBreakable;
	public GameObject smoke;
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		// keep track of breakable bricks
		if(isBreakable) {
			breakableCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		AudioSource.PlayClipAtPoint(crack, transform.position, .1f);
		if(isBreakable) HandleHits();
		// SimulateWin();
	}
	
	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits) {
			breakableCount--;
			SmokePuff();
			levelManager.BrickDestroyed();
			Destroy (gameObject);
		} else {
			LoadSprites();
		}
	}
	
	private void SmokePuff()
	{
		Vector3 smokePos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
		GameObject smokePuff = Instantiate(smoke, smokePos, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.renderer.sortingLayerName = "smokeLayer";
		smokePuff.particleSystem.startColor = GetComponent<SpriteRenderer>().color;
		Destroy(smokePuff, .5f);
	}
	
	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex])
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
	}

	
}
