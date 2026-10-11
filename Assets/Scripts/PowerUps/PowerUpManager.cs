using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {
  
  [SerializeField] private  GameObject powerUpPaddleAdd;
  [SerializeField] private GameObject powerUpPaddleSub;
  [SerializeField] private GameObject powerUpBallAdd;
  [SerializeField] private GameObject powerUpTurrets;
  [SerializeField] private GameObject powerUpHealth;

  private List<GameObject> powerUps;

  private void Awake() {
    powerUps = new List<GameObject> {
      powerUpPaddleAdd,
      powerUpPaddleSub,
      powerUpBallAdd,
      powerUpTurrets,
      powerUpHealth
    };
  }

  public List<GameObject> GetPowerUpsList() {
    return powerUps;
  }
}
