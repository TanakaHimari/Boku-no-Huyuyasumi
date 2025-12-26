using UnityEngine;

public class SEchange : MonoBehaviour
{
    [SerializeField]
    [Header("Ä¶‚·‚éSE–¼")]
    private string seName = "SE";


    /// <summary>
    /// Inspector ‚Åw’è‚µ‚½ SE ‚ğÄ¶‚·‚é
    /// </summary>
    public void PlaySE()
    {
        Debug.Log("PlaySE ŒÄ‚Î‚ê‚½‚æ: " + name);
        SoundManager.Instance.PlaySE(seName);
    }

}
