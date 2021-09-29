using System;
using System.Collections.Generic;
using System.Text;
namespace Transfer.City.Models.Keys
{
	public class UserAgentsKeys
	{

		#region Data Members

		int _iD;

		#endregion

		#region Constructor

		public UserAgentsKeys(int iD)
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
