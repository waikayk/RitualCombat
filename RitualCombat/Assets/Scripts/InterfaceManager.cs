using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InterfaceManager : MonoBehaviour {
	public Color orbActiveColor;
	public Color orbInactiveColor;
	public Image[] powerOrbsPlayer;
	public Image[] powerOrbsEnemy;
//	public Button waterCant;
//	public Button fireCant;
//	public Button woodCant;
//	public Button lightningCant;
	public Text alert;
	public Text warning;
	public Text playerSpell;
	
	private GameController master;
	private Coroutine alertRoutine;
	private Coroutine warningRoutine;
	
	private List<string> currentSpellIncantation;
	
	void Awake(){
		World.instance.interfaceManager = this;
		alert.gameObject.SetActive(false);
	}
	
	void Start(){
		master = World.instance.master;
		currentSpellIncantation = new List<string>();
	}
	
	public void MakeAnnouncement(string text,Color color, float lingerDuration = 1f){
		if(alertRoutine != null) StopCoroutine(alertRoutine);
		
		alert.text = text;
		alert.color = color;
		alertRoutine = StartCoroutine(PunchIn(alert.transform, lingerDuration));
	}
	
	public void MakeAnnouncement(string text, float lingerDuration = 1f){
		MakeAnnouncement(text, Color.white, lingerDuration);
	}
	
	public void MakeWarning(string text, float lingerDuration = 1f){
		if(warningRoutine != null) StopCoroutine(warningRoutine);
		
		warning.text = text;
		warningRoutine = StartCoroutine(PunchIn(warning.transform, lingerDuration));
	}
	
	IEnumerator PunchIn(Transform objectTransform, float lingerDuration){
		objectTransform.gameObject.SetActive(true);
		
		objectTransform.localScale = new Vector3(2f, 2f, 2f);
		Vector3 scaleFrom  = objectTransform.localScale;
		Vector3 scaleTo = Vector3.one * 0.85f;
		for(float t = 0; t < 1f; t += Time.deltaTime/0.25f){
			objectTransform.localScale = Vector3.Lerp(scaleFrom, scaleTo, t);
			yield return null;
		}
		scaleFrom  = objectTransform.localScale;
		for(float t = 0; t < 1f; t += Time.deltaTime/0.1f){
			objectTransform.localScale = Vector3.Lerp(scaleFrom, Vector3.one, t);
			yield return null;
		}
		
		objectTransform.localScale = Vector3.one;
		
		//lingerDuration in the negatives will linger forever
		if(lingerDuration >= 0){
			yield return new WaitForSeconds(lingerDuration);
			objectTransform.gameObject.SetActive(false);
		}
	}
	
	public void AddElement(string element){
		if(currentSpellIncantation.Count >= 5){
			MakeWarning("No more Incantations can be made!", 0.5f);
			return;
		}
		playerSpell.text += " " + element;
		currentSpellIncantation.Add(element);
	}
	
	public void ExecuteSpell(){
		playerSpell.text = "";
		string incantation = "";
		foreach(string element in currentSpellIncantation){
			incantation += element;
		}
		master.ExecuteSpell(incantation);
		ClearIncantations();
	}
	
	public void ClearIncantations(){
		playerSpell.text = "";
		currentSpellIncantation.Clear();
	}
}
