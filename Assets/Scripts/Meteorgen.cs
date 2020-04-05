using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorgen : MonoBehaviour
{
    public LineRenderer lr;
    public PolygonCollider2D col;

    public float minrad;
    public float maxrad;
    public bool tangible;
    
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();

        
        var numverts = (int)Mathf.FloorToInt(Random.Range(4,7));

        Vector3[] lineverts = new Vector3[numverts];
        Vector2[] colverts = new Vector2[numverts];

        for(int i  = 0; i<numverts; i++)
        {
            var rad = Random.Range(minrad, maxrad);
            lineverts[i] = new Vector3(rad*Mathf.Cos(2 * Mathf.PI * i/numverts), rad*Mathf.Sin(2*Mathf.PI*i/numverts), -1);
            colverts[i] = new Vector2(lineverts[i].x, lineverts[i].y);
        }

        lr.positionCount = numverts;
        lr.SetPositions(lineverts);

        if (tangible)
        {
            col = GetComponent<PolygonCollider2D>();
            col.pathCount = 1;
            col.SetPath(0, colverts);
        }

    }
}
