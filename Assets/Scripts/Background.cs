using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    [HideInInspector]
  public Vector3 MaxPoint;
    [HideInInspector]
  public Vector3 MinPoint;

	// Use this for initialization
	void Start () {
        MaxPoint = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0.0f));
        MinPoint = Camera.main.ScreenToWorldPoint(Vector3.zero);
        float widthScreen = MaxPoint.x - MinPoint.x;
        float heightScreen = MaxPoint.y - MinPoint.y;
        //
        float pixelsPerUnit = this.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        Vector3 sizeofsprite = new Vector3(this.GetComponent<SpriteRenderer>().sprite.rect.width, this.GetComponent<SpriteRenderer>().sprite.rect.height,0.0f);
        //
        Vector3 sizeofBackground = new Vector3(widthScreen / (sizeofsprite.x / pixelsPerUnit), heightScreen / (sizeofsprite.y / pixelsPerUnit),0.0f);
      this.transform.localScale = sizeofBackground;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
