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
    private string PlayerSettingsFP = "/Playersettings.json";

    public PlayerSave playerSave = new PlayerSave();
    private string PlayerSaveFP = "/PlayerSave.json";

    // Start is called before the first frame update
    void Start()
    {
        if(!File.Exists(Application.dataPath + PlayerSettingsFP)){
            string str = JsonUtility.ToJson(playerSettings);
            File.WriteAllText(Application.dataPath + PlayerSettingsFP, str);
        }
        else
        {
            string str = File.ReadAllText(Application.dataPath + PlayerSettingsFP);
            playerSettings = JsonUtility.FromJson<PlayerSettings>(str);
        }
        if(!File.Exists(Application.dataPath + PlayerSaveFP))
        {
            string str = JsonUtility.ToJson(playerSave);
            File.WriteAllText(Application.dataPath + PlayerSaveFP, str);
        }
        else
        {
            string str = File.ReadAllText(Application.dataPath + PlayerSaveFP);
            playerSave = JsonUtility.FromJson<PlayerSave>(str);
        }
    }

    public void UpdateControlStickSettings(bool active)
    {
        playerSettings.StickControls = active;
        string str = JsonUtility.ToJson(playerSettings);
        File.WriteAllText(Application.dataPath + "/PlayerSettings.json", str);
    }
}
