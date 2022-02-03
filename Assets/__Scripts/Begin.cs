using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Begin : MonoBehaviour
{
    //declaring static variables
    public static int SCORE;
    public static int NUM_PICK;
   
    
    // Start is called before the first frame update
    void Start()
    {
        //assigning initial values to static variables
        SCORE = 0;
        NUM_PICK = 8;

        //declaring variables
        int shape;
        GameObject pick;

        //Loop to create different game objects 
        for(int i = 1; i <= 8; i++){
            //picks a number to randomly choose the type of object being created
            shape = Random.Range(0,3);
            //creates a cube and assigns the tag "Cube" to it
            if(shape == 0){
                pick = GameObject.CreatePrimitive(PrimitiveType.Cube);
                pick.tag = "Cube";
            }
            //creates a capsule and assigns the tag "Capsule" to it
            else if(shape == 1){
                pick = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                pick.tag = "Capsule";
            }
            //creates a cylinder and assigns the tag "Cylinder" to it
            else{
                pick = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                pick.tag = "Cylinder";
            }
            //Adds a flamingo picture on created game objects
            pick.GetComponentInChildren<Renderer>().material = Resources.Load<Material>("pink");
            //Adds the script that destroys the objects when the ball collides with it
            pick.AddComponent<PickUp>();
            //Adds a Collider component to the created objects and turns on the Trigger button
            Collider col = pick.GetComponent<Collider>();
            col.isTrigger = true;
            //creates a different name for each game object to make it easier to distinguish between them
            pick.name = "pick" + i;
            //randomly positioning the objects on the game board
            pick.transform.position = new Vector3(Random.Range(-6.0f,6.0f),1.5f,Random.Range(-6.0f,6.0f));
            //Randomly changing the rotation of the objects
            pick.transform.rotation = new Quaternion(Random.Range(0.0f,45.0f),Random.Range(0.0f,-45.0f),0.0f,1.0f);
            //changing the default size of the created game objects to make them bigger
            pick.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //resets the game when the number of pick up objects left in the box is 0 using the Invoke function after a few second delay
        if(NUM_PICK == 0){
             Invoke("Reset",2f);
        }
        
    }

    //method to reset the game
    private void Reset(){
        //resets the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
