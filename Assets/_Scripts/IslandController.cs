/* Author: Tom Tsiliopoulos */
/* File: IslandController.cs */
/* Creation Date: Sept 21, 2015 */
/* Description:   */
/* ... */


using UnityEngine;
using System.Collections;

public class IslandController : MonoBehaviour
{
    //  PUBLIC INSTANCE VARIABLES
    public float speed;

    // Use this for initialization
    void Start()
    {
        // initialize transform of ocean background
        this._Reset();


    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = new Vector2(0.0f, 0.0f);      //create new object and assign
        currentPosition = gameObject.GetComponent<Transform>().position;    // copy object's position into variable
        // ocean drops down @ 5 pixels / frame, @ 60fps it will move 300 pixels in 1 frame

        currentPosition.y -= speed;     // scroll ocean down
        gameObject.GetComponent<Transform>().position = currentPosition;    // move the gameObject to currentPosition
        // bottom boundary check - gameObject meets top of camera viewport
        if (currentPosition.y <= -270)
        {
            this._Reset();
        }

    }

    private void _Reset()
    {
        Vector2 resetPosition = new Vector2(Random.Range(-290f, 290f), 270f);   // Add random x position
        gameObject.GetComponent<Transform>().position = resetPosition;
        
    }
}
