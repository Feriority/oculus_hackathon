using UnityEngine;
using System.Collections;

public class VRGUIPlease : VRGUI
{
	public OVRPlayerController Controller;
	public const int TOTAL_PICKUPS = 22;

	public override void OnVRGUI()
	{
		acceptMouse = false;
		GUI.skin.label.fontSize = 30;
		GUILayout.BeginArea(new Rect(300, 100, 200, 100));
		GUILayout.Label("Stars: " + Controller.GetPickupCount() + "/" + TOTAL_PICKUPS);
		GUILayout.EndArea();
	}
}
