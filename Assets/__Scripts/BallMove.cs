using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    //delcaring variables
    public Rigidbody phy;

    // Start is called before the first frame update
    void Start()
    {
        //assigning Rigidbody variables
        phy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //moves the ball right if the right arrow key is pressed
        if(Input.GetKey(KeyCode.RightArrow)){
            phy.velocity = new Vector3(10,0,0);
        }
        //moves the ball left if the left arrow key is pressed
        else if(Input.GetKey(KeyCode.LeftArrow)){
            phy.velocity = new Vector3(-10,0,0);
        }
        //moves the ball backwards if the up arrow key is pressed
        else if(Input.GetKey(KeyCode.UpArrow)){
            phy.velocity = new Vector3(0,0,10);
        }
        //moves the ball forwards if the down arrow key is pressed
        else if(Input.GetKey(KeyCode.DownArrow)){
            phy.velocity = new Vector3(0,0,-10);
        }
    }
}
