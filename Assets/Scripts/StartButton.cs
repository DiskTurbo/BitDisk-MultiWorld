using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using JSAM;

public class StartButton : MonoBehaviour
{
    [SerializeField] Image logo;
    [SerializeField] Text copyright;
    [SerializeField] Text pressstart;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            logo.CrossFadeAlpha(0f, 0.5f, false);
            copyright.CrossFadeAlpha(0f, 0.5f, false);
            pressstart.CrossFadeAlpha(0f, 0.5f, false);
            this.GetComponent<Button>().interactable = false;
            JSAM.AudioManager.PlaySound(Sounds.StartButton);
            Invoke("LoadScene", 5f);
        }
    }

    public void OnStartButton_Pressed()
    {
        logo.CrossFadeAlpha(0f, 0.5f, false);
        copyright.CrossFadeAlpha(0f, 0.5f, false);
        pressstart.CrossFadeAlpha(0f, 0.5f, false);
        this.GetComponent<Button>().interactable = false;
        JSAM.AudioManager.PlaySound(Sounds.StartButton);
        Invoke("LoadScene", 5f);
    }

    void LoadScene()
    {
        SceneManager.LoadScene("Main");
    }
}
