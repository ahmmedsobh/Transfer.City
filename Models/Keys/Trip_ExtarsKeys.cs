using System;
using System.Collections.Generic;
using System.Text;
namespace Transfer.City.Models.Keys
{
	public class Trip_ExtarsKeys
	{

		#region Data Members

		int _iD;

		#endregion

		#region Constructor

		public Trip_ExtarsKeys(int iD)
		{
			 _iD = iD; 
		}

		#endregion

		#region Properties

		public int  ID
		{
			 get { return _iD; }
		}

		#endregion

	}
}
