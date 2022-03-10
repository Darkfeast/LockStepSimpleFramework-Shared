//
// @brief: 豺狼人
// @version: 1.0.0
// @author helin
// @date: 8/20/2018
// 
// 
//

using System.Collections;

public class Grizzly : BaseSoldier
{
    public Grizzly()
    {
        //虚方法尽量不要在构造方法里面调用，因为可能造成初始顺序出错问题
        // loadProperties();
    }

    //- 每帧循环
    // 
    // @return none
    public override void updateLogic()
    {
        //调用父类Update
        base.updateLogic();
    }

    public override void Init(FixVector3 origin, FixVector3 end, Fix64 moveTime, ActionCallback act)
    {
        m_fixv3LogicPosition = origin;
        updateRenderPosition(0);
        //立即记录最后的位置,否则通过vector3.lerp来进行移动动画时会出现画面抖动的bug
        recordLastPos();
        moveTo(m_fixv3LogicPosition, end, moveTime);
    }
    
    public override void Create(string nameValue)
    {
        //设置具体的名字
        m_scName = nameValue;
        createFromPrefab("Prefabs/Soldier", this);
        loadProperties();
    }
    
    //- 加载属性
    // 
    // @return none
    public override void loadProperties()
    {
        setHp((Fix64) 200);
    }
}