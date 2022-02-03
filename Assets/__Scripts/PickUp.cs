using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    //declaring variables
    Text t;
    
    // Start is called before the first frame update
    void Start()
    {
        //Finds the UI text object with the tag "Text"
        GameObject textScore = GameObject.FindWithTag("Text");
        //gets the text component of the text object
        t = textScore.GetComponent<Text>();
        //displays the text as 0 when the game starts
        t.text = "Score: " + Begin.SCORE; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //method that destorys the game object the ball collides with and adds the corresponding points to the total points
    void OnTriggerEnter(Collider c){
        //destroys the game object that the ball collided with
        Destroy(gameObject);
        //increases the score by 10 if the object is a cube
        if(gameObject.tag == "Cube"){
            Begin.SCORE += 10;
        }
        //increases the score by 20 if the object is a cylinder
        else if(gameObject.tag == "Cylinder"){
            Begin.SCORE += 20;
        }
        //increases the score by 30 if the object is a capsule
        else{
            Begin.SCORE += 30;
        }
        
        //updates the total score in the corner
        t.text = "Score: " + Begin.SCORE;
        //decreases the game object count
        Begin.NUM_PICK--;
    }
}
