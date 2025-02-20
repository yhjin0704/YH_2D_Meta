using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : BaseController
{
    private Enter CurrentOnEnter = null;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            string keyPressed = Input.inputString.ToLower();
            Debug.Log($"InputKey : {keyPressed}");
            if (!IsMove)
            {
                if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
                {
                    InputMove(keyPressed);
                }

                KeyCheck();
            }
        }

        if (IsMove)
        {
            Move();
        }
    }

    private void InputMove(string _InputKey)
    {
        IsMove = true;
        animator.SetBool("IsMove", IsMove);
        IsRayCheck = true;

        switch (_InputKey)
        {
            case "w":
                Dir = Vector2.up;
                animator.SetInteger("Dir", 0);
                break;
            case "a":
                Dir = Vector2.left;
                animator.SetInteger("Dir", 1);
                break;
            case "s":
                Dir = Vector2.down;
                animator.SetInteger("Dir", 2);
                break;
            case "d":
                Dir = Vector2.right;
                animator.SetInteger("Dir", 3);
                break;
            default:
                Debug.Log("이동키가 아닌 값이 InputMove()메서드에 입력되었습니다.");
                break;
        }
    }

    void KeyCheck()
    {
        Interaction();
        SwitchRunMode();
    }

    void Interaction()
    {
        if (null == CurrentOnEnter)
        {
            return;
        }

        if (Input.GetKeyDown("f"))
        {
            CurrentOnEnter.EnterScene();
        }
    }

    void SwitchRunMode()
    {
        if (Input.GetKeyDown("b"))
        {
            IsRun = !IsRun;
            animator.SetBool("IsRun", IsRun);
        }
    }

    private void OnTriggerEnter2D(Collider2D _Col)
    {

        Enter enter = _Col.GetComponent<Enter>();

        CurrentOnEnter = enter;
    }

    private void OnTriggerExit2D(Collider2D _Col)
    {
        if (_Col.GetComponent<Enter>() == CurrentOnEnter)
        {
            CurrentOnEnter = null;
        }
    }
}
