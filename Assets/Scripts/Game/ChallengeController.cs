using UnityEngine;
using QFramework;
using System.Linq;
using System.Collections.Generic;

namespace projectlndieFem
{
    public partial class ChallengeController : ViewController,IController
    {

        private IChallengeSystem mChallengeSystem;
        private void Awake()
        {
            mChallengeSystem =this.GetSystem<IChallengeSystem>();
        }
        private void OnDestroy()
        {
            mChallengeSystem = null;
        }


        void Start()
        {
            // Code Here
            mLabelsyle = new GUIStyle("Label")
            {
                font = Font,
            };


            
        }


        public Font Font;
        private GUIStyle mLabelsyle;
        private void OnGUI()
        {
            if (mChallengeSystem == null)
            {
                Debug.LogError("[ChallengeController] ChallengeSystem is null!");
                return;
            }

            if (mChallengeSystem.ActiveChallenges == null)
            {
                Debug.LogError("[ChallengeController] ActiveChallenges is null!");
                return;
            }

            if (mChallengeSystem.FinishedChallenges == null)
            {
                Debug.LogError("[ChallengeController] FinishedChallenges is null!");
                return;
            }
            IMGUIHelper.SetDesignResolution(960, 540);

            GUI.Label(new Rect(960 - 300, 24 + -24, 300, 24), "@@ 도전 @@", mLabelsyle);

            for (var i = 0; i < mChallengeSystem.ActiveChallenges.Count; i++)
            {
                var challenge = mChallengeSystem.ActiveChallenges[i];

                GUI.Label(new Rect(960 - 300, 24 + i * 24, 300, 24), challenge.Name, mLabelsyle);

                if (challenge.State == Challenge.States.Finished)
                {
                    GUI.Label(new Rect(960 - 300, 24 + i * 24, 300, 24), "<color=green>" + challenge.Name + "</color>", mLabelsyle);
                }
            }
            for (var i = 0; i < mChallengeSystem.FinishedChallenges.Count; i++)
            {
                var challenge = mChallengeSystem.FinishedChallenges[i];

                GUI.Label(new Rect(960 - 300, 24 + (i + mChallengeSystem.ActiveChallenges.Count) * 24, 300, 24),
                "<color=green>" + challenge.Name + "</color>", mLabelsyle);

            }
        }


        public IArchitecture GetArchitecture()
        {
            return Global.Interface;
        }
    }
}
