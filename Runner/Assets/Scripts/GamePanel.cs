using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePanel : MonoBehaviour {

	[SerializeField]
	private Transform root;

	[SerializeField]
	private Image image;

	[SerializeField]
	private Text curScoreText, bestScoreText;

	[SerializeField]
	private Button retryButton, quitButton, levelButton;

	[SerializeField]
	private Text mainText;
	
	[SerializeField]
	private Player player;

	private bool isLevel=false;

	private void Start(){
		retryButton.onClick.AddListener(Retry);
		quitButton.onClick.AddListener(Quit);
		levelButton.onClick.AddListener(NextLevel);
		root.gameObject.SetActive(false);
	}

	public void InitWin(float curScore, float bestScore, bool isEnd){
		root.gameObject.SetActive(true);
		mainText.text = "WIN!!!";
		image.color = Color.magenta;
		isEnd = false;
	    
		levelButton.gameObject.SetActive(true);

		curScoreText.text = "Your score: " + curScore.ToString("0");
		bestScoreText.text = "Best score: " + bestScore.ToString("0");
	}

	public void InitLose(float curScore, float bestScore, bool isEnd){
		root.gameObject.SetActive(true);
		mainText.text = "WASTED";
		image.color = Color.blue;
		isEnd = false;

		curScoreText.text = "Your score: " + curScore.ToString("0");
		bestScoreText.text = "Best score: " + bestScore.ToString("0");
	}

	private void Retry(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);		
	}

	private void NextLevel(){
		if(isLevel==false){
		SceneManager.LoadScene("level2");
		isLevel=true;
		}
		else if(isLevel==true){
		SceneManager.LoadScene("level1");
		isLevel=false;
		}
	}

	private void Quit(){
		Application.Quit();
	}

	private void OnDestroy() {
		retryButton.onClick.RemoveAllListeners();
		quitButton.onClick.RemoveAllListeners();
	}

}
