using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int NumBgCount = 5;
    public int ObstacleCount = 0;
    public Vector3 ObstacleLastPosition = Vector3.zero;

    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();

        ObstacleLastPosition = obstacles[0].transform.position;
        ObstacleCount = obstacles.Length;

        for (int i = 0; i < ObstacleCount; i++)
        {
            ObstacleLastPosition = obstacles[i].SetRandomPlace(ObstacleLastPosition, ObstacleCount);
        }
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D _Collision)
    {
        Debug.Log("Triggered: " + _Collision.name);

        if (_Collision.CompareTag("BackGround"))
        {
            float widthOfBgObject = ((BoxCollider2D)_Collision).size.x;
            Vector3 pos = _Collision.transform.position;

            pos.x += widthOfBgObject * NumBgCount;
            _Collision.transform.position = pos;
            return;
        }

        Obstacle obstacle = _Collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            ObstacleLastPosition = obstacle.SetRandomPlace(ObstacleLastPosition, ObstacleCount);
        }
    }
}
