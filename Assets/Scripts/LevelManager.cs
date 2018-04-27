﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string level){
		Brick.breakableCount = 0;
		Application.LoadLevel(level);		
	}
	
	public void LoadNextLevel(){
		Brick.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void QuitRequest(){
		Application.Quit();
	}
	
	public void BrickDestroyed() {
		if(Brick.breakableCount <= 0){
			LoadNextLevel();
		}
	}
	
}
