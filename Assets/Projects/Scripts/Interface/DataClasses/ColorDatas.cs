using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 图表颜色数据
/// </summary>
public class ColorDatas : MonoBehaviour
{
    #region 单例
    private static ColorDatas m_instance;
    public static ColorDatas Instance { get { return m_instance; } }

    private void Awake()
    {
        m_instance = this;
    }
    #endregion

    //计划统计分析图表的颜色数据
    [Header("计划统计分析图表的颜色数据")]
    public PlanningStatisticsColors planningStatisticsColors;

    [Serializable]
    public class PlanningStatisticsColors
    {
        public List<Color> DataColorList
        {
            get
            {
                return new List<Color>() { overColor, notColor, workingColor, shipColor,
            achievementRateColor ,passRateColor, timelyRateColor};
            }
        }

        [SerializeField]
        private Color overColor;
        [SerializeField]
        private Color notColor;
        [SerializeField]
        private Color workingColor;
        [SerializeField]
        private Color shipColor;
        [SerializeField]
        private Color achievementRateColor;
        [SerializeField]
        private Color passRateColor;
        [SerializeField]
        private Color timelyRateColor;
    }

    [Header("产品产量统计")]
    public ProductOutputColors productOutputColors;

    [Serializable]
    public class ProductOutputColors
    {
        public List<Color> DataColorList { get { return pointColors; } }

        [SerializeField]
        private List<Color> pointColors;
    }
}
