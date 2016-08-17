/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2015/9/9
 * Time: 14:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using excel2db_read.excel2db;

namespace excel2db_read
{
	public class CityNdbDataManager : NdbDataManager<CityData>
	{
		public void initData(){
			Init();
			List<CityData> list = GetBeanList();
			foreach(CityData cityData in list){
				Console.WriteLine(cityData.GetName1());
			}
		}
		
		override
		public string GetNdbName() {
			return "city";
		}

		override
		public Type GetBeanType(){
			return Type.GetType("excel2db_read.CityData");
		}
	}
}
