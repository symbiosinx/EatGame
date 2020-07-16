using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Wobble : MonoBehaviour {

	[SerializeField] PostProcessVolume volume;
    void Start()
    {
        
    }

    void Update()
    {
		LensDistortion lensDistortionLayer = null;
		volume.profile.TryGetSettings(out lensDistortionLayer);
		lensDistortionLayer.enabled.value = true;
		lensDistortionLayer.intensity.value = Mathf.Sin(Time.time)*15f-35f;
    }
}
