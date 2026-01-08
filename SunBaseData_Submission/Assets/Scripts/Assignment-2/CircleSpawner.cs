using System.Collections;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    [SerializeField] int circleCount;
    [SerializeField] GameObject CirclePrefab;
    IEnumerator Start()
    {
        yield return null;

        Camera cam = Camera.main;

        Vector3 bottomleft = cam.ViewportToWorldPoint(Vector3.zero);
        Vector3 topright = cam.ViewportToWorldPoint(Vector2.one);

        float xSize = bottomleft.x - topright.x, ySize = bottomleft.y - topright.y;

        float maxCircleradius = Mathf.Abs(Mathf.Min(xSize, ySize) / 2);

        float circleradius = Random.Range(1, maxCircleradius);

        circleCount = Random.Range(5, 11);

        for (int i = 0; i < circleCount; i++)
        {
            GameObject spawncircle = Instantiate(CirclePrefab, transform);
            spawncircle.transform.localScale = Vector3.one * circleradius;

            spawncircle.transform.position = new Vector3(Random.Range(bottomleft.x, topright.x), Random.Range(bottomleft.y, topright.y));

            spawncircle.GetComponent<SpriteRenderer>().color = new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                1
                );

            spawncircle.SetActive(true);
            circleradius = Random.Range(1, maxCircleradius);
            yield return null;
        }
    }
}
