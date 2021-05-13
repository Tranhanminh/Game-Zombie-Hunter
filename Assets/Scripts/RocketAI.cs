using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAI : MonoBehaviour {
    public Transform target;
    Vector3 targetposion;
    public float MovingSpeed;
    public float RotationSpeed;
    public float Rotationoffset;
    public float Duration;
    public GameObject AnimationDestroy;
    // Use this for initialization
    void Start () {
		if(target == null)
        {
            targetposion = Vector3.zero;
        }
        else
        {
            targetposion = target.transform.position;
        }
     
    }
	
	// Update is called once per frame
	void Update () {
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, GetrotationZ()));
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        //
        this.transform.position += this.transform.up * MovingSpeed * Time.deltaTime;
        //
        try
        {
            if (target == null)
            {
                GameObject[] listenemy = GameObject.FindGameObjectsWithTag("enemy");
                this.target = listenemy[Random.Range(0, listenemy.Length)].transform;

                targetposion = target.position;
            }
            else
            {
                targetposion = target.position;
            }
        }
        catch
        {
            targetposion = Vector3.zero;
        }
        
        // kiem tra xem rocket nay co ton tai hon Duration giay khong
        if(Duration<= 0.0f)
        {
            createAnimationDestroy();
            GameObject.Destroy(this.gameObject);
        }
        Duration -= Time.deltaTime;
	}
    float GetrotationZ()
    {
        Vector3 Direction = (targetposion - this.transform.position).normalized;
        float result = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        return result + Rotationoffset;
    }

    void createAnimationDestroy()
    {
        GameObject aimationDestroyClone = (GameObject)GameObject.Instantiate(AnimationDestroy,this.transform.position, Quaternion.identity);
        GameObject.Destroy(aimationDestroyClone, 0.30f);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            GameObject.Destroy(other.gameObject);
            GameObject.Destroy(this.gameObject);
        }
    }
}
