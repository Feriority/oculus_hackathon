using UnityEngine;
using System.Collections;

public class VRGUIPlease : VRGUI
{
	public OVRPlayerController Controller;
	public bool intro = true;

	public override void OnVRGUI()
	{
		acceptMouse = false;
		GUI.skin.label.fontSize = 30;
		GUILayout.BeginArea(new Rect(200, 0, 200, 100));
		GUILayout.Label("Stars: " + Controller.GetPickupCount());
		GUILayout.EndArea();
		if (intro) {
			GUI.color = Color.black;
			GUILayout.BeginArea(new Rect(400, 0, 500, 500));
			GUILayout.Label("Welcome to Rift Island! \n There are stars placed throughout the Island \n Collect all of them or you'll end up like our friends here. \n Press space to continue");
			GUILayout.EndArea();
		}
		if (intro && Input.GetKeyDown ("space")) {
			intro = false;
		}

	}
}
