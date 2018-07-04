using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataIO
{
    PlanningStatistics GetData_PlanningStatistics();
    List<ProductOutput> GetData_ProductOutputList(int timeType);
    ProductTotal GetData_ProductTotal(int id);
    List<ProductCostTotal> GetData_ProductCostTotal(int id);
    List<ProductPassRate> GetData_ProductPassRateList(int timeType);
    List<ProductCost> GetData_ProductCost(int timeType);
}
