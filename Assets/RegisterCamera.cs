using UnityEngine;
using Cinemachine;
public class RegisterCamera : MonoBehaviour
{
        void Start(){
        CameraSwitch.Instance.Register(GetComponent<CinemachineVirtualCamera>());
        Debug.Log("Hellooo register me pleaaaase " + gameObject.name);
    }
}
