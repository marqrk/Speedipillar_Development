using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{

    public GameObject tutorial1;

    public GameObject tutorialButton1;
    public GameObject tutorialButton2;
    public GameObject tutorialButton3;

    public GameObject tutorial2;
    public GameObject tutorial3;


    // Start is called before the first frame update
    void Start()
    {
        tutorial1.SetActive(true);
        tutorialButton1.SetActive(true);

        tutorial2.SetActive(false);
        tutorial3.SetActive(false);
        
        tutorialButton2.SetActive(false);
        tutorialButton3.SetActive(false);
    }

    public void Next()
    {
        if (tutorial1.activeInHierarchy)
        {
            tutorial1.SetActive(false);
            tutorialButton2.SetActive(true);
            tutorial2.SetActive(true);
        }
        else if (tutorial2.activeInHierarchy)
        {
            tutorial2.SetActive(false);
            tutorial3.SetActive(true);
            tutorialButton1.SetActive(false);
            tutorialButton3.SetActive(true);
        }
    }
    public void Prev()
    {
        if (tutorial2.activeInHierarchy)
        {
            tutorial2.SetActive(false);
            tutorial1.SetActive (true);
            tutorialButton2.SetActive(false);
        }
        else if (tutorial3.activeInHierarchy)
        {
            tutorial3.SetActive(false);
            tutorial2.SetActive (true);
            tutorialButton1.SetActive(true);
            tutorialButton3.SetActive(false);
        }
    }

    public void StartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
