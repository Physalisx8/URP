
using UnityEngine;

public class RegisterTriggers : MonoBehaviour
{
    void Awake(){
     CameraSwitch.Instance.RegisterTriggers(gameObject);
    }
}
