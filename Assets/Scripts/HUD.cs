using UnityEngine;
using UnityEngine.UIElements;

public class HUD : MonoBehaviour
{
    private UIDocument _uiDocument;
    private static Label _scoreLabel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _uiDocument = GetComponent<UIDocument>();
        _scoreLabel = _uiDocument.rootVisualElement.Q<Label>("Score");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetScore(int score)
    {
        if (_scoreLabel == null)
            return;
        _scoreLabel.text = "Score : " + score.ToString();
    }
}
