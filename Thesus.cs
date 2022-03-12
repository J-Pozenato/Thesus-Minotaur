using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Thesus : MonoBehaviour
{
    public Vector2 pos;
    public Mover mover;
    public GameObject colup;
    public GameObject colleft;
    public GameObject coldown;
    public GameObject colright;
    public Minotaur minotaur;
    public bool move = true;
    public Text minoturn;
    public Text playerturn;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (move && Input.GetKeyDown(KeyCode.UpArrow)) // I used KeyDown to receive only one input
        {
            if (colup.CompareTag("inactive"))
            {
                pos = transform.position;
                mover.target.y += 1;
                StartCoroutine(waitMovement());
            }



        }
        if (move && Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (coldown.CompareTag("inactive"))
            {
                pos = transform.position;

                mover.target.y -= 1;
                StartCoroutine(waitMovement());
            }



        }
        if (move && Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (colright.CompareTag("inactive"))
            {
                pos = transform.position;
                mover.target.x += 1;
                StartCoroutine(waitMovement());
            }



        }
        if (move && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (colleft.CompareTag("inactive"))
            {
                pos = transform.position;
                mover.target.x -= 1;
                StartCoroutine(waitMovement());
            }
        }
        if (move && Input.GetKeyDown(KeyCode.W))     // Pressing W makes the player wait a turn
        {
            StartCoroutine(waitMovement());
        }
    }



    IEnumerator waitMovement()
    {
        move = false;                          //cancel movement until your turn starts again
        yield return new WaitForSeconds(1);    // wait for the movement to end
        playerturn.enabled = false;            // disable "Player's turn" text message
        minoturn.enabled = true;               // enable "Minotaur's turn" text message 
        minotaur.LastPos();
        minotaur.turn = true;                  // starts the Turn of the minotaur
        minotaur.movesN = 0;                   // the minotaur cam move two square so prepare the moves
        yield return new WaitForSeconds(2);    // wait for the minotaur movement to end 
        minoturn.enabled = false;              // disable "Minotaur's turn" text message
        move = true;                           // Returns to the player's turn
        playerturn.enabled = true;             // enable "Player's turn" text message
    }

    public void Undo()
    {
        transform.position = pos;
        mover.target = pos;
    }
}
