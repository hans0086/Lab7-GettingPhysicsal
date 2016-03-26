using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts {
  [RequireComponent(typeof(Camera))]
  public class MouseCameraControl: MonoBehaviour {
    Camera _camera;

    public void Start() {
      _camera = GetComponent<Camera>();
    }

    public void Update() {
      Vector2 mousePosition = Input.mousePosition;
      Vector2 screenSize = new Vector2(Screen.width, Screen.height);
      Vector2 screenCenter = screenSize / 2.0f;
      Vector2 difference = (mousePosition - screenCenter);

      Vector3 rotation = Vector3.zero;
      rotation.x = (difference.y / screenSize.y) * _camera.aspect;

      transform.localRotation = Quaternion.Euler(rotation); 
      
    }
  }
}
