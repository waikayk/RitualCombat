using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SlidingMenu{
	public Toggle menuToggle;
	public RectTransform menu;
	public Vector3 offscreenOffset;
	public bool isActiveInitially;
	private bool isShowingInternal = false;
	public bool isShowing{
		get{return isShowingInternal;}
	}

	private Vector3 onscreenPosition;
	private Vector3 offscreenPosition;
	
	private GoTween tween;
	
	public virtual void Initialize(){
		onscreenPosition = menu.localPosition;
		offscreenPosition = onscreenPosition + offscreenOffset;
		
		if(!isActiveInitially) 
			menu.transform.localPosition = offscreenPosition;
		else 
			isShowingInternal = true;
	}
	
	public void Show(bool state, float duration = 0.25f, bool force = false){
		if(isShowingInternal == state && !force) return;
		if(tween != null) tween.destroy();
		tween = menu.localPositionTo (duration, state ? onscreenPosition : offscreenPosition, false);
		isShowingInternal = state;
	}
	
	public void ResizeBackground(float height){
		menu.SetSizeWithCurrentAnchors(
			RectTransform.Axis.Vertical, 	height
		);
	}
}