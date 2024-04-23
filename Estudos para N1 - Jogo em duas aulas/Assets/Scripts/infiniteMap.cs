using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class infiniteMap : MonoBehaviour
{
    public GameObject pipeSection;
    public TMP_Text title;
    public TMP_Text pontuacao;
    public TMP_Text recorde;

    int pontos;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        CheckBestScoreText();
  }

    private void OnTriggerEnter(Collider other)
    {
        float pos = Random.Range(3.0f, 0.1f);

        if (other.gameObject.CompareTag("invisible_wall"))
        {
            Instantiate(pipeSection, new Vector3(2f, pos, -8f), Quaternion.identity);
            title.enabled = false;
        }


        if (other.gameObject.CompareTag("points"))
        {
            pontos++;
            pontuacao.SetText(pontos.ToString());
            CheckBestScore();
            CheckBestScoreText();
        }
    }


    void CheckBestScore()
    {
        if (pontos > PlayerPrefs.GetInt("Best", 0))
            PlayerPrefs.SetInt("Best", pontos);

        
    }

    void CheckBestScoreText()
    {
        recorde.text = $"{PlayerPrefs.GetInt("Best", 0)}";
    }



    private void Reset()
    {
        SceneManager.LoadScene("Flappy");
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("pipes"))
            Reset();
    }

}
