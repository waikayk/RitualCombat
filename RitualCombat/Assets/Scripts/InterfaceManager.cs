using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InterfaceManager : MonoBehaviour {
	public Color orbActiveColor;
	public Color orbInactiveColor;
	public Image[] powerOrbsPlayer;
	public Image[] powerOrbsEnemy;
	
	void Awake(){
		World.instance.interfaceManager = this;
	}
}
