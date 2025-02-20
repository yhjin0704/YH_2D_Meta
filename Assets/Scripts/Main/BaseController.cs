using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BaseController : MonoBehaviour
{
    protected Vector2 Dir = Vector2.down;
    public Vector2 gDir { get { return Dir; } }

    public float Speed;

    protected bool IsMove = false;
    protected bool IsRightFoot = true;
    protected bool IsRun = false;
    protected bool IsRayCheck = false;

    Vector2 targetPosition;

    [SerializeField] private SpriteRenderer renderer;

    protected virtual void Awake()
    {
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
    }

    // Update is called once per frame
    protected virtual void Update()
    {
    }

    protected virtual void FixedUpdate()
    {
    }

    protected virtual void Move()
    {
        if (!IsMove)
        {
            return;
        }

        if (IsRayCheck)
        {
            IsRayCheck = false;
            RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + (1.0f * Dir), Dir, 0.2f);

            Debug.DrawRay((Vector2)transform.position + (1.0f * Dir), Dir, Color.red, 0.2f);
            
            Collider2D CharactorCol = GetComponent<Collider2D>();
            if (hit.collider != null)
            {
                bool a = hit.collider.gameObject.GetComponentInParent<Enter>();
                if (hit.collider.gameObject.GetComponentInParent<Enter>() == false)
                {
                    IsMove = false;
                    return;
                }
            }

            targetPosition = (Vector2)transform.position + Dir;
        }

        float stateSpeed = Speed;
        if (IsRun)
        {
            stateSpeed *= 1.5f;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * stateSpeed);

        if (Vector2.Distance(transform.position, targetPosition) < 0.01f)
        {
            transform.position = targetPosition;
            IsMove = false;
        }
    }
}
