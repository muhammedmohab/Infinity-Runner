using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 offset;
    private Vector3 movement;
    private Vector3 animOffset = new Vector3(0, 5, 5);
    private float strtrans = 0.0f; // starting transation;
    private float animtime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - lookAt.position; 
    }

    // Update is called once per frame
    void Update()
    {
        movement = lookAt.position + offset;
        if(strtrans > 1.0f)
        {
            //Normal camera movement + offset;
            transform.position = movement;
        }
        else
        {
            //Camera Start animation;
            transform.position = Vector3.Lerp(movement + animOffset, movement, strtrans);
            strtrans = strtrans + Time.deltaTime * 1 / animtime;

        }


    }
}
