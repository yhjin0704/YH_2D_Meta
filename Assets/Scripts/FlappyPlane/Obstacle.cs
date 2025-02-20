using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    public float HighPosY = 1.0f;
    public float LowPosY = -1.0f;

    public float HoleSizeMin = 0.8f;
    public float HoleSizeMax = 1.8f;

    public Transform TopObject;
    public Transform BottomObject;

    public float WidthPadding = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 SetRandomPlace(Vector3 _LastPosition, int _ObstacleCount)
    {
        float holeSize = Random.Range(HoleSizeMin, HoleSizeMax);
        float halfHoleSize = holeSize / 2.0f;

        TopObject.localPosition = new Vector3(0, halfHoleSize);
        BottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = _LastPosition + new Vector3(WidthPadding, 0);

        placePosition.y = Random.Range(LowPosY, HighPosY);
        transform.position = placePosition;

        return placePosition;
    }
}
