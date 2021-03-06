﻿using UnityEngine;
using System.Collections;

public class PrefsManager : MonoBehaviour {

	const string MAST_VOLUME_KEY = "master_volume";
	const string DIFFICULTY = "difficulty";
	const string LEVEL_KEY = "level_unlocked";

	public static void SetMasterVolume (float volume) {
		if(volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MAST_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("Volume out of range");
		}
	}
	
	public static float GetMasterVolume () {
		return PlayerPrefs.GetFloat (MAST_VOLUME_KEY);
	}
	
	public static void UnlockLevel(int level) {
		if(level <= Application.levelCount - 1) {
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
		} else {
			Debug.LogError("Level not unlocked");
		}
	}
	
	public static bool UnlockedLevel(int level) {
		int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue == 1);
		
		if(level <= Application.levelCount - 1) {
			return isLevelUnlocked;
		} else {
			Debug.LogError("Trying to query level that is not in build order");
			return false;
		}
	}
	
	public static void Difficulty(float difficulty) {
		if(difficulty >= 1f && difficulty <= 3f) {
			PlayerPrefs.SetFloat (DIFFICULTY, difficulty);
		} else {
			Debug.LogError("Difficulty out of range");
		}
	}
	
	public static float GetDifficulty() {
		return PlayerPrefs.GetFloat (DIFFICULTY);
	}
}
