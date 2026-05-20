using UnityEngine;
using UnityEngine.EventSystems;


public class ZoneDrop : MonoBehaviour
{
    /// Cette variable static est partagée par toutes les instances de 
    /// ZoneDrop, donce c'est un peu d'état partagé. CEtte technique est outil pour 
    /// pour les comptages centralisées.
    /// 

    public GameObject boutonSuivant;

    private static int points = 0;
    //const => pas changer
    private const int POINTAGE_MAX = 3;

    public string typeZone;
    public GameObject texteVictoire;

    // Référence à l'emplacement du snap
    public GameObject pointSnap;
    public bool estLibre = true;

    // Couleurs pour la rétroaction visuelle
    private Color couleurArrierePlanBase = Color.gray;
    private Color couleurArrierePlanNiveauComplet = Color.lightCoral;


    private void Start()
    {
        points = 0;

        ChangerArrierePlan(couleurArrierePlanBase);
        texteVictoire.SetActive(false);

        boutonSuivant.SetActive(false);

    }

    // Fonction OnDrop 
    public void OnDrop(BaseEventData eventData)
    {
        // - Récupère les infos du pointeur et le traite comme un PointerEventData.
        PointerEventData pointerData = eventData as PointerEventData;
        GameObject objet = pointerData.pointerDrag; ;

        BlocDrag bloc = objet.GetComponent<BlocDrag>();

        // Verifie si la pièce est la bonne
        if (bloc.typePiece != typeZone)
        {
            return;
        }

        // Verifie si la pièce est la libre

        if (estLibre)
        {
            // place la piece au point de snap
            objet.transform.position = pointSnap.transform.position;


            // Met la piece comme enfant de la zone
            objet.transform.SetParent(transform);

            bloc.ConnecterZone(this);

            estLibre = false;

            points += 1;

            VerifierFinNiveau();

        }
    }


    // Fonction OnPointerEnter : Exécutee quand le pointeur arrive dans cette zone.
    // - On recupère les infos du pointer
    // - Si le pointer est en train de faire un drag-and-drop, ...
    // - ... on change la couler de la zone si elle est libre ou non.

    // Fonction OnPointerExit : Exécutée quand le pointeur sort de cette zone.
    // - On change la couleur de la zone à sa couleur de base.


    private void VerifierFinNiveau()
    {
        //Debug.Log("Points : " + points);

        if (points == POINTAGE_MAX)
        {
            //Debug.Log("Niveau end");
            ChangerArrierePlan(couleurArrierePlanNiveauComplet);

            texteVictoire.SetActive(true);

            boutonSuivant.SetActive(true);
        }
    }


    public void ChangerCouleurZone(Color nouvelleCouleur)
    {
        GetComponent<SpriteRenderer>().color = nouvelleCouleur;
    }

    public void ChangerArrierePlan(Color nouvelleCouleur)
    {
        Camera.main.backgroundColor = nouvelleCouleur;
    }

    // Exécutée par l'objet déposé (voir BlocDrag) quand il
    // se déconnecte de cette ZoneDrop.
    public void Liberer()
    {
        estLibre = true;
        points -= 1;
        ChangerArrierePlan(couleurArrierePlanBase);
    }
}
