using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class Level_Select_Functionality : MonoBehaviour
{
    public GameObject canvas;
    public const int NumberOfLevels = 7;

    public void LevelOne() { SceneManager.LoadScene(3); }
    public void LevelTwo() { SceneManager.LoadScene(4); }
    public void LevelThree() { SceneManager.LoadScene(5); }
    public void LevelFour() { SceneManager.LoadScene(6); }
    public void LevelFive() { SceneManager.LoadScene(7); }
    public void LevelSix() { SceneManager.LoadScene(8); }
    public void LevelSeven() { SceneManager.LoadScene(9); }
    public void LevelEight() { SceneManager.LoadScene(10); }
    public void LevelNine() { SceneManager.LoadScene(11); }
    public void LevelTen() { SceneManager.LoadScene(12); }

    // Start is called before the first frame update
    void Start()
    {
        JsonHandlerScript json = GetComponent<JsonHandlerScript>();

        JsonHandlerScript.PlayerSave playerSave = json.playerSave;

        for (int i = 0; i < NumberOfLevels; i++)
        {
            bool temp = GetLevelData(i + 1, playerSave);
            canvas.transform.GetChild(i + 11).gameObject.SetActive(temp);
        }
    }

    bool GetLevelData(int level, JsonHandlerScript.PlayerSave saveData)
    {
        switch (level)
        {
            case 1:
                return saveData.Level1Finished;
            case 2:
                return saveData.Level2Finished;
            case 3:
                return saveData.Level3Finished;
            case 4:
                return saveData.Level4Finished;
            case 5:
                return saveData.Level5Finished;
            case 6:
                return saveData.Level6Finished;
            case 7:
                return saveData.Level7Finished;
        }
        return false;
    }

    void CompletionStarActivate(int level, bool temp)
    {
        switch (level)
        {
            case 0:
                
                break;
        }
    }
}
