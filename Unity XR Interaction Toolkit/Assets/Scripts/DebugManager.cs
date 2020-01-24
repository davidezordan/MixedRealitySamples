using UnityEngine;

namespace Dev.Davide.UnityHelpers {

	public class DebugManager {
		public static bool isDebugging = false;

		public static void Info(string message) {
			if(!isDebugging) {
				return;
			} else {
				Debug.Log(message);
			}
		}
	}
	
}
