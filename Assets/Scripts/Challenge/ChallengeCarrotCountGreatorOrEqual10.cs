using projectlndieFem;
using QFramework;
using System.Collections.Generic;

public class ChallengeCarrotCountGreatorOrEqual10 : Challenge, IUnRegisterList
{
    public override string Name { get; } = " 10개 당근 보요하기";

    public int mCarrotCount = 0;
    public override void OnStart()
    {
        ToolBarSystem.OnItemCountChanged.Register((Item, count) =>
        {
            if(Item.Name == "carrot")
            {
                mCarrotCount = count;
            }
        }).AddToUnregisterList(this);
    }
    public override bool CheckFinish()
    {
        return mCarrotCount >= 10;
    }

    public override void OnFinish()
    {

        this.UnRegisterAll();
    }

    public List<IUnRegister> UnregisterList { get; } = new List<IUnRegister>();

}