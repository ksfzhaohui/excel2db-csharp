/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2015/9/9
 * Time: 13:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Reflection;

namespace excel2db_read.excel2db
{
	public abstract class NdbDataManager<T>
	{
		private DBFile<T> dbFile;
		private string ndbFilePath;
		
		public abstract string GetNdbName();

		public abstract Type GetBeanType();
		
		public void Init() {
			dbFile = new DBFile<T>();
			dbFile.init(ndbFilePath+"/"+GetNdbName()+".ndb");
			
			List<T> beanList = dbFile.GetBeanList();
			Object[,] data = dbFile.GetData();
			List<string> columnNames = dbFile.GetColumnNames();
			Header header = dbFile.GetHeader();
			
			Type type = GetBeanType();
			for(int i = 0;i < header.GetRecordSize();i++) {
				ConstructorInfo ci = type.GetConstructor(new Type[] {});
				T t = (T)ci.Invoke(new object[] {});
				for(int k = 0;k < header.GetFieldSize();k++){
					string column = columnNames[k];
					string setMethod = GetSetMethod(column);
					MethodInfo method = type.GetMethod(setMethod);
					method.Invoke(t,new Object[]{data[i,k]});
				}
				beanList.Add(t);
			}
		}
		
		public List<T> GetBeanList() {
			return dbFile.GetBeanList();
		} 
		
		public void SetNdbFilePath(string ndbFilePath) {
			this.ndbFilePath = ndbFilePath;
		}
		
		private string GetSetMethod(string column) {
			return "Set"+System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(column);
		}
	}
}
