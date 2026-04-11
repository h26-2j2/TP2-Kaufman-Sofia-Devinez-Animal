using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScene : MonoBehaviour
{
    public string sceneIntro = "Intro";
    public string sceneNiveau1 = "Niveau 1";
    //public string sceneNiveau2 = "Niveau 2";
    //public string sceneNiveau3 = "Niveau 3";

    public void DemarrerJeu()
    {
        SceneManager.LoadScene(sceneNiveau1);
    }
    public void RetourIntro()
    {
        SceneManager.LoadScene(sceneIntro);
    }
}
