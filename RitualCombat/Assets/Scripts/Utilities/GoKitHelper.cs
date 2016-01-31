/*
 * This helper class written mostly for my own sanity.
 * 
 * -Wai Kay Kong
 */

using UnityEngine;
using System.Collections;

public delegate void VoidDelegate();

public static class GoKitHelper{
	public static GoTween MakeTween(
		Transform TheTransform, 
		Vector3 Position, 
		Quaternion Rotation, 
		float MoveTime = 0.5f, 
		bool IsLocal = false, 
		GoEaseType Ease = GoEaseType.Linear,
		VoidDelegate OnCompleteFunction = null
		)
	{
		GoTweenConfig Config = new GoTweenConfig();
		Config.addTweenProperty(new PositionTweenProperty(Position, false, IsLocal));
		//Config.addTweenProperty(new EulerAnglesTweenProperty(Rotation, false, IsLocal));
		Config.addTweenProperty(new RotationQuaternionTweenProperty(Rotation, false, IsLocal));
		Config.setEaseType(Ease);
		if(OnCompleteFunction != null){
			Config.onComplete(c => {
				OnCompleteFunction();
			});
		}
		GoTween NewTween = new GoTween(TheTransform, MoveTime, Config);
		Go.addTween(NewTween);
		
		return NewTween;
	}
	
	public static GoTween MakeTweenRotation(
		Transform TheTransform,
		Quaternion Rotation,
		float MoveTime,
		bool IsLocal = false,
		GoEaseType Ease = GoEaseType.Linear,
		VoidDelegate OnCompleteFunction = null
		)
	{
		GoTweenConfig Config = new GoTweenConfig();
		//Config.addTweenProperty(new EulerAnglesTweenProperty(Rotation, false, IsLocal));
		Config.addTweenProperty(new RotationQuaternionTweenProperty(Rotation, false, IsLocal));
		Config.setEaseType(Ease);
		if(OnCompleteFunction != null){
			Config.onComplete(c => {
				OnCompleteFunction();
			});
		}
		
		GoTween NewTween = new GoTween(TheTransform, MoveTime, Config);
		Go.addTween(NewTween);
		
		return NewTween;
	}
	
	public static GoTween MakeTweenPosition(
		Transform TheTransform,
		Vector3 Position,
		float MoveTime,
		bool IsLocal = false,
		GoEaseType Ease = GoEaseType.Linear,
		VoidDelegate OnCompleteFunction = null
		)
	{
		GoTweenConfig Config = new GoTweenConfig();
		Config.addTweenProperty(new PositionTweenProperty(Position, false, IsLocal));
		Config.setEaseType(Ease);
		if(OnCompleteFunction != null){
			Config.onComplete(c => {
				OnCompleteFunction();
			});
		}
		
		GoTween NewTween = new GoTween(TheTransform, MoveTime, Config);
		Go.addTween(NewTween);
		
		return NewTween;
	}
}
