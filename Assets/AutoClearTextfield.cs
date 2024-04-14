using TMPro;
using UnityEngine;

public class AutoClearTextfield : MonoBehaviour
{
    public float timeBeforeClear;

    private float _lastTextsetTime;

    // Update is called once per frame
    void Update()
    {
        if (Time.time - _lastTextsetTime > timeBeforeClear)
        {
            SetText(string.Empty);
        }
    }

    public void SetText(string text)
    {
        gameObject.GetComponent<TextMeshProUGUI>().SetText(text);
        _lastTextsetTime = Time.time;
    }
}
