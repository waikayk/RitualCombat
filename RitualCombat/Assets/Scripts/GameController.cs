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
			interfaceControl.MakeAnnouncement("THIS IS A TEST!", Color.red);
		}
//		else if(Input.GetKeyDown(KeyCode.RightArrow)){
//			LoadNextLevel();
//		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
		
		//TODO - Make this actually press the UI buttons instead of directly hitting the code
		if(Input.GetButtonDown("WaterCant")){
			interfaceControl.AddElement("Water");
		}
		else if(Input.GetButtonDown("FireCant")){
			interfaceControl.AddElement("Fire");
		}
		else if(Input.GetButtonDown("WoodCant")){
			interfaceControl.AddElement("Wood");
		}
		else if(Input.GetButtonDown("LightningCant")){
			interfaceControl.AddElement("Lightning");
		}
		else if(Input.GetButtonDown("ExecuteSpell")){
			interfaceControl.ExecuteSpell();
		}
	}
	
	public void LoadNextLevel(){
		int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
			if(nextSceneIndex >= SceneManager.sceneCountInBuildSettings) 
				nextSceneIndex = 0;
			SceneManager.LoadScene(nextSceneIndex);
	}
	
	public void ExecuteSpell(string incantation){
		print(incantation);
	}
}
