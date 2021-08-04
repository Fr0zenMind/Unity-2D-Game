using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    string easy = "easy";
    string mediu = "mediu";
    string hard = "hard";

    public void easyDifficulty()
    {
        File.WriteAllText(Application.dataPath + "/difficulty.txt", easy);
    }
    public void mediuDifficulty()
    {
        File.WriteAllText(Application.dataPath + "/difficulty.txt", mediu);
    }
    public void hardDifficulty()
    {
        File.WriteAllText(Application.dataPath + "/difficulty.txt", hard);
    }
}
