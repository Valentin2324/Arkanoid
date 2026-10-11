using UnityEngine;

public class PowerUpTurrets : MonoBehaviour {

  [SerializeField] private TurretsLogic turrets;
  [SerializeField] private float powerUpDuration;
  [SerializeField] private AudioClip turretsPowerUpAudio;

  private FillBarManagerUI fillBarManagerUI;

  private void Awake() {
    turrets = FindFirstObjectByType<TurretsLogic>();
    fillBarManagerUI = FindFirstObjectByType<FillBarManagerUI>();
  }
  
  private void OnTriggerEnter2D(Collider2D collider) {
    if (collider.gameObject.CompareTag("Player")) {
      AudioSource.PlayClipAtPoint(turretsPowerUpAudio, Camera.main.transform.position);
      turrets.StartTurretsRoutine(powerUpDuration);

      fillBarManagerUI.TurretsFillBar.StartFillBar(powerUpDuration);

      Destroy(gameObject);
    }
  }
}
