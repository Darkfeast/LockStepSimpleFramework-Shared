//
// @brief: unity对象基类
// @version: 1.0.0
// @author helin
// @date: 8/20/2018
// 
// 
//
#if _CLIENTLOGIC_
using UnityEngine;
#endif

/*
往事蒙尘在我眉睫之间，                       
方今重回到江南旧院。                        
残朽了，岁月刻的牌匾，                       
叩开回忆之门一问尘缘。                       
我乘乌篷船翩然过桥亭，                        多年后我又乘船过江南，
与清明桥上嫣然那个你，                        可清明桥上再无你倩影，
不经意，相看成了风景。                        未留意，眷顾成了曾经。
我蘸酒写诗而你误入诗句。                      一道古镇清风长叹了半声。
                           
我轻弹古筝歌遍，方知断了的琴弦                 玉笛余音向天阙，流年也沉默封缄，   
再也唱不出思念。                             为你静敛岁月吊唁。
你刺绣化梦的蝶，后觉断了的红线                 黛瓦青砖雨不绝，我蒙霜冷彻心间，
再也绣不出情缘。                             为你倾尽悼念。
执手昨日疏影西窗前，灯花落尽檐外月一剪，        或许怨天命旁观冷眼，或许问天命总妒良缘，
棋局与人生，哪个更多劫？                      说莫失莫忘，无常总上演。
孑然今宵微雨断桥边，往事焚灰你香冢长眠，        天涯一隔两端有多远，怎敌一隔阴阳两相望，
从此处处烟波，都似你眉眼。                    从此处处苍翠，都似你裙边。
    

忆江南山悠然水悠然，你眸凝万水眉黛千山，
待百年与你，共长眠江南。
忆江南船依然桥依然，与你将前缘再续编撰：
若有三生一世，再遇你江南。
*/

using System.Collections;

public class UnityObject
{
    public string m_scBundle = "";
    public string m_scAsset = "";
    public string m_scType = ""; // 塔  士兵  子弹

    //是否被杀掉了
    public bool m_bKilled = false;
#if _CLIENTLOGIC_
    public GameObject m_gameObject;
#endif
    //最后的位置
    public FixVector3 m_fixv3LastPosition = new FixVector3(Fix64.Zero, Fix64.Zero, Fix64.Zero);

    //逻辑位置
    public FixVector3 m_fixv3LogicPosition = new FixVector3(Fix64.Zero, Fix64.Zero, Fix64.Zero);

    //旋转值
    FixVector3 m_fixv3LogicRotation;

    //缩放值
    FixVector3 m_fixv3LogicScale;

    public void createFromPrefab(string path, UnityObject script) {
#if _CLIENTLOGIC_
        Prefab.create(path, script);
#endif
    }


    public void updateRenderPosition(float interpolation) {
#if _CLIENTLOGIC_
        if (m_bKilled)
        {
            return;
        }

        //只有会移动的对象才需要采用插值算法补间动画,不会移动的对象直接设置位置即可
        if ((m_scType == "soldier" || m_scType == "bullet") && interpolation != 0)
        {
            m_gameObject.transform.localPosition = Vector3.Lerp(m_fixv3LastPosition.ToVector3(), m_fixv3LogicPosition.ToVector3(), interpolation);
        }
        else
        {
            m_gameObject.transform.localPosition = m_fixv3LogicPosition.ToVector3();
        }
#endif
    }

    //- 播放动画
    // 
    // @param animationName 动画名
    // @return; none
    public void playAnimation(string animationName) {

    }

    //- 排队播放动画
    // 
    // @param animationName 动画名
    // @return; none
    public void playAnimationQueued(string animationName) {
#if _CLIENTLOGIC_

#endif
    }

    //- 停止动画
    // 
    // @return; none
    public void stopAnimation() {
#if _CLIENTLOGIC_
        Animation animation = m_gameObject.transform.GetComponent<Animation>();
         if (null != animation)
         {
                animation.Stop();
         }
#endif
    }

    //- 设置缩放值
    // 
    // @param value 要设置的缩放值
    // @return; none
    public void setScale(FixVector3 value)
    {
        m_fixv3LogicScale = value;

#if _CLIENTLOGIC_
        m_gameObject.transform.localScale = value.ToVector3();
#endif
    }

    //- 获取缩放值
    // 
    // @return; 缩放值
    public FixVector3 getScale()
    { 
        return m_fixv3LogicScale;
    }

    //- 设置旋转值
    // 
    // @param value 要设置的旋转值
    // @return; none
    public void setRotation(FixVector3 value)
    {
        m_fixv3LogicRotation = value;
#if _CLIENTLOGIC_
        m_gameObject.transform.localEulerAngles = value.ToVector3();
        setVisible(true);
#endif
    }

    //- 获取旋转值
    // 
    // @return; 旋转值
    public FixVector3 getRotation()
    {
        return m_fixv3LogicRotation;
    }

    //- 设置是否可见
    // 
    // @param value 是否可见
    // @return; none
    public void setVisible(bool value)
    {
#if _CLIENTLOGIC_
        m_gameObject.SetActive(value);
#endif
    }

    //- 删除gameobject
    // 
    // @return; none
    public void destroyGameObject()
    {
#if _CLIENTLOGIC_
        GameObject.Destroy(m_gameObject);
        m_gameObject.transform.localPosition = new Vector3(10000, 10000, 0);
#endif
    }

    //- 设置GameObject的名字
    // 
    // @param name 名字
    // @return; none
    public void setGameObjectName(string name)
    {
#if _CLIENTLOGIC_
        m_gameObject.name = name;
#endif
    }

    //- 获取GameObject的名字
    // 
    // @return; GameObject的名字
    public string getGameObjectName()
     {
#if _CLIENTLOGIC_
        return m_gameObject.name;
#else
		return "";
#endif
    }

    //- 设置位置
    // 
    // @param position 要设置到的位置
    // @return; none
    public void setGameObjectPosition(FixVector3 position)
    {
#if _CLIENTLOGIC_
        m_gameObject.transform.localPosition = position.ToVector3();
#endif
    }

    //- 获取位置
    // 
    // @return; 当前逻辑位置
    //public FixVector3 getPosition() {
    //     if (!GameData.g_client) { return new FixVector3(Fix64.Zero, Fix64.Zero, Fix64.Zero);}

    //    return gameObject.transform.localPosition;
    // }

    //- 设置颜色
    // 
    // @param r 红
    // @param g 绿
    // @param b 蓝
    // @return; none
    public void setColor(float r, float g, float b)
    {
#if _CLIENTLOGIC_
        m_gameObject.GetComponent<SpriteRenderer>().color = new Color(r, g, b, 1);
#endif
    }
}
