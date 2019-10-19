using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class YouWin : MonoBehaviour
{
    public PlayerMovement playerMovement;       // Reference to the player's health.
    public float restartDelay = 5f;         // Time to wait before restarting the level
	public Text text;
	public EnemyHealth enemyHealth;


    Animator anim;                          // Reference to the animator component.
    float restartTimer;                     // Timer to count up to restarting the level


    void Awake ()
    {
        // Set up the reference.
        anim = GetComponent <Animator> ();
    }


    void Update ()
    {
        // If the player has run out of health...
        if(playerMovement.win == true)
        {
			enemyHealth.currentHealth = 0;
            // ... tell the animator the game is over.
            anim.SetTrigger ("GameWin");
			text.text = "You Win!";
			
            // .. increment a timer to count up to restarting.
            restartTimer += Time.deltaTime;

            // .. if it reaches the restart delay...
            if(restartTimer >= restartDelay)
            {
                // .. then reload the currently loaded level.
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}