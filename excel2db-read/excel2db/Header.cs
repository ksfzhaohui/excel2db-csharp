/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2015/9/8
 * Time: 16:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace excel2db_read.excel2db
{
	/// <summary>
	/// Description of Header.
	/// </summary>
	public class Header
	{
		/** 记录数量 **/
		private int recordSize;
		/** 字段数量 **/
		private int fieldSize;
		/** 名称buff的长度 **/
		private int namebuflength;
		/** 类型buff的长度 **/
		private int typebuflength;
		/** 数据buff的长度 **/
		private int databuflength;
	
		public Header(int recordSize, int fieldSize, int namebuflength,
				int typebuflength, int databuflength) {
			this.recordSize = recordSize;
			this.fieldSize = fieldSize;
			this.namebuflength = namebuflength;
			this.typebuflength = typebuflength;
			this.databuflength = databuflength;
		}
		
		public int GetRecordSize() {
			return recordSize;
		}
	
		public void SetRecordSize(int recordSize) {
			this.recordSize = recordSize;
		}
	
		public int GetFieldSize() {
			return fieldSize;
		}
	
		public void SetFieldSize(int fieldSize) {
			this.fieldSize = fieldSize;
		}
	
		public int GetNamebuflength() {
			return namebuflength;
		}
	
		public void SetNamebuflength(int namebuflength) {
			this.namebuflength = namebuflength;
		}
	
		public int GetTypebuflength() {
			return typebuflength;
		}
	
		public void SetTypebuflength(int typebuflength) {
			this.typebuflength = typebuflength;
		}
	
		public int GetDatabuflength() {
			return databuflength;
		}
	
		public void SetDatabuflength(int databuflength) {
			this.databuflength = databuflength;
		}
	}
}
