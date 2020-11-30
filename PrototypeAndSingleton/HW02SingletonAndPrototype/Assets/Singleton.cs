using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    Camera myCamera;
    RaycastHit rayHit;
    int score =0;
    Ray r;
    public TextMesh scoreText;

   public GameObject gameCon;
    private void Awake()
    {
        GameObject[] GameConainters = GameObject.FindGameObjectsWithTag("GameCon");
        Debug.Log("check if there is already game container in scene");
        if (GameConainters.Length > 1)
        {
            Destroy(GameConainters[1]);
            Debug.Log("Destroy the new Game container");
        }
        else
        {
            Debug.Log("Dont destroy the existing Game container");
            DontDestroyOnLoad(gameCon);

        }
        
    }
    private void Start()
    {

        SceneHandler.instance.Init();

        Init();

    }
    private void Init()
    {
        Debug.Log("Init: ScoreText, Action to TargetCubes , assign camera and Start Deploying Cubes");
          myCamera = Camera.main;

        scoreText.text = "Score: 0";
        Spawner.instance.addScore = AddToScore;
        Spawner.instance.StartThrowTarget();
    }

    private void Update()
    {
        Player.Instance.InstansiateBullet();
    }

    private void FixedUpdate()
    {
        r = myCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(r ,out rayHit , 50f))
            {
            
                Player.Instance.RotateTheCannon(rayHit.point);
            }
      }


    private void AddToScore() {
        score++;
        scoreText.text = "Score: " + score ;
        if (score == 10) 
        {
            Debug.Log("score reached to 10 loading next scene");
            score = 0;
            SceneHandler.instance.LoadNextScene();
            Init();
        }
    
    }
}
