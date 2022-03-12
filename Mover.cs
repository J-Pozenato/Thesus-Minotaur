using UnityEngine;

public class Mover : MonoBehaviour
{

    float speed = 1f;
    public Vector2 target;

    private Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;       //grabs the object position
        target = pos;                   // initaly the target doens't exist so set it to pos

    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, target, step);
        //Move the object towards a target in a set time
    }
}
