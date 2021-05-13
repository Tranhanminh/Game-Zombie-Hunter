using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Path : MonoBehaviour {
    public Color StarPointColor = Color. red;
    public Color PathColor = Color. white;
    public Color PointColor = Color. white;
    //
  public List<Transform> ListPoints = new List<Transform>();
    // Use this for initialization
void OnDrawGizmos()
    {
        Gizmos.color = StarPointColor;
        ListPoints.Clear();
        //
        foreach(Transform t in this.GetComponentsInChildren<Transform>())
        {
            if (t != this.transform)
            {
                ListPoints.Add(t);
            }
        }
        //
        for(int i=0; i<ListPoints.Count; i++)
        {
            if (i > 0)
                {
                    Gizmos.DrawLine(ListPoints[i - 1].position, ListPoints[i].position);
                    Gizmos.color = PointColor;
                    Gizmos.DrawSphere(ListPoints[i].position, 0.15f);
                    Gizmos.color = PathColor;
            }
            else
                {
                    Gizmos.DrawSphere(ListPoints[i].position, 0.15f);
                    Gizmos.color = PathColor;
                }
        }
    }
}
