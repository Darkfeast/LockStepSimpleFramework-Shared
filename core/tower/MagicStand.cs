//
// @brief: 魔法塔
// @version: 1.0.0
// @author helin
// @date: 8/20/2018
// 
// 
//
using System.Collections;

public class MagicStand : BaseTower
{
    public MagicStand()
    {
        changeState("towerstand");
    }

    //- 每帧循环
    // 
    // @return none
    public override void updateLogic()
    {
        //调用父类Update
        base.updateLogic();
    }

    //- 加载属性
    // 
    // @return none
    public override void loadProperties()
    {
        setDamageValue((Fix64)50);
        attackRange = (Fix64)6 + GameData.g_srand.Range(1, 3);
        attackSpeed = (Fix64)1;
    }

    public override void Create(string nameValue)
    {
        //每个塔加载的资源不同,所以单独处理
        //设置名字为魔法塔
        // m_scName = "magicstand";
        m_scName = nameValue;
        createFromPrefab("Prefabs/Tower", this);
        loadProperties();
    }

    public override void Init(FixVector3 pos)
    {
        m_fixv3LogicPosition = pos;
        updateRenderPosition(0);
    }
}
