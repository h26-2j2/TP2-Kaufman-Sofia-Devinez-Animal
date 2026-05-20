using UnityEngine;
using UnityEngine.SceneManagement;

   
public class AnimalClic : MonoBehaviour
{
        public bool estBonneReponse = false;
        public GameObject texteBravo;
        public GameObject texteErreur;


        private void OnMouseDown()
        {
            if (estBonneReponse)
            {
                texteBravo.SetActive(true);

                Invoke("FinJeu", 2f);
            }
            else
            {
                texteErreur.SetActive(true);

                Invoke("CacherErreur", 1f);
            }
        }

        void CacherErreur()
        {
            texteErreur.SetActive(false);
        }

        void FinJeu()
        {
            SceneManager.LoadScene("Fin");
        }
    }


