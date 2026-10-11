using UnityEngine;

public class ScoreColliderPowerUpSpawn : MonoBehaviour {
  
  [SerializeField] private ScoreCollider scoreCollider;
  [SerializeField] private PowerUpManager powerUpManager;

  private GameObject powerUpChosen;

  private void ChoosePowerUp() {
    int randomIndex = Random.Range(0, powerUpManager.GetPowerUpsList().Count);
    powerUpChosen = powerUpManager.GetPowerUpsList()[randomIndex];
  }

  public void ChanceToSpawn(Vector3 spawnPosition, float multipliyer) {
    ChoosePowerUp();
    
    float chance = Random.Range(0.0f, 10.0f);
    if (chance * multipliyer < 9.5f) {
      // didn't spawn
      // spawn chance 5%
      return;
    }

    Instantiate(powerUpChosen, spawnPosition, Quaternion.identity);
  }
}
