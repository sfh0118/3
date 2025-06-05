using UnityEngine;
using QFramework;
using System.Linq;
using System.Collections.Generic;

namespace projectlndieFem
{
    public partial class ChallengeController : ViewController//,IController
    {



        //private IChallengeSystem mUIChallengeSystem;
        private void Awake()
        {
        }
        //public override void OnDestroy()
        //{
        //    mUIChallengeSystem = null;
        //}


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
            IMGUIHelper.SetDesignResolution(960, 540);

            GUI.Label(new Rect(960 - 300, 24 + -24, 300, 24), "@@ 도전 @@", mLabelsyle);

            for (var i = 0; i < ChallengeSystem.ActiveChallenges.Count; i++)
            {
                var challenge = ChallengeSystem.ActiveChallenges[i];

                GUI.Label(new Rect(960 - 300, 24 + i * 24, 300, 24), challenge.Name, mLabelsyle);

                if (challenge.State == Challenge.States.Finished)
                {
                    GUI.Label(new Rect(960 - 300, 24 + i * 24, 300, 24), "<color=green>" + challenge.Name + "</color>", mLabelsyle);
                }
            }
            for (var i = 0; i < ChallengeSystem.FinishedChallenges.Count; i++)
            {
                var challenge = ChallengeSystem.FinishedChallenges[i];

                GUI.Label(new Rect(960 - 300, 24 + (i + ChallengeSystem.ActiveChallenges.Count) * 24, 300, 24),
                "<color=green>" + challenge.Name + "</color>", mLabelsyle);

            }
        }
        //public IArchitecture GetArchitecture()
        //{
        //    return Global.Interface;
        //}
    }
}
