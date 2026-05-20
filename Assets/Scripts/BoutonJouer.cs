using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScene : MonoBehaviour
{
    //----------- Noms de scenes -----
    public string sceneIntro = "Intro";
    public string sceneNiveau1 = "Niveau 1";
    public string sceneNiveau2 = "Niveau 2";
    public string sceneNiveau3 = "Niveau 3";

    //------- Bouton jouer --------
    public void DemarrerJeu()
    {
        SceneManager.LoadScene(sceneNiveau1);
    }

    //---------- Retour intro --------
    public void RetourIntro()
    {
        SceneManager.LoadScene(sceneIntro);
    }

    //----------- Aller niveau 2---------
    public void AllerNiveau2()
    {
        SceneManager.LoadScene(sceneNiveau2);
    }
    //----------- Aller niveau 2---------
    public void AllerNiveau3()
    {
        SceneManager.LoadScene(sceneNiveau3);
    }

    // recharge la scene actuel
    public void RedemarrerScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
