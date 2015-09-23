using UnityEngine;
using System.Collections;
// creates a number of clouds, 


public class GameController : MonoBehaviour {
    //PUBLIC INSTANCE VARIABLES
    public GameObject cloud;        // call super object
    public int cloudCount;

	// Use this for initialization
	void Start ()
	{
	    this._CloudStart();     // put in Start() since no updates required

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Cloud
    private void _CloudStart()
    {
        for (int count = 0; count < this.cloudCount; count++)
        {
            Instantiate(cloud);     // add a cloude to the scene up to cloudCount
        }
    }
}
