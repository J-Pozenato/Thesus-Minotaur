using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public int level;
    public int nextLevel;
    public int previousLevel;
    Scene scene;
    public Minotaur mino;
    public Thesus thes;

    public void Start()
    {
        scene = SceneManager.GetActiveScene();      //Gets information for the current scene
        level = scene.buildIndex;                   //Gets the current scene index
        previousLevel = level - 1;
        nextLevel = level + 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R)) // R restart Level
        {
            string nextScene = "Level" + level;
            sceneLoader(nextScene);
        }
        if (Input.GetKey(KeyCode.P)) // P previous Level
        {
            if (previousLevel > 0)
            {
                string nextScene = "Level" + previousLevel;
                sceneLoader(nextScene);
            }

        }
        if (Input.GetKey(KeyCode.N)) // N Next Level
        {
            if (nextLevel < SceneManager.sceneCountInBuildSettings)  //you can't go to next level if there is no next level
            {
                string nextScene = "Level" + nextLevel;
                sceneLoader(nextScene);
            }
            else
            {
                sceneLoader("MainMenu");
            }
        }
        if (Input.GetKey(KeyCode.M)) // M MainMenu Level
        {
            //string nextScene = "MainMenu";
            sceneLoader("MainMenu");
        }
        if (Input.GetKey(KeyCode.U)) // U undo last Move
        {
            thes.Undo();
            mino.Undo();

        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // When the player hits the exit sign goes to nextLevel
    {
        if (collision.gameObject.tag == "Thesus")
        {
            string nextScene = "Level" + nextLevel;
            sceneLoader(nextScene);

        }
    }

    void sceneLoader(string scene)          //function called to load the next scene
    {
        SceneManager.LoadScene(scene);
    }
}
