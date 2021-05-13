using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    public Path MovingPath;
    //
    public float MovingSpeed;   
    public bool isRotation = false;
    public float RotationSpeed;
    public float Rotationoffset;
    int CurrentPointIndex = 0;
    float MinDistanceLimit = 0.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //di chuyển
        float Distance = Vector3.Distance(new Vector3(MovingPath.ListPoints[CurrentPointIndex].position.x, MovingPath.ListPoints[CurrentPointIndex].position.y, 0.0f), new Vector3(this.transform.position.x, this.transform.position.y, 0.0f));
        //
        this.transform.position += (MovingPath.ListPoints[CurrentPointIndex].position - this.transform.position).normalized * MovingSpeed * Time.deltaTime;
        //quay đầu
        if(isRotation)
        {
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, GetrotationZ()));
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        }
        //Quaternion targetRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, GetrotationZ()));
        //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        //kiểm tra cuối path
        if (Distance <= MinDistanceLimit )
        {
            CurrentPointIndex ++;
            if(CurrentPointIndex >= MovingPath.ListPoints.Count)
            {
                CurrentPointIndex = 0; 
                //GameObject.Destroy(this.gameObject);
            }
        }
	}
    float GetrotationZ()
    {
        Vector3 Direction = (MovingPath.ListPoints[CurrentPointIndex].position - this.transform.position).normalized;
        float result = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        return result + Rotationoffset;
    }
}
