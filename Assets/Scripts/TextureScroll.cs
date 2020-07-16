using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroll : MonoBehaviour {
    
	[SerializeField] Material mat;

	float timer = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		timer += SpeedManager.instance.speed * Time.deltaTime * .05f;
        mat.SetTextureOffset("_MainTex", new Vector2(0f, -timer));
    }
}
