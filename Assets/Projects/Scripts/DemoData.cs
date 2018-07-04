using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DemoData : IDataIO
{
    private static DemoData m_instance;
    public static DemoData Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new DemoData();
            }
            return m_instance;
        }
    }

    public PlanningStatistics GetData_PlanningStatistics()
    {
        PlanningStatistics p = new PlanningStatistics();
        p.SetData(1980, 1690, 100, 90, 100, 90, 90, 90);
        return p;
    }

    public List<ProductCostTotal> GetData_ProductCostTotal(int id)
    {
        List<ProductCostTotal> list = new List<ProductCostTotal>();

        return list;
    }

    public List<ProductOutput> GetData_ProductOutputList(int timeType)
    {
        TimeType type = (TimeType)timeType;
        List<ProductOutput> list = new List<ProductOutput>();

        switch (type)
        {
            case TimeType.Day:
                for (int i = 0; i < 8; i++)
                {
                    int num = i + 65;
                    byte[] bt = new byte[] { (byte)num };
                    ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
                    string str = aSCIIEncoding.GetString(bt);
                    ProductOutput p = new ProductOutput();
                    p.SetData(i, "产品" + str, Random.Range(500, 5000));
                    list.Add(p);
                }
                break;
            case TimeType.Month:
                for (int i = 0; i < 8; i++)
                {
                    int num = i + 65;
                    byte[] bt = new byte[] { (byte)num };
                    ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
                    string str = aSCIIEncoding.GetString(bt);
                    ProductOutput p = new ProductOutput();
                    p.SetData(i, "产品" + str, Random.Range(5000, 50000));
                    list.Add(p);
                }
                break;
            case TimeType.Year:
                for (int i = 0; i < 8; i++)
                {
                    int num = i + 65;
                    byte[] bt = new byte[] { (byte)num };
                    ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
                    string str = aSCIIEncoding.GetString(bt);
                    ProductOutput p = new ProductOutput();
                    p.SetData(i, "产品" + str, Random.Range(50000, 500000));
                    list.Add(p);
                }
                break;
            default:
                break;
        }
        return list;
    }

    public List<ProductPassRate> GetData_ProductPassRateList(int timeType)
    {
        List<ProductPassRate> list = new List<ProductPassRate>();

        return list;
    }

    public ProductTotal GetData_ProductTotal(int id)
    {
        ProductTotal p = new ProductTotal();
        p.SetData("Product" + id, Random.Range(10000, 100000), Random.Range(1000, 10000), Random.Range(100, 1000), Random.Range(10, 100));
        return p;
    }
}
