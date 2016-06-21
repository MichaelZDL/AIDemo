using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
	[TaskDescription("flee to home")]
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=112")]
	[TaskIcon("{SkinColor}IdleIcon.png")]
	public class Flee : Action
	{
		public override TaskStatus OnUpdate()
		{
			if (Vector3.Distance (GetComponent<DataBind> ().Home.position, transform.position) > 0.5f) {
				GetComponent<actorTest> ().TestMove (GetComponent<DataBind> ().Home.position);
				return TaskStatus.Running;
			}
			else
				return TaskStatus.Success;
		}
	}
}