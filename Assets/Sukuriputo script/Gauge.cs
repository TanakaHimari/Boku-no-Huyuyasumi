using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Gauge : MonoBehaviour
{
    [Range(1, 100)]
    public float maxGauge = 100f;

    [Range(1, 100)]
    public float currentGauge = 0f;

    public Image image;
}
