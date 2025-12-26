using UnityEngine;

[CreateAssetMenu(fileName = "SecretButoonData",menuName = "Game/SecretButoonData")]
public class SecretButtonData : ScriptableObject


{
    [Header("アタッチするゲームマネージャー")]
    public GameManager targetManager;

    [Header("増減する量")]
    public float　fluctuationAmount;

    [Header("操作するゲージ")]
    [Tooltip("GameManager の gauges リストのインデックスと対応してます")]
    public int targetGaugeIndex;

    [Header("ボタン出現条件")]
    [Tooltip("この数値になったらボタンが表示されます")]
    public float appearThreshold;

    public GaugeConditionType conditionType;

}

public enum GaugeConditionType
{
    LessOrEqual,   // 減るゲージ用（<=）
    GreaterOrEqual // 増えるゲージ用（>=）
}
