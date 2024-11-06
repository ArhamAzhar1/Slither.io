using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{

    private Camera _mainCamera;
    private Vector3 _mouseInput;
    private void Initialize()
    {
        _mainCamera = _mainCamera.main ;
    }
   private void Update()
   {
       
        _mouseInput.x =Input.mousePosition.x;
        _mouseInput.y =Input.mousePosition.y;
        _mouseInput.z =_mainCamera.nearClipPlane;
        Vector3 mouseWorldCoordinates = _mainCamera.SceenToWorldPoint((Vector3)Input.mousePosition);
        transform.position = new MoveTorward(current:transform.position, target:mouseWorldCoordinates, Time.deltatime);
   }
}

