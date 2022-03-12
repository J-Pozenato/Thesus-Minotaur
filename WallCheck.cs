using UnityEngine;

public class WallCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "inactive";        // I used the tags because its different 
    }


    public void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Wall")
        {
            gameObject.tag = "active";      // When the tag is set to active the move to this side is blocked
        }

    }

    private void OnTriggerExit2D(Collider2D target)
    {
        if (target.gameObject.tag == "Wall")
        {
            gameObject.tag = "inactive";
        }
    }


}
