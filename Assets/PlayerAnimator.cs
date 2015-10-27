using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour {
    //  PUBLIC INSTANCE VARIABLES
    public Sprite[] sprites;
    public float framesPerSecond;

    // PRIVATE INSTANCE VARIABLES
    private SpriteRenderer _spriteRenderer;

	// Use this for initialization
	void Start ()
	{
	    this._spriteRenderer = gameObject.GetComponent<SpriteRenderer>() as SpriteRenderer; // .. as makes it more compatible? safe

	}
	
	// Update is called once per frame
	void Update () {
	    int index = (int) ( Time.timeSinceLevelLoad * this.framesPerSecond );   // recasted every frame
	    index %= ( this.sprites.Length - 1 );                // switch frames per tick count
	    this._spriteRenderer.sprite = this.sprites[index];  // flip the sprites

	}
}
