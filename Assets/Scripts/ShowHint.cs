using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   

public class ShowHint : MonoBehaviour
{

[SerializeField] TMPro.TextMeshProUGUI hintText;
[SerializeField] TMPro.TextMeshProUGUI hintCountText;
[SerializeField] int hintCount;
 GameManager gameManager;

    private void OnEnable()
    {
        Reset();
    }

    void Awake(){
        gameManager = FindObjectOfType<GameManager>();
    }

  void Update(){
    if(Input.GetKeyDown(KeyCode.H)){
        Show();
    }
  }

void Show(){
    
    hintText.text = gameManager.Hint;
    IncreaseHintCounter();
    
}

    public void IncreaseHintCounter()
    {
    hintCount+=1;
    hintCountText.text = "Hinweise: " + hintCount;
    }
public void Hide(){
    hintText.text = "";
}

    public void Reset()
    {
        hintCount = 0;
        hintCountText.text = "Hinweise: 0";
    }
}
