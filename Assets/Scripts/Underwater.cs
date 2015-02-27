using UnityEngine;
using System.Collections;

public class Underwater : MonoBehaviour {
	
	//This script enables underwater effects. Attach to main camera.
	
	//Define variable
	public int underwaterLevel = 20;

	//The scene's default fog settings
	private bool defaultFog;
	private Color defaultFogColor;
	private float defaultFogDensity;
	private float defaultFogStart;
	private float defaultFogEnd;
	private Material defaultSkybox;
	private Material noSkybox;

	void Start () {
		//Set the background color
		camera.backgroundColor = new Color(0, 0.4f, 0.7f, 1);

		//The scene's default fog settings
		defaultFog = RenderSettings.fog;
		defaultFogColor = RenderSettings.fogColor;
		defaultFogDensity = RenderSettings.fogDensity;
		defaultFogStart = RenderSettings.fogStartDistance;
		defaultFogEnd = RenderSettings.fogEndDistance;
		defaultSkybox = RenderSettings.skybox;
	}
	
	void Update () {
		if (transform.position.y < underwaterLevel)
		{
			RenderSettings.fog = true;
			RenderSettings.fogColor = new Color(0, 0.4f, 0.7f, 0.6f);
			RenderSettings.fogMode = FogMode.Linear;
			RenderSettings.fogStartDistance = -200;
			RenderSettings.fogEndDistance = 100;
			RenderSettings.skybox = noSkybox;
		}
		else
		{
			RenderSettings.fog = defaultFog;
			RenderSettings.fogColor = defaultFogColor;
			RenderSettings.fogStartDistance = defaultFogStart;
			RenderSettings.fogEndDistance = defaultFogEnd;
			RenderSettings.skybox = defaultSkybox;
		}
	}
}