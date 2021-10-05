using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Transfer.City.DataLayer;
using Transfer.City.Models;

namespace Transfer.City.BusinessLayer
{
    public class FindTransferFactory
    {
        #region data Members

        FindTransferSql _dataObject = null;

        #endregion

        #region Constructor

        public FindTransferFactory()
        {
            _dataObject = new FindTransferSql();
        }

        #endregion


        public List<FindTransfer> SearchResult(FindTransfer businessObject)
        {
            return _dataObject.SearchResult(businessObject);
        }
    }
}