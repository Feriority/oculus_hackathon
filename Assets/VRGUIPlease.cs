using UnityEngine;
using System.Collections;

public class VRGUIPlease : VRGUI
{
	public OVRPlayerController Controller;
	public bool intro = true;
	public const int TOTAL_PICKUPS = 22;


	public override void OnVRGUI()
	{
		acceptMouse = false;
		GUI.skin.label.fontSize = 30;
		GUILayout.BeginArea(new Rect(300, 0, 200, 100));
		GUILayout.Label("Stars: " + Controller.GetPickupCount() + "/" + TOTAL_PICKUPS);
		GUILayout.EndArea();
		if (intro) {
			GUILayout.BeginArea(new Rect(500, 0, 500, 500));
			GUILayout.Label("Welcome to Rift Island! \n There are stars placed throughout the Island \n Collect all of them or you'll end up like our friends here. \n Press space to continue");
			GUILayout.EndArea();
		}
		if (intro && Input.GetKeyDown ("space")) {
			intro = false;
		}

	}
}
