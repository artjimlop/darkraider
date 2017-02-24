using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveQuest : MonoBehaviour {

	public string questName = string.Empty;
	public Text messageText = null;
	public string[] messages;

	void OnTriggerEnter2D(Collider2D collider) {
		if (!collider.CompareTag ("Player")) {
			return;
		}
		Quest.QUEST_STATUS status = QuestManager.GetQuestStatus (questName);
		messageText.text = messages[(int) status];
	}

	void OnTriggerExit2D(Collider2D collider) {
		Quest.QUEST_STATUS status = QuestManager.GetQuestStatus (questName);
		if (status == Quest.QUEST_STATUS.UNASSIGNED) {
			QuestManager.SetQuestStatus (questName, Quest.QUEST_STATUS.ASSIGNED);
		}
		if (status == Quest.QUEST_STATUS.COMPLETED) {
			Application.LoadLevel (5); //win level
		}
	}

}
