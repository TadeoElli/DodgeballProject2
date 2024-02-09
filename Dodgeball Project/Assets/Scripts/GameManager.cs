using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string scene, otherScene;
    public GameObject player, capsule;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(scene);
        }
        else if(Input.GetKeyDown(KeyCode.T)){
            SceneManager.LoadScene(otherScene);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1)){
            player.layer = 6;
            capsule.layer = 6;
            Debug.Log("si");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2)){
            player.layer = 7;
            capsule.layer = 7; 
        }
    }
}
