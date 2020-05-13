using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscript : MonoBehaviour
{

    public float ballForce;
    public scenemanager scene;
  
    void Start()
    {
        ballSpawn();
        scene = FindObjectOfType<scenemanager>();
    }

    public void ballSpawn()
    {
        float spawnprobablity;
        spawnprobablity = Random.Range(-2, 2);
        Debug.Log("probability of spawn : " + spawnprobablity);
        ballMovement(spawnprobablity);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            float ball_velocity = GetComponent<Rigidbody2D>().velocity.y;
            ball_velocity += other.rigidbody.velocity.y * 0.5f;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, ball_velocity);

        }

        if(other.gameObject.tag == "Goal A")
        {
            scene.AddScoreB();
            StartCoroutine(Reset());
        }
        else
            if(other.gameObject.tag == "Goal B")
            {
                scene.AddScoreA();
                StartCoroutine(Reset());
            }
    }

    IEnumerator Reset()
    {
        WaitForSeconds time = new WaitForSeconds(1);

        resetPosition();
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return time;
        ballSpawn();
    }

    void resetPosition()
    {
        transform.position = new Vector3(0, 0, -7.78f);
    }

    public void ballMovement(float range)
    {
        if (range < 0)
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * ballForce);
        else
            if (range > 0)
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * ballForce);

       if (range == 0)
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * ballForce);

    }
}
