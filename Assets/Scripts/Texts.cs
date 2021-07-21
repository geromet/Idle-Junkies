using UnityEngine;
using TMPro;

public class Texts : MonoBehaviour
{
    public TMP_Text dollars;
    public void UpdateText(Score score)
    {
        dollars.text = score.dollars.ToString();

    }
    
}
