using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Infection : MonoBehaviour {
  public Color infectedColor;
  private Color _oldColor;
  public Color decay1;
  public Color decay2;
  private Material _rendererMaterial;
  private Material _rendererMaterialTop;
  private Material _rendererMaterialBottom;
  private float _elapsedTime = 0.0f;
  private float _decayTimer = 0.0f;
  private int infected = 0;
  private int decayFlag = 0;
  private int stageDecay = 0;
 
	// Use this for initialization
	void Start () {
    //get the top and bottom gums game objects and Meshrenderers
    MeshRenderer renderer = GetComponent<MeshRenderer>();
	GameObject topGum = GameObject.Find ("Mouth Top");
	GameObject bottomGum = GameObject.Find ("Mouth Bottom");
	MeshRenderer rendererTop = topGum.GetComponent<MeshRenderer> ();
	MeshRenderer rendererBottom = bottomGum.GetComponent<MeshRenderer> ();
	decay1 = Color.red;
	decay2 = Color.black;

	    if(renderer != null) {
	      _rendererMaterial = renderer.material;

	      _oldColor = _rendererMaterial.color;
	    }
		if (rendererTop != null) {
			_rendererMaterialTop = rendererTop.material;
		}
		if (rendererBottom != null) {
			_rendererMaterialBottom = rendererBottom.material;
		}
		InvokeRepeating ("GumDecay", 10, 10.0f);
	}
	
	// Update is called once per frame
	void Update () {
	    if(_elapsedTime < 1.0f) {
	      _elapsedTime += Time.deltaTime;

	      _rendererMaterial.color = Color.Lerp(_oldColor, infectedColor, _elapsedTime);
	    }/*
		if (_rendererMaterial.color.Equals(infectedColor)) {
			//StartCoroutine (StartWait());
			_decayTimer += Time.deltaTime;
			if (_decayTimer > 30.0f) {
				Application.LoadLevel (0);
			}
			if (_decayTimer > 20.0f && decayFlag == 1) {
				decayFlag = 2;
				if (_rendererMaterialTop.color.Equals (decay2)) {
					Application.LoadLevel (0);
					//_decayTimer = 0.0f;
				}
				if (_rendererMaterialTop.color.Equals (decay1)) {
					_rendererMaterialTop.color = decay2;
					_rendererMaterialBottom.color = decay2;
					//_decayTimer = 0.0f;
				}
			}
			if (_decayTimer > 10.0f && decayFlag == 0) {
				//_decayTimer = 0.0f;
				decayFlag = 1;
				if (_rendererMaterialTop.color.Equals (decay2)) {
					Application.LoadLevel (0);
					//_decayTimer = 0.0f;
				}
				if (_rendererMaterialTop.color.Equals (decay1)) {
					_rendererMaterialTop.color = decay2;
					_rendererMaterialBottom.color = decay2;
					//_decayTimer = 0.0f;
				} else {
					_rendererMaterialTop.color = decay1;
					_rendererMaterialBottom.color = decay1;
					//_decayTimer = 0.0f;
				}
			}

		}

	*/}
	void GumDecay(){
		if (_rendererMaterial.color.Equals (infectedColor)) {
			Debug.Log ("Infected tooth found!");

			if (_rendererMaterialTop.color.Equals (decay2)) {
				Application.LoadLevel (0);
			}
			else if (_rendererMaterialTop.color.Equals (decay1)) {
				_rendererMaterialTop.color = decay2;
				_rendererMaterialBottom.color = decay2;
			} else {
				_rendererMaterialTop.color = decay1;
				_rendererMaterialBottom.color = decay1;
			}

		}


	}


}
