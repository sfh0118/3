using UnityEngine;
using QFramework;

namespace projectlndieFem
{
	public partial class UIChallenge : ViewController, IController
	{
		private void Start()
		{
			ChallengeItemTemplate.Hide();
			UpdateView();
		}
		void UpdateView()
		{
			ChallengeRoot.DestroyChildren();
			//foreach (var activeChallenge in this.GetSystem<IChallengeSystem>().ActiveChallenges) ;
			//{
			//	ChallengeItemTemplate.InstantiateWithParent(ChallengeRoot)
			//		.Self(self =>
			//		{
			//			self.text = "<color= yellow>[진행중]</color> " + activeChallenge.Name;
			//		})
			//		.Show();
			//}
			//foreach (var finishedChallenge in this.GetSystem<IChallengeSystem>().FinishedChallenge) ;
			//{
			//	ChallengeItemTemplate.InstantiateWithParent(ChallengeRoot)
			//		.Self(self =>
			//		{
			//			self.text = "<color= green>[완료]</color> " + finishedChallenge.Name;
			//		})
			//		.Show();
			//}
		}
		public IArchitecture GetArchitecture()
		{
			return Global.Interface;
			// Code Here
		}

	}
}
