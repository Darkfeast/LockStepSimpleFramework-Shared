//
// @brief: 直射子弹
// @version: 1.0.0
// @author helin
// @date: 8/20/2018
// 
// 
//
using System.Collections;

public class DirectionShootBullet : BaseBullet
{
    Fix64 m_fixMoveTime = Fix64.Zero;
    Fix64 m_fixSpeed = Fix64.Zero;

    //- 每帧循环
    // 
    // @return none
    public override void updateLogic()
    {
        //调用父类Update
        base.updateLogic();
    }

    //- 初始化数据
    // 
    // @param src 发射源
    // @param dest 射击目标
    // @param poOri 发射的起始位置
    // @param poDst 发射的目标位置
    // @return none.
    public override void initData(LiveObject src, LiveObject dest, FixVector3 poOri, FixVector3 poDst)
    {
        base.initData(src, dest, poOri, poDst);

        Fix64 distance = FixVector3.Distance(poOri, poDst);
        m_fixMoveTime = distance / m_fixSpeed;
        
        
        //刷新显示位置  //设置当前位置插值到逻辑位置
        updateRenderPosition(0);  //因为子弹刚生成出来 所以不需要插值位置 直接设置到逻辑位置 就是出生位置
        //立即记录最后的位置,否则通过vector3.lerp来进行移动动画时会出现画面抖动的bug
        recordLastPos();  //将这一逻辑帧 的逻辑位置 更新给 最后一次移动位置   因为上面已经插值过逻辑位置了，所以逻辑位置已经不是最新的  而是最后一次（上一次）的移动位置
        
        
        //shoot
        m_fixv3LogicPosition = m_fixv3SrcPosition;
        moveTo(m_fixv3SrcPosition, m_fixv3DestPosition, m_fixMoveTime, delegate ()
        {
            doShootDest();
        });
    }

    //- 射击
    // //这个方法的位置不合理，应该在 Tower类里面
    // 子弹没有主动射击这个动作
    // @return none.
    public void shoot()
    {
        
    }

    //- 根据名字加载预制体
    // DF 同一种类型的子弹可能有不同的皮肤 所以
    // @param name 子弹的名字
    // @return none
    public override void createBody(string nameValue)
    {
        m_scName = nameValue;
        //加载子弹主体
        createFromPrefab("Prefabs/Bullet", this);
    }

    //- 加载属性
    // 
    // @return none
    public override void loadProperties()
    {
        m_fixSpeed = (Fix64)10;
    }
}