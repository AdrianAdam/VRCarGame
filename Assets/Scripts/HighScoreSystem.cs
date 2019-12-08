using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreSystem : MonoBehaviour
{
    public Text highScore;

    private string[] scenes = {"Level1", "Level2", "Level3", "Level4", "Level5", "Level6", "Level7", "Level8", "Level9", "Level10" };

    // Start is called before the first frame update
    void Start()
    {
        int score = 0;
        for(int i = 0; i < scenes.Length; i++)
        {
            score += PlayerPrefs.GetInt(scenes[i], 0);
        }

        highScore.text = string.Concat("High score: ", score);
    }
}
