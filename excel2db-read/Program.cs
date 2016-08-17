/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2015/9/8
 * Time: 16:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace excel2db_read
{
	class Program
	{
		public static void Main(string[] args)
		{
			//CityNdbDataManager city=new CityNdbDataManager();
			//city.setNdbFilePath("D:/ndbtest/excelPath");
			//city.initData();
			
			ArrayNdbDataManager arrayTest = new ArrayNdbDataManager();
			arrayTest.SetNdbFilePath("D:/ndbtest");
			arrayTest.initData();
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}