using UnityEngine;
using System.Collections;

public class World{
	#region Singleton Pattern
	private static World instanceInternal;
	public static World instance {
		get{
			if (instanceInternal == null){
				new World();
			}
			return instanceInternal;
		}
	}
	
	public World(){
		instanceInternal = this;
	}
	#endregion
	
	public GameController master;
	public InterfaceManager interfaceManager;
}
