using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highScoreScript : MonoBehaviour {

	public int highscore;
	// Use this for initialization
	void Start () {
		GameObject theplayer= GameObject.Find("player");
		player player= theplayer.GetComponent<player>();
		highscore= player.currentScore;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(highscore);
	}
}
