using UnityEngine;
using UnityEngine.SceneManagement;
public class Menus : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created



    public void LoadGame()
    {
        Debug.Log("Loading Game");
        SceneManager.LoadScene("Main");
    }
    





    public void Quitgame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }





    // Update is called once per frame
   
}
