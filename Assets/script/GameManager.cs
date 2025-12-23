using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public class GaugeRuntime
    {
        //ゲージの設定データ
        public GaugeData data;
        //ゲージ画像
        public Image image;
        // 実行時のゲージ値
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

    private void Start()
    {
        //ゲーム開始時に全てのゲージの画像を初期化
        foreach (var gauge in gauges)
        {
            gauge.Initialize();
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
    }

}
