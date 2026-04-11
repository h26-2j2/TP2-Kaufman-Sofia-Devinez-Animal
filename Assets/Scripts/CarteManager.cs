using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class CarteManager : MonoBehaviour
{
    public GameObject premiereCarte;
    public GameObject deuxiemeCarte;


    //============= Victoire =======
    public GameObject UIVictoire; 

    bool jeuFini = false;

    float tempsFin = 0;
    float delaiFin = 2f; //avant l'action
  

    int pairesTrouvee = 0;
    int totalPaires = 3;
    //============== Delai ==================

    //attendre avant cahcer cartes
    bool attendre = false;

    // temps ou clique 2e cartea
    float tempsDebutAttemdre;
    float delai = 1f;

    private void Start()
    {
        UIVictoire.SetActive(false);
    }

    private void Update()
    {
        //============================ Delai cartes incorrectes =============
        if (attendre)
        {
            if (Time.time > tempsDebutAttemdre + delai)
            {
                if (premiereCarte  != null)
                    premiereCarte.GetComponent<CarteMemoire>().CacherCarte();

                if (deuxiemeCarte != null)
                    deuxiemeCarte.GetComponent<CarteMemoire>().CacherCarte();

                premiereCarte = null;
                deuxiemeCarte = null;

                attendre
                = false;    
            }
        }
        // ===========fin du jeu ============
        if (jeuFini)
        {
            if(Time.time > tempsFin + delaiFin)
            {
                if(Keyboard.current.spaceKey.wasPressedThisFrame)
                {
                    RedemarrerScene(); 
                }
            }
        }
    }
    public void CarteClique(GameObject carte)
    {
        // Bloque les clics (spam)
        if (attendre || jeuFini) return; ;

        if (premiereCarte == null)
        {
            premiereCarte = carte;
        }
        else
        {
            deuxiemeCarte = carte;

            if (premiereCarte == deuxiemeCarte)
            {
                deuxiemeCarte = null;
                return;
            }

            Sprite face1 = premiereCarte.GetComponent<CarteMemoire>().faceSprite;
            Sprite face2 = deuxiemeCarte.GetComponent<CarteMemoire>().faceSprite;

            if (face1 != face2)
            {
                attendre = true;
                tempsDebutAttemdre = Time.time;
            }
            else
            {
                pairesTrouvee++;

                // bonne paire? remettre 
                premiereCarte = null;
                deuxiemeCarte = null;

                if(pairesTrouvee >= totalPaires)
                {
                    Victoire();
                }
            }


            }

        }
    void Victoire()
    {
        if (jeuFini) return;
        jeuFini = true;
        Debug.Log("Victoire!");
        UIVictoire.SetActive(true);

        tempsFin = Time.time;
    }

    void RedemarrerScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    }
