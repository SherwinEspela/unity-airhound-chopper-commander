using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AirHound {
	public interface IRewardable
	{
		void IncreaseRocketReward();
		void IncreaseHealthReward();
	}
}