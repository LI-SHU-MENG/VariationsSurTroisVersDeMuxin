using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiral : MonoBehaviour
{
    private BoxCollider[] speakers;
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        speakers = GetComponentsInChildren<BoxCollider>();
        lineRenderer = GetComponent<LineRenderer>();
        
        Vector3[] points = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(points);
        //evenly distribute speakers on height
         float totalHeight = Mathf.Abs(points[0].y - points[points.Length - 1].y);
         float spacing = totalHeight / speakers.Length;
         for (int i = 0; i < speakers.Length; i++)
         {
             float height = totalHeight - i * spacing;
             //find the nearest point to the height
             float minDistance = float.MaxValue;
             Vector3 nearestPoint = Vector3.zero;
             float offset = points[points.Length - 1].y;
             //get would position of the point on the line
                
             for (int j = 0; j < points.Length; j++)
             {
                 Vector3 point = points[j];
                 float distance = Mathf.Abs(point.y - height - offset);
                 if (distance < minDistance)
                 {
                     minDistance = distance;
                     nearestPoint = point;
                 }
             }
             //apply offset
             speakers[i].transform.position = (nearestPoint - new Vector3(0, offset, 0)) * lineRenderer.transform.localScale.y;
             print(speakers[i].transform.position);
         }
        
        //evenly distribute speakers on the spiral
        // int spacing = lineRenderer.positionCount / speakers.Length;
        // for (int i = 0; i < speakers.Length; i++)
        // {
        //     int index = i * spacing;
        //     speakers[i].transform.position = lineRenderer.GetPosition(index);
        //     print(speakers[i].transform.position);
        // }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
