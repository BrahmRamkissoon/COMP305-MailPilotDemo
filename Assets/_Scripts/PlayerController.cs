using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    // PUBLIC INSTANCE VARIABLES ++++++++++++++++++++++++++++++++++++++++++++++++++
    public Vector2 move = new Vector2(0.0f, 0.0f);
    public Boundary boundary;

    public Text MouseLabel;

    // PRIVATE INSTANCE VARIABLES ++++++++++++++++++++++++++++++++++++++++++++++++++
    private Vector2 _newPosition = new Vector2(0.0f, 0.0f);

    // Use this for initialization
    void Start()
    {
        //Input.GetAxis("Horizontal");
  
    }

    // Update is called once per frame
    void Update()
    {
        this._CheckInput();     // this is how to do it
    }

    // Check input method, private
    private void _CheckInput()
    {
        this._newPosition = gameObject.GetComponent<Transform>().position;  // current position

        /*        // Check for right arrow press
                if ((Input.GetAxis("Horizontal")) > 0)
                {
                    this._newPosition.x += this.move.x;   // add move value to current position
                   // gameObject.GetComponent<Transform>().position = _newPosition;
                }

                // check for left arrow press
                if (Input.GetAxis("Horizontal") < 0)
                {
                    this._newPosition.x -= this.move.x;   // subtract move value to current position
                   // gameObject.GetComponent<Transform>().position = _newPosition;
                }
         */

        // use mouse input

        this.MouseLabel.text = "X: " + Input.mousePosition.x + "\nY: " + Input.mousePosition.y;
        this._newPosition.x = Input.mousePosition.x - 300.0f;

        
        // boundary check
        if ((this._newPosition.x) <= this.boundary.xMin)          // half the size of the sprite ( 65 / 2) since position.x is from center of sprite
        {
            this._newPosition.x = this.boundary.xMin;
        }

        if ((this._newPosition.x) >= this.boundary.xMax)
        {
            this._newPosition.x = this.boundary.xMax;
        }

        gameObject.GetComponent<Transform>().position = this._newPosition;



    }
}
