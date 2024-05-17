using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            PlayerPrefs.SetString("OncekiSahne", SceneManager.GetActiveScene().name);
            PlayerPrefs.Save();

            SceneManager.LoadScene("DeadMenu");
        }
    }
   
}
