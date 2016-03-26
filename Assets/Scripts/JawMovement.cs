using UnityEngine;

public class JawMovement : MonoBehaviour {

  public Vector3 minimumExtent;
  public Vector3 maximumExtent;
  public float directionTime;

  bool movingToMaximumExtent = true;
  float elapsedTime;

	// Update is called once per frame
	void Update () {
    if(directionTime != 0.0f) {
      elapsedTime += Time.deltaTime;
      float timePercentage = Mathf.Min(1.0f, elapsedTime / directionTime);

      if(movingToMaximumExtent) {
        transform.localPosition = Vector3.Lerp(minimumExtent, maximumExtent, timePercentage);
      }
      else {
        transform.localPosition = Vector3.Lerp(maximumExtent, minimumExtent, timePercentage);
      }

      if(elapsedTime >= 1.0f) {
        elapsedTime = 0.0f;
        movingToMaximumExtent = !movingToMaximumExtent;
      }
    }
	}
}
