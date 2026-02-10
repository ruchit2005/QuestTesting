using UnityEngine;
using TMPro;

public class HashcodeManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI codeText;       // drag the TMP text (digit display) here
    void Start()
    {
        if (codeText != null)
            codeText.text = "";
    }

    public void AddNum(string num)
    {
        if (codeText != null)
            codeText.text += num;
    }

    public void ClearCode()
    {
        if (codeText != null)
            codeText.text = "";
    }

    public void SubmitCode()
    {
        
    }
}
