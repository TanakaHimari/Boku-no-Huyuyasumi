using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public class GaugeRuntime
    {
        [Header("ゲージの設定データ")]
        public GaugeData data;
        [Header("ゲージの画像")]
        public Image image;
        [Header("実行時のゲージの値")]
        public float currentGauge;

      


        public void Initialize()
        {
            currentGauge = data.startGauge;
            UpdateUI();
        }


        //ゲージ画像を現在地に合わせて更新
        public void UpdateUI()
        {
            image.fillAmount = currentGauge / data.maxGauge;
        }
        //ゲージを増やす処理
        public void AddGauge()
        {
            currentGauge += data.increaseAmount;
            UpdateUI();
        }

        //ゲージを減らす処理
        public void ReduceGauge()
        {
            currentGauge -= data.increaseAmount;
            UpdateUI();
        }


        //満タンかどうかの判定
        public bool IsFull()
        {
            return currentGauge >= data.maxGauge;
        }
        //0かどうかの判定
        public bool IsEmpty()
        {
            return currentGauge <= 0f;
        }




    }
    [Header("ゲーム内で扱うゲージ")]
    public List<GaugeRuntime> gauges = new List<GaugeRuntime>();

    [Header("隠しボタンの設定データ")]
    public SecretButtonData secretButtonData;

    [Header("出現するもうひとつボタン")]
    public GameObject specialButton;
    [Header("出現条件")]
    [Tooltip("データの値がこの数になったときにもうひとつボタンが出現")]
    public float appearThreshold = 50f;

    private void Start()
    {
        //ゲーム開始時に全てのゲージの画像を初期化
        foreach (var gauge in gauges)
        {
            gauge.Initialize();

        }
        CheckButtonAppearance();
    }
    //隠しボタンを出現させる
    /// <summary>
    /// 隠しボタンを出すべきかどうかを判定する処理
    /// </summary>
    private void CheckButtonAppearance()
    {
        var gauge = gauges[secretButtonData.targetGaugeIndex];

        bool shouldAppear = false;

        switch (secretButtonData.conditionType)
        {
            case GaugeConditionType.LessOrEqual:
                shouldAppear = gauge.currentGauge <= secretButtonData.appearThreshold;
                break;

            case GaugeConditionType.GreaterOrEqual:
                shouldAppear = gauge.currentGauge >= secretButtonData.appearThreshold;
                break;
        }

        specialButton.SetActive(shouldAppear);
    }


    /// <summary>
    /// 隠しボタンが押されたときの処理
    /// </summary>
    public void OnSecretButtonClick()
    {
        var manager = secretButtonData.targetManager;

        // 操作対象のゲージ
        var target = gauges[secretButtonData.targetGaugeIndex];

        // 指定量だけゲージを増やす（または減らす）
        target.currentGauge += secretButtonData.fluctuationAmount;

        // UI を更新
        target.UpdateUI();

        var gauge = gauges[secretButtonData.targetGaugeIndex];

        if (gauge.IsFull())
        {
            Debug.Log("満たされました");
        }

        if (gauge.IsEmpty())
        {
            Debug.Log("ゼロになりました");
        }

    }




    //ボタンから呼ばれるゲージ増減処理
    public void AddGauge()
    {
        foreach (var gauge in gauges)
        {
            gauge.AddGauge();

            if (gauge.IsFull())
            {
                Debug.Log("満たされました");
            }
            

        }
        CheckButtonAppearance();
    }

    public void ReduceGauge()
    {
        foreach (var gauge in gauges)
        {
            gauge.ReduceGauge();

            if (gauge.IsEmpty())
            {
                Debug.Log("ゼロになりました");
            }
        }
        CheckButtonAppearance();
    }

}
