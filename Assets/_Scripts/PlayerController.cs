using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    // PUBLIC INSTANCE VARIABLES ++++++++++++++++++++++++++++++++++++++++++++++++++
    public Vector2 move = new Vector2(0.0f, 0.0f);
    public Boundary boundary;

    // PRIVATE INSTANCE VARIABLES ++++++++++++++++++++++++++++++++++++++++++++++++++
    private Vector2 _newPosition = new Vector2(0.0f, 0.0f);

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this._CheckInput();     // this is how to do it
    }

    // Check input method, private
    private void _CheckInput()
    {
        _newPosition = gameObject.GetComponent<Transform>().position;

        if ((this._newPosition.x + 33f ) <= this.boundary.xMin)          // half the size of the sprite ( 65 / 2) since position.x is from center of sprite
        {
            Debug.Log("left boundary passed");

            this._newPosition.x = this.boundary.xMin + 33f;
        }

        if ((this._newPosition.x + 33f) >= this.boundary.xMax)
        {
            Debug.Log("right boundary passed");
            this._newPosition.x = this.boundary.xMax + 33f;
        }

        Debug.Log(this._newPosition);
        

        // Check for right arrow press
        if ((Input.GetAxis("Horizontal")) > 0)
        {
            _newPosition.x += move.x;
            gameObject.GetComponent<Transform>().position = _newPosition;
        }

        // check for left arrow press
        if (Input.GetAxis("Horizontal") < 0)
        {
            _newPosition.x -= move.x;
            gameObject.GetComponent<Transform>().position = _newPosition;
            Debug.Log("move left");
        }
    }
}
