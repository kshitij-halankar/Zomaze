using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ZombieUserInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CollisionWithZombie("Ghoul1");
        CollisionWithZombie("Ghoul2");
        CollisionWithZombie("Ghoul3");
       
    }

    void CollisionWithZombie(string zombieName){
        Vector3 zombiePosition = GameObject.Find(zombieName).transform.position;
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
         if (Vector3.Angle(GameObject.Find(zombieName).transform.forward, playerPosition - zombiePosition) < 15){
            if(Math.Abs(playerPosition.x - zombiePosition.x) < 4 && Math.Abs(playerPosition.z - zombiePosition.z) < 4){
                Scene currentScene = SceneManager.GetActiveScene();
                //SceneManager.LoadScene(gameOverScene);
                GameOverScreen.Setup(10, currentScene.name);
            }
            }
        else{
            if(Math.Abs(playerPosition.z - zombiePosition.z) < 1 && Math.Abs(playerPosition.x - zombiePosition.x) < 1){
                Scene currentScene = SceneManager.GetActiveScene();
                //SceneManager.LoadScene(gameOverScene);
                GameOverScreen.Setup(10, currentScene.name);
            }
        }
    }
}
