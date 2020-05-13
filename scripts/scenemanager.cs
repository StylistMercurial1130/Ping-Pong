using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scenemanager : MonoBehaviour
{

    public ballscript ball;
    public Text scoreBoard;

    [SerializeField]
    private float scoreA = 0, scoreB = 0;
    

    void Start()
    {
        Instantiate(ball, new Vector3(0, 0, -7.78f), Quaternion.identity);
    }
    
    void Update()
    {
        scoreBoard.text = scoreA.ToString() + "-" + scoreB.ToString();
    }
    public void AddScoreA() 
    {
        scoreA++; 
    }

    public void AddScoreB() 
    {
        scoreB++;
    }
}
