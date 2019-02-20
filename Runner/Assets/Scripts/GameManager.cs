
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

[SerializeField]
private Text scoreText;
[SerializeField]
private Player player;

[SerializeField]
private GamePanel gamePanel;


private bool IsEnd;
private float playerScore = 0;
private int countOfChanges = 0;


private void Start(){
	player.onGameOver += GameOver;
	player.onGameWin += GameWin;
}

private void GameWin(){
	float best = PlayerPrefs.GetFloat("Score");
	if(playerScore > best){
		best = playerScore;
		PlayerPrefs.SetFloat("Score", best);
	}
	player.transform.position = new Vector3(0,1,0);

	IsEnd = true;
	gamePanel.InitWin(playerScore,best,IsEnd);
}
private void GameOver(){
	float best = PlayerPrefs.GetFloat("Score");
	if(playerScore > best){
		best = playerScore;
		PlayerPrefs.SetFloat("Score", best);
	}
	player.transform.position = new Vector3(0,1,0);
	IsEnd = true;
	gamePanel.InitLose(playerScore,best,IsEnd);
}
private void Update(){
	if(!IsEnd){
	playerScore =  player.transform.position.z / 50;
	scoreText.text = "Счет: " + playerScore.ToString("0");		
	}
}


}
