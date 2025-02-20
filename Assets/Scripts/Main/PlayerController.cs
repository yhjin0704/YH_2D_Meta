using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : BaseController
{
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
}
