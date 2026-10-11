using UnityEngine;

public class FillBarManagerUI : MonoBehaviour {
  
  [SerializeField] private FillBarUI fillBarPaddleAdd;
  [SerializeField] private FillBarUI fillBarPaddleSub;
  [SerializeField] private FillBarUI fillBarBallAdd;
  [SerializeField] private FillBarUI fillBarTurrets;

  public FillBarUI PaddleAddFillBar => fillBarPaddleAdd;
  public FillBarUI PaddleSubFillBar => fillBarPaddleSub;
  public FillBarUI BallAddFillBar => fillBarBallAdd;
  public FillBarUI TurretsFillBar => fillBarTurrets;
}
