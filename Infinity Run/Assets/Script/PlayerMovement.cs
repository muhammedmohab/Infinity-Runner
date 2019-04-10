using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //keycode let us asside a key when pressed move the object
    public KeyCode moveL;
    public KeyCode moveR;

    public int speedUp = 4;
    public float vertVelocity = 0;
    public float horizVelocity = 0;
    public int laneNum = 2;
    public bool Lock = false; // flase==0 true==1
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        GetComponent<Rigidbody>().velocity = new Vector3(horizVelocity, vertVelocity, speedUp);

        if (Input.GetKeyDown(moveL) && (laneNum > 1) && (Lock == false))
        {
            horizVelocity = -2;
            //start a coroutine and wait for a half a second and let horizVelocity = 0;
            StartCoroutine(stopMove ());
            laneNum -=1 ;
            Lock = true;

        }
        if (Input.GetKeyDown(moveR) && (laneNum < 3) && (Lock == false))
        {
            horizVelocity = 2;
            //start a coroutine and wait for a half a second and let horizVelocity = 0;
            StartCoroutine(stopMove());
            laneNum += 1;
            Lock = true;

        }
    }

    //Pre made Routine.
    void OnCollisionEnter(Collision x)
    {
        if(x.gameObject.tag == "Kills")
        {
            Destroy(gameObject);
        }
        if(x.gameObject.tag == "Powerups")
        {
            Destroy(x.gameObject);

        }
    }

    IEnumerator stopMove()
    {
        //yield is wait
        yield return new WaitForSeconds(.5f);
        horizVelocity = 0;
        Lock = false;
    }
}
