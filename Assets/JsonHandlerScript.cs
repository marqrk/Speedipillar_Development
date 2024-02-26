using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonHandlerScript : MonoBehaviour
{

    [System.Serializable]
    public struct PlayerSettings
    {
        public bool StickControls;
    }

    [System.Serializable]
    public struct PlayerSave
    {
        public bool Level1Finished;
        public bool Level2Finished;
        public bool Level3Finished;
        public bool Level4Finished;
        public bool Level5Finished;
        public bool Level6Finished;
        public bool Level7Finished;
    }

    public PlayerSettings playerSettings = new PlayerSettings();
    private string PlayerSettingsFP = "Playersettings.json";

    public PlayerSave playerSave = new PlayerSave();
    private string PlayerSaveFP = "PlayerSave.json";

    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + PlayerSettingsFP))
        { 
            var str = File.ReadAllText(Application.persistentDataPath + PlayerSettingsFP);
            playerSettings = JsonUtility.FromJson<PlayerSettings>(str);
        }
        if (File.Exists(Application.persistentDataPath + PlayerSaveFP))
        {
            var str = File.ReadAllText(Application.persistentDataPath + PlayerSaveFP);

            playerSave = JsonUtility.FromJson<PlayerSave>(str);
        }
    }

    public void UpdatePlayerSave(int level)
    {
        switch (level)
        {
            case 1:
                playerSave.Level1Finished = true;
                break;
            case 2:
                playerSave.Level2Finished = true;
                break;
            case 3:
                playerSave.Level3Finished = true;
                break;
            case 4:
                playerSave.Level4Finished = true;
                break;
            case 5:
                playerSave.Level5Finished = true;
                break;
            case 6: 
                playerSave.Level6Finished = true;
                break;
            case 7:
                playerSave.Level7Finished = true;
                break;
        }

        string str = JsonUtility.ToJson(playerSave);
        File.WriteAllText(Application.persistentDataPath + PlayerSaveFP, str);
    }
    public void UpdateControlStickSettings(bool active)
    {
        playerSettings.StickControls = active;
        string str = JsonUtility.ToJson(playerSettings);
        File.WriteAllText(Application.persistentDataPath + PlayerSettingsFP, str);
    }

}
