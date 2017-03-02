using System.Collections;
using UnityEngine;

public class Shake : MonoBehaviour {

	public float shakeTime;
	public float shakeSpeed;
	public float magnitude;

	void Update () {
		if (Input.GetKeyDown(KeyCode.A)) {
			StartCoroutine(ShakeIt());
		}
	}

	IEnumerator ShakeIt() {
        
    float elapsed = 0.0f;
    float randomStart = Random.Range(-1.000f, 1.000f);
    Vector3 originalCamPos = Camera.main.transform.position;
    
    while (elapsed < shakeTime) {
        
        elapsed += Time.deltaTime;          
        
        float percentComplete = elapsed / shakeTime;         
        float damper = 1.0f - Mathf.Clamp(2.0f * percentComplete - 1.0f, 0.0f, 1.0f);
        float alpha =  randomStart + shakeSpeed*percentComplete;
        // map value to [-1, 1]
        float x = Mathf.PerlinNoise(alpha, 0) * 2.0f - 1.0f;
        float y = Mathf.PerlinNoise(0, alpha) * 2.0f - 1.0f;

        x *= magnitude * damper;
        y *= magnitude * damper;
        
        Camera.main.transform.position = new Vector3(originalCamPos.x, y, x);
            
        yield return null;
    }
    
    Camera.main.transform.position = originalCamPos;
	}
}
