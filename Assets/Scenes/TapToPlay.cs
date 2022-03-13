using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapToPlay : MonoBehaviour
{
    void OnMouseDown()
    {
        //SceneManager.LoadScene("Scene2");
        SceneManager.LoadScene("Scene Test");
    }

}