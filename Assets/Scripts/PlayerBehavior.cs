using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
    public GameObject Bullet;
    public GameObject Rocket;
    //
    public Sprite LeftSide;
    public Sprite RightSide;
    public Sprite Default;
    private GameObject gameController;
    //
    public Vector3 sizeofSprite
    {
        get
        {
            float pixelsPerUnit = this.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
            Vector3 sizeofsprite = new Vector3(this.GetComponent<SpriteRenderer>().sprite.rect.width, this.GetComponent<SpriteRenderer>().sprite.rect.height, 0.0f);
            //
            sizeofsprite = new Vector3(sizeofsprite.x / pixelsPerUnit * this.transform.localScale.x, sizeofsprite.y / pixelsPerUnit * this.transform.localScale.y, 0.0f);
            return sizeofsprite;
        }
    }
    float speed = 2f;
	// Use this for initialization
	void Start () {
        this.GetComponent<SpriteRenderer>().sprite = Default;
        gameController = GameObject.FindGameObjectWithTag("GameController");
		
	}
	
	// Update is called once per frame
	void Update () {
        //moving up
		if(Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        //moving down
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        //moving left
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * speed * Time.deltaTime);
            this.GetComponent<SpriteRenderer>().sprite = LeftSide;
        }
        //moving right
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
            this.GetComponent<SpriteRenderer>().sprite = RightSide;
        }
        //
        if(Input.GetKeyUp(KeyCode.A)|| Input.GetKeyUp(KeyCode.D))
        {
            this.GetComponent<SpriteRenderer>().sprite = Default;
        }
        // 
		if (Input.GetKeyDown(KeyCode.J))
        {
            Fire();
        }
        //
		if(Input.GetKeyDown(KeyCode.K)|| Input.GetKeyDown(KeyCode.K))
        {
            FireRocket();
        }
    }
    public void Fire()
    {
        GameObject bulletClone = (GameObject)Instantiate(Bullet);
        // Calculate position
        Vector3 position = new Vector3(this.transform.position.x, this.transform.position.y + sizeofSprite.y / 2.0f - bulletClone.GetComponent<BulletBehavior>().sizeofSprite.y / 2.0f, 0.0f);
        bulletClone.transform.position = position;
    }
    public void FireRocket()
    {
        GameObject rocketClone = (GameObject)Instantiate(Rocket, this.transform.position, Quaternion.identity);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            GameObject.Destroy(this.gameObject);
            gameController.GetComponent<UiController>().EndGame();

        }
    }
}
