using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StoryRoller : MonoBehaviour
{
    [Header("読み込むストーリーデータ")]
    public StoryData storyData;

    [Header("スクロールさせる Text (UI)")]
    public TextMeshProUGUI storyText;

    [Header("スクロール速度（大きいほど速い）")]
    public float scrollSpeed = 50f;

    [Header("Text を入れる親オブジェクト（Mask付き）")]
    public RectTransform viewport;

    [Header("シーンチェンジするY位置（Viewport基準）")]
    public float endThreshold = 200f;

    [Header("終わったら移動するシーン名")]
    public string nextSceneName;




    private RectTransform textRect;

    private void Start()
    {
        textRect = storyText.GetComponent<RectTransform>();

        // StoryData の文章を全部つなげる
        storyText.text = "";
        foreach (var s in storyData.stories)
        {
            storyText.text += s.StoryText + "\n\n";
        }

        // 初期位置を「画面の下」にセット
        textRect.anchoredPosition = new Vector2(0, -viewport.rect.height);
    }

    private void Update()
    {
        // 上方向へ移動
        textRect.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        //最後の文字が座標のとこまで来たらscene移動
        if (textRect.anchoredPosition.y >= textRect.rect.height - endThreshold)
        {
            SceneManager.LoadScene(nextSceneName);
        }

    }
}