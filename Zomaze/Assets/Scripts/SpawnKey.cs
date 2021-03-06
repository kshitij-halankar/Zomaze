using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnKey : MonoBehaviour
{
    public GameObject keyPrefab;
    public GameObject spawnedKey;
    public Vector3 center;
    public Vector3 size;
    private Vector3[] levelSize = new Vector3[5];
    private Vector3[] levelCenter = new Vector3[5];
    public float spawnCollisionRadiusCheck;
    public CalculateScore calculateScore;

    // Start is called before the first frame update
    void Start()
    {
        levelSize[0] =  new Vector3(22f, 0f, 21.5f);
        levelCenter[0] =  new Vector3(22f, 1f, 20.5f);
        levelSize[1] =  new Vector3(18f, 0f, 18f);
        levelCenter[1] =  new Vector3(10f, 1f, -17.5f);
        levelSize[2] =  new Vector3(29.5f, 0f, 29.5f);
        levelCenter[2] =  new Vector3(20f, 1f, 17.5f);
        levelSize[3] =  new Vector3(47f, 0f, 47f);
        levelCenter[3] =  new Vector3(26.4f, 1f, 28.6f);
        levelSize[4] =  new Vector3(39f, 0f, 39f);
        levelCenter[4] =  new Vector3(26.5f, 1f, 24f);

        // Create a temporary reference to the current scene.
         Scene currentScene = SceneManager.GetActiveScene();
 
         // Retrieve the name of this scene.
         string sceneName = currentScene.name;

        if(sceneName == "Level1"){
            size = levelSize[0];
            center = levelCenter[0];
        }
        else if(sceneName == "Level2"){
            size = levelSize[1];
            center = levelCenter[1];
        }
        else if(sceneName == "Level3"){
            size = levelSize[2];
            center = levelCenter[2];
        }
        else if(sceneName == "MazeLevel4"){
            size = levelSize[3];
            center = levelCenter[3];
        }
        else if(sceneName == "Level5"){
            size = levelSize[4];
            center = levelCenter[4];
        }
       

        SpawnKeyObject();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnKeyObject()
    {
       
        spawnCollisionRadiusCheck = 0.5f;
        var breakCondition = 0;
        Vector3 pos = new Vector3();
        while (breakCondition < 1000){
            pos = center + new Vector3(Random.Range(-size.x/2, size.x/2), 1, Random.Range(-size.z/2, size.z/2));
            breakCondition = breakCondition+1;
            Quaternion q = new Quaternion(90, 180, 180, 0);
            if (!Physics.CheckSphere(pos, spawnCollisionRadiusCheck))
            {
                
                spawnedKey = Instantiate(keyPrefab, pos, q);
                transform.position = pos;
                break;
            }
        }
        if(breakCondition == 1000){
            spawnedKey = Instantiate(keyPrefab, pos, Quaternion.identity);
            transform.position = pos;
        }

    }

    private void OnTriggerEnter(Collider collidingObject){
        if(collidingObject.gameObject.name == "Player"){
            calculateScore.keyCollected();
            Destroy(spawnedKey);
            Destroy(this.gameObject);
        }
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(center, size);
    }
}
