using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class InfectTeeth : MonoBehaviour {
  public List<GameObject> teeth;
  public Color infectionColor;
  public GameObject toothPrefab;
	//public Color decay1;
	//public Color decay2;

  public float nextInfectionDelay = 1.0f;
  private float _elapsedTime = 0.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
    _elapsedTime += Time.deltaTime;
    if(_elapsedTime >= nextInfectionDelay) {
      _elapsedTime = 0.0f;

      InfectTooth();
    }
  }

  public void InfectTooth() {
    if(teeth.Count > 0) {
      for(int attemptedToothCount = 0; attemptedToothCount < teeth.Count; attemptedToothCount++) {

        // Get our infection index.
        int index = (int)Random.Range(0, teeth.Count);
        GameObject selectedTooth = teeth[index];

        // Make sure we're not infecting a tooth that's already infected.
		if(teeth[index] != null){
	        if(selectedTooth.GetComponent<Infection>() == null) {
	          Infection newInfection = selectedTooth.AddComponent<Infection>();
	          newInfection.infectedColor = infectionColor;
			  //set the decay state colors
			  //newInfection.decay1 = decay1;
			  //newInfection.decay2 = decay2;
	        }
	        else {
	          continue;
	        }
		}
      }
    }
  }

  public void RemoveTooth(GameObject toothToRemove) {
	// find the tooth that is being removed from the list
    if(teeth.Contains(toothToRemove)) {
      //get the tooth's index
      int toothIndex = teeth.IndexOf(toothToRemove);
	  //remove tooth at that index
	 // teeth.RemoveAt(toothIndex);
	  teeth[toothIndex] = null;
    }
  }

  public void SpawnTooth() {/*
    for(int toothIndex = 0; toothIndex < teeth.Count; toothIndex++) {
			if (teeth [toothIndex] == null) {
				Debug.Log ("Found Empty Tooth");
				GameObject newTooth = Instantiate (toothPrefab, new Vector3 (teethLocationX [toothIndex], teethLocationY [toothIndex], teethLocationZ [toothIndex]), Quaternion.identity) as GameObject;
				if(toothIndex < 8)
					newTooth.transform.parent = GameObject.Find ("Top Teeth").transform;
				if (toothIndex > 7)
					newTooth.transform.parent = GameObject.Find ("Teeth").transform;
				Rigidbody rigid = newTooth.GetComponent<Rigidbody> ();
				rigid.isKinematic = true;
				rigid.useGravity = false;
				Tooth spawnedToothScript = newTooth.GetComponent<Tooth> ();
				spawnedToothScript.skull = GameObject.Find ("Skull").GetComponent<InfectTeeth>();
				teeth [toothIndex] = newTooth;
			}
	 }*/
    }
  }

