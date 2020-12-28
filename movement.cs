using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    Rigidbody rb;
    Transform t;
    GameObject p;
    Rigidbody pRb;
    Transform pT;
    bool isGrounded = true;
    bool possesion = false;
    Animator anim;
    CharacterController character;
    Vector3 direction;
    Vector3 rotation;
    public float speed;
    public float rotationSpeed;
    public GameObject ragdoll;

    void Start () {
        
        t = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        character = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        ragdoll.setParent(t);
	}

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void OnCollisionEnter(Collision col) { }

    void OnCollisionExit(Collision col){ }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == ("Player"))
        {
            p = col.gameObject;
            pRb = p.GetComponent<Rigidbody>();
            pT = p.GetComponent<Transform>();
            possesion = true;
            pT.SetParent(t);
        }
    }

    void OnTriggerExit(Collider col){ }


    void FixedUpdate () {

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        { }

        int w = Input.GetKey(KeyCode.W) ? 2 : 1, a = Input.GetKey(KeyCode.A) ? 3 : 1, s = Input.GetKey(KeyCode.S) ? 5 : 1, d = Input.GetKey(KeyCode.D) ? 7 : 1, left = Input.GetKey(KeyCode.LeftArrow) ? 2 : 1, right = Input.GetKey(KeyCode.RightArrow) ? 3 : 1;
        switch (left * right)
        {
            default:
                rotation = new Vector3(0.0f, 0.0f, 0.0f);
                break;
            case 2:
                rotation = Vector3.down;
                break;
            case 3:
                rotation = Vector3.up;
                break;
        }
        switch (w * a * s * d)
        {
            default://none
                direction = new Vector3(0.0f, 0.0f, 0.0f);//anim.SetInteger("move", 0);
                break;
            case 2:
            case 42://forward
                direction = Vector3.forward;//anim.SetInteger("move", 1);
                break;
            case 3:
            case 30://left
                direction = Vector3.left;//anim.SetInteger("move", 2);
                break;
            case 5:
            case 105://back
                direction = Vector3.back;//anim.SetInteger("move", 3);
                break;
            case 7:
            case 70://right
                direction = Vector3.right;//anim.SetInteger("move", 4);
                break;
            case 6://forward-left
                direction = (1.0f / 1.4142f) * (Vector3.forward + Vector3.left);//anim.SetInteger("move", 5);
                break;
            case 14://forward-right
                direction = (1.0f / 1.4142f) * (Vector3.forward + Vector3.right);//anim.SetInteger("move", 6);
                break;
            case 15://back-left
                direction = (1.0f / 1.4142f) * (Vector3.back + Vector3.left);//anim.SetInteger("move", 7);
                break;
            case 35://back-right
                direction = (1.0f / 1.4142f) * (Vector3.back + Vector3.right);//anim.SetInteger("move", 8);
                break;
        }
        
        if (Input.GetKeyDown(KeyCode.Space)&&possesion)
        {
            possesion = false;
            pT.SetParent(null);
            p = null;
            pRb = null;
            pT = null;
        }


        if (possesion)
        {
            //t.position = pT.position + new Vector3(1.0f, 1.0f, 1.0f);
            //t.RotateAround(pT.up, rotation.magnitude*rotationSpeed/100);
        }

        //player.Translate((speed / 100.0f * (direction)));
        //player.Rotate(rotation * rotationSpeed);
        //t.Translate(speed * direction);
        t.Rotate(rotationSpeed * rotation);
        character.SimpleMove(speed * transform.TransformDirection(direction));
        //rb.angularVelocity = (rotationSpeed * rotation);

    }

    /*
    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    {

        //rb.velocity += speed * (Vector3.up) * 1.0f;
        character.Move(speed * (Vector3.up) * 1.0f);
        isGrounded = false;
    }

    if (!isGrounded)
    {
        //anim.enabled = false;
    }
    else
    {
        //anim.enabled = true;
    }

    if (anim.enabled&&!isGrounded)
    {
        //rb.velocity -= 9.8f * (Vector3.up) * 0.05f;
    }
    */
}

