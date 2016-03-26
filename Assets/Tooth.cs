using UnityEngine;
using UnityEngine.SceneManagement;

public class Tooth : MonoBehaviour {
  public InfectTeeth skull;
	public Infection infected;
	public Color decay1;
	public Color decay2;
	private Color toothColor;
  public float timeToDestroyTooth = 2.0f;
  private float _elapsedTime;
	private Material _rendererTooth;
	private Material _rendererMaterialTop;
	private Material _rendererMaterialBottom;

	 void Start(){
		MeshRenderer renderer = GetComponent<MeshRenderer>();
		if (renderer != null) {
			_rendererTooth = renderer.material;
		}
		decay1 = Color.red;
		decay2 = Color.black;

		}
 	 public void OnCollisionEnter(Collision collision) {
    	GameObject otherGO = collision.collider.gameObject;
	    if(otherGO.tag == "Sweets") {
	      Rigidbody rigidbody = GetComponent<Rigidbody>();
	      rigidbody.isKinematic = false;
	      rigidbody.useGravity = true;

	      // Propogate velocity.
	      Rigidbody otherGORigidbody = otherGO.GetComponent<Rigidbody>();
	      rigidbody.velocity = otherGORigidbody.velocity;
	      rigidbody.angularVelocity = otherGORigidbody.angularVelocity;
				//RemoveTooth(this)
				//if (_elapsedTime = timeToDestroyTooth) {				
				skull.RemoveTooth (this.gameObject);
				Destroy (this.gameObject, 2.0f);
				//if you hit a fully infected tooth
				if (_rendererTooth.color.Equals(skull.infectionColor)) {
					
				} else {//if the tooth isn't fully infected
					//get the top and bottom gum objects
					GameObject topGum = GameObject.Find ("Mouth Top");
					GameObject bottomGum = GameObject.Find ("Mouth Bottom");
					MeshRenderer rendererTop = topGum.GetComponent<MeshRenderer> ();
					MeshRenderer rendererBottom = bottomGum.GetComponent<MeshRenderer> ();
					if (rendererTop != null) {
						_rendererMaterialTop = rendererTop.material;
						//if it is in the 2nd decay state, reset the level
						if (_rendererMaterialTop.color.Equals(decay2)) {
							Application.LoadLevel (0);
						//if it is in the 1st decay state, go to the 2nd
						} else if (_rendererMaterialTop.color.Equals(decay1)) {
							_rendererMaterialTop.color = decay2;
							Destroy (otherGO);
						//set the  top gums to the 1st decay state
						} else {
							_rendererMaterialTop.color = decay1;
							Destroy (otherGO);
						}
					}
					if (rendererBottom != null) {
						_rendererMaterialBottom = rendererBottom.material;
						//if it is in the 2nd decay state, reload the level
						if (_rendererMaterialBottom.color.Equals(decay2)) {
							Application.LoadLevel (0);
						//if it is in the 1st decay state, go to the 2nd decay state
						} else if (_rendererMaterialBottom.color.Equals(decay1)) {
							_rendererMaterialBottom.color = decay2;
							Destroy (otherGO);
						//set the bottom gum to the 1st decay state
						} else {
							_rendererMaterialBottom.color = decay1;
							Destroy (otherGO);
						}
					}


				}
	    }
  }
}
