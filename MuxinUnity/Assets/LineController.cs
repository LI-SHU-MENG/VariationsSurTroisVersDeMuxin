using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        DrawLogSpiral();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void DrawLogSpiral()
    {
        //draw log spiral of 1000 points
        // n=100
        // a=0.5
        // b=0.20
        // th=np.linspace(0, 500, 10000)
        // x=a*exp(b*th)*cos(th)
        // y=a*exp(b*th)*sin(th)
        //z=np.linspace(0,2, 10000)
        
        int n = 1000;
        float a = 0.5f;
        float b = 0.20f;
        float slopeDegree = 45;
        
        for (int i = 0; i < n; i++)
        {
            float t = i * 0.05f;
            float x = a * Mathf.Exp(b * t) * Mathf.Cos(t);
            float y = a * Mathf.Exp(b * t) * Mathf.Sin(t);
            // z depends on the value of x and y, it goes down porportionally to x or y, z/x = tan(slopeDegree)
            float c = slopeDegree * Mathf.Deg2Rad;
            float z = a * Mathf.Exp(b * t) * Mathf.Tan(c);
            lineRenderer.positionCount = i + 1;
            lineRenderer.SetPosition(i, new Vector3(x, n-z, y));
        }
        
    }
    
    void DrawEquiangularSpiral()
    {
        //draw equiangular spiral of 1000 points, each point is 1 unit away from the previous point
        for (int i = 0; i < 1000; i++)
        {
            float t = i * 0.1f;
            float x = t * Mathf.Cos(t);
            float y = t * Mathf.Sin(t);
            lineRenderer.positionCount = i + 1;
            lineRenderer.SetPosition(i, new Vector3(x, 0, y));
        }
    }
}
