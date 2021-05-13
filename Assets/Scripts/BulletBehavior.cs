using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {
    float speed = 5.0f;
    float LimitY;
    private GameObject gameController;
    //public GameObject animationDestroy;
    //AudioSource amthanh;
    [HideInInspector]
    public Vector3 sizeofSprite
    {
        get
        {
            float pixelsPerUnit = this.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
            Vector3 sizeofsprite = new Vector3(this.GetComponent<SpriteRenderer>().sprite.rect.width, this.GetComponent<SpriteRenderer>().sprite.rect.height, 0.0f);
            //
            sizeofsprite = new Vector3( sizeofsprite.x / pixelsPerUnit * this.transform.localScale.x, sizeofsprite.y / pixelsPerUnit * this.transform.localScale.y, 0.0f);
            return sizeofsprite;
        }
    }
    // Use this for initialization
    void Start () {
		
        LimitY = FindObjectOfType<Background>().MaxPoint.y + sizeofSprite.y / 2.0f;
        gameController = GameObject.FindGameObjectWithTag("GameController"); 
    }
	
	// Update is called once per frame
	void Update () {
		if (this. transform .position.y >= LimitY)
        {
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            this.transform.position += new Vector3(0.0f, speed * Time.deltaTime , 0.0f);
        }
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        //amthanh.Play();
        if (other.gameObject.tag == "enemy")
        {
            
            GameObject.Destroy(other.gameObject);
            gameController.GetComponent<UiController>().GetPoint();

        }
    }
    //void OnDestroy()
    //{
    //    GameObject exp = Instantiate(animationDestroy, transform.position, Quaternion.identity) as GameObject;
    //    Destroy(exp, 1.25f);
    //}
}
