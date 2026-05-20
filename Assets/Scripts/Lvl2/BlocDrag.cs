using UnityEngine;
using UnityEngine.EventSystems;


public class BlocDrag : MonoBehaviour
{
    /// Garde une référence à une zone connectée
    public ZoneDrop zoneConnectee = null;

    public string typePiece;

    // Fonciton OnBeginDrag : Exécutée quand on commence le drag.
    public void OnBeginDrag(BaseEventData eventData)
    {
        // - Enlève le parent de ce Transform.
        transform.SetParent(null);
        // - Désactive le Collider2D pour éviter des bugs de détection.
        GetComponent<Collider2D>().enabled = false;

    }




    // Fonction OnDrag : Exécutée pendant qu'on glisse ce bloc.
    public void OnDrag(BaseEventData eventData)
    {
        // - Récupère les infos du pointeur et le traite comme un PointerEventData.
        PointerEventData pointerEventData = eventData as PointerEventData;
        // - On fait la conversion d'une position du pointeur à l'écran (en pixels)
        // à une position au monde (en unités).
        Vector2 positionPointerMonde = Camera.main.ScreenToWorldPoint(pointerEventData.position);

        // - On téléporte le bloc à la position de la souris
        transform.position = positionPointerMonde;
    }


    // Fonction OnEndDrag : Exécutée quand le drag est fini.

    public void OnEndDrag(BaseEventData eventData)
    {
        // - On réactive le Collider.
        GetComponent<Collider2D>().enabled = true;

        // Exécutée par une ZoneDrop quand le bloc est
        // déposé (OnDrop).

    }
    // - On réactive le Collider.

    // Exécutée par une ZoneDrop quand le bloc est
    // déposé (OnDrop).
    public void ConnecterZone(ZoneDrop zone)
    {
        zoneConnectee = zone;
    }

    public void DeconnecterZone()
    {
        // Si ce bloc est connectée à une ZoneDrop,
        // on le deconnecte et on libère la zone.
        if (zoneConnectee != null)
        {
            zoneConnectee.Liberer();
        }
        zoneConnectee = null;
    }
}
