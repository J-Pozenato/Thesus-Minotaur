using System.Collections;
using UnityEngine;

public class Minotaur : MonoBehaviour
{
    public bool turn = false;
    public int movesN = 0;
    public Vector2 pos;

    public Mover mover;
    public GameObject colup;
    public GameObject colleft;
    public GameObject coldown;
    public GameObject colright;
    public GameObject Theseus;



    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (movesN < 2)
        {
            if (turn)
            {
                StartCoroutine(Turn());
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Thesus")
        {
            Destroy(collision.gameObject);


        }
    }

    IEnumerator Turn()
    {
        if (colleft.CompareTag("inactive") && Theseus.transform.position.x < transform.position.x)
        {
            mover.target.x -= 1;
            movesN++;

        }
        else if (colright.CompareTag("inactive") && Theseus.transform.position.x > transform.position.x)
        {
            mover.target.x += 1;
            movesN++;
        }
        else if (colup.CompareTag("inactive") && Theseus.transform.position.y > transform.position.y)
        {
            mover.target.y += 1;
            movesN++;
        }
        else if (coldown.CompareTag("inactive") && Theseus.transform.position.y < transform.position.y)
        {
            mover.target.y -= 1;
            movesN++;
        }
        else
        {
            movesN++;
        }
        turn = false;
        yield return new WaitForSeconds(1);
        turn = true;
    }

    public void LastPos()
    {
        pos = transform.position;
    }

    public void Undo()
    {
        transform.position = pos;
        mover.target = pos;
    }


}
