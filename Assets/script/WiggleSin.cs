using Unity.Mathematics;
using UnityEngine;

public class WiggleSin : MonoBehaviour
{
    [SerializeField]
    [Header("触れ幅")]
    [Range(5,50)]
    private float amplitude = 10f;

    [SerializeField]
    [Header("揺れるスピード")]
    [Range(1, 10)]
    private float speed = 1f;

    //初期位置を保存するための変数
    private　float startX;
    
    void Start()
    {
        //オブジェクトの座標を記録する
        //揺れの中心が常に元の位置になるようにする
        startX = transform.localRotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Sin 波を取得
        float sin = Mathf.Sin(Time.time * speed);

        // 負の値だけ使う（正の値は0にする）
        float offset = Mathf.Min(0, sin * amplitude);

        // 左にだけ動いて、元の位置に戻る
        transform.localPosition = new Vector3(
            startX + offset,
            transform.localPosition.y,
            0
        );


    }
}
