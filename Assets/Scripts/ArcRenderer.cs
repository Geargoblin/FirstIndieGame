using System.Collections.Generic;
using UnityEngine;

public class ArcRenderer : MonoBehaviour
{
    public GameObject arrowPrefab; //the arrow head
    public GameObject dotPrefab; //the dots
    public int poolSize = 50; // the size of dot pool
    private List<GameObject> dotPool = new List<GameObject>(); //the dot pool
    private GameObject arrowInstance; //reference to arrow head

    public float spacing = 50; //the spacing of the dots
    public float arrowAngleAdjustment = 0; //Angle correction for the arrow head
    public int dotsToSkip = 1; //number of dots to skip in order to give the arrow head space
    private Vector3 arrowDirection; //Holds the position the arrow head needs to point from

    void Start()
    {
        arrowInstance = Instantiate(arrowPrefab, transform);
        arrowInstance.transform.localPosition = Vector3.zero;
        InitializeDotPool(poolSize);
    }

    void Update()
    {
        Vector3 mousPos = Input.mousePosition;

        mousPos.z = 0;

        Vector3 startPos = transform.position;
        Vector3 midPoint = CalculateMidPoint(startPos, mousPos);

        UpdateArc(startPos, midPoint, mousPos);
        PositionAndRotateArrow(mousPos);
    }

    void UpdateArc(Vector3 start, Vector3 mid, Vector3 end)
    {
        int numDots = Mathf.CeilToInt(Vector3.Distance(start, end) / spacing);

        for (int i = 0; i < numDots && i < dotPool.Count; i++)
        {
            float t = i / (float)numDots;
            t = Mathf.Clamp(t, 0f, 1f); //ensures t within [0,1]

            Vector3 postion = QuadraticBezierPoint(start, mid, end, t);

            if (i != numDots - (dotsToSkip + 1) && i - dotsToSkip + 1 >= 0)
            {
                arrowDirection = dotPool[i].transform.position;
            }
        }

        //Deactivate unused dots
        for (int i = numDots - dotsToSkip; i < dotPool.Count; i++)
        {
            if (i > 0)
            {
                dotPool[i].SetActive(false);   
            }
        }
    }

    void PositionAndRotateArrow(Vector3 position)
    {
        arrowInstance.transform.position = position;
        Vector3 direction = arrowDirection - position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle += arrowAngleAdjustment;
        arrowInstance.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);    
    }

    Vector3 CalculateMidPoint(Vector3 start, Vector3 end)
    {
        Vector3 midPoint = (start + end) / 2;
        float arcHeight = Vector3.Distance(start, end) / 3f;
        midPoint.y += arcHeight;
        return midPoint;
    }

    Vector3 QuadraticBezierPoint(Vector3 start, Vector3 control, Vector3 end, float t)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 point = uu * start;
        point += 2 * u * t * control;
        point += tt * end;
        return point;
    }

    void InitializeDotPool(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject dot = Instantiate(dotPrefab, Vector3.zero, Quaternion.identity, transform);
            dot.SetActive(false);
            dotPool.Add(dot);
        }
    }
}
