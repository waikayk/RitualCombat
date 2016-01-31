using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InterfaceManager : MonoBehaviour {
	public Color orbActiveColor;
	public Color orbInactiveColor;
	public Image[] powerOrbsPlayer;
	public Image[] powerOrbsEnemy;
	public Text alert;
	
	private Coroutine alertRoutine;
	
	void Awake(){
		World.instance.interfaceManager = this;
		alert.gameObject.SetActive(false);
	}
	
	void Start(){
		
	}
	
	public void MakeAnnouncement(string text, float lingerDuration = 1f){
		if(alertRoutine != null) StopCoroutine(alertRoutine);
		
		alert.text = text;
		alertRoutine = StartCoroutine(AlertPunch(lingerDuration));
	}
	
	IEnumerator AlertPunch(float lingerDuration){
		alert.gameObject.SetActive(true);
		
		alert.rectTransform.localScale = new Vector3(2f, 2f, 2f);
		Vector3 scaleFrom  = alert.rectTransform.localScale;
		Vector3 scaleTo = Vector3.one * 0.85f;
		for(float t = 0; t < 1f; t += Time.deltaTime/0.25f){
			alert.rectTransform.localScale = Vector3.Lerp(scaleFrom, scaleTo, t);
			yield return null;
		}
		scaleFrom  = alert.rectTransform.localScale;
		for(float t = 0; t < 1f; t += Time.deltaTime/0.1f){
			alert.rectTransform.localScale = Vector3.Lerp(scaleFrom, Vector3.one, t);
			yield return null;
		}
		
		alert.rectTransform.localScale = Vector3.one;
		yield return new WaitForSeconds(lingerDuration);
		
		alert.gameObject.SetActive(false);
	}
}
