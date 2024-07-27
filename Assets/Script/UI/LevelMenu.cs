using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void OpenLevel(int LevelID)
    {
        string levelName = "level " + LevelID;
        SceneManager.LoadScene(levelName);
    }
}
