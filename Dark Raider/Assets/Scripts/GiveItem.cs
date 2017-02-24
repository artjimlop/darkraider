using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveItem : MonoBehaviour {

	public string questName;
	private AudioSource theAudio = null;
	private SpriteRenderer theRender = null;
	private Collider2D theCollider = null;

	void Awake() {
		theAudio = GetComponent<AudioSource> ();
		theRender = GetComponent<SpriteRenderer> ();
		theCollider = GetComponent<Collider2D> ();
	}

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
		if (QuestManager.GetQuestStatus (questName) == Quest.QUEST_STATUS.ASSIGNED) {
			gameObject.SetActive (true);
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (!collider.CompareTag ("Player"))
			return;
		if (!gameObject.activeSelf) {
			return;
		}

		QuestManager.SetQuestStatus (questName, Quest.QUEST_STATUS.COMPLETED);
		theRender.enabled = theCollider.enabled = false;
		if (theAudio != null) {
			theAudio.Play ();
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
