using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] string scene_name;
    public void Change_Scene()
    {
        SceneManager.LoadScene(sceneName: scene_name);
    }
}
