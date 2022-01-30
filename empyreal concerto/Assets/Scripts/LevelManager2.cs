using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager2 : MonoBehaviour
{
    public int index;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //Loading level with building index
            SceneManager.LoadScene(index);
        }

    }
   
}
