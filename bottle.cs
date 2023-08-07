using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottle : MonoBehaviour
{
    public static float fallingSpeed = 10;
    public AudioSource bottleSound;

    void Start()
    {
        transform.position = new Vector2(Random.Range(-7.59f, 7.59f), Random.Range(5.90f, 20f));
    }

    void Update()
    {
        transform.Translate(0f, -fallingSpeed * Time.deltaTime, 0f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            transform.position = new Vector2(Random.Range(-7.59f, 7.59f), Random.Range(5.90f, 9f));
        }
        else if (collision.gameObject.tag == "case")
        {
            caseMovement.increase = "+1";
            caseMovement.score++;
            bottleSound.Play();
            transform.position = new Vector2(Random.Range(-7.59f, 7.59f), Random.Range(5.90f, 9f));
        }
    }
}
