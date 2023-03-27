using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTran : MonoBehaviour
{
    public string sceneToTran;
    
    public void SceneTransition()
    {
        SceneManager.LoadScene(sceneToTran);
    }
}
