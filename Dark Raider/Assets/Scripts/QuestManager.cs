using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest {

	public enum QUEST_STATUS {
		UNASSIGNED= 0,
		ASSIGNED = 1,
		COMPLETED = 2
	}

	public QUEST_STATUS status = QUEST_STATUS.UNASSIGNED;
	public string QUEST_NAME = string.Empty;
}

public class QuestManager : MonoBehaviour {

	public Quest[] quests;

	private static QuestManager manager = null;

	public static QuestManager managerInstance {

		get {
			if (manager == null) {
				GameObject questObject = new GameObject("Default");
				manager = questObject.AddComponent<QuestManager>();
			}
			return manager;
		}
	}

	void Awake() {
		if (manager) {
			DestroyImmediate (gameObject);
			return;
		}
		manager = this;
		DontDestroyOnLoad (manager);
	}

	public static Quest.QUEST_STATUS GetQuestStatus(string questName) {
		foreach (Quest quest in managerInstance.quests) {
			if(quest.QUEST_NAME.Equals(questName)){
				return quest.status;
			}
		}

		return Quest.QUEST_STATUS.UNASSIGNED;
	}

	public static void SetQuestStatus(string questName, Quest.QUEST_STATUS newQuestStatus) {
		foreach (Quest quest in managerInstance.quests) {
			if (quest.QUEST_NAME.Equals (questName)) {
				quest.status = newQuestStatus;
				return;
			}
		}
	}

	public static void Reset() {
		if (managerInstance == null)
			return;
		foreach (Quest quest in managerInstance.quests) {
			quest.status = Quest.QUEST_STATUS.UNASSIGNED;
		}
	}
}
