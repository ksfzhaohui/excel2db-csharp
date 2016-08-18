/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2015/9/8
 * Time: 16:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace excel2db_read.excel2db
{
	
	public class DBFile<T>
	{
		/** header的长度 **/
		private int HEADER_LENGTH = 5 * 4;
		
		private Header header;
		private List<string> columnNames;
		private List<char> columnTypes;
		private Object[,] data;
		private List<T> beanList = new List<T>();
		
		public DBFile() {
		}
		
		public void init(string filePath) {
			FileStream aFile = null;
			try {
				aFile = new FileStream(filePath,FileMode.Open);
				ParseHeader(aFile);
				ParseColumnName(aFile);
				ParseColumnType(aFile);
				ParseData(aFile);
			} catch (System.IO.IOException e) {
             	Console.WriteLine("Error reading from {0}. Message = {1}", filePath, e.Message);
            } finally {
            	if (aFile != null) {
                	aFile.Close();
            	}
        	}
		}
		
		/*
		 * 解析头部
		 */
		private void ParseHeader(FileStream aFile) {
			byte[] array = GetByteArray(aFile,HEADER_LENGTH);
			
			ByteBuffer buffer = ByteBuffer.Allocate(array);
			int records = buffer.ReadInt();
			int fields = buffer.ReadInt();
			int namebuflength = buffer.ReadInt();
			int typebuflength = buffer.ReadInt();
			int databuflength = buffer.ReadInt();
			
			columnNames = new List<string>(fields);
			columnTypes = new List<char>(fields);
			data = new Object[records,fields];
			
			header = new Header(records, fields, namebuflength, typebuflength,
			                    databuflength);
		}
		
		/*
		 * 解析获取字段名称
		 */
		private void ParseColumnName(FileStream aFile) {
			int namebuflength = header.GetNamebuflength();
			byte[] array = GetByteArray(aFile,namebuflength);
			
			ByteBuffer buffer = ByteBuffer.Allocate(array);
			int fileSize = header.GetFieldSize();
			for(int i = 0;i < fileSize;i++){
				columnNames.Add(GetString(buffer));
			}
		}
		
		/*
		 * 解析获取各个类型
		 */
		private void ParseColumnType(FileStream aFile) {
			int typebuflength = header.GetTypebuflength();
			byte[] array = GetByteArray(aFile,typebuflength);

			ByteBuffer buffer = ByteBuffer.Allocate(array);
			int fileSize = header.GetFieldSize();
			for(int i = 0;i < fileSize;i++){
				columnTypes.Add((char)buffer.ReadByte());
			}
		}
		
		/*
		 * 解析获取每行数据
		 */
		private void ParseData(FileStream aFile) {
			int databuflength = header.GetDatabuflength();
			byte[] array = GetByteArray(aFile,databuflength);

			ByteBuffer buffer = ByteBuffer.Allocate(array);
			int records = header.GetRecordSize();
			int fileSize = header.GetFieldSize();
			for(int i = 0;i < records;i++){
				for (int k = 0; k < fileSize; k++) {
					char type = columnTypes[k];
					Object obj = null;
					switch(type){
						case 'i':
							obj = buffer.ReadInt();
							break;
						case 'f':
							obj = buffer.ReadFloat();
							break;
						case 'l':
							obj = buffer.ReadLong();
							break;
						case 's':
							obj = GetString(buffer);
							break;
						case 'x':
							string[] ivs = GetString(buffer).Split('#');
							int[] ints = new int[ivs.Length];
							for(int j = 0;j < ivs.Length; j++){
								ints[j] = int.Parse(ivs[j]);
							}
							obj = ints;
							break;
						case 'y':
							string[] fvs = GetString(buffer).Split('#');
							float[] floats = new float[fvs.Length];
							for(int j = 0;j < fvs.Length; j++){
								floats[j] = float.Parse(fvs[j]);
							}
							obj = floats;
							break;
						case 'z':
							string[] lvs = GetString(buffer).Split('#');
							long[] longs = new long[lvs.Length];
							for(int j = 0;j < lvs.Length; j++){
								longs[j] = long.Parse(lvs[j]);
							}
							obj = longs;
							break;
						case 'j':
							string[] svs = GetString(buffer).Split('#');
							obj = svs;
							break;
						case 'k':
							string[] dvs = GetString(buffer).Split('#');
							double[] doubles = new double[dvs.Length];
							for(int j = 0;j < dvs.Length; j++){
								doubles[j] = double.Parse(dvs[j]);
							}
							obj = doubles;
							break;
					}
					data[i,k] = obj;
				}
			}
			
		}
		
		private byte[] GetByteArray(FileStream aFile,int len) {
			byte[] array = new byte[len];
			aFile.Read(array,0,len);
			return array;
		}
		
		/*
		 * 从缓存区获取字符串
		 */
		private string GetString(ByteBuffer buffer){
			int len = buffer.ReadInt();
			byte[] dst = new byte[len];
			buffer.ReadBytes(dst,0,len);
			return Encoding.UTF8.GetString(dst);
		}
		
		public List<T> GetBeanList() {
			return beanList;
		}
		
		public List<string> GetColumnNames() {
			return columnNames;
		}
		
		public Object[,] GetData() {
			return data;
		}
		
		public Header GetHeader() {
			return header;
		}
	}
}
