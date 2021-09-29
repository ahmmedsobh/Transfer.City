using System;
using System.Collections.Generic;
using System.Text;
namespace Transfer.City.Models.Keys
{
	public class UserLoginLogKeys
	{

		#region Data Members

		long _iD;

		#endregion

		#region Constructor

		public UserLoginLogKeys(long iD)
		{
			 _iD = iD; 
		}

		#endregion

		#region Properties

		public long  ID
		{
			 get { return _iD; }
		}

		#endregion

	}
}
