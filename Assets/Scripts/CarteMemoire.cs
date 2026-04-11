using UnityEngine;
using UnityEngine.EventSystems;

public class CarteMemoire : MonoBehaviour
{
    public Sprite faceSprite;
    public Sprite backSprite;

    private SpriteRenderer sr;
    private bool estRetourne = false;

    public CarteManager manager; //connect toi au manager
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = backSprite;
    }

    public void OnCarteClique(BaseEventData eventData)
    {
        if (estRetourne) return;
        
            sr.sprite = faceSprite;
            estRetourne = true;

            manager.CarteClique(gameObject);
        
    }
    public void CacherCarte()
    {
        sr.sprite = backSprite;
        estRetourne = false;
    }

}
