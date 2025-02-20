using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameManager gameManager = null;
    UIManager uiManager = null;
    Animator animator = null;
    Rigidbody2D rigidBody = null;

    public float FlapForce = 5.0f;
    public float ForwardSpeed = 3.0f;
    public bool IsDead = false;

    float DeathCooldown = 0.0f;
    bool IsFlap = false;
    float ElapsedTime = 0.0f;

    public bool GodMode = false;

    void Start()
    {
        gameManager = GameManager.Instance;
        uiManager = FindObjectOfType<UIManager>();
        animator = transform.GetComponentInChildren<Animator>();
        rigidBody = transform.GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            Debug.LogError("Not Founded Animator");
        }

        if (rigidBody == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }
    }

    void Update()
    {
        if (IsDead)
        {
            if (DeathCooldown <= 0)
            {
                uiManager.RestartButton.gameObject.SetActive(true);
                uiManager.ExitButton.gameObject.SetActive(true);
            }
            else
            {
                DeathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            ElapsedTime += Time.deltaTime;
            if (ElapsedTime >= 1.0f)
            {
                gameManager.AddScore(1);
                ElapsedTime = 0.0f;
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                IsFlap = true;
            }
        }
    }

    public void FixedUpdate()
    {
        if (IsDead)
            return;

        Vector3 velocity = rigidBody.velocity;
        velocity.x = ForwardSpeed;

        if (IsFlap)
        {
            velocity.y += FlapForce;
            IsFlap = false;
        }

        rigidBody.velocity = velocity;

        float angle = Mathf.Clamp((rigidBody.velocity.y * 10f), -90, 90);
        float lerpAngle = Mathf.Lerp(transform.rotation.eulerAngles.z, angle, Time.fixedDeltaTime * 5f);
        transform.rotation = Quaternion.Euler(0, 0, lerpAngle);
    }

    public void OnCollisionEnter2D(Collision2D _Collision)
    {
        if (GodMode)
            return;

        if (IsDead)
            return;

        animator.SetBool("IsDie", true);
        IsDead = true;
        DeathCooldown = 3.0f;
        gameManager.GameOver();
    }
}
