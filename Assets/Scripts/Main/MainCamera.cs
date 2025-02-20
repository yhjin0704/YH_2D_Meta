using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera: MonoBehaviour
{
    public Transform Target;

    float OffsetX;
    float OffsetY;

    void Start()
    {
        if (Target == null)
            return;

        OffsetX = transform.position.x - Target.position.x;
        OffsetY = transform.position.y - Target.position.y;
    }

    void Update()
    {
        if (Target == null)
            return;

        Vector3 pos = transform.position;

        pos.x = Target.position.x + OffsetX;
        pos.y = Target.position.y + OffsetY;

        transform.position = pos;
    }
}
