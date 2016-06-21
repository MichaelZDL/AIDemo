using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
	[TaskDescription("if weapon cool down and enemy in sight,Frie")]
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=112")]
	[TaskIcon("{SkinColor}IdleIcon.png")]
	public class Attack : Action
	{
		public override TaskStatus OnUpdate()
		{
			GetComponent<actorTest> ().TestAttack ();
			return TaskStatus.Success;
		}
	}
}