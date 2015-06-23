﻿using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	public class reloadHandler : MonoBehaviour
	{
		
		public string Name;
		
		void OnEnable()
		{
			
		}
		
		public void SetDownState()
		{
			CrossPlatformInputManager.SetButtonDown(Name);
			Application.LoadLevel("joys");
		}
		
		
		public void SetUpState()
		{
			CrossPlatformInputManager.SetButtonUp(Name);
		}
		
		
		public void SetAxisPositiveState()
		{
			CrossPlatformInputManager.SetAxisPositive(Name);
		}
		
		
		public void SetAxisNeutralState()
		{
			CrossPlatformInputManager.SetAxisZero(Name);
		}
		
		
		public void SetAxisNegativeState()
		{
			CrossPlatformInputManager.SetAxisNegative(Name);
		}
		
		public void Update()
		{
			
		}
	}
}

