using UnityEngine;
using System.Collections;

public class Underwater : MonoBehaviour {
	
	//This script enables underwater effects. Attach to main camera.
	
	//Define variable
	public int underwaterLevel = 25;

	//The scene's default fog settings
	private bool defaultFog;
	private Color defaultFogColor;
	private float defaultFogDensity;
	private float defaultFogStart;
	private float defaultFogEnd;
	private Material defaultSkybox;
	private Material noSkybox;
	private OVRPlayerController pController;
	private float defaultGravity;
	private float defaultDamping;
	private float defaultJumpForce;
	private bool isUnderwater;

	void Start () {
		//Set the background color
		//cam = gameObject.GetComponent<Camera> ();
		//cam.backgroundColor = new Color(0.08f, 0.4f, 0.53f, 1);

		//The scene's default fog settings
		isUnderwater = false;
		defaultFog = RenderSettings.fog;
		defaultFogColor = RenderSettings.fogColor;
		defaultFogDensity = RenderSettings.fogDensity;
		defaultFogStart = RenderSettings.fogStartDistance;
		defaultFogEnd = RenderSettings.fogEndDistance;
		defaultSkybox = RenderSettings.skybox;
		defaultGravity = 1f;
		defaultDamping = .3f;
		defaultJumpForce = 2f;
	}
	
	void Update () {
		pController = gameObject.GetComponent<OVRPlayerController> ();
		if ((transform.position.y < underwaterLevel) && !isUnderwater) {
			isUnderwater = true;
			RenderSettings.fog = true;
			RenderSettings.fogColor = new Color (0.08f, 0.4f, 0.53f, 0.6f);
			RenderSettings.fogMode = FogMode.Linear;
			RenderSettings.fogStartDistance = -200;
			RenderSettings.fogEndDistance = 100;
			RenderSettings.skybox = noSkybox;

			pController.GravityModifier = 0.02f;
			pController.Damping = defaultDamping * 3;
		} 
		else if ((transform.position.y > underwaterLevel) && isUnderwater)
		{
			isUnderwater = false;
			RenderSettings.fog = defaultFog;
			RenderSettings.fogColor = defaultFogColor;
			RenderSettings.fogStartDistance = defaultFogStart;
			RenderSettings.fogEndDistance = defaultFogEnd;
			RenderSettings.skybox = defaultSkybox;

			pController.GravityModifier = defaultGravity;
			pController.Damping = defaultDamping;
			pController.JumpForce = defaultJumpForce;
		}

		if (isUnderwater)
		{
			pController.FallSpeed = pController.FallSpeed < -.05f ? -.05f : pController.FallSpeed;
			pController.isJumping = false;
			if (transform.position.y + 1 > underwaterLevel)
				pController.JumpForce = defaultJumpForce;
			else
				pController.JumpForce = .2f;
		}
	}
}