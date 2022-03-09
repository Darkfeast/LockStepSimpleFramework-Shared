//
// @brief: 子弹工厂类
// @version: 1.0.0
// @author helin
// @date: 8/20/2018
// 
// 
//

using System.Collections;

public class BulletFactory
{
    string m_scBulletName = "";

    //- 创建子弹
    // 
    // @param id 子弹id
    // @param src 由谁发出来的子弹
    // @param dest 射向目标的子弹
    // @param poShootStartPosition 子弹生成的位置
    // @param poShootEndPosition 子弹要到达的位置
    // @return none
    public void createBullet(LiveObject src, LiveObject dest, FixVector3 poShootStartPosition, FixVector3 poShootEndPosition)
    {
        BaseBullet bullet = null;

        //直射子弹
        bullet = new DirectionShootBullet();

        //根据名字加载资源
        bullet.createBody(m_scBulletName);

        bullet.initData(src, dest, poShootStartPosition, poShootEndPosition);
     
        //加入子弹列表
        GameData.g_listBullet.Add(bullet);
    }

    //- 移除子弹
    // 
    // @param bullet 要移除的子弹对象
    // @return none
    void removeBullet(BaseBullet bullet)
    {
        GameData.g_listBullet.Remove(bullet);
    }

    //- 加载属性
    // 
    // @return none
    void loadProperties()
    {
    }
}