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
	public class ArrayNdbDataManager : NdbDataManager<P_arrayTestData>
	{
		public void initData(){
			Init();
			List<P_arrayTestData> list = GetBeanList();
			foreach(P_arrayTestData data in list){
				Console.WriteLine(data.GetName1());
				Console.WriteLine(data.GetPid()[0]);
				Console.WriteLine(data.GetName2()[0]);
				Console.WriteLine(data.GetName3()[0]);
				Console.WriteLine(data.GetName4()[0]);
				Console.WriteLine("===========================");
			}
		}
		
		override
		public string GetNdbName() {
			return "P_arrayTest";
		}

		override
		public Type GetBeanType(){
			return Type.GetType("excel2db_read.P_arrayTestData");
		}
	}
}
