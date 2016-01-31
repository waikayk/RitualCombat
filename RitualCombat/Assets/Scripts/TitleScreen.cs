using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {
	
	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			ExitGame();
		}
	}
	
	public void StartGame(){
		SceneManager.LoadScene(1);
	}
	
	public void ExitGame(){
		Application.Quit();
	}
}
