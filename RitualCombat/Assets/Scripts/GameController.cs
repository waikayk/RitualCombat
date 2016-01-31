using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {
	
	private InterfaceManager interfaceControl;
	
	void Awake(){
		World.instance.master = this;
	}
	
	void Start(){
		interfaceControl = World.instance.interfaceManager;
		
		interfaceControl.MakeAnnouncement(SceneManager.GetActiveScene().name, 1.5f);
	}
	
	void Update(){
		ProcessInput();
	}
	
	void ProcessInput(){
		if(Input.GetKeyDown(KeyCode.I)){
			interfaceControl.MakeAnnouncement("THIS IS A TEST!");
		}
		else if(Input.GetKeyDown(KeyCode.RightArrow)){
			int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
			if(nextSceneIndex >= SceneManager.sceneCountInBuildSettings) 
				nextSceneIndex = 0;
			SceneManager.LoadScene(nextSceneIndex);
		}
	}
}
