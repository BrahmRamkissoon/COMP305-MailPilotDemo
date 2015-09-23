/* Author: Tom Tsiliopoulos */
/* File: CloudController.cs */
/* Creation Date: Sept 22, 2015 */
/* Description: THis script controls the cloud gameObject's movement  */
/* ... */

using UnityEngine;
using System.Collections;

// create new class to handle boundary of scene
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;

}

[System.Serializable]
public class Speed
{
    public float xMin, xMax, yMin, yMax;

}

public class CloudController : MonoBehaviour
{
    //  PUBLIC INSTANCE VARIABLES
    public Speed speed;
    public Boundary boundary;

    // PRIVATE INSTANCE VARIABLES
    private float _currentSpeed;
    private float _currentDrift;

    // Use this for initialization
    void Start()
    {
        // initialize transform of object
        this._Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = new Vector2(0.0f, 0.0f);      //create new object and assign
        currentPosition = gameObject.GetComponent<Transform>().position;    // copy object's position into variable
        
        currentPosition.y -= this._currentSpeed;     // scroll object down the screen
        currentPosition.x += this._currentDrift;    // move objects left or right randomly
        gameObject.GetComponent<Transform>().position = currentPosition;    // move the gameObject to currentPosition

        // bottom boundary check - gameObject meets top of camera viewport
        if (currentPosition.y <= boundary.yMin)
        {
            this._Reset();
        }

    }

    private void _Reset()
    {
        this._currentSpeed = Random.Range(speed.yMin, speed.yMax);
        this._currentDrift = Random.Range(speed.xMin, speed.xMax);
        Vector2 resetPosition = new Vector2(Random.Range(boundary.xMin, boundary.xMax), boundary.yMax);   // Add random x position
        gameObject.GetComponent<Transform>().position = resetPosition;

    }
}
