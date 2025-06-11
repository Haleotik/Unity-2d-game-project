using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager_scr : MonoBehaviour
{
    public void _CoolScene()
    { SceneManager.LoadScene(2); }

    public void _FinishScene()
    { SceneManager.LoadScene(1); }

    public void _RestartScene()
    { SceneManager.LoadScene(0); }
}
