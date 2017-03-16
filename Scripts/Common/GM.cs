using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GM : Singleton<GM> {

    public static void Init()
    {
        Debug.Log("GM,Init");
        TileModel.Init();
    }
    public static void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
