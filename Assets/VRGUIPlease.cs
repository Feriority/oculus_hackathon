using UnityEngine;
using System.Collections;

public class VRGUIPlease : VRGUI 
{
	public override void OnVRGUI()
	{
		acceptMouse = false;
		GUI.skin.label.fontSize = 30;
		GUILayout.BeginArea(new Rect(300, 100, 200, 100));
		GUILayout.Label("Lives: " + 10);
		GUILayout.EndArea();
	}
}
