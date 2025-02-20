using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : BaseController
{
    private Enter CurrentOnEnter = null;

    // Start is called before the first frame update
    void Start()
    {
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

                Interaction();
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
        IsRayCheck = true;

        switch (_InputKey)
        {
            case "w":
                Dir = Vector2.up;
                break;
            case "a":
                Dir = Vector2.left;
                break;
            case "s":
                Dir = Vector2.down;
                break;
            case "d":
                Dir = Vector2.right;
                break;
            default:
                Debug.Log("이동키가 아닌 값이 InputMove()메서드에 입력되었습니다.");
                break;
        }
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
