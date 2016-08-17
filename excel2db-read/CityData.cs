/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2015/9/9
 * Time: 14:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace excel2db_read
{
	/// <summary>
	/// Description of CityData.
	/// </summary>
	public class CityData
	{
		private int name1;
		private long name2;
		private float name3;
		private string name4;

		public int GetName1() {
			return name1;
		}

		public void SetName1(int name1) {
			this.name1 = name1;
		}

		public long GetName2() {
			return name2;
		}

		public void SetName2(long name2) {
			this.name2 = name2;
		}

		public float GetName3() {
			return name3;
		}

		public void SetName3(float name3) {
			this.name3 = name3;
		}

		public string GetName4() {
			return name4;
		}

		public void SetName4(string name4) {
			this.name4 = name4;
		}
	}
}
