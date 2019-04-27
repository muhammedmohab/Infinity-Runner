using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //keycode let us asside a key when pressed move the object
    public KeyCode moveL;
    public KeyCode moveR;

    public int speedUp = 2;
    public float vertVelocity = 0;
    public float horizVelocity = 0;
    public int laneNum = 2;
    public int coins = 0;
    private bool Lock = false; // flase==0 true==1
    private bool isDead = false; //bool to detect if object is dead or not.
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == true) //if the player is dead then don't do anything.
            return;
        
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
            //Destroy(gameObject);
            death();
        }
        //if (x.gameObject.tag == "Coins")
        //{
        //    Destroy(x.gameObject);
        //    coins++;
        //    GetComponent<Score>().addScore(5);
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        coins++;
        GetComponent<Score>().addScore(5);
    }
    IEnumerator stopMove()
    {
        //yield is wait
        yield return new WaitForSeconds(.5f);
        horizVelocity = 0;
        Lock = false;
    }

    //function that speeds up the game with each level passed in score
    public void setSpeed(int x)
    {
        speedUp ++;
    }

    //function that stops everything when player die
    void death()
    {
        isDead = true;
        GetComponent<Score>().onDeath();
    }
}
