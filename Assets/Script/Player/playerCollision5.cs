using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using collision.GameObject;

public class playerCollision5 : MonoBehaviour
{
    public GameObject congratsScreen;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                PlayerManager.isGameOver = true;
                AudioManager.instance.Play("GameOver");
                //AudioManager.instance.Stop("musicSource");
                gameObject.SetActive(false);
            }
        }
        if (collision.transform.tag == "LvL")
        {
            Time.timeScale = 0;
            congratsScreen.SetActive(true);
        }
    }
}

