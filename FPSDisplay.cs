using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour {

	private float timePassPerFrame=0f;
	public Text fpsText;
	public Text averageFPStext;
	public Text averageFPSthisSectext;

	float sumFPS;
	float totalFrames;
	float sumThisSec;
	float totalFramesThisSec;
	public float fpsEveryXsec=1f;
	void Start () {

		InvokeRepeating ("AverageFPS", 1f,1f);
		if (fpsEveryXsec > 0.5f) {
			InvokeRepeating ("AverageFPSEveryXsec", fpsEveryXsec,fpsEveryXsec);
		}
		sumFPS = 0f;
		totalFrames = 0f;
		sumThisSec = 0f;
		totalFramesThisSec = 0f;
	}

	// Update is called once per frame
	void Update () {

		// get time pass per frame
		timePassPerFrame += Time.deltaTime - timePassPerFrame;

		// fps= frame per sec i.e. 1/ time pass per frame
		float fps= 1f/ timePassPerFrame;

		fpsText.text = "FPS = " + fps.ToString("F0"); 

		sumFPS += fps;
		totalFrames += 1f;
		sumThisSec += fps;
		totalFramesThisSec += 1f;
	}		
	void AverageFPS(){
	
		float averageFPSValue = sumFPS / totalFrames;
		averageFPStext.text = "Average FPS :" + averageFPSValue.ToString("F1");
	}
	void AverageFPSEveryXsec(){
		float AverageFPSEveryXsecValue = sumThisSec / totalFramesThisSec;
		averageFPSthisSectext.text = "Average FPS this sec:" + AverageFPSEveryXsecValue.ToString("F1");

		sumThisSec = 0f;
		totalFramesThisSec = 0f;
	}
}