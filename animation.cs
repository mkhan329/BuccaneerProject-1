using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int w = Input.GetKey(KeyCode.W) ? 2 : 1, a = Input.GetKey(KeyCode.A) ? 3 : 1, s = Input.GetKey(KeyCode.S) ? 5 : 1, d = Input.GetKey(KeyCode.D) ? 7 : 1, left = Input.GetKey(KeyCode.LeftArrow) ? 2 : 1, right = Input.GetKey(KeyCode.RightArrow) ? 3 : 1;
        switch (left * right)
        {
            default:
                
                break;
            case 2:
                
                break;
            case 3:
                
                break;
        }
        switch (w * a * s * d)
        {
            default://none
                anim.SetInteger("move", 0);
                break;
            case 2:
            case 42://forward
                anim.SetInteger("move", 1);
                break;
            case 3:
            case 30://left
                anim.SetInteger("move", 2);
                break;
            case 5:
            case 105://back
                anim.SetInteger("move", 3);
                break;
            case 7:
            case 70://right
                anim.SetInteger("move", 4);
                break;
            case 6://forward-left
                anim.SetInteger("move", 5);
                break;
            case 14://forward-right
                anim.SetInteger("move", 6);
                break;
            case 15://back-left
                anim.SetInteger("move", 7);
                break;
            case 35://back-right
                anim.SetInteger("move", 8);
                break;
        }
    }
}
