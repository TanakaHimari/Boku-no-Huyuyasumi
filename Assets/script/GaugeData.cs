using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GaugeData", menuName = "Game/GaugeData")]
public class GaugeData : ScriptableObject

{
    [Header("ゲージの最大値")]
    [Range(1, 100)]
    public float maxGauge = 100f;

    [Header("初期ゲージ")]
    [Range(1, 100)]
    public float startGauge = 1f;

    [Header("ゲージの増減量")]
    [Range(1, 100)]
    public float increaseAmount = 10f;

    [Header("ゲージ画像")]
    public Sprite gaugeSprite;

   

}
