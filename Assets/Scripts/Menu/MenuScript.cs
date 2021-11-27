using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public AudioClip clickMenu;
    // Update is called once per frame
    void Update()
    {
        // Teclando ESC saira do Jogo, mas somente no executavel e nao dentro do editor
        if (Input.GetKeyDown(KeyCode.Escape))
        {        
            Application.Quit();
        }
    }

    public void ClicarJogar()
    {
        AudioSource.PlayClipAtPoint(clickMenu, transform.position);
        SceneManager.LoadScene("Gameplay");
    }

    public void ClicarIntroducao()
    {
        AudioSource.PlayClipAtPoint(clickMenu, transform.position);
        SceneManager.LoadScene("Introduction");
    }

    public void ClicarCreditos()
    {
        AudioSource.PlayClipAtPoint(clickMenu, transform.position);
        SceneManager.LoadScene("Credits");
    }

    public void VoltarAoMenu()
    {
        AudioSource.PlayClipAtPoint(clickMenu, transform.position);
        SceneManager.LoadScene("MainMenu");
    }

    public void ClicarSair()
    {
        AudioSource.PlayClipAtPoint(clickMenu, transform.position);
        Application.Quit();
    }

}
