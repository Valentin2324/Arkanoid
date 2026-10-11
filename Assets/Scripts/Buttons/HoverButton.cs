using UnityEngine;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour, IPointerEnterHandler {
  
  [SerializeField] private AudioSource audioSource;
  [SerializeField] private AudioClip hoverButtonSFX;

  public void OnPointerEnter(PointerEventData eventData) {
    audioSource.PlayOneShot(hoverButtonSFX);
  }


}
