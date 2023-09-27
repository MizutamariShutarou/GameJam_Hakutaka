using UnityEngine;
using UnityEngine.UI;

public class InputFieldFocus : MonoBehaviour
{
    void Start()
    {
        InputField i = this.GetComponent<InputField>();
        i.ActivateInputField();
        i.onEndEdit.AddListener(text =>
        {
            if (!string.IsNullOrEmpty(text))
            {
                i.text = "";
            }
            i.ActivateInputField();
        });
    }
}