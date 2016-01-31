/*
 * Use for parsing Strings into Ints or Floats
 * 
 * Written by: Wai Kay Kong
 */ 

using UnityEngine;
using System.Collections;

static internal class Parse{
	static public int StringToInt(string str){
		int n;
		if(int.TryParse(str, out n)){
			return n;
		}
		return 0;
	}
	
	static public float StringToFloat(string str){
		float n;
		if(float.TryParse(str, out n)){
			return n;
		}
		return 0;
	}
	
	static public string LongToNiceString(long Value){
		if(Value > 1000000000000){
			float NewValue = (float)Value/1000000000000f;
			return NewValue.ToString("F1") + "Tr";
		}
		else if(Value > 1000000000){
			float NewValue = (float)Value/1000000000f;
			return NewValue.ToString("F1") + "B";
		}
		else if(Value > 1000000){
			float NewValue = (float)Value/1000000f;
			return NewValue.ToString("F1") + "M";
		}
		else if(Value > 1000){
			float NewValue = (float)Value/1000f;
			return NewValue.ToString("F1") + "K";
		}
		return Value.ToString("F1");
	}
}
