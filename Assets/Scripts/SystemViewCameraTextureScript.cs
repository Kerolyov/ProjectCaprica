using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemViewCameraTextureScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // This script should be on the same gameobject as the image/sprite

        RectTransform rt = GetComponent<RectTransform>();

        systemViewTexture = new RenderTexture( (int)rt.rect.width, (int)rt.rect.height, 24 );
        SystemCamera.targetTexture = systemViewTexture;

        //Sprite sprite = Sprite.Create(  );

        RawImage ri = GetComponent<RawImage>();

        ri.texture = systemViewTexture;

    }

    RenderTexture systemViewTexture;

    public Camera SystemCamera;
	
	// Update is called once per frame
	void Update () {
		
	}
}
