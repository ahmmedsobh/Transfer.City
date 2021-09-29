using System;
using System.Collections.Generic;
using System.Text;
namespace Transfer.City.Models.Keys
{
	public class UserPermissionsKeys
	{

		#region Data Members

		int _iD;

		#endregion

		#region Constructor

		public UserPermissionsKeys(int iD)
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
