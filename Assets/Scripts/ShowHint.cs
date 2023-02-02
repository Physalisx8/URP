using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   

public class ShowHint : MonoBehaviour
{

[SerializeField] TMPro.TextMeshProUGUI hintText;
[SerializeField] TMPro.TextMeshProUGUI hintCountText;
[SerializeField] TMPro.TextMeshProUGUI hintCountOutro;
[SerializeField] GameObject Button;
[SerializeField] public int hintCount;
 GameManager gameManager;

    private void OnEnable()
    {
        Reset();
    }

    void Awake(){
        gameManager = FindObjectOfType<GameManager>();
    }

  /*void Update(){
    if(Input.GetKeyDown(KeyCode.H)){
        Show();
    }
  }
  */


public void Show(){
    
    hintText.text = gameManager.Hint;
    IncreaseHintCounter();
    Button.SetActive(false);
    
}

    public void IncreaseHintCounter()
    {
    hintCount+=1;
    hintCountText.text = "Hinweise: " + hintCount;
    hintCountOutro.text = "Hinweise: "+ hintCount;
    }
public void Hide(){
    Button.SetActive(true);
    hintText.text = "";
}

    public void Reset()
    {
        hintCount = 0;
        hintCountText.text = "Hinweise: 0";
        hintCountOutro.text = "Hinweise: 0";
    }
}
