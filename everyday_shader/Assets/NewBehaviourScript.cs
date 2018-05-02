using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	public Material material;
	float intime = 1;
	float outtime = 6.5f;
	float size = 0.2f;
	float size_time = 4;

	void Start () {
		// ２秒後にFadeIn()を、５秒後にFadeOut()を呼び出す
		Invoke("FadeIn", intime);
		Invoke("FadeOut", outtime);
		StartCoroutine(Set());
	}
	IEnumerator Set(){
		
		while(true){
		yield return new WaitForSeconds(outtime+size_time);
		Invoke("FadeIn", intime);
		Invoke("FadeOut", outtime);
		}			

	}
	void FadeIn() {
		// SetValue()を毎フレーム呼び出して、１秒間に０から１までの値の中間値を渡す
		iTween.ValueTo(gameObject, iTween.Hash("from", 0f, "to", size, "time", size_time, "onupdate", "SetValue","EaseType", iTween.EaseType.easeInExpo));
	}
	void FadeOut() {
		// SetValue()を毎フレーム呼び出して、１秒間に１から０までの値の中間値を渡す
		iTween.ValueTo(gameObject, iTween.Hash("from", size, "to", 0f, "time", size_time, "onupdate", "SetValue","EaseType", iTween.EaseType.easeInOutQuart));
	}
	void SetValue(float alpha) {
		// iTweenで呼ばれたら、受け取った値をImageのアルファ値にセット
		material.SetFloat("_Displacement", alpha);
	}

	// Update is called once per frame
	void Update () {
	}
}
