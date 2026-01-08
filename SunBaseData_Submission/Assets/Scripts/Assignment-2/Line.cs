using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;

    [HideInInspector] public List<Vector2> points = new List<Vector2>();
    [HideInInspector] public int pointsCount = 0;

    //The minimum distance between line's points.
    float pointsMinDistance = 0.1f;

    //Circle collider added to each line's point
    float circleColliderRadius;

    public void AddPoint(Vector2 newPoint)
    {
        //If distance between last point and new point is less than pointsMinDistance do nothing (return)
        if (pointsCount >= 1 && Vector2.Distance(newPoint, GetLastPoint()) < pointsMinDistance)
            return;

        points.Add(newPoint);
        pointsCount++;

        //Line Renderer
        lineRenderer.positionCount = pointsCount;
        lineRenderer.SetPosition(pointsCount - 1, newPoint);


        /*
        if (points.Count > 30)
        {
            points.RemoveAt(0);
            pointsCount--;
            lineRenderer.positionCount = pointsCount;
            lineRenderer.SetPositions(points.Select(value => (Vector3)value).ToArray());
        }
        */

        //Edge Collider
        //Edge colliders accept only 2 points or more (we can't create an edge with one point :D )
        if (pointsCount > 1)
            edgeCollider.points = points.ToArray();
    }

    public Vector2 GetLastPoint()
    {
        return (Vector2)lineRenderer.GetPosition(pointsCount - 1);
    }

    public void SetLineColor(Gradient colorGradient)
    {
        lineRenderer.colorGradient = colorGradient;
    }

    public void SetPointsMinDistance(float distance)
    {
        pointsMinDistance = distance;
    }

    public void SetLineWidth(float width)
    {
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;

        circleColliderRadius = width / 2f;

        edgeCollider.edgeRadius = circleColliderRadius;
    }

    public void removeAllPoints()
    {
        StartCoroutine("removeAllpoints");
    }

    IEnumerator removeAllpoints()
    {
        while (points.Count > 0)
        {
            points.RemoveAt(0);
            pointsCount--;
            lineRenderer.positionCount = pointsCount;
            lineRenderer.SetPositions(points.Select(value => (Vector3)value).ToArray());
            yield return null;
        }

        Destroy(gameObject);
    }

}