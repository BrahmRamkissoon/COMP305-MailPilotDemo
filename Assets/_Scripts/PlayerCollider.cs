using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCollider : MonoBehaviour {
    // PUBLIC INSTANCE VARIABLES +++++++++++++++++++++++++
    public Text scoreLabel;
    public Text livesLabel;
    public Text gameOverLabel;
    public Text finalScoreLabel;
    //public int scoreValue = 0;
    //public int livesValue = 5;



    // PRIVATE INSTANCE VARIABLES +++++++++++++++++++++++++
    private AudioSource[] _audioSources;    // array of audio sources
    private AudioSource _cloudAudioSource, _islandAudioSource;
  

    private int _score = 0;
    private int _lives = 5;
    private int _highscore = 0;

	// Use this for initialization
	void Start ()
	{
	    this._ScoreUpdate();
        // note that the order is based on what is shown from top to bottom in GUI
        this._audioSources = this.GetComponents<AudioSource>(); // get the array of audio sources
        this._cloudAudioSource = this._audioSources[1];     // reference audio for cloud
	    this._islandAudioSource = this._audioSources[2];    // reference audio for island

        //this._highScore = GameObject.FindWithTag("HighScoreController").GetComponent("HighScoreScript");
        this.gameOverLabel.enabled = false;
        this.finalScoreLabel.enabled = false;
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    

    void OnTriggerEnter2D(Collider2D otherGameObject)
    {
        if (otherGameObject.tag == "Island")
        {
            this._islandAudioSource.Play();     // play yay sound
            this._score += 100;     // add 100 points
        }

        if (otherGameObject.tag == "Cloud")
        {
            this._cloudAudioSource.Play();     // play thunder sound
            this._lives--;       // remove one life

            if ( this._lives <= 0 )       // end game if life = 0
            {
                this._EndGame();    // 
            }
            
        }
        this._ScoreUpdate();
    }

    //  PRIVATE METHODS
    private void _ScoreUpdate ()
    {
        this.scoreLabel.text = "Score: " + this._score;
        this.livesLabel.text = "Lives: " + this._lives;
    }

    // Endgame method
    private void _EndGame ()
    {
        if ( this._lives <= 0 )       // end game if life = 0
        {
            Destroy(gameObject);
            this.scoreLabel.enabled = false;
            this.livesLabel.enabled = false;
            this.gameOverLabel.enabled = true;
            this.finalScoreLabel.enabled = true;
            this.finalScoreLabel.text = "Score: " + this._score;
        }
    }
}
